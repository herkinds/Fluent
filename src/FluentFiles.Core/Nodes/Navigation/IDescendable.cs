namespace FluentFiles.Core.Nodes
{
    public interface IDescendable<TPath, TChild> where TPath : IPath where TChild : INode
    {
        TPath Descend(TChild child);
    }
}
