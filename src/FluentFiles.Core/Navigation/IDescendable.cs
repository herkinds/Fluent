using Herkinds.FluentFiles.Core.Nodes;

namespace Herkinds.FluentFiles.Core.Navigation
{
    public interface IDescendable<TPath, TChild> where TPath : IPath where TChild : INode
    {
        TPath Descend(TChild child);
    }
}
