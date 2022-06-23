// <copyright file="MainForm.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace BatchImageMerger
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Microsoft.VisualBasic;
    using PublicDomain;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Formats;
    using SixLabors.ImageSharp.Formats.Png;
    using SixLabors.ImageSharp.PixelFormats;
    using SixLabors.ImageSharp.Processing;

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
        private System.Drawing.Icon associatedIcon = null;

        /// <summary>
        /// The settings data.
        /// </summary>
        private SettingsData settingsData = null;

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

            /* Set icons */

            // Set associated icon from exe file
            this.associatedIcon = System.Drawing.Icon.ExtractAssociatedIcon(typeof(MainForm).GetTypeInfo().Assembly.Location);

            // Set public domain weekly tool strip menu item image
            this.freeReleasesPublicDomainisToolStripMenuItem.Image = this.associatedIcon.ToBitmap();

            /* Settings data */

            // Check for settings file
            if (!File.Exists(this.settingsDataPath))
            {
                // Create new settings file
                this.SaveSettingsFile(this.settingsDataPath, new SettingsData());
            }

            // Load settings from disk
            this.settingsData = this.LoadSettingsFile(this.settingsDataPath);

            // Set GUI via reset
            this.ResetGui();
        }

        /// <summary>
        /// Resets the GUI.
        /// </summary>
        private void ResetGui()
        {
            //  Clear
            this.itemsListView.Items.Clear();

            // Reset counters
            this.importedCountToolStripStatusLabel.Text = "0";
            this.outputCountToolStripStatusLabel.Text = "0";

            // Set values
            this.alwaysOnTopToolStripMenuItem.Checked = this.settingsData.AlwaysOnTop;
            this.scanSubdirectoriesToolStripMenuItem.Checked = this.settingsData.ScanSubdirectories;
            this.imagesNumericUpDown.Value = this.settingsData.Images;
            this.spaceNumericUpDown.Value = this.settingsData.Space;
            this.orientationComboBox.SelectedItem = this.settingsData.Orientation;
            this.formatComboBox.SelectedItem = this.settingsData.OutputFormat;
            this.destinationPathTextBox.Text = this.settingsData.DestinationPath;
        }

        /// <summary>
        /// Handles the browse button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnBrowseButtonClick(object sender, EventArgs e)
        {
            // Set description
            this.folderBrowserDialog.Description = "Populate image list";

            // Reset selected path
            this.folderBrowserDialog.SelectedPath = string.Empty;

            // Show folder browser dialog
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK && this.folderBrowserDialog.SelectedPath.Length > 0)
            {
                // Add directory images
                this.AddDirectoryImages(this.folderBrowserDialog.SelectedPath);
            }
        }

        /// <summary>
        /// Adds the directory images.
        /// </summary>
        /// <param name="directoryPath">Directory path.</param>
        private void AddDirectoryImages(string directoryPath)
        {
            // Prevent drawing
            this.itemsListView.BeginUpdate();

            // Set pattern
            string pattern = $"\\.({ this.settingsData.FileExtensions.Replace(',', '|') })";

            // Collect files
            var files = Directory.GetFiles(directoryPath, "*.*", this.scanSubdirectoriesToolStripMenuItem.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(file => Regex.IsMatch(Path.GetExtension(file).ToLower(), pattern));

            // Iterate files
            foreach (var file in files)
            {
                // Add to list
                this.itemsListView.Items.Add(file);
            }

            // Adjust column width
            this.itemsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // Resume drawing
            this.itemsListView.EndUpdate();

            // Update count
            this.importedCountToolStripStatusLabel.Text = this.itemsListView.Items.Count.ToString();
        }

        /// <summary>
        /// Handles the process button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnProcessButtonClick(object sender, EventArgs e)
        {
            // Check there's something to work with
            if (this.itemsListView.Items.Count == 0)
            {
                // Advise user
                MessageBox.Show("Add images to process", "No images", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Halt flow
                return;
            }

            // Check output directory
            if (this.destinationPathTextBox.Text.Length == 0)
            {
                // Advise user
                MessageBox.Show("Set destination directory", "No directory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Halt flow
                return;
            }

            // Set variables
            bool isHorizontal = this.orientationComboBox.SelectedItem.ToString() == "Horizontal" ? true : false;
            int batchImages = (int)this.imagesNumericUpDown.Value;
            int processedImages = 0;
            int errorCount = 0;
            List<string> imagePathsList = new List<string>(); // All added images path

            /* Processing */

            // Collect image paths
            for (int i = 0; i < this.itemsListView.Items.Count; i++)
            {
                // Add to image paths list
                imagePathsList.Add(this.itemsListView.Items[i].Text);
            }

            // Iterate images in list
            while (imagePathsList.Count > 0)
            {
                try
                {
                    // (Re)set width and height
                    int width = 0;
                    int height = 0;

                    // Set currentpatchs list
                    List<string> currentPathsList = new List<string>();

                    // Set current images
                    int currentImages = Math.Min(batchImages, imagePathsList.Count);

                    // Iterate times output images
                    for (int i = 0; i < currentImages; i++)
                    {
                        // Set imagePath
                        string imagePath = imagePathsList[0];

                        // Remove current
                        imagePathsList.RemoveAt(0);

                        // Add to current paths list
                        currentPathsList.Add(imagePath);

                        // Set image info
                        IImageInfo imageInfo = Image.Identify(imagePath);

                        // Act upon orientation
                        if (isHorizontal)
                        {
                            // Add to width
                            width += imageInfo.Width;

                            // Check for max height 
                            if (height < imageInfo.Height)
                            {
                                // Update height
                                height = imageInfo.Height;
                            }
                        }
                        else // Is vertical
                        {
                            // Add to height
                            height += imageInfo.Height;

                            // Check for max width
                            if (width < imageInfo.Width)
                            {
                                // Update width
                                width = imageInfo.Width;
                            }
                        }
                    }

                    // Add spacing
                    if (isHorizontal)
                    {
                        // Horizontal spacing
                        width += (int)(this.spaceNumericUpDown.Value * (currentImages - 1));
                    }
                    else
                    {
                        // Vertical spacing
                        height += (int)(this.spaceNumericUpDown.Value * (currentImages - 1));
                    }

                    // Process
                    using (var image = new Image<Rgba32>(width, height))
                    {
                        // Set offsets
                        int leftOffset = 0;
                        int topOffset = 0;

                        // Iterate image paths
                        for (int i = 0; i < currentPathsList.Count; i++)
                        {
                            // Add space if not zero
                            if (i > 0)
                            {
                                // Add spacing
                                if (isHorizontal)
                                {
                                    // Horizontal offset
                                    leftOffset += (int)this.spaceNumericUpDown.Value;
                                }
                                else
                                {
                                    // Vertical offset
                                    topOffset += (int)this.spaceNumericUpDown.Value;
                                }
                            }

                            // Load image from disk
                            using (Image currentImage = Image.Load<Rgba32>(currentPathsList[i]))
                            {
                                // Draw current image
                                image.Mutate(c => c.DrawImage(currentImage, new Point(leftOffset, topOffset), 1f));

                                // Update offset according to current image
                                if (isHorizontal)
                                {
                                    // Horizontal offset
                                    leftOffset += currentImage.Width;
                                }
                                else
                                {
                                    // Vertical offset
                                    topOffset += currentImage.Height;
                                }
                            }
                        }

                        // Save to disk
                        switch (this.settingsData.OutputFormat.ToLowerInvariant())
                        {
                            // .png
                            case "png":
                            default:

                                // TODO Compression level [Can be improved]
                                PngCompressionLevel pngCompressionLevel;

                                // Set by settings data
                                switch (this.settingsData.PngCompression)
                                {
                                    case 0:
                                        pngCompressionLevel = PngCompressionLevel.Level0;

                                        break;

                                    case 1:
                                        pngCompressionLevel = PngCompressionLevel.Level1;

                                        break;

                                    case 2:
                                        pngCompressionLevel = PngCompressionLevel.Level2;

                                        break;

                                    case 3:
                                        pngCompressionLevel = PngCompressionLevel.Level3;

                                        break;

                                    case 4:
                                        pngCompressionLevel = PngCompressionLevel.Level4;

                                        break;

                                    case 5:
                                        pngCompressionLevel = PngCompressionLevel.Level5;

                                        break;

                                    case 6:
                                        pngCompressionLevel = PngCompressionLevel.Level6;

                                        break;

                                    case 7:
                                        pngCompressionLevel = PngCompressionLevel.Level7;

                                        break;

                                    case 8:
                                        pngCompressionLevel = PngCompressionLevel.Level8;

                                        break;

                                    case 9:
                                    default:
                                        pngCompressionLevel = PngCompressionLevel.Level9;

                                        break;
                                }

                                // Set png encoder
                                IImageEncoder pngEncoder = new PngEncoder()
                                {
                                    CompressionLevel = pngCompressionLevel
                                };

                                // Save merged image to disk
                                image.Save($"{Path.Combine(this.destinationPathTextBox.Text, (processedImages + 1).ToString()) }.png", pngEncoder);

                                break;
                        }

                        // Raise processed images count
                        processedImages++;
                    }
                }
                catch (Exception ex)
                {
                    // Raise error count
                    errorCount++;

                    try
                    {
                        // Log to error file
                        File.AppendAllText("BatchImageMerger-ErrorLog.txt", $"{Environment.NewLine}{Environment.NewLine}{ex.Message}");
                    }
                    catch
                    {
                        ; // Let it fall through
                    }
                }
            }

            // Update processed images count in status
            this.outputCountToolStripStatusLabel.Text = processedImages.ToString();

            // Inform user
            MessageBox.Show($"Processed: {processedImages}.");
        }

        /// <summary>
        /// Handles the new tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Preserved values
            string fileExtensions = this.settingsData.FileExtensions;
            int pngCompression = this.settingsData.PngCompression;
            int jpgQuality = this.settingsData.JpgQuality;

            // Create new settings file
            this.SaveSettingsFile(this.settingsDataPath, new SettingsData());

            // Load settings from disk
            this.settingsData = this.LoadSettingsFile(this.settingsDataPath);

            // Check preserved values
            if (fileExtensions != this.settingsData.FileExtensions || pngCompression != this.settingsData.PngCompression || jpgQuality != this.settingsData.JpgQuality)
            {
                // Ask user
                if (MessageBox.Show("Keep file extensions, PNG and JPG values?", "Keep values", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.settingsData.FileExtensions = fileExtensions;
                    this.settingsData.PngCompression = pngCompression;
                    this.settingsData.JpgQuality = jpgQuality;
                }
            }

            // Set GUI via reset
            this.ResetGui();
        }

        /// <summary>
        /// Handles the imported file extensions tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnImportedFileExtensionsToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Topmost toggle for input box [can be improved]
            bool topmost = this.TopMost;
            this.TopMost = false;

            // Set new file extensions
            string fileExtensions = Interaction.InputBox("Edit file extensions:", "Extensions", this.settingsData.FileExtensions);

            // Declare file extensions list
            List<string> fileExtensionsList = new List<string>();

            // Check there's something
            if (fileExtensions.Length > 0)
            {
                // Split by comma and iterate
                foreach (string possibleExtension in fileExtensions.Split(','))
                {
                    // Clean
                    string fileExtension = Regex.Replace(possibleExtension, @"[^A-Za-z0-9]+", string.Empty);

                    // Check 
                    if (fileExtension.Length > 0)
                    {
                        // Add to list
                        fileExtensionsList.Add(fileExtension);
                    }
                }

                // Check there's an extension
                if (fileExtensionsList.Count > 0)
                {
                    // Update file extensions
                    this.settingsData.FileExtensions = string.Join(",", fileExtensionsList);
                }
            }

            // TODO Topmost toggle for input box
            this.TopMost = topmost;
        }

        /// <summary>
        /// Handles the options tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOptionsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set tool strip menu item
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;

            // Toggle checked
            toolStripMenuItem.Checked = !toolStripMenuItem.Checked;

            // Set topmost by check box
            this.TopMost = this.alwaysOnTopToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the free releases public domainis tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFreeReleasesPublicDomainisToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open our website
            Process.Start("https://publicdomain.is");
        }

        /// <summary>
        /// Originals the thread redditcom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OriginalThreadRedditcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open orignal thread
            Process.Start("https://www.reddit.com/r/software/comments/v9d4qa/im_looking_for_a_program_that_can_batch_merge/");
        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open GitHub repository
            Process.Start("https://github.com/publicdomain/batch-image-merger");
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

                // Set pattern
                string pattern = $"\\.({ this.settingsData.FileExtensions.Replace(',', '|') })";

                // Add dropped items
                foreach (string item in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    // Directory or file
                    if (Directory.Exists(item))
                    {
                        // Add directory images
                        this.AddDirectoryImages(item);
                    }
                    else
                    {
                        // Filter by file extension
                        if (Regex.IsMatch(Path.GetExtension(item).ToLower(), pattern))
                        {
                            // Add
                            this.itemsListView.Items.Add(item);
                        }
                    }
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
                        System.Drawing.Rectangle rectangle = destinationListViewItem.GetBounds(ItemBoundsPortion.Entire);

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
                        System.Drawing.Rectangle rectangle = destinationListViewItem.GetBounds(ItemBoundsPortion.Entire);

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
        /// Handles the main form load.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormLoad(object sender, EventArgs e)
        {
            // Set topmost
            this.TopMost = this.settingsData.AlwaysOnTop;
        }

        /// <summary>
        /// Handles the main form form closing.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            /* Setiings data values */

            // Set values
            this.settingsData.AlwaysOnTop = this.alwaysOnTopToolStripMenuItem.Checked;
            this.settingsData.ScanSubdirectories = this.scanSubdirectoriesToolStripMenuItem.Checked;
            this.settingsData.Images = this.imagesNumericUpDown.Value;
            this.settingsData.Space = this.spaceNumericUpDown.Value;
            this.settingsData.Orientation = this.orientationComboBox.SelectedItem.ToString();
            this.settingsData.OutputFormat = this.formatComboBox.SelectedItem.ToString();
            this.settingsData.DestinationPath = this.destinationPathTextBox.Text;

            // Save settings data to disk
            this.SaveSettingsFile(this.settingsDataPath, this.settingsData);
        }

        /// <summary>
        /// Handles the output format values tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOutputFormatValuesToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Loads the settings file.
        /// </summary>
        /// <returns>The settings file.</returns>
        /// <param name="settingsFilePath">Settings file path.</param>
        private SettingsData LoadSettingsFile(string settingsFilePath)
        {
            // Use file stream
            using (FileStream fileStream = File.OpenRead(settingsFilePath))
            {
                // Set xml serialzer
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsData));

                // Return populated settings data
                return xmlSerializer.Deserialize(fileStream) as SettingsData;
            }
        }

        /// <summary>
        /// Saves the settings file.
        /// </summary>
        /// <param name="settingsFilePath">Settings file path.</param>
        /// <param name="settingsDataParam">Settings data parameter.</param>
        private void SaveSettingsFile(string settingsFilePath, SettingsData settingsDataParam)
        {
            try
            {
                // Use stream writer
                using (StreamWriter streamWriter = new StreamWriter(settingsFilePath, false))
                {
                    // Set xml serialzer
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsData));

                    // Serialize settings data
                    xmlSerializer.Serialize(streamWriter, settingsDataParam);
                }
            }
            catch (Exception exception)
            {
                // Advise user
                MessageBox.Show($"Error saving settings file.{Environment.NewLine}{Environment.NewLine}Message:{Environment.NewLine}{exception.Message}", "File error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the remove tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnRemoveToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Prevent drawing
            this.itemsListView.BeginUpdate();

            // Remove selected items
            foreach (ListViewItem item in this.itemsListView.SelectedItems)
            {
                this.itemsListView.Items.Remove(item);
            }

            // Adjust column width^M
            this.itemsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            // Resume drawing
            this.itemsListView.EndUpdate();

            // Update count
            this.importedCountToolStripStatusLabel.Text = this.itemsListView.Items.Count.ToString();
        }

        /// <summary>
        /// Ons the destination browse button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnDestinationBrowseButtonClick(object sender, EventArgs e)
        {
            // Set description
            this.folderBrowserDialog.Description = "Set destination directory";

            // Set selected path
            this.folderBrowserDialog.SelectedPath = this.settingsData.DestinationPath;

            // Show folder browser dialog
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK && this.folderBrowserDialog.SelectedPath.Length > 0 && this.folderBrowserDialog.SelectedPath != this.settingsData.DestinationPath)
            {
                // Set destination path fields
                this.settingsData.DestinationPath = this.folderBrowserDialog.SelectedPath;
                this.destinationPathTextBox.Text = this.folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Handles the exit tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Close program
            this.Close();
        }
    }
}
