using Herkinds.FluentFiles.Nodes;
using System.Collections.Generic;

namespace Herkinds.FluentFiles
{
    public interface IPath : IReadOnlyList<INode>
    {
        bool Exists();

        void Create();
    }
}
