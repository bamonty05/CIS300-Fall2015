namespace Ksu.Cis300.Homework5
{
    partial class Form1
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
            this.uxText2 = new System.Windows.Forms.Button();
            this.uxText1 = new System.Windows.Forms.Button();
            this.uxAnalyzeText = new System.Windows.Forms.Button();
            this.uxFilePath1 = new System.Windows.Forms.TextBox();
            this.uxFilePath2 = new System.Windows.Forms.TextBox();
            this.uxOpenfile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxText2
            // 
            this.uxText2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxText2.Location = new System.Drawing.Point(12, 48);
            this.uxText2.Name = "uxText2";
            this.uxText2.Size = new System.Drawing.Size(93, 30);
            this.uxText2.TabIndex = 1;
            this.uxText2.Text = "Text 2:";
            this.uxText2.UseVisualStyleBackColor = true;
            this.uxText2.Click += new System.EventHandler(this.uxText2_Click);
            // 
            // uxText1
            // 
            this.uxText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxText1.Location = new System.Drawing.Point(12, 12);
            this.uxText1.Name = "uxText1";
            this.uxText1.Size = new System.Drawing.Size(93, 30);
            this.uxText1.TabIndex = 2;
            this.uxText1.Text = "Text 1:";
            this.uxText1.UseVisualStyleBackColor = true;
            this.uxText1.Click += new System.EventHandler(this.uxText1_Click);
            // 
            // uxAnalyzeText
            // 
            this.uxAnalyzeText.Enabled = false;
            this.uxAnalyzeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAnalyzeText.Location = new System.Drawing.Point(11, 84);
            this.uxAnalyzeText.Name = "uxAnalyzeText";
            this.uxAnalyzeText.Size = new System.Drawing.Size(406, 31);
            this.uxAnalyzeText.TabIndex = 3;
            this.uxAnalyzeText.Text = "Analyze Text";
            this.uxAnalyzeText.UseVisualStyleBackColor = true;
            this.uxAnalyzeText.Click += new System.EventHandler(this.uxAnalyzeText_Click);
            // 
            // uxFilePath1
            // 
            this.uxFilePath1.Location = new System.Drawing.Point(111, 18);
            this.uxFilePath1.Name = "uxFilePath1";
            this.uxFilePath1.ReadOnly = true;
            this.uxFilePath1.Size = new System.Drawing.Size(306, 20);
            this.uxFilePath1.TabIndex = 4;
            // 
            // uxFilePath2
            // 
            this.uxFilePath2.Location = new System.Drawing.Point(111, 54);
            this.uxFilePath2.Name = "uxFilePath2";
            this.uxFilePath2.ReadOnly = true;
            this.uxFilePath2.Size = new System.Drawing.Size(306, 20);
            this.uxFilePath2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(435, 127);
            this.Controls.Add(this.uxFilePath2);
            this.Controls.Add(this.uxFilePath1);
            this.Controls.Add(this.uxAnalyzeText);
            this.Controls.Add(this.uxText1);
            this.Controls.Add(this.uxText2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Text Analyzer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxText2;
        private System.Windows.Forms.Button uxText1;
        private System.Windows.Forms.Button uxAnalyzeText;
        private System.Windows.Forms.TextBox uxFilePath1;
        private System.Windows.Forms.TextBox uxFilePath2;
        private System.Windows.Forms.OpenFileDialog uxOpenfile;
    }
}

