using System;
using System.Linq;

namespace Herkinds.FluentFiles.Nodes
{
    public sealed class DirectoryNode : INode
    {
        private DirectoryNode(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }

        public static DirectoryNode Empty { get; } = new DirectoryNode(string.Empty);

        #region Factory methods
        public static bool TryParse(string name, out DirectoryNode folder)
        {
            bool isValid = System.IO.Path.GetInvalidPathChars().Any(c => name.Contains(c));
            folder = isValid ? new DirectoryNode(name) : Empty;
            return isValid;
        }

        public static DirectoryNode Parse(string name)
        {
            if (TryParse(name, out DirectoryNode folder))
                return folder;
            else
                throw new System.IO.DirectoryNotFoundException(); // TODO improve exception
        }
        #endregion
    }
}
