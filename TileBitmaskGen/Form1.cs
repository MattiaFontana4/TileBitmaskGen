using TileBitmaskGen.BitmaskGeneratorJson;

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

        private Panel CreateRulePanel(uint ruleIndex)
        {
            // Pseudocode:
            // 1. Create a new fixed-size Panel.
            // 2. Add a TextBox for the tile name, with a label "Tile Name".
            // 3. Create a 3x3 grid of ComboBox (or other control) to select "None", "Any", "Same" for each cell.
            // 4. Add descriptive labels for the grid (e.g. "Neighbors", "Center", etc).
            // 5. Return the panel.

            var panel = new Panel
            {
                Size = new Size(400, 180),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(5),
                Location = new Point(10, (int) (ruleIndex * 190)) // Adjust location based on rule index
            };

            // Label for tile name
            var labelTileName = new Label
            {
                Text = "Tile Name:",
                Location = new Point(10, 10),
                AutoSize = true
            };
            panel.Controls.Add(labelTileName);

            // TextBox for tile name
            var textBoxTileName = new TextBox
            {
                Name = $"textBoxTileName_{ruleIndex}",
                Location = new Point(80, 7),
                Size = new Size(120, 23)
            };
            panel.Controls.Add(textBoxTileName);

            // Label for grid
            var labelGrid = new Label
            {
                Text = "Neighbor pattern:",
                Location = new Point(10, 40),
                AutoSize = true
            };
            panel.Controls.Add(labelGrid);

            // Options for neighbors
            string[] options = { "None", "Any", "Same" };

            // 3x3 grid of ComboBox
            int startX = 30;
            int startY = 65;
            int cellSize = 40;
            ComboBox[,] gridBoxes = new ComboBox[3, 3];

            for (int row = 0 ; row < 3 ; row++)
            {
                for (int col = 0 ; col < 3 ; col++)
                {
                    var combo = new ComboBox
                    {
                        Name = $"combo_{ruleIndex}_{row}_{col}",
                        Location = new Point(startX + col * cellSize, startY + row * cellSize),
                        Size = new Size(cellSize, 23),
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    combo.Items.AddRange(options);
                    combo.SelectedIndex = (row == 1 && col == 1) ? 2 : 0; // Center default "Same", others "None"
                    gridBoxes[row, col] = combo;
                    panel.Controls.Add(combo);
                }
            }

            // Descriptive labels for directions
            var directions = new[] { "Top", "Center", "Bottom" };
            for (int row = 0 ; row < 3 ; row++)
            {
                var lbl = new Label
                {
                    Text = directions[row],
                    Location = new Point(startX + 3 * cellSize + 5, startY + row * cellSize + 3),
                    AutoSize = true
                };
                panel.Controls.Add(lbl);
            }
            var directionsCol = new[] { "Left", "Center", "Right" };
            for (int col = 0 ; col < 3 ; col++)
            {
                var lbl = new Label
                {
                    Text = directionsCol[col],
                    Location = new Point(startX + col * cellSize, startY - 18),
                    AutoSize = true
                };
                panel.Controls.Add(lbl);
            }

            return panel;
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
            var rulePanel = CreateRulePanel(_ruleCount++);
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

                    var jsonGenerator = new BitmaskGeneratorJsonWritter(outputPath, _rules);
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
