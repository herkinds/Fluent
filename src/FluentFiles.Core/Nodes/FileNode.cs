using System;
using System.Linq;

namespace Herkinds.FluentFiles.Core.Nodes
{
    public sealed class FileNode : INode
    {
        private FileNode(string name, string extension)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Extension = extension ?? throw new ArgumentNullException(nameof(extension));
        }

        public string Name { get; }

        public string Extension { get; }

        public static FileNode Empty { get; } = new FileNode(string.Empty, string.Empty);

        #region Factory methods
        public static bool TryParse(string name, string extension, out FileNode file)
        {
            bool isValid = System.IO.Path.GetInvalidFileNameChars().Any(c => name.Contains(c));
            file = isValid ? new FileNode(name, extension) : Empty;
            return isValid;
        }

        public static FileNode Parse(string name, string extension)
        {
            if (TryParse(name, extension, out FileNode folder))
                return folder;
            else
                throw new System.IO.FileNotFoundException(); // TODO improve exception
        }
        #endregion
    }
}
