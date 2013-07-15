using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Rules;

namespace KevinWilliams.PlaceholderSettingsRules
{
    /// <summary>
    /// Custom rule context used by the placeholder settings conditions and actions.
    /// </summary>
    public class PlaceholderSettingsRuleContext : RuleContext
    {
        public List<Item> AllowedRenderingItems { get; set; }
        public ID DeviceId { get; set; }
        public string PlaceholderKey { get; set; }
        public Database ContentDatabase { get; set; }
        public string LayoutDefinition { get; set; }
        public bool? DisplaySelectionTree { get; set; }
    }
}
