using FluentFiles.Core.Nodes;
using FluentFiles.Core.Nodes.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FluentFiles.Core
{
    public sealed class Path : IPath, IAscendable<Path>, IDescendable<Path, FolderNode>
    {
        public Path(DriveNode drive, params FolderNode[] folders)
        {
            Drive = drive ?? throw new ArgumentNullException(nameof(drive));
            Folders = folders;
        }

        public DriveNode Drive { get; }

        public IReadOnlyList<FolderNode> Folders { get; }

        #region IAscendable & IDescendable
        public Path Ascend()
            => new Path(Drive, Folders.Take(Folders.Count - 1).ToArray());

        public Path Descend(FolderNode child)
            => new Path(Drive, Folders.Append(child).ToArray());
        #endregion

        #region IPath
        public INode this[int index]
        {
            get
            {
                if (index == 0)
                    return Drive;
                else
                    return Folders[index - 1];
            }
        }

        public int Count => Folders.Count + 1;

        public IEnumerator<INode> GetEnumerator()
        {
            yield return Drive;
            foreach (var folder in Folders)
                yield return folder;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public bool Exists()
            => System.IO.Directory.Exists(this);

        public void Create()
            => System.IO.Directory.CreateDirectory(this);
        #endregion

        public static implicit operator string(Path path)
            => path?.ToString();

        public override string ToString()
            => string.Join(Separator, this.Select(node => node.Name));

        public static char Separator { get => System.IO.Path.PathSeparator; }
    }
}
