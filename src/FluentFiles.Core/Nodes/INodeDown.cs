using System.Collections.Generic;

namespace FluentFiles.Core.Nodes
{
    public interface INodeDown
    {
        IEnumerable<INode> Down();
    }
}
