using Herkinds.FluentFiles.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Herkinds.FluentFiles.Nodes
{
    /// <summary>
    /// Is the adapter class for <see cref="DriveInfo"/>, which provides access to information on a drive.
    /// </summary>
    public sealed class DriveNode : INode, IDescendable<DirectoryPath, DirectoryNode>
    {
        private readonly DriveInfo drive;

        /// <summary>
        /// Is the adapter for <see cref="DriveInfo"/>, which provides access to information on the specified drive.
        /// </summary>
        /// <param name="driveName">A valid drive path or drive letter. This can be either uppercase
        /// or lowercase, 'a' to 'z'. A null value is not valid.</param>
        /// <exception cref="ArgumentNullException">The drive letter cannot be null.</exception>
        /// <exception cref="ArgumentException"> The first letter of driveName is not an uppercase or 
        /// lowercase letter from 'a' to 'z'. -or- driveName does not refer to a valid drive.</exception>
        public DriveNode(string driveName) : this(new DriveInfo(driveName)) { }

        /// <summary>
        /// Is the adapter for <see cref="DriveInfo"/>, which provides access to information on the specified drive.
        /// </summary>
        /// <param name="drive">A <see cref="DriveInfo"/> drive. A null value is not valid.</param>
        /// <exception cref="ArgumentNullException">The drive cannot be null.</exception>
        public DriveNode(DriveInfo drive)
        {
            this.drive = drive ?? throw new ArgumentNullException(nameof(drive));
        }

        /// <summary>
        /// Gets the name of the drive, such as C:\.
        /// </summary>
        public string Name { get => drive.Name; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public DirectoryPath Descend(DirectoryNode directory)
            => new DirectoryPath(this, directory);

        /// <summary>
        /// Returns a drive name as a string.
        /// </summary>
        /// <returns>The name of the drive.</returns>
        public override string ToString() => Name;

        #region Factory methods
        /// <summary>
        /// Retrieves the drive names of all logical drives on a computer.
        /// </summary>
        /// <returns>An enumerable collection of type <see cref="DriveNode"/> that represents the logical drives on
        /// a computer.</returns>
        /// <exception cref="IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        public static IEnumerable<DriveNode> GetDrives()
            => DriveInfo.GetDrives().Select(drive => new DriveNode(drive));
        #endregion
    }
}
