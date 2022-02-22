namespace Herkinds.FluentFiles.Nodes
{
    using System;
    using System.Linq;

    /// <summary>
    /// A file node.
    /// </summary>
    public sealed class FileNode : INode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileNode"/> class.
        /// </summary>
        /// <param name="name">The name of the file.</param>
        /// <param name="extension">The extension of the file.</param>
        public FileNode(string name, string extension)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Extension = extension ?? throw new ArgumentNullException(nameof(extension));
        }

        /// <summary>
        /// Gets a null file node.
        /// </summary>
        public static FileNode Null => new FileNode(string.Empty, string.Empty);

        /// <summary>
        /// Gets the file name without the extension.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        public string Extension { get; }

        /// <summary>
        /// Converts a file name and extension to <see cref="FileNode"/>. A return indicates
        /// whether the conversion was successful.
        /// </summary>
        /// <param name="name">The file name.</param>
        /// <param name="extension">The file extension.</param>
        /// <param name="file">The converted file.</param>
        /// <returns>True if the conversion was successful.</returns>
        public static bool TryParse(string name, string extension, out FileNode file)
        {
            bool isValid = System.IO.Path.GetInvalidFileNameChars().Any(c => name.Contains(c));

            // TODO: Check extension?
            file = isValid ? new FileNode(name, extension) : Null;
            return isValid;
        }

        /// <summary>
        /// Converts a file name and extension to <see cref="FileNode"/>.
        /// </summary>
        /// <param name="name">The file name.</param>
        /// <param name="extension">The file extension.</param>
        /// <returns>The converted file.</returns>
        /// <exception cref="ArgumentException">When the file name or extension is not valid.</exception>
        public static FileNode Parse(string name, string extension)
        {
            if (TryParse(name, extension, out FileNode folder))
            {
                return folder;
            }
            else
            {
                throw new ArgumentException($"Could not convert '{name}.{extension}' to a file node.");
            }
        }
    }
}
