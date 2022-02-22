namespace Herkinds.FluentFiles
{
    using System.Collections.Generic;
    using Herkinds.FluentFiles.Nodes;

    /// <summary>
    /// A generic file path interface.
    /// </summary>
    public interface IPath : IReadOnlyList<INode>
    {
        /// <summary>
        /// Verifies if a path exists.
        /// </summary>
        /// <returns>True if the path exists.</returns>
        bool Exists();

        /// <summary>
        /// Creates the path in the file system.
        /// </summary>
        void Create();
    }
}
