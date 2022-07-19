namespace WinFormsParser
{
    partial class frmParser
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
        private void InitializeComponent()
        {
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmbDelimiter = new System.Windows.Forms.ComboBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.btnRunQuery = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.cmbQuery = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(104, 67);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // cmbDelimiter
            // 
            this.cmbDelimiter.Enabled = false;
            this.cmbDelimiter.FormattingEnabled = true;
            this.cmbDelimiter.Items.AddRange(new object[] {
            ",",
            ";",
            ":",
            "-"});
            this.cmbDelimiter.Location = new System.Drawing.Point(230, 68);
            this.cmbDelimiter.Name = "cmbDelimiter";
            this.cmbDelimiter.Size = new System.Drawing.Size(75, 23);
            this.cmbDelimiter.TabIndex = 1;
            this.cmbDelimiter.Text = "Delimiter";
            this.cmbDelimiter.SelectedIndexChanged += new System.EventHandler(this.cmbDelimiter_SelectedIndexChanged);
            // 
            // btnParse
            // 
            this.btnParse.Enabled = false;
            this.btnParse.Location = new System.Drawing.Point(356, 67);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 2;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // btnRunQuery
            // 
            this.btnRunQuery.Enabled = false;
            this.btnRunQuery.Location = new System.Drawing.Point(869, 120);
            this.btnRunQuery.Name = "btnRunQuery";
            this.btnRunQuery.Size = new System.Drawing.Size(124, 23);
            this.btnRunQuery.TabIndex = 3;
            this.btnRunQuery.Text = "Run Query";
            this.btnRunQuery.UseVisualStyleBackColor = true;
            this.btnRunQuery.Click += new System.EventHandler(this.btnRunQuery_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(104, 182);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(889, 391);
            this.txtOutput.TabIndex = 5;
            // 
            // cmbQuery
            // 
            this.cmbQuery.Enabled = false;
            this.cmbQuery.FormattingEnabled = true;
            this.cmbQuery.Items.AddRange(new object[] {
            "Every person who has “Esq” in their company name",
            "Every person who lives in “Derbyshire”",
            "Every person whose house number is exactly three digits",
            "Every person whose website URL is longer than 35 characters",
            "Every person who lives in a postcode area with a single-digit value",
            "Every person whose first phone number is larger than their second phone number."});
            this.cmbQuery.Location = new System.Drawing.Point(104, 121);
            this.cmbQuery.Name = "cmbQuery";
            this.cmbQuery.Size = new System.Drawing.Size(710, 23);
            this.cmbQuery.TabIndex = 4;
            this.cmbQuery.Text = "Select A Query";
            this.cmbQuery.SelectedIndexChanged += new System.EventHandler(this.cmbQuery_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(869, 68);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(124, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 644);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.cmbQuery);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnRunQuery);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.cmbDelimiter);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "frmParser";
            this.Text = "Parser";
            this.Load += new System.EventHandler(this.frmParser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSelectFile;
        private OpenFileDialog openFileDialog1;
        private ComboBox cmbDelimiter;
        private Button btnParse;
        private Button btnRunQuery;
        private TextBox txtOutput;
        private ComboBox cmbQuery;
        private Button btnReset;
    }
}