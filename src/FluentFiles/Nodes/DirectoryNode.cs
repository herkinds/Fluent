namespace Herkinds.FluentFiles.Nodes
{
    using System;
    using System.Linq;

    /// <summary>
    /// A directory node.
    /// </summary>
    public sealed class DirectoryNode : INode
    {
        private DirectoryNode(string name)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Gets a null directory node.
        /// </summary>
        public static DirectoryNode Null => new DirectoryNode(string.Empty);

        /// <summary>
        /// Gets the name of the directory.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Converts a name to a directory node. A return indicates whether the conversion was successful.
        /// </summary>
        /// <param name="name">The name of the directory.</param>
        /// <param name="folder">The converted directory node.</param>
        /// <returns>True if the conversion was successful.</returns>
        public static bool TryParse(string name, out DirectoryNode folder)
        {
            bool isValid = System.IO.Path.GetInvalidPathChars().Any(c => name.Contains(c));
            folder = isValid ? new DirectoryNode(name) : Null;
            return isValid;
        }

        /// <summary>
        /// Converts a name to a directory node.
        /// </summary>
        /// <param name="name">The name of the directory.</param>
        /// <returns>The converted directory node.</returns>
        /// <exception cref="ArgumentException">When the directory name is not valid.</exception>
        public static DirectoryNode Parse(string name)
        {
            if (TryParse(name, out DirectoryNode folder))
            {
                return folder;
            }
            else
            {
                throw new ArgumentException($"Could not convert '{name}' to a directory node.");
            }
        }
    }
}
