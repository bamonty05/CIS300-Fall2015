namespace Ksu.Cis300.Homework1
{
    partial class uxTravelingSalesMan
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
            this.uxDrawing = new Ksu.Cis300.Drawing.DrawingPanel();
            this.uxList = new System.Windows.Forms.ListBox();
            this.uxFind = new System.Windows.Forms.Button();
            this.uxClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxDrawing
            // 
            this.uxDrawing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxDrawing.BackColor = System.Drawing.Color.White;
            this.uxDrawing.Location = new System.Drawing.Point(12, 12);
            this.uxDrawing.Name = "uxDrawing";
            this.uxDrawing.Size = new System.Drawing.Size(323, 348);
            this.uxDrawing.TabIndex = 0;
            // 
            // uxList
            // 
            this.uxList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxList.FormattingEnabled = true;
            this.uxList.Location = new System.Drawing.Point(341, 84);
            this.uxList.Name = "uxList";
            this.uxList.Size = new System.Drawing.Size(129, 264);
            this.uxList.TabIndex = 1;
            // 
            // uxFind
            // 
            this.uxFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxFind.Location = new System.Drawing.Point(341, 12);
            this.uxFind.Name = "uxFind";
            this.uxFind.Size = new System.Drawing.Size(129, 30);
            this.uxFind.TabIndex = 2;
            this.uxFind.Text = "Find Tour";
            this.uxFind.UseVisualStyleBackColor = true;
            this.uxFind.Click += new System.EventHandler(this.uxFind_Click);
            // 
            // uxClear
            // 
            this.uxClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uxClear.Location = new System.Drawing.Point(341, 48);
            this.uxClear.Name = "uxClear";
            this.uxClear.Size = new System.Drawing.Size(129, 30);
            this.uxClear.TabIndex = 3;
            this.uxClear.Text = "Clear";
            this.uxClear.UseVisualStyleBackColor = true;
            this.uxClear.Click += new System.EventHandler(this.uxClear_Click);
            // 
            // uxTravelingSalesMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 372);
            this.Controls.Add(this.uxClear);
            this.Controls.Add(this.uxFind);
            this.Controls.Add(this.uxList);
            this.Controls.Add(this.uxDrawing);
            this.Name = "uxTravelingSalesMan";
            this.Text = "Traveling Salesman";
            this.ResumeLayout(false);

        }

        #endregion

        private Ksu.Cis300.Drawing.DrawingPanel uxDrawing;
        private System.Windows.Forms.ListBox uxList;
        private System.Windows.Forms.Button uxFind;
        private System.Windows.Forms.Button uxClear;
    }
}

