using Herkinds.FluentFiles.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Herkinds.FluentFiles
{
    public sealed class FilePath : IPath
    {
        public FilePath(DirectoryPath location, FileNode file)
        {
            Location = location ?? throw new ArgumentNullException(nameof(location));
            File = file ?? throw new ArgumentNullException(nameof(file));
        }

        public DirectoryPath Location { get; }

        public FileNode File { get; set; }

        #region IPath
        public INode this[int index]
        {
            get
            {
                if (index == Location.Count)
                    return File;
                else
                    return Location[index - 1];
            }
        }

        public int Count => Location.Count + 1;

        public IEnumerator<INode> GetEnumerator()
        {
            yield return Location.Drive;
            foreach (var folder in Location.Directories)
                yield return folder;
            yield return File;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public bool Exists()
            => System.IO.File.Exists(this);

        public void Create()
            => System.IO.File.Create(this);
        #endregion

        #region Cast & ToString
        public static implicit operator string(FilePath path)
            => path?.ToString();

        public static implicit operator FileInfo(FilePath path)
            => new FileInfo(path);

        public override string ToString()
            => Path.Combine(this.Select(node => node.Name).ToArray());
        #endregion
    }
}
