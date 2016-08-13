using System;
using System.Collections.Generic;
using System.Linq;


namespace Webyneter.ComponentsAnalysis.Core
{
    [Serializable]
    public sealed class _SerializableSettings
    {
        public IEnumerable<KeyValuePair<string, object>> SettingNameValueMap
        {
            get { return settingNameValueMap.AsEnumerable(); }
        }

        private readonly Dictionary<string, object> settingNameValueMap;
    }
}