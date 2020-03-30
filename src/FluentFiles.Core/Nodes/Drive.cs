using System;

namespace FluentFiles.Core.Nodes
{
    public sealed class Drive : INode
    {
        public Drive(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; }

        public override string ToString() => $"{Name}:";

        #region Factory methods
        public static Drive C { get => new Drive("C"); }

        public static Drive D { get => new Drive("D"); }
        #endregion
    }
}
