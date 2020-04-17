using FluentAssertions;
using Herkinds.FluentFiles.Nodes;
using Xunit;

namespace Herkinds.FluentFiles.Test
{
    public class DriveNodeTests
    {
        [Fact]
        public void GetDrives()
        {
            var drives = DriveNode.GetDrives();

            drives.Should().NotBeEmpty();
        }
    }
}
