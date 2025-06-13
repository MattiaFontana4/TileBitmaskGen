using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileBitmaskGen.BitmaskGeneratorJson
{
    internal class BitmaskGeneratorJsonReader
    {
        private string _jsonFilePath;
        private List<TileRule> _rules;

        public BitmaskGeneratorJsonReader(string jsonFilePath)
        {
            if (string.IsNullOrEmpty(jsonFilePath))
            {
                throw new ArgumentNullException(nameof(jsonFilePath), "JSON file path cannot be null or empty.");
            }
            _jsonFilePath = jsonFilePath;
            _rules = new List<TileRule>( );
        }

        public List<TileRule> ReadRulesFromJson( )
        {
            if (!System.IO.File.Exists(_jsonFilePath))
            {
                throw new FileNotFoundException("JSON file not found.", _jsonFilePath);
            }
            string jsonContent = System.IO.File.ReadAllText(_jsonFilePath);
            _rules = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TileRule>>(jsonContent);
            if (_rules == null || _rules.Count == 0)
            {
                throw new InvalidOperationException("No rules found in the JSON file.");
            }
            return _rules;
        }

    }
}
