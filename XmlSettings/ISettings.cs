using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace XmlSettings {
    public interface ISettings {
        string GetValue(string section, string key);
        IList<KeyValuePair<string, string>> GetValues(string section);
        void SetValue(string section, string key, string value);
        void SetValues(string section, IList<KeyValuePair<string, string>> values);
        bool DeleteValue(string section, string key);
        bool DeleteSection(string section);
    }
}
