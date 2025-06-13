using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileBitmaskGen.BitmaskGeneratorJson
{
    internal class BitmaskGeneratorJsonWritter
    {
        private string _jsonFilePath;
        private List<TileRule> _rules;

        public BitmaskGeneratorJsonWritter(string jsonFilePath, List<TileRule> rules)
        {
            if (string.IsNullOrEmpty(jsonFilePath))
            {
                throw new ArgumentNullException(nameof(jsonFilePath), "JSON file path cannot be null or empty.");
            }
            if (rules == null || rules.Count == 0)
            {
                throw new ArgumentNullException(nameof(rules), "Rules cannot be null or empty.");
            }
            _jsonFilePath = jsonFilePath;
            _rules = rules;
        }

        public void WriteRulesToJson()
        {
            if (string.IsNullOrEmpty(_jsonFilePath))
            {
                throw new InvalidOperationException("JSON file path is not set.");
            }
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(_rules, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(_jsonFilePath, jsonContent);
        }

    }
}
