namespace TileBitmaskGen
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            JsonPath = new TextBox( );
            loadJsonbtn = new Button( );
            label1 = new Label( );
            browseBtn = new Button( );
            comboBoxOutType = new ComboBox( );
            label2 = new Label( );
            label3 = new Label( );
            OutputPath = new TextBox( );
            button1 = new Button( );
            label4 = new Label( );
            textBox1 = new TextBox( );
            Rules = new GroupBox( );
            panelRules = new Panel( );
            panel1 = new Panel( );
            Rules.SuspendLayout( );
            panelRules.SuspendLayout( );
            SuspendLayout( );
            // 
            // JsonPath
            // 
            JsonPath.Location = new Point(103, 32);
            JsonPath.Name = "JsonPath";
            JsonPath.Size = new Size(719, 23);
            JsonPath.TabIndex = 0;
            // 
            // loadJsonbtn
            // 
            loadJsonbtn.Location = new Point(909, 32);
            loadJsonbtn.Name = "loadJsonbtn";
            loadJsonbtn.Size = new Size(67, 23);
            loadJsonbtn.TabIndex = 1;
            loadJsonbtn.Text = "LoadJson";
            loadJsonbtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 35);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 2;
            label1.Text = "Path Json";
            // 
            // browseBtn
            // 
            browseBtn.Location = new Point(828, 31);
            browseBtn.Name = "browseBtn";
            browseBtn.Size = new Size(75, 24);
            browseBtn.TabIndex = 3;
            browseBtn.Text = "Browse";
            browseBtn.UseVisualStyleBackColor = true;
            // 
            // comboBoxOutType
            // 
            comboBoxOutType.FormattingEnabled = true;
            comboBoxOutType.Items.AddRange(new object[] { "CSharp", "Java", "Cpp" });
            comboBoxOutType.Location = new Point(103, 66);
            comboBoxOutType.Name = "comboBoxOutType";
            comboBoxOutType.Size = new Size(121, 23);
            comboBoxOutType.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 69);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 5;
            label2.Text = "Output type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 103);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 6;
            label3.Text = "Output Path";
            // 
            // OutputPath
            // 
            OutputPath.Location = new Point(103, 100);
            OutputPath.Name = "OutputPath";
            OutputPath.Size = new Size(719, 23);
            OutputPath.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(828, 99);
            button1.Name = "button1";
            button1.Size = new Size(75, 24);
            button1.TabIndex = 8;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 138);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 9;
            label4.Text = "Default Tile Name";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(133, 135);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(306, 23);
            textBox1.TabIndex = 10;
            // 
            // Rules
            // 
            Rules.Controls.Add(panelRules);
            Rules.Location = new Point(26, 208);
            Rules.Name = "Rules";
            Rules.Size = new Size(950, 514);
            Rules.TabIndex = 11;
            Rules.TabStop = false;
            Rules.Text = "Rules";
            // 
            // panelRules
            // 
            panelRules.AutoScroll = true;
            panelRules.Controls.Add(panel1);
            panelRules.Location = new Point(6, 22);
            panelRules.Name = "panelRules";
            panelRules.Size = new Size(938, 475);
            panelRules.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(932, 141);
            panel1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 734);
            Controls.Add(Rules);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(OutputPath);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBoxOutType);
            Controls.Add(browseBtn);
            Controls.Add(label1);
            Controls.Add(loadJsonbtn);
            Controls.Add(JsonPath);
            Name = "Form1";
            Text = "Form1";
            Rules.ResumeLayout(false);
            panelRules.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout( );
        }

        #endregion

        private TextBox JsonPath;
        private Button loadJsonbtn;
        private Label label1;
        private Button browseBtn;
        private ComboBox comboBoxOutType;
        private Label label2;
        private Label label3;
        private TextBox OutputPath;
        private Button button1;
        private Label label4;
        private TextBox textBox1;
        private GroupBox Rules;
        private Panel panelRules;
        private Panel panel1;






    }
}
