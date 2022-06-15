
namespace BatchImageMerger
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importedFileExtensionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outputFormatValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.jPGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.freeReleasesPublicDomainisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.originalThreadRedditcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sourceCodeGithubcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.importedTextToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.importedCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.outputTextToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.outputCountToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.itemsListView = new System.Windows.Forms.ListView();
			this.itemsColumnHeader = new System.Windows.Forms.ColumnHeader();
			this.imagesNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.imagesLabel = new System.Windows.Forms.Label();
			this.orientationLabel = new System.Windows.Forms.Label();
			this.orientationComboBox = new System.Windows.Forms.ComboBox();
			this.importLabel = new System.Windows.Forms.Label();
			this.browseButton = new System.Windows.Forms.Button();
			this.processButton = new System.Windows.Forms.Button();
			this.spaceLabel = new System.Windows.Forms.Label();
			this.spaceNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.outputLabel = new System.Windows.Forms.Label();
			this.formatComboBox = new System.Windows.Forms.ComboBox();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.mainMenuStrip.SuspendLayout();
			this.mainStatusStrip.SuspendLayout();
			this.mainTableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imagesNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spaceNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem1,
									this.toolsToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(284, 24);
			this.mainMenuStrip.TabIndex = 57;
			// 
			// fileToolStripMenuItem1
			// 
			this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newToolStripMenuItem,
									this.toolStripSeparator3,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
			this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem1.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.OnNewToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(138, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItemClick);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.settingsToolStripMenuItem,
									this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.importedFileExtensionsToolStripMenuItem,
									this.outputFormatValuesToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.settingsToolStripMenuItem.Text = "&Settings";
			// 
			// importedFileExtensionsToolStripMenuItem
			// 
			this.importedFileExtensionsToolStripMenuItem.Name = "importedFileExtensionsToolStripMenuItem";
			this.importedFileExtensionsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.importedFileExtensionsToolStripMenuItem.Text = "&Imported file extensions";
			this.importedFileExtensionsToolStripMenuItem.Click += new System.EventHandler(this.OnImportedFileExtensionsToolStripMenuItemClick);
			// 
			// outputFormatValuesToolStripMenuItem
			// 
			this.outputFormatValuesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.jPGToolStripMenuItem,
									this.pNGToolStripMenuItem});
			this.outputFormatValuesToolStripMenuItem.Name = "outputFormatValuesToolStripMenuItem";
			this.outputFormatValuesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
			this.outputFormatValuesToolStripMenuItem.Text = "&Output format values";
			this.outputFormatValuesToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnOutputFormatValuesToolStripMenuItemDropDownItemClicked);
			// 
			// jPGToolStripMenuItem
			// 
			this.jPGToolStripMenuItem.Name = "jPGToolStripMenuItem";
			this.jPGToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.jPGToolStripMenuItem.Text = "&JPG";
			// 
			// pNGToolStripMenuItem
			// 
			this.pNGToolStripMenuItem.Name = "pNGToolStripMenuItem";
			this.pNGToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
			this.pNGToolStripMenuItem.Text = "&PNG";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.alwaysOnTopToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.optionsToolStripMenuItem.Text = "&Options";
			this.optionsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnOptionsToolStripMenuItemDropDownItemClicked);
			// 
			// alwaysOnTopToolStripMenuItem
			// 
			this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
			this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.alwaysOnTopToolStripMenuItem.Text = "&Always on top";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.freeReleasesPublicDomainisToolStripMenuItem,
									this.originalThreadRedditcomToolStripMenuItem,
									this.sourceCodeGithubcomToolStripMenuItem,
									this.toolStripSeparator2,
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// freeReleasesPublicDomainisToolStripMenuItem
			// 
			this.freeReleasesPublicDomainisToolStripMenuItem.Name = "freeReleasesPublicDomainisToolStripMenuItem";
			this.freeReleasesPublicDomainisToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
			this.freeReleasesPublicDomainisToolStripMenuItem.Text = "&Free Releases @ PublicDomain.is";
			this.freeReleasesPublicDomainisToolStripMenuItem.Click += new System.EventHandler(this.OnFreeReleasesPublicDomainisToolStripMenuItemClick);
			// 
			// originalThreadRedditcomToolStripMenuItem
			// 
			this.originalThreadRedditcomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("originalThreadRedditcomToolStripMenuItem.Image")));
			this.originalThreadRedditcomToolStripMenuItem.Name = "originalThreadRedditcomToolStripMenuItem";
			this.originalThreadRedditcomToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
			this.originalThreadRedditcomToolStripMenuItem.Text = "Original thread @ Reddit.com";
			this.originalThreadRedditcomToolStripMenuItem.Click += new System.EventHandler(this.OriginalThreadRedditcomToolStripMenuItemClick);
			// 
			// sourceCodeGithubcomToolStripMenuItem
			// 
			this.sourceCodeGithubcomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sourceCodeGithubcomToolStripMenuItem.Image")));
			this.sourceCodeGithubcomToolStripMenuItem.Name = "sourceCodeGithubcomToolStripMenuItem";
			this.sourceCodeGithubcomToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
			this.sourceCodeGithubcomToolStripMenuItem.Text = "&Source code @ Github.com";
			this.sourceCodeGithubcomToolStripMenuItem.Click += new System.EventHandler(this.OnSourceCodeGithubcomToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolStripMenuItemClick);
			// 
			// mainStatusStrip
			// 
			this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.importedTextToolStripStatusLabel,
									this.importedCountToolStripStatusLabel,
									this.outputTextToolStripStatusLabel,
									this.outputCountToolStripStatusLabel});
			this.mainStatusStrip.Location = new System.Drawing.Point(0, 418);
			this.mainStatusStrip.Name = "mainStatusStrip";
			this.mainStatusStrip.Size = new System.Drawing.Size(284, 22);
			this.mainStatusStrip.SizingGrip = false;
			this.mainStatusStrip.TabIndex = 56;
			// 
			// importedTextToolStripStatusLabel
			// 
			this.importedTextToolStripStatusLabel.Name = "importedTextToolStripStatusLabel";
			this.importedTextToolStripStatusLabel.Size = new System.Drawing.Size(55, 17);
			this.importedTextToolStripStatusLabel.Text = "Inported:";
			// 
			// importedCountToolStripStatusLabel
			// 
			this.importedCountToolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.importedCountToolStripStatusLabel.Name = "importedCountToolStripStatusLabel";
			this.importedCountToolStripStatusLabel.Size = new System.Drawing.Size(14, 17);
			this.importedCountToolStripStatusLabel.Text = "0";
			// 
			// outputTextToolStripStatusLabel
			// 
			this.outputTextToolStripStatusLabel.Name = "outputTextToolStripStatusLabel";
			this.outputTextToolStripStatusLabel.Size = new System.Drawing.Size(48, 17);
			this.outputTextToolStripStatusLabel.Text = "Output:";
			// 
			// outputCountToolStripStatusLabel
			// 
			this.outputCountToolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.outputCountToolStripStatusLabel.Name = "outputCountToolStripStatusLabel";
			this.outputCountToolStripStatusLabel.Size = new System.Drawing.Size(14, 17);
			this.outputCountToolStripStatusLabel.Text = "0";
			// 
			// mainTableLayoutPanel
			// 
			this.mainTableLayoutPanel.ColumnCount = 2;
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
			this.mainTableLayoutPanel.Controls.Add(this.itemsListView, 0, 4);
			this.mainTableLayoutPanel.Controls.Add(this.imagesNumericUpDown, 1, 0);
			this.mainTableLayoutPanel.Controls.Add(this.imagesLabel, 0, 0);
			this.mainTableLayoutPanel.Controls.Add(this.orientationLabel, 0, 1);
			this.mainTableLayoutPanel.Controls.Add(this.orientationComboBox, 1, 1);
			this.mainTableLayoutPanel.Controls.Add(this.importLabel, 0, 3);
			this.mainTableLayoutPanel.Controls.Add(this.browseButton, 1, 3);
			this.mainTableLayoutPanel.Controls.Add(this.processButton, 0, 6);
			this.mainTableLayoutPanel.Controls.Add(this.spaceLabel, 0, 2);
			this.mainTableLayoutPanel.Controls.Add(this.spaceNumericUpDown, 1, 2);
			this.mainTableLayoutPanel.Controls.Add(this.outputLabel, 0, 5);
			this.mainTableLayoutPanel.Controls.Add(this.formatComboBox, 1, 5);
			this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
			this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
			this.mainTableLayoutPanel.RowCount = 7;
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			this.mainTableLayoutPanel.Size = new System.Drawing.Size(284, 394);
			this.mainTableLayoutPanel.TabIndex = 58;
			// 
			// itemsListView
			// 
			this.itemsListView.AllowDrop = true;
			this.itemsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.itemsColumnHeader});
			this.mainTableLayoutPanel.SetColumnSpan(this.itemsListView, 2);
			this.itemsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemsListView.Location = new System.Drawing.Point(3, 131);
			this.itemsListView.Name = "itemsListView";
			this.itemsListView.Size = new System.Drawing.Size(278, 193);
			this.itemsListView.TabIndex = 4;
			this.itemsListView.UseCompatibleStateImageBehavior = false;
			this.itemsListView.View = System.Windows.Forms.View.Details;
			this.itemsListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnItemsListViewDragDrop);
			this.itemsListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnItemsListViewDragEnter);
			this.itemsListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnItemsListViewMouseDown);
			this.itemsListView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnItemsListViewMouseMove);
			this.itemsListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnItemsListViewMouseUp);
			// 
			// itemsColumnHeader
			// 
			this.itemsColumnHeader.Text = "Items";
			this.itemsColumnHeader.Width = 250;
			// 
			// imagesNumericUpDown
			// 
			this.imagesNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imagesNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.imagesNumericUpDown.Location = new System.Drawing.Point(116, 3);
			this.imagesNumericUpDown.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.imagesNumericUpDown.Minimum = new decimal(new int[] {
									2,
									0,
									0,
									0});
			this.imagesNumericUpDown.Name = "imagesNumericUpDown";
			this.imagesNumericUpDown.Size = new System.Drawing.Size(165, 26);
			this.imagesNumericUpDown.TabIndex = 0;
			this.imagesNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.imagesNumericUpDown.Value = new decimal(new int[] {
									3,
									0,
									0,
									0});
			// 
			// imagesLabel
			// 
			this.imagesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imagesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.imagesLabel.Location = new System.Drawing.Point(3, 0);
			this.imagesLabel.Name = "imagesLabel";
			this.imagesLabel.Size = new System.Drawing.Size(107, 32);
			this.imagesLabel.TabIndex = 0;
			this.imagesLabel.Text = "Images";
			this.imagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// orientationLabel
			// 
			this.orientationLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.orientationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.orientationLabel.Location = new System.Drawing.Point(3, 32);
			this.orientationLabel.Name = "orientationLabel";
			this.orientationLabel.Size = new System.Drawing.Size(107, 32);
			this.orientationLabel.TabIndex = 1;
			this.orientationLabel.Text = "Orientation:";
			this.orientationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// orientationComboBox
			// 
			this.orientationComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.orientationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.orientationComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.orientationComboBox.FormattingEnabled = true;
			this.orientationComboBox.Items.AddRange(new object[] {
									"Vertical",
									"Horizontal"});
			this.orientationComboBox.Location = new System.Drawing.Point(116, 35);
			this.orientationComboBox.Name = "orientationComboBox";
			this.orientationComboBox.Size = new System.Drawing.Size(165, 28);
			this.orientationComboBox.TabIndex = 1;
			// 
			// importLabel
			// 
			this.importLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.importLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.importLabel.Location = new System.Drawing.Point(3, 96);
			this.importLabel.Name = "importLabel";
			this.importLabel.Size = new System.Drawing.Size(107, 32);
			this.importLabel.TabIndex = 3;
			this.importLabel.Text = "Import:";
			this.importLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// browseButton
			// 
			this.browseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.browseButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.browseButton.Location = new System.Drawing.Point(114, 97);
			this.browseButton.Margin = new System.Windows.Forms.Padding(1);
			this.browseButton.Name = "browseButton";
			this.browseButton.Size = new System.Drawing.Size(169, 30);
			this.browseButton.TabIndex = 3;
			this.browseButton.Text = "&Browse";
			this.browseButton.UseVisualStyleBackColor = true;
			this.browseButton.Click += new System.EventHandler(this.OnBrowseButtonClick);
			// 
			// processButton
			// 
			this.mainTableLayoutPanel.SetColumnSpan(this.processButton, 2);
			this.processButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.processButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.processButton.ForeColor = System.Drawing.Color.DarkGreen;
			this.processButton.Location = new System.Drawing.Point(3, 362);
			this.processButton.Name = "processButton";
			this.processButton.Size = new System.Drawing.Size(278, 29);
			this.processButton.TabIndex = 6;
			this.processButton.Text = "&Process";
			this.processButton.UseVisualStyleBackColor = true;
			this.processButton.Click += new System.EventHandler(this.OnProcessButtonClick);
			// 
			// spaceLabel
			// 
			this.spaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.spaceLabel.Location = new System.Drawing.Point(3, 64);
			this.spaceLabel.Name = "spaceLabel";
			this.spaceLabel.Size = new System.Drawing.Size(100, 23);
			this.spaceLabel.TabIndex = 2;
			this.spaceLabel.Text = "&Space";
			this.spaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// spaceNumericUpDown
			// 
			this.spaceNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spaceNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.spaceNumericUpDown.Location = new System.Drawing.Point(116, 67);
			this.spaceNumericUpDown.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.spaceNumericUpDown.Name = "spaceNumericUpDown";
			this.spaceNumericUpDown.Size = new System.Drawing.Size(165, 26);
			this.spaceNumericUpDown.TabIndex = 2;
			this.spaceNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// outputLabel
			// 
			this.outputLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
			this.outputLabel.Location = new System.Drawing.Point(3, 327);
			this.outputLabel.Name = "outputLabel";
			this.outputLabel.Size = new System.Drawing.Size(107, 32);
			this.outputLabel.TabIndex = 5;
			this.outputLabel.Text = "&Output";
			this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// formatComboBox
			// 
			this.formatComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.formatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.formatComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.formatComboBox.FormattingEnabled = true;
			this.formatComboBox.Items.AddRange(new object[] {
									"BMP",
									"JPG",
									"PNG"});
			this.formatComboBox.Location = new System.Drawing.Point(116, 330);
			this.formatComboBox.Name = "formatComboBox";
			this.formatComboBox.Size = new System.Drawing.Size(165, 28);
			this.formatComboBox.TabIndex = 5;
			// 
			// MainForm
			// 
			this.AcceptButton = this.processButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 440);
			this.Controls.Add(this.mainTableLayoutPanel);
			this.Controls.Add(this.mainMenuStrip);
			this.Controls.Add(this.mainStatusStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BatchImageMerger";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormFormClosing);
			this.Load += new System.EventHandler(this.OnMainFormLoad);
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.mainStatusStrip.ResumeLayout(false);
			this.mainStatusStrip.PerformLayout();
			this.mainTableLayoutPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imagesNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spaceNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem pNGToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem jPGToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem outputFormatValuesToolStripMenuItem;
		private System.Windows.Forms.ComboBox formatComboBox;
		private System.Windows.Forms.Label outputLabel;
		private System.Windows.Forms.NumericUpDown spaceNumericUpDown;
		private System.Windows.Forms.Label spaceLabel;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.ToolStripMenuItem importedFileExtensionsToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader itemsColumnHeader;
		private System.Windows.Forms.ListView itemsListView;
		private System.Windows.Forms.Button processButton;
		private System.Windows.Forms.Button browseButton;
		private System.Windows.Forms.Label importLabel;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ComboBox orientationComboBox;
		private System.Windows.Forms.Label orientationLabel;
		private System.Windows.Forms.Label imagesLabel;
		private System.Windows.Forms.NumericUpDown imagesNumericUpDown;
		private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
		private System.Windows.Forms.ToolStripStatusLabel outputCountToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel outputTextToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel importedCountToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel importedTextToolStripStatusLabel;
		private System.Windows.Forms.StatusStrip mainStatusStrip;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem sourceCodeGithubcomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem originalThreadRedditcomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem freeReleasesPublicDomainisToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
		private System.Windows.Forms.MenuStrip mainMenuStrip;
	}
}
