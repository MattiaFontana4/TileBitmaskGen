namespace TileBitmaskGen
{
    partial class PanelTileRule
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose( );
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent( uint ruleIndex)
        {

            Size = new Size(900, 150);
            BorderStyle = BorderStyle.FixedSingle;
            Margin = new Padding(5);
            Location = new Point(5, (int) (ruleIndex * 155)); // Adjust location based on rule index

            // Label for tile name
            var labelTileName = new Label
            {
                Text = "Tile Name:",
                Location = new Point(10, 60),
                AutoSize = true
            };
            Controls.Add(labelTileName);

            // TextBox for tile name
            var textBoxTileName = new TextBox
            {
                Name = $"textBoxTileName_{ruleIndex}",
                Location = new Point(80, 57),
                Size = new Size(120, 23)
            };
            Controls.Add(textBoxTileName);

            // Label for grid
            var labelGrid = new Label
            {
                Text = "Neighbor pattern:",
                Location = new Point(310, 80),
                AutoSize = true
            };
            Controls.Add(labelGrid);

            // Options for neighbors
            string[] options = { "None", "Any", "Same" };

            // 3x3 grid of ComboBox
            int startX = 430;
            int startY = 30;
            int cellSizeX = 60;
            int cellSizeY = 40;
            ComboBox[,] gridBoxes = new ComboBox[3, 3];

            for (int row = 0 ; row < 3 ; row++)
            {
                for (int col = 0 ; col < 3 ; col++)
                {
                    if (!(row == 1 && col == 1))
                    {
                        var combo = new ComboBox
                        {
                            Name = $"combo_{ruleIndex}_{row}_{col}",
                            Location = new Point(startX + col * cellSizeX, startY + row * cellSizeY),
                            Size = new Size(cellSizeX, 23),
                            DropDownStyle = ComboBoxStyle.DropDownList
                        };
                        combo.Items.AddRange(options);
                        combo.SelectedIndex = (row == 1 && col == 1) ? 2 : 0; // Center default "Same", others "None"
                        gridBoxes[row, col] = combo;
                        Controls.Add(combo);
                    }

                }
            }

            // Descriptive labels for directions
            var directions = new[] { "Top", "Center", "Bottom" };
            for (int row = 0 ; row < 3 ; row++)
            {
                var lbl = new Label
                {
                    Text = directions[row],
                    Location = new Point(startX + 3 * cellSizeX + 5, startY + row * cellSizeY + 3),
                    AutoSize = true
                };
                Controls.Add(lbl);
            }
            var directionsCol = new[] { "Left", "Center", "Right" };
            for (int col = 0 ; col < 3 ; col++)
            {
                var lbl = new Label
                {
                    Text = directionsCol[col],
                    Location = new Point(startX + col * cellSizeX, startY - 18),
                    AutoSize = true
                };
                Controls.Add(lbl);
            }

        }

        #endregion
    }
}
