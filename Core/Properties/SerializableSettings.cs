using System;
using System.Collections.Generic;
using System.Linq;

namespace Avtonomov.CraniometryDataAnalysis.Lib
{
    [Serializable]
    public sealed class _SerializableSettings
    {
        public IEnumerable<KeyValuePair<string, object>> SettingNameValueMap
        {
            get { return settingNameValueMap.AsEnumerable(); }
        }

        private readonly Dictionary<string, object> settingNameValueMap;

        public _SerializableSettings()
        {
            //PropertyInfo[] propsInfo = typeof(TSettings).GetProperties(BindingFlags.Instance
            //    | BindingFlags.Public
            //    | BindingFlags.SetProperty);
            //settingNameValueMap = new Dictionary<string, object>(propsInfo.Length);
            //foreach (var propInfo in propsInfo)
            //{
            //    settingNameValueMap.Add(propInfo.Name, propInfo.GetValue(settings, null));
            //}
        }
    }

    //[Serializable]
    //internal class SerializableSettings<TSettings> 
    //    where TSettings : ApplicationSettingsBase
    //{
    //    public IEnumerable<KeyValuePair<string, object>> SettingNameValueMap
    //    {
    //        get { return settingNameValueMap.AsEnumerable(); }
    //    }

    //    private readonly Dictionary<string, object> settingNameValueMap;

    //    public SerializableSettings(TSettings settings)
    //    {
    //        PropertyInfo[] propsInfo = typeof(TSettings).GetProperties(BindingFlags.Instance
    //            | BindingFlags.Public
    //            | BindingFlags.SetProperty);
    //        settingNameValueMap = new Dictionary<string, object>(propsInfo.Length);
    //        foreach (var propInfo in propsInfo)
    //        {
    //            settingNameValueMap.Add(propInfo.Name, propInfo.GetValue(settings, null));
    //        }
    //    }
    //}
}