using System;
using System.Linq;

namespace FluentFiles.Core.Nodes
{
    public sealed class FolderNode : INode
    {
        private FolderNode(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }

        public static FolderNode Empty { get; } = new FolderNode(string.Empty);

        #region Factory methods
        public static bool TryParse(string name, out FolderNode folder)
        {
            bool isValid = System.IO.Path.GetInvalidPathChars().Any(c => name.Contains(c));
            folder = isValid ? new FolderNode(name) : Empty;
            return isValid;
        }

        public static FolderNode Parse(string name)
        {
            if (TryParse(name, out FolderNode folder))
                return folder;
            else
                throw new System.IO.DirectoryNotFoundException(); // TODO improve exception
        }
        #endregion
    }
}
