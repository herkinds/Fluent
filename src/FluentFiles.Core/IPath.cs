using Herkinds.FluentFiles.Core.Nodes;
using System.Collections.Generic;

namespace Herkinds.FluentFiles.Core
{
    public interface IPath : IReadOnlyList<INode>
    {
        bool Exists();

        void Create();
    }
}
