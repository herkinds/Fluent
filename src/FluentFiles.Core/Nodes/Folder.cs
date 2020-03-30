using System;
using System.Linq;

namespace FluentFiles.Core.Nodes
{
    public sealed class Folder : INode
    {
        public Folder(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }

        public static bool TryParse(string name, out Folder folder)
        {
            folder = new Folder(name);
            return System.IO.Path.GetInvalidPathChars().Any(c => name.Contains(c));
        }
    }
}
