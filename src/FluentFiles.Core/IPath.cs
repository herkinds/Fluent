using FluentFiles.Core.Nodes;
using System.Collections.Generic;

namespace FluentFiles.Core
{
    public interface IPath : IReadOnlyList<INode>
    {
        bool Exists();

        void Create();
    }
}
