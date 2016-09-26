namespace Ksu.Cis300.Sudoku
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uxPanel = new System.Windows.Forms.Panel();
            this.uxGrid = new System.Windows.Forms.DataGridView();
            this.uxMenuStrip = new System.Windows.Forms.MenuStrip();
            this.uxTools = new System.Windows.Forms.ToolStripMenuItem();
            this.uxLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.uxSolve = new System.Windows.Forms.Button();
            this.uxOpenfileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxGrid)).BeginInit();
            this.uxMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxPanel
            // 
            this.uxPanel.Controls.Add(this.uxGrid);
            this.uxPanel.Location = new System.Drawing.Point(11, 26);
            this.uxPanel.Margin = new System.Windows.Forms.Padding(2);
            this.uxPanel.Name = "uxPanel";
            this.uxPanel.Size = new System.Drawing.Size(370, 369);
            this.uxPanel.TabIndex = 0;
            // 
            // uxGrid
            // 
            this.uxGrid.AllowUserToAddRows = false;
            this.uxGrid.AllowUserToDeleteRows = false;
            this.uxGrid.AllowUserToResizeColumns = false;
            this.uxGrid.AllowUserToResizeRows = false;
            this.uxGrid.BackgroundColor = System.Drawing.Color.White;
            this.uxGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uxGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uxGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.uxGrid.Location = new System.Drawing.Point(2, 2);
            this.uxGrid.Margin = new System.Windows.Forms.Padding(2);
            this.uxGrid.Name = "uxGrid";
            this.uxGrid.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.uxGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.uxGrid.RowTemplate.Height = 28;
            this.uxGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.uxGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.uxGrid.Size = new System.Drawing.Size(370, 369);
            this.uxGrid.TabIndex = 0;
            this.uxGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.uxGrid_CellEndEdit);
            // 
            // uxMenuStrip
            // 
            this.uxMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxTools});
            this.uxMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxMenuStrip.Name = "uxMenuStrip";
            this.uxMenuStrip.Size = new System.Drawing.Size(391, 24);
            this.uxMenuStrip.TabIndex = 1;
            this.uxMenuStrip.Text = "menuStrip1";
            // 
            // uxTools
            // 
            this.uxTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxLoad});
            this.uxTools.Name = "uxTools";
            this.uxTools.Size = new System.Drawing.Size(44, 20);
            this.uxTools.Text = "Tools";
            // 
            // uxLoad
            // 
            this.uxLoad.Name = "uxLoad";
            this.uxLoad.Size = new System.Drawing.Size(152, 22);
            this.uxLoad.Text = "Load a Puzzle";
            this.uxLoad.Click += new System.EventHandler(this.uxLoad_Click);
            // 
            // uxSolve
            // 
            this.uxSolve.Location = new System.Drawing.Point(118, 402);
            this.uxSolve.Name = "uxSolve";
            this.uxSolve.Size = new System.Drawing.Size(147, 44);
            this.uxSolve.TabIndex = 2;
            this.uxSolve.Text = "Solve Puzzle";
            this.uxSolve.UseVisualStyleBackColor = true;
            this.uxSolve.Click += new System.EventHandler(this.uxSolve_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 478);
            this.Controls.Add(this.uxSolve);
            this.Controls.Add(this.uxPanel);
            this.Controls.Add(this.uxMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.uxMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Sudoku Solver";
            this.uxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxGrid)).EndInit();
            this.uxMenuStrip.ResumeLayout(false);
            this.uxMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel uxPanel;
        private System.Windows.Forms.DataGridView uxGrid;
        private System.Windows.Forms.MenuStrip uxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem uxTools;
        private System.Windows.Forms.ToolStripMenuItem uxLoad;
        private System.Windows.Forms.Button uxSolve;
        private System.Windows.Forms.OpenFileDialog uxOpenfileDialog;
    }
}

