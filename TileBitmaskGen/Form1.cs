namespace TileBitmaskGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Panel CreateRulePanel(int ruleIndex)
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
                Margin = new Padding(5)
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

    }
}
