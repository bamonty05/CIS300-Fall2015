namespace Ksu.Cis300.NameLookup
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxOpen = new System.Windows.Forms.Button();
            this.uxRank = new System.Windows.Forms.TextBox();
            this.uxRankLabel = new System.Windows.Forms.Label();
            this.uxFrequency = new System.Windows.Forms.TextBox();
            this.uxFrequencyLabel = new System.Windows.Forms.Label();
            this.uxLookup = new System.Windows.Forms.Button();
            this.uxName = new System.Windows.Forms.TextBox();
            this.uxNameLabel = new System.Windows.Forms.Label();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxLabelLetter = new System.Windows.Forms.Label();
            this.uxOutputFile = new System.Windows.Forms.Button();
            this.uxFindCommonLetter = new System.Windows.Forms.Button();
            this.uxCountLetter = new System.Windows.Forms.Button();
            this.uxFirstLetter = new System.Windows.Forms.TextBox();
            this.uxLetterResult = new System.Windows.Forms.TextBox();
            this.uxCommonLetterResult = new System.Windows.Forms.TextBox();
            this.uxSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // uxOpen
            // 
            this.uxOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxOpen.Location = new System.Drawing.Point(22, 20);
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(310, 41);
            this.uxOpen.TabIndex = 31;
            this.uxOpen.Text = "Open Data File";
            this.uxOpen.UseVisualStyleBackColor = true;
            this.uxOpen.Click += new System.EventHandler(this.uxOpen_Click);
            // 
            // uxRank
            // 
            this.uxRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRank.Location = new System.Drawing.Point(82, 184);
            this.uxRank.Name = "uxRank";
            this.uxRank.ReadOnly = true;
            this.uxRank.Size = new System.Drawing.Size(250, 29);
            this.uxRank.TabIndex = 30;
            this.uxRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxRankLabel
            // 
            this.uxRankLabel.AutoSize = true;
            this.uxRankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRankLabel.Location = new System.Drawing.Point(18, 187);
            this.uxRankLabel.Name = "uxRankLabel";
            this.uxRankLabel.Size = new System.Drawing.Size(58, 24);
            this.uxRankLabel.TabIndex = 29;
            this.uxRankLabel.Text = "Rank:";
            // 
            // uxFrequency
            // 
            this.uxFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFrequency.Location = new System.Drawing.Point(131, 149);
            this.uxFrequency.Name = "uxFrequency";
            this.uxFrequency.ReadOnly = true;
            this.uxFrequency.Size = new System.Drawing.Size(201, 29);
            this.uxFrequency.TabIndex = 28;
            this.uxFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxFrequencyLabel
            // 
            this.uxFrequencyLabel.AutoSize = true;
            this.uxFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFrequencyLabel.Location = new System.Drawing.Point(18, 152);
            this.uxFrequencyLabel.Name = "uxFrequencyLabel";
            this.uxFrequencyLabel.Size = new System.Drawing.Size(107, 24);
            this.uxFrequencyLabel.TabIndex = 27;
            this.uxFrequencyLabel.Text = "Frequency:";
            // 
            // uxLookup
            // 
            this.uxLookup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLookup.Location = new System.Drawing.Point(22, 102);
            this.uxLookup.Name = "uxLookup";
            this.uxLookup.Size = new System.Drawing.Size(310, 41);
            this.uxLookup.TabIndex = 26;
            this.uxLookup.Text = "Get Statistics";
            this.uxLookup.UseVisualStyleBackColor = true;
            this.uxLookup.Click += new System.EventHandler(this.uxLookup_Click);
            // 
            // uxName
            // 
            this.uxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxName.Location = new System.Drawing.Point(90, 67);
            this.uxName.Name = "uxName";
            this.uxName.Size = new System.Drawing.Size(242, 29);
            this.uxName.TabIndex = 25;
            // 
            // uxNameLabel
            // 
            this.uxNameLabel.AutoSize = true;
            this.uxNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNameLabel.Location = new System.Drawing.Point(18, 70);
            this.uxNameLabel.Name = "uxNameLabel";
            this.uxNameLabel.Size = new System.Drawing.Size(66, 24);
            this.uxNameLabel.TabIndex = 24;
            this.uxNameLabel.Text = "Name:";
            // 
            // uxLabelLetter
            // 
            this.uxLabelLetter.AutoSize = true;
            this.uxLabelLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLabelLetter.Location = new System.Drawing.Point(347, 20);
            this.uxLabelLetter.Name = "uxLabelLetter";
            this.uxLabelLetter.Size = new System.Drawing.Size(100, 24);
            this.uxLabelLetter.TabIndex = 33;
            this.uxLabelLetter.Text = "First letter: ";
            // 
            // uxOutputFile
            // 
            this.uxOutputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxOutputFile.Location = new System.Drawing.Point(22, 228);
            this.uxOutputFile.Name = "uxOutputFile";
            this.uxOutputFile.Size = new System.Drawing.Size(310, 46);
            this.uxOutputFile.TabIndex = 34;
            this.uxOutputFile.Text = "Output Sorted File";
            this.uxOutputFile.UseVisualStyleBackColor = true;
            this.uxOutputFile.Click += new System.EventHandler(this.uxOutputFile_Click);
            // 
            // uxFindCommonLetter
            // 
            this.uxFindCommonLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFindCommonLetter.Location = new System.Drawing.Point(350, 169);
            this.uxFindCommonLetter.Name = "uxFindCommonLetter";
            this.uxFindCommonLetter.Size = new System.Drawing.Size(310, 41);
            this.uxFindCommonLetter.TabIndex = 35;
            this.uxFindCommonLetter.Text = "Find Most Common Letter";
            this.uxFindCommonLetter.UseVisualStyleBackColor = true;
            this.uxFindCommonLetter.Click += new System.EventHandler(this.uxFindCommonLetter_Click);
            // 
            // uxCountLetter
            // 
            this.uxCountLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCountLetter.Location = new System.Drawing.Point(351, 55);
            this.uxCountLetter.Name = "uxCountLetter";
            this.uxCountLetter.Size = new System.Drawing.Size(310, 41);
            this.uxCountLetter.TabIndex = 36;
            this.uxCountLetter.Text = "Count Names with Letter";
            this.uxCountLetter.UseVisualStyleBackColor = true;
            this.uxCountLetter.Click += new System.EventHandler(this.uxCountLetter_Click);
            // 
            // uxFirstLetter
            // 
            this.uxFirstLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxFirstLetter.Location = new System.Drawing.Point(453, 17);
            this.uxFirstLetter.Name = "uxFirstLetter";
            this.uxFirstLetter.Size = new System.Drawing.Size(208, 29);
            this.uxFirstLetter.TabIndex = 39;
            this.uxFirstLetter.UseWaitCursor = true;
            // 
            // uxLetterResult
            // 
            this.uxLetterResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLetterResult.Location = new System.Drawing.Point(351, 102);
            this.uxLetterResult.Multiline = true;
            this.uxLetterResult.Name = "uxLetterResult";
            this.uxLetterResult.Size = new System.Drawing.Size(309, 61);
            this.uxLetterResult.TabIndex = 40;
            // 
            // uxCommonLetterResult
            // 
            this.uxCommonLetterResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCommonLetterResult.Location = new System.Drawing.Point(351, 216);
            this.uxCommonLetterResult.Multiline = true;
            this.uxCommonLetterResult.Name = "uxCommonLetterResult";
            this.uxCommonLetterResult.Size = new System.Drawing.Size(309, 58);
            this.uxCommonLetterResult.TabIndex = 41;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 284);
            this.Controls.Add(this.uxCommonLetterResult);
            this.Controls.Add(this.uxLetterResult);
            this.Controls.Add(this.uxFirstLetter);
            this.Controls.Add(this.uxCountLetter);
            this.Controls.Add(this.uxFindCommonLetter);
            this.Controls.Add(this.uxOutputFile);
            this.Controls.Add(this.uxLabelLetter);
            this.Controls.Add(this.uxOpen);
            this.Controls.Add(this.uxRank);
            this.Controls.Add(this.uxRankLabel);
            this.Controls.Add(this.uxFrequency);
            this.Controls.Add(this.uxFrequencyLabel);
            this.Controls.Add(this.uxLookup);
            this.Controls.Add(this.uxName);
            this.Controls.Add(this.uxNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Name Lookup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxOpen;
        private System.Windows.Forms.TextBox uxRank;
        private System.Windows.Forms.Label uxRankLabel;
        private System.Windows.Forms.TextBox uxFrequency;
        private System.Windows.Forms.Label uxFrequencyLabel;
        private System.Windows.Forms.Button uxLookup;
        private System.Windows.Forms.TextBox uxName;
        private System.Windows.Forms.Label uxNameLabel;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.Label uxLabelLetter;
        private System.Windows.Forms.Button uxOutputFile;
        private System.Windows.Forms.Button uxFindCommonLetter;
        private System.Windows.Forms.Button uxCountLetter;
        private System.Windows.Forms.TextBox uxFirstLetter;
        private System.Windows.Forms.TextBox uxLetterResult;
        private System.Windows.Forms.TextBox uxCommonLetterResult;
        private System.Windows.Forms.SaveFileDialog uxSaveDialog;
    }
}

