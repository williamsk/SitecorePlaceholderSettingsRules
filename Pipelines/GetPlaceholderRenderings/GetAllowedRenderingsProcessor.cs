using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetPlaceholderRenderings;
using Sitecore.Rules;

namespace KevinWilliams.PlaceholderSettingsRules.Pipelines.GetPlaceholderRenderings
{
    /// <summary>
    /// GetPlaceholderRenderings pipeline processor.  Meant to replace Sitecore's GetAllowedRenderings processor.
    /// </summary>
    public class GetAllowedRenderingsProcessor : Sitecore.Pipelines.GetPlaceholderRenderings.GetAllowedRenderings
    {
        private ID DeviceId;
        private string PlaceholderKey;
        private Database ContentDatabase;
        private string LayoutDefinition;

        /// <summary>
        /// Stores arguments for later use.
        /// </summary>
        public new void Process(GetPlaceholderRenderingsArgs args)
        {
            Assert.IsNotNull(args, "args");

            // Store these args for later.
            DeviceId = args.DeviceId;
            PlaceholderKey = args.PlaceholderKey;
            ContentDatabase = args.ContentDatabase;
            LayoutDefinition = args.LayoutDefinition;

            // Call the base class implementation.
            base.Process(args);
        }

        /// <summary>
        /// Overrides the base class implementation and adds execution of rules to determine allowed renderings.
        /// </summary>
        protected override List<Sitecore.Data.Items.Item> GetRenderings(Sitecore.Data.Items.Item placeholderItem, out bool allowedControlsSpecified)
        {
            // Get the initial list of renderings from the base implementation.
            var list = base.GetRenderings(placeholderItem, out allowedControlsSpecified);

            // Get the rules from the placeholder item.
            string rulesXml = placeholderItem[Constants.RulesFieldId];
            if (string.IsNullOrWhiteSpace(rulesXml)) return list;

            // Parse the rules.
            var parsedRules = RuleFactory.ParseRules<PlaceholderSettingsRuleContext>(placeholderItem.Database, rulesXml);

            // Construct the context.
            PlaceholderSettingsRuleContext context = new PlaceholderSettingsRuleContext();
            context.Item = placeholderItem;
            context.AllowedRenderingItems = list;
            context.DeviceId = DeviceId;
            context.PlaceholderKey = PlaceholderKey;
            context.ContentDatabase = ContentDatabase;
            context.LayoutDefinition = LayoutDefinition;

            // Execute the rules.
            RuleList<PlaceholderSettingsRuleContext> rules = new RuleList<PlaceholderSettingsRuleContext>();
            rules.Name = placeholderItem.Paths.Path;
            rules.AddRange(parsedRules.Rules);
            rules.Run(context);

            // Did the rules specify if the selection tree should be displayed?
            if (context.DisplaySelectionTree.HasValue)
                allowedControlsSpecified = !context.DisplaySelectionTree.Value;
            // If not, only display the tree if there are no allowed renderings.
            else
                allowedControlsSpecified = context.AllowedRenderingItems.Count > 0;

            // Return the list.
            return context.AllowedRenderingItems;
        }
    }
}
