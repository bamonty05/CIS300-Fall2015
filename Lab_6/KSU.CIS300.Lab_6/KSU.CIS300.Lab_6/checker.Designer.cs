namespace KSU.CIS300.Lab_6
{
    partial class uxLab6
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
            this.uxButton = new System.Windows.Forms.Button();
            this.uxLabel = new System.Windows.Forms.Label();
            this.uxText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // uxButton
            // 
            this.uxButton.Location = new System.Drawing.Point(114, 40);
            this.uxButton.Name = "uxButton";
            this.uxButton.Size = new System.Drawing.Size(152, 37);
            this.uxButton.TabIndex = 0;
            this.uxButton.Text = "Check";
            this.uxButton.UseVisualStyleBackColor = true;
            this.uxButton.Click += new System.EventHandler(this.uxButton_Click);
            // 
            // uxLabel
            // 
            this.uxLabel.AutoSize = true;
            this.uxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxLabel.Location = new System.Drawing.Point(12, 9);
            this.uxLabel.Name = "uxLabel";
            this.uxLabel.Size = new System.Drawing.Size(131, 25);
            this.uxLabel.TabIndex = 1;
            this.uxLabel.Text = "Enter String:";
            this.uxLabel.Click += new System.EventHandler(this.uxLabel_Click);
            // 
            // uxText
            // 
            this.uxText.Location = new System.Drawing.Point(149, 14);
            this.uxText.Name = "uxText";
            this.uxText.Size = new System.Drawing.Size(188, 20);
            this.uxText.TabIndex = 2;
            // 
            // uxLab6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 86);
            this.Controls.Add(this.uxText);
            this.Controls.Add(this.uxLabel);
            this.Controls.Add(this.uxButton);
            this.Name = "uxLab6";
            this.Text = "Lab 6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxButton;
        private System.Windows.Forms.Label uxLabel;
        private System.Windows.Forms.TextBox uxText;
    }
}

