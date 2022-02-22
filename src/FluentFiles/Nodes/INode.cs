namespace Herkinds.FluentFiles.Nodes
{
    /// <summary>
    /// An abstract node of a <see cref="IPath"/>.
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Gets the name of the node.
        /// </summary>
        string Name { get; }
    }
}
