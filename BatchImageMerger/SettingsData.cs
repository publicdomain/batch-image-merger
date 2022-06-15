﻿// <copyright file="SettingsData.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>
// <auto-generated />

namespace PublicDomain
{
    // Directives
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Urlister settings.
    /// </summary>
    public class SettingsData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:PublicDomain.SettingsData"/> class.
        /// </summary>
        public SettingsData()
        {
            // Parameterless constructor
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:PublicDomain.SettingsData"/> always on top.
        /// </summary>
        /// <value><c>true</c> if always on top; otherwise, <c>false</c>.</value>
        public bool AlwaysOnTop { get; set; } = true;

        /// <summary>
        /// Gets or sets the file extensions.
        /// </summary>
        /// <value>The file extensions.</value>
        public string FileExtensions { get; set; } = "*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.pbm;*.tga;*.tiff;*.tif;*.webp";

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        public decimal Images { get; set; } = 3;

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>The orientation.</value>
        public string Orientation { get; set; } = "Horizontal";

        /// <summary>
        /// Gets or sets the output format.
        /// </summary>
        /// <value>The output format.</value>
        public string OutputFormat { get; set; } = "PNG";

        /// <summary>
        /// Gets or sets the png values.
        /// </summary>
        /// <value>The png values.</value>
        public string PngValues { get; set; } = "";

        /// <summary>
        /// Gets or sets the jpg values.
        /// </summary>
        /// <value>The jpg values.</value>
        public string JpgValues { get; set; } = "";
    }
}