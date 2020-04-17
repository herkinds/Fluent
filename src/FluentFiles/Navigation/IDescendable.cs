using Herkinds.FluentFiles.Nodes;

namespace Herkinds.FluentFiles.Navigation
{
    public interface IDescendable<TPath, TChild> where TPath : IPath where TChild : INode
    {
        TPath Descend(TChild child);
    }
}
