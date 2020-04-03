using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentFiles.Core.Nodes
{
    public sealed class DriveNode : INode, IDescendable<DirectoryPath, DirectoryNode>
    {
        private readonly System.IO.DriveInfo drive;

        public DriveNode(System.IO.DriveInfo drive)
        {
            this.drive = drive ?? throw new ArgumentNullException(nameof(drive));
        }

        public string Name { get => drive.Name; }

        public System.IO.DriveType DriveType { get => drive.DriveType; }

        // TODO Extend for more properties of DriveInfo

        public DirectoryPath Descend(DirectoryNode child)
            => new DirectoryPath(this, child);

        public override string ToString() => Name;

        #region Factory methods
        public static IEnumerable<DriveNode> GetDrives()
            => System.IO.DriveInfo.GetDrives()
            .Select(drive => new DriveNode(drive));
        #endregion
    }
}
