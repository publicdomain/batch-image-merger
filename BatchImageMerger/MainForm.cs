// <copyright file="MainForm.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace BatchImageMerger
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        // The list view item
        private ListViewItem listViewItem = null;

        /// <summary>
        /// Gets or sets the associated icon.
        /// </summary>
        /// <value>The associated icon.</value>
        private Icon associatedIcon = null;

        /// <summary>
        /// The settings data.
        /// </summary>
        // private SettingsData settingsData = null;

        /// <summary>
        /// The settings data path.
        /// </summary>
        private string settingsDataPath = $"{Application.ProductName}-SettingsData.txt";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BatchImageMerger.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the browse button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnBrowseButtonClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the process button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnProcessButtonClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the new tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the imported file extensions tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnImportedFileExtensionsToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the options tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOptionsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the free releases public domainis tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFreeReleasesPublicDomainisToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Originals the thread redditcom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OriginalThreadRedditcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the about tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the items list view drag drop.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnItemsListViewDragDrop(object sender, DragEventArgs e)
        {
            // Files or directories
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Prevent drawing
                this.itemsListView.BeginUpdate();

                // Add dropped items
                foreach (string item in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    // TODO Filter by file extension

                    this.itemsListView.Items.Add(item);
                }

                // Adjust column width
                this.itemsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                // Resume drawing
                this.itemsListView.EndUpdate();

                // Update count
                this.importedCountToolStripStatusLabel.Text = this.itemsListView.Items.Count.ToString();
            }
        }


        /// <summary>
        /// Handles the items list view drag enter.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnItemsListViewDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        /// <summary>
        /// Handles the items list view mouse down.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnItemsListViewMouseDown(object sender, MouseEventArgs e)
        {
            listViewItem = this.itemsListView.GetItemAt(e.X, e.Y);
        }

        /// <summary>
        /// Handles the items list view mouse move.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnItemsListViewMouseMove(object sender, MouseEventArgs e)
        {
            if (listViewItem != null)
            {
                // Change cursor
                Cursor = Cursors.Hand;

                try
                {
                    ListViewItem destinationListViewItem = this.itemsListView.GetItemAt(0, Math.Min(e.Y, this.itemsListView.Items[this.itemsListView.Items.Count - 1].GetBounds(ItemBoundsPortion.Entire).Bottom - 1));

                    if (destinationListViewItem != null)
                    {
                        Rectangle rectangle = destinationListViewItem.GetBounds(ItemBoundsPortion.Entire);

                        bool insertBefore = (e.Y < rectangle.Top + (rectangle.Height / 2));

                        // Check if must scroll up
                        if (destinationListViewItem.Index == this.itemsListView.TopItem.Index && insertBefore && this.itemsListView.TopItem.Index > 0)
                        {
                            this.itemsListView.EnsureVisible(this.itemsListView.TopItem.Index - 1);
                        }
                        else // Check if must scroll down
                        {
                            ListViewItem bottomItem = this.itemsListView.TopItem;

                            for (int i = this.itemsListView.TopItem.Index + 1; i < this.itemsListView.Items.Count; i++)
                            {
                                if (this.itemsListView.ClientRectangle.Contains(this.itemsListView.Items[i].Bounds))
                                {
                                    bottomItem = this.itemsListView.Items[i];
                                }
                                else
                                {
                                    break;
                                }
                            }

                            if (destinationListViewItem.Index == bottomItem.Index && !insertBefore && bottomItem.Index < this.itemsListView.Items.Count - 1)
                            {
                                this.itemsListView.EnsureVisible(bottomItem.Index + 1);
                            }
                        }
                    }
                }
                catch {; }
            }
        }

        /// <summary>
        /// Handles the items list view mouse up.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnItemsListViewMouseUp(object sender, MouseEventArgs e)
        {
            if (listViewItem != null)
            {
                try
                {
                    ListViewItem destinationListViewItem = this.itemsListView.GetItemAt(0, Math.Min(e.Y, this.itemsListView.Items[this.itemsListView.Items.Count - 1].GetBounds(ItemBoundsPortion.Entire).Bottom - 1));

                    if (destinationListViewItem != null)
                    {
                        Rectangle rectangle = destinationListViewItem.GetBounds(ItemBoundsPortion.Entire);

                        bool insertBefore = (e.Y < rectangle.Top + (rectangle.Height / 2));

                        if (listViewItem != destinationListViewItem)
                        {
                            this.itemsListView.Items.Remove(listViewItem);

                            this.itemsListView.Items.Insert(destinationListViewItem.Index + (insertBefore ? 0 : 1), listViewItem);
                        }

                        this.itemsListView.Invalidate();
                    }
                }
                finally
                {
                    listViewItem = null;

                    Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Handles the exit tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }
    }
}
