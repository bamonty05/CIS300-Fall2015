namespace Lab_2
{
    partial class Lab2
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
            this.uxMenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.uxFile = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.uxSave = new System.Windows.Forms.ToolStripMenuItem();
            this.uxText = new System.Windows.Forms.TextBox();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.uxMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxMenuStrip1
            // 
            this.uxMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxFile});
            this.uxMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.uxMenuStrip1.Name = "uxMenuStrip1";
            this.uxMenuStrip1.Size = new System.Drawing.Size(723, 24);
            this.uxMenuStrip1.TabIndex = 0;
            this.uxMenuStrip1.Text = "menuStrip1";
            // 
            // uxFile
            // 
            this.uxFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxOpen,
            this.uxSave});
            this.uxFile.Name = "uxFile";
            this.uxFile.Size = new System.Drawing.Size(35, 20);
            this.uxFile.Text = "File";
            // 
            // uxOpen
            // 
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(152, 22);
            this.uxOpen.Text = "Open";
            this.uxOpen.Click += new System.EventHandler(this.uxOpen_Click);
            // 
            // uxSave
            // 
            this.uxSave.Name = "uxSave";
            this.uxSave.Size = new System.Drawing.Size(152, 22);
            this.uxSave.Text = "Save as";
            this.uxSave.Click += new System.EventHandler(this.uxSave_Click);
            // 
            // uxText
            // 
            this.uxText.Location = new System.Drawing.Point(12, 27);
            this.uxText.Multiline = true;
            this.uxText.Name = "uxText";
            this.uxText.Size = new System.Drawing.Size(699, 402);
            this.uxText.TabIndex = 1;
            // 
            // Lab2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 441);
            this.Controls.Add(this.uxText);
            this.Controls.Add(this.uxMenuStrip1);
            this.MainMenuStrip = this.uxMenuStrip1;
            this.Name = "Lab2";
            this.Text = "Text Editor";
            this.uxMenuStrip1.ResumeLayout(false);
            this.uxMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip uxMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uxFile;
        private System.Windows.Forms.ToolStripMenuItem uxOpen;
        private System.Windows.Forms.ToolStripMenuItem uxSave;
        private System.Windows.Forms.TextBox uxText;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.SaveFileDialog uxSaveDialog;
    }
}

