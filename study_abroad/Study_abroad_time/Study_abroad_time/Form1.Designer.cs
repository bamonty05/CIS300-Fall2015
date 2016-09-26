namespace Study_abroad_time
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
            this.uxHour1 = new System.Windows.Forms.Label();
            this.uxText1 = new System.Windows.Forms.TextBox();
            this.uxDifference = new System.Windows.Forms.TextBox();
            this.uxFindDifference = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxHour1
            // 
            this.uxHour1.AutoSize = true;
            this.uxHour1.Location = new System.Drawing.Point(13, 38);
            this.uxHour1.Name = "uxHour1";
            this.uxHour1.Size = new System.Drawing.Size(13, 13);
            this.uxHour1.TabIndex = 0;
            this.uxHour1.Text = "1";
            // 
            // uxText1
            // 
            this.uxText1.Location = new System.Drawing.Point(13, 55);
            this.uxText1.Name = "uxText1";
            this.uxText1.Size = new System.Drawing.Size(35, 20);
            this.uxText1.TabIndex = 1;
            this.uxText1.Tag = "1";
            // 
            // uxDifference
            // 
            this.uxDifference.Location = new System.Drawing.Point(93, 191);
            this.uxDifference.Name = "uxDifference";
            this.uxDifference.Size = new System.Drawing.Size(36, 20);
            this.uxDifference.TabIndex = 2;
            // 
            // uxFindDifference
            // 
            this.uxFindDifference.Location = new System.Drawing.Point(12, 191);
            this.uxFindDifference.Name = "uxFindDifference";
            this.uxFindDifference.Size = new System.Drawing.Size(75, 23);
            this.uxFindDifference.TabIndex = 3;
            this.uxFindDifference.Text = "Find Difference";
            this.uxFindDifference.UseVisualStyleBackColor = true;
            this.uxFindDifference.Click += new System.EventHandler(this.uxFindDifference_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.uxFindDifference);
            this.Controls.Add(this.uxDifference);
            this.Controls.Add(this.uxText1);
            this.Controls.Add(this.uxHour1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxHour1;
        private System.Windows.Forms.TextBox uxText1;
        private System.Windows.Forms.TextBox uxDifference;
        private System.Windows.Forms.Button uxFindDifference;
    }
}

