namespace Herkinds.FluentFiles.Navigation
{
    using Herkinds.FluentFiles.Nodes;

    /// <summary>
    /// Defines the possibility to descend from a <see cref="IPath"/>.
    /// </summary>
    /// <typeparam name="TPath">The path type which can be descended from.</typeparam>
    /// <typeparam name="TChild">The child node type which can be descended to.</typeparam>
    public interface IDescendable<TPath, TChild>
        where TPath : IPath
        where TChild : INode
    {
        /// <summary>
        /// Descends to a <see cref="INode"/> from the current <see cref="IPath"/>.
        /// </summary>
        /// <param name="child">The node to which to descend.</param>
        /// <returns>The <see cref="IPath"/> which is descended to.</returns>
        TPath Descend(TChild child);
    }
}
