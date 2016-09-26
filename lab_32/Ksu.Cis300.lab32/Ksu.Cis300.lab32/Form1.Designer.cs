namespace Ksu.Cis300.lab32
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
            this.uxReadGraph = new System.Windows.Forms.Button();
            this.uxOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxReadGraph
            // 
            this.uxReadGraph.Location = new System.Drawing.Point(496, 245);
            this.uxReadGraph.Name = "uxReadGraph";
            this.uxReadGraph.Size = new System.Drawing.Size(160, 86);
            this.uxReadGraph.TabIndex = 0;
            this.uxReadGraph.Text = "Read a Graph";
            this.uxReadGraph.UseVisualStyleBackColor = true;
            this.uxReadGraph.Click += new System.EventHandler(this.uxReadGraph_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 631);
            this.Controls.Add(this.uxReadGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxReadGraph;
        private System.Windows.Forms.OpenFileDialog uxOpenFile;
    }
}

