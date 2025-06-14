using TileBitmaskCore.BitmaskGeneratorJson;
using TileBitmaskCore;

namespace TileBitmaskGen
{
    public partial class Form1 : Form
    {
        private uint _ruleCount = 0; // Counter for rules
        private List<TileRule> _rules = new List<TileRule>( );
        private string defaultTileName;

        public Form1( )
        {
            InitializeComponent( );
        }


        private void loadJsonbtn_Click(object sender, EventArgs e)
        {

        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                Title = "Select JSON File"
            };

            if (openFileDialog.ShowDialog( ) == DialogResult.OK)
            {
                JsonPath.Text = openFileDialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filter = string.Empty;

            switch (comboBoxOutType.SelectedItem)
            {
                case OutputType.Json:
                    filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                    break;
                case OutputType.CSharpClass:
                    filter = "C# Class files (*.cs)|*.cs|All files (*.*)|*.*";
                    break;
                case OutputType.JavaClass:
                    filter = "Java Class files (*.java)|*.java|All files (*.*)|*.*";
                    break;
                case OutputType.CppClass:
                    filter = "C++ Class files (*.cpp)|*.cpp|All files (*.*)|*.*";
                    break;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = filter,
                Title = "Save Output File"
            };

            if (saveFileDialog.ShowDialog( ) == DialogResult.OK)
            {
                OutputPath.Text = saveFileDialog.FileName;
            }
        }

        private void JsonPath_DataContextChanged(object sender, EventArgs e)
        {
        }

        private void JsonPath_TextChanged(object sender, EventArgs e)
        {
            string path = JsonPath.Text;
            loadJsonbtn.Enabled = !string.IsNullOrEmpty(path) && File.Exists(path) && string.Equals(Path.GetExtension(path), ".json", StringComparison.OrdinalIgnoreCase);
        }

        private void comboBoxOutType_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedType = comboBoxOutType.SelectedItem as OutputType?;
            string path = OutputPath.Text;

            if (selectedType.HasValue)
            {
                switch (selectedType.Value)
                {
                    case OutputType.Json:
                        OutputPath.Text = Path.ChangeExtension(path, ".json");
                        break;
                    case OutputType.CSharpClass:
                        OutputPath.Text = Path.ChangeExtension(path, ".cs");
                        break;
                    case OutputType.JavaClass:
                        OutputPath.Text = Path.ChangeExtension(path, ".java");
                        break;
                    case OutputType.CppClass:
                        OutputPath.Text = Path.ChangeExtension(path, ".cpp");
                        break;
                }
            }

        }

        private void addRulebtn_Click(object sender, EventArgs e)
        {
            var rulePanel = new PanelTileRule(_ruleCount++);
            panelRules.Controls.Add(rulePanel);
        }

        private void buttonCompute_Click(object sender, EventArgs e)
        {
            if (_ruleCount == 0)
            {
                MessageBox.Show("Please add at least one rule before computing the bitmask.", "No Rules", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var outputType = comboBoxOutType.SelectedItem as OutputType?;
            if (!outputType.HasValue)
            {
                MessageBox.Show("Please select an output type.", "No Output Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(defaultTileName))
            {
                MessageBox.Show("Please set a default tile name before computing the bitmask.", "No Default Tile Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string outputPath = OutputPath.Text;
            if (string.IsNullOrEmpty(outputPath) || !Path.HasExtension(outputPath))
            {
                MessageBox.Show("Please specify a valid output file path.", "Invalid Output Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            switch (outputType.Value)
                {
                case OutputType.Json:
                    // Handle JSON output generation

                    var jsonGenerator = new BitmaskGeneratorJsonWriter(outputPath, _rules);
                    jsonGenerator.WriteRulesToJson( );

                    break;
                case OutputType.CSharpClass:
                    WriteOutputFile(outputPath, OutputLanguage.CSharp);
                    break;
                case OutputType.JavaClass:
                    WriteOutputFile(outputPath, OutputLanguage.Java);
                    break;
                case OutputType.CppClass:
                    WriteOutputFile(outputPath, OutputLanguage.Cpp);
                    break;
                default:
                    MessageBox.Show("Unsupported output type selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }





        }

        private void WriteOutputFile(string outputPath, OutputLanguage outputLanguage)
        {
            var bitmaskGenerator = new BitmaskGenerator( );
            bitmaskGenerator.SetRules(_rules, defaultTileName);
            var tileNames = bitmaskGenerator.GetTileNames( );
            var tileBitmasks = bitmaskGenerator.GetTileBitmasks( );

            var tileBitmaskStringGenerator = new TileBitmaskStringGenerator(tileBitmasks, tileNames);

            string result = tileBitmaskStringGenerator.GenerateBitmaskString(outputLanguage);
            File.WriteAllText(outputPath, result);
        }
    }

    public enum  OutputType
    {
        Json,
        CSharpClass,
        JavaClass,
        CppClass
    }


}
