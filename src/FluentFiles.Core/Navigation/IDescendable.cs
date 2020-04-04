using FluentFiles.Core.Nodes;

namespace FluentFiles.Core.Navigation
{
    public interface IDescendable<TPath, TChild> where TPath : IPath where TChild : INode
    {
        TPath Descend(TChild child);
    }
}
