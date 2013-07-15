using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sitecore.Configuration;

namespace KevinWilliams.PlaceholderSettingsRules
{
    /// <summary>
    /// Constant values used throughout the code.
    /// </summary>
    public static class Constants
    {
        public static string RulesFieldId
        {
            get
            {
                string id = Settings.GetSetting("KevinWilliams.PlaceholderSettingsRules.RulesFieldId", null);
                if (id == null) throw new Exception("Could not read the 'KevinWilliams.PlaceholderSettingsRules.RulesFieldId' setting from Sitecore config");
                else return id;
            }
        }

        public static string AllowOptionId
        {
            get
            {
                string id = Settings.GetSetting("KevinWilliams.PlaceholderSettingsRules.AllowOptionId", null);
                if (id == null) throw new Exception("Could not read the 'KevinWilliams.PlaceholderSettingsRules.AllowOptionId' setting from Sitecore config");
                else return id;
            }
        }

        public static string DoNotAllowOptionId
        {
            get
            {
                string id = Settings.GetSetting("KevinWilliams.PlaceholderSettingsRules.DoNotAllowOptionId", null);
                if (id == null) throw new Exception("Could not read the 'KevinWilliams.PlaceholderSettingsRules.DoNotAllowOptionId' setting from Sitecore config");
                else return id;
            }
        }
    }
}
