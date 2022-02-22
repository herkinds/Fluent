namespace Herkinds.FluentFiles
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Herkinds.FluentFiles.Navigation;
    using Herkinds.FluentFiles.Nodes;

    /// <summary>
    /// A directory or folder path.
    /// </summary>
    public sealed class DirectoryPath : IPath,
        IAscendable<DirectoryPath>,
        IDescendable<DirectoryPath, DirectoryNode>,
        IDescendable<FilePath, FileNode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryPath"/> class.
        /// </summary>
        /// <param name="drive">The <see cref="Drive"/> from which the path starts.</param>
        /// <param name="directories">An ordered array of <see cref="DirectoryNode"/> making up the path to the directory.</param>
        public DirectoryPath(DriveNode drive, params DirectoryNode[] directories)
        {
            this.Drive = drive ?? throw new ArgumentNullException(nameof(drive));
            this.Directories = directories;
        }

        /// <summary>
        /// Gets the drive for this directory path.
        /// </summary>
        public DriveNode Drive { get; }

        /// <summary>
        /// Gets the directories.
        /// </summary>
        public IReadOnlyList<DirectoryNode> Directories { get; }

        /// <summary>
        /// Gets the number of nodes of the path.
        /// </summary>
        public int Count => this.Directories.Count + 1;

        /// <summary>
        /// Gets the node at the specified index of the path.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>A node.</returns>
        public INode this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return this.Drive;
                }
                else
                {
                    return this.Directories[index - 1];
                }
            }
        }

        /// <summary>
        /// Implicit cast to <see cref="string"/>.
        /// </summary>
        /// <param name="path">The directory path.</param>
        public static implicit operator string(DirectoryPath path)
            => path?.ToString();

        /// <summary>
        /// Implicit cast to <see cref="DirectoryInfo"/>.
        /// </summary>
        /// <param name="path">The directory path.</param>
        public static implicit operator DirectoryInfo(DirectoryPath path)
            => new DirectoryInfo(path);

        /// <inheritdoc/>
        public DirectoryPath Ascend()
            => new DirectoryPath(this.Drive, this.Directories.Take(this.Directories.Count - 1).ToArray());

        /// <inheritdoc/>
        public DirectoryPath Descend(DirectoryNode child)
            => new DirectoryPath(this.Drive, this.Directories.Append(child).ToArray());

        /// <inheritdoc/>
        public FilePath Descend(FileNode child)
            => new FilePath(this, child);

        /// <inheritdoc/>
        public IEnumerator<INode> GetEnumerator()
        {
            yield return this.Drive;
            foreach (var folder in this.Directories)
            {
                yield return folder;
            }
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        /// <summary>
        /// Determines whether this directory path exists.
        /// </summary>
        /// <returns>true if the caller has the required permissions and path contains the name of
        /// an existing file; otherwise, false. This method also returns false if path is
        /// null, an invalid path, or a zero-length string. If the caller does not have sufficient
        /// permissions to read the specified file, no exception is thrown and the method
        /// returns false regardless of the existence of path.</returns>
        public bool Exists()
            => Directory.Exists(this);

        /// <summary>
        /// Creates or overwrites the directory path.
        /// </summary>
        public void Create()
            => Directory.CreateDirectory(this);

        /// <inheritdoc/>
        public override string ToString()
            => Path.Combine(this.Select(node => node.Name).ToArray());
    }
}
