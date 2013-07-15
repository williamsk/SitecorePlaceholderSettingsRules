using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Rules.Actions;

namespace KevinWilliams.PlaceholderSettingsRules.Actions
{
    /// <summary>
    /// Custom Sitecore rules engine action that disallows all renderings from being added to a placeholder.
    /// </summary>
    public class DisallowAllRenderings<T> : RuleAction<T> where T : PlaceholderSettingsRuleContext
    {
        public override void Apply(T ruleContext)
        {
            // Do not allow any renderings at all.
            ruleContext.DisplaySelectionTree = false;
            ruleContext.AllowedRenderingItems.RemoveAll(i => true);
        }
    }
}
