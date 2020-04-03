using FluentFiles.Core.Nodes;
using FluentFiles.Core.Nodes.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FluentFiles.Core
{
    public sealed class DirectoryPath : IPath, IAscendable<DirectoryPath>, IDescendable<DirectoryPath, DirectoryNode>
    {
        public DirectoryPath(DriveNode drive, params DirectoryNode[] directories)
        {
            Drive = drive ?? throw new ArgumentNullException(nameof(drive));
            Directories = directories;
        }

        public DriveNode Drive { get; }

        public IReadOnlyList<DirectoryNode> Directories { get; }

        #region IAscendable & IDescendable
        public DirectoryPath Ascend()
            => new DirectoryPath(Drive, Directories.Take(Directories.Count - 1).ToArray());

        public DirectoryPath Descend(DirectoryNode child)
            => new DirectoryPath(Drive, Directories.Append(child).ToArray());
        #endregion

        #region IPath
        public INode this[int index]
        {
            get
            {
                if (index == 0)
                    return Drive;
                else
                    return Directories[index - 1];
            }
        }

        public int Count => Directories.Count + 1;

        public IEnumerator<INode> GetEnumerator()
        {
            yield return Drive;
            foreach (var folder in Directories)
                yield return folder;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public bool Exists()
            => System.IO.Directory.Exists(this);

        public void Create()
            => System.IO.Directory.CreateDirectory(this);
        #endregion

        public static implicit operator string(DirectoryPath path)
            => path?.ToString();

        public static implicit operator DirectoryInfo(DirectoryPath path)
            => new DirectoryInfo(path);

        public override string ToString()
            => Path.Combine(this.Select(node => node.Name).ToArray());
    }
}
