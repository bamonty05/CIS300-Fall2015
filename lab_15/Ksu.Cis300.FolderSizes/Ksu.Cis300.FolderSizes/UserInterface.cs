/* UserInterface.cs
 * Author: Jacob Dokos
 * Code: 11 19 14 06
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ksu.Cis300.FolderSizes
{
    /// <summary>
    /// A GUI for a program that finds folder sizes.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a Click event on the Folder button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSetFolder_Click(object sender, EventArgs e)
        {
            if (uxFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                SetCurrentFolder(new DirectoryInfo(uxFolderBrowser.SelectedPath));
            }
        }

        /// <summary>
        /// Sets the currently-analyzed folder to the given path name.
        /// </summary>
        /// <param name="folder">The path name for the folder to analyze.</param>
        private void SetCurrentFolder(DirectoryInfo folder)
        {
            uxCurrentFolder.Text = folder.FullName;
            long size = TotalSize(folder);
            uxSize.Text = size.ToString("N0");
            uxFolderList.Items.Clear();
            uxUp.Enabled = (folder.Parent != null);
            try
            {
                foreach (DirectoryInfo d in folder.GetDirectories())
                {
                    uxFolderList.Items.Add(d);
                }
            }
            catch (Exception e)
            {
                // If we can't access the sub-folders, we can't add them to the list.
            }
        }

        /// <summary>
        /// Handles a Click event on the "Up one level" button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxUp_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(uxCurrentFolder.Text);
            SetCurrentFolder(d.Parent);
        }

        /// <summary>
        /// Handles a SelectedIndexChanged event on the list of folders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFolderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryInfo d = (DirectoryInfo)uxFolderList.SelectedItem;
            SetCurrentFolder(d);
        }

        /// <summary>
        /// Computes the size of the given directory and all its sub-directories.
        /// </summary>
        /// <param name="dir">The directory to analyze.</param>
        /// <returns>The total size in bytes of dir and all its sub-directories.</returns>
        private long TotalSize(DirectoryInfo dir)
        {
            try
            {
                DirectoryInfo[] subFolders = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();

                long size = 0;

                for (int i = 0; i < files.Length; i++ )
                {
                    size += files[i].Length;
                }

                for (int i = 0; i < subFolders.Length; i++)
                {
                    size += TotalSize(subFolders[i]);
                }

                return size; 
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
