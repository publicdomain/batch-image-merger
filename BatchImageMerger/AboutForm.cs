// <copyright file="AboutForm.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

namespace PublicDomain
{
    // Directives
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Description of AboutForm.
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutForm"/> class.
        /// </summary>
        /// <param name="formTitle">Form title.</param>
        /// <param name="moduleTitle">Module title.</param>
        /// <param name="moduleInfo">Module info.</param>
        /// <param name="moduleLicenseText">Module license text.</param>
        /// <param name="moduleIcon">Module icon.</param>
        public AboutForm(string formTitle, string moduleTitle, string moduleInfo, string moduleLicenseText, Image moduleIcon)
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            // Set form title
            this.Text = formTitle;

            // Set module title
            this.moduleTitleLabel.Text = moduleTitle;

            // Set module info
            this.moduleInfoLabel.Text = moduleInfo;

            // Set module license text
            this.moduleLicenseRichTextBox.Text = moduleLicenseText;

            // Set module icon
            this.moduleIconPictureBox.Image = moduleIcon;
        }

        /// <summary>
        /// Ons the ok button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOkButtonClick(object sender, EventArgs e)
        {
            // Close form
            this.Close();
        }

        /// <summary>
        /// Licenses the rich text box link clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnLicenseRichTextBoxLinkClicked(object sender, LinkClickedEventArgs e)
        {
            // Uri
            var uri = new Uri(e.LinkText);

            // Validate url 
            if (uri.IsWellFormedOriginalString())
            {
                // Launch with default browser
                Process.Start(uri.ToString());
            }
        }
    }
}
