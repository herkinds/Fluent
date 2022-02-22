namespace Herkinds.FluentFiles.Test
{
    using System.Linq;
    using FluentAssertions;
    using Herkinds.FluentFiles.Nodes;
    using Xunit;

    /// <summary>
    /// Unit tests for <see cref="DriveNode"/>.
    /// </summary>
    public class DriveNodeTests
    {
        /// <summary>
        /// Checks if any drives can be retreived.
        /// </summary>
        [Fact]
        public void GetDrives()
        {
            var drives = DriveNode.GetDrives();

            drives.Should().NotBeEmpty();
            drives.First().Name.Should().NotBeNullOrEmpty();
        }
    }
}
