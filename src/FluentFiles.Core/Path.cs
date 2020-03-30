using FluentFiles.Core.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FluentFiles.Core
{
    public sealed class Path : IReadOnlyList<INode>
    {
        public Path(Drive drive, params Folder[] folders)
        {
            Drive = drive ?? throw new ArgumentNullException(nameof(drive));
            Folders = folders;
        }

        public Drive Drive { get; }

        public IReadOnlyList<Folder> Folders { get; }

        #region IReadOnlyList
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
        #endregion

        public bool Exists()
            => System.IO.Directory.Exists(this);

        public static implicit operator string(Path path)
            => path?.ToString();

        public override string ToString()
            => string.Join(Separator, this.Select(node => node.Name));

        public static char Separator { get => System.IO.Path.PathSeparator; }
    }
}
