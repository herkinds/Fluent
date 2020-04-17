using FluentAssertions;
using Herkinds.FluentFiles.Nodes;
using Xunit;

namespace Herkinds.FluentFiles.Test
{
    public class DriveNodeTests
    {
        [Fact]
        public void DriveName()
        {
            var drive = new DriveNode("C");

            drive.Name.Should().Contain("C:");
        }
    }
}
