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
    /// A file path.
    /// </summary>
    public sealed class FilePath : IPath, IAscendable<DirectoryPath>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilePath"/> class.
        /// </summary>
        /// <param name="location">A directory path.</param>
        /// <param name="file">A file node.</param>
        public FilePath(DirectoryPath location, FileNode file)
        {
            this.Location = location ?? throw new ArgumentNullException(nameof(location));
            this.File = file ?? throw new ArgumentNullException(nameof(file));
        }

        /// <summary>
        /// Gets the location of the file.
        /// </summary>
        public DirectoryPath Location { get; }

        /// <summary>
        /// Gets the file.
        /// </summary>
        public FileNode File { get; }

        /// <summary>
        /// Gets the number of nodes of the path.
        /// </summary>
        public int Count => this.Location.Count + 1;

        /// <summary>
        /// Gets the node at the specified index of the path.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>A node.</returns>
        public INode this[int index]
        {
            get
            {
                if (index == this.Location.Count)
                {
                    return this.File;
                }
                else
                {
                    return this.Location[index - 1];
                }
            }
        }

        /// <summary>
        /// Implicit cast to <see cref="FileInfo"/>.
        /// </summary>
        /// <param name="path">The file path.</param>
        public static implicit operator FileInfo(FilePath path)
            => new FileInfo(path);

        /// <summary>
        /// Implicit cast to <see cref="string"/>.
        /// </summary>
        /// <param name="path">The file path.</param>
        public static implicit operator string(FilePath path)
           => path?.ToString();

        /// <inheritdoc/>
        public DirectoryPath Ascend()
            => this.Location;

        /// <inheritdoc/>
        public IEnumerator<INode> GetEnumerator()
        {
            yield return this.Location.Drive;

            foreach (var folder in this.Location.Directories)
            {
                yield return folder;
            }

            yield return this.File;
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        /// <summary>
        /// Determines whether this file path exists.
        /// </summary>
        /// <returns>true if the caller has the required permissions and path contains the name of
        /// an existing file; otherwise, false. This method also returns false if path is
        /// null, an invalid path, or a zero-length string. If the caller does not have sufficient
        /// permissions to read the specified file, no exception is thrown and the method
        /// returns false regardless of the existence of path.</returns>
        public bool Exists()
            => System.IO.File.Exists(this);

        /// <summary>
        /// Creates or overwrites the file path.
        /// </summary>
        public void Create()
            => System.IO.File.Create(this);

        /// <inheritdoc/>
        public override string ToString()
            => Path.Combine(this.Select(node => node.Name).ToArray());
    }
}
