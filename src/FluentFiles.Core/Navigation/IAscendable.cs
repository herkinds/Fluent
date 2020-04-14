namespace Herkinds.FluentFiles.Core.Nodes.Navigation
{
    public interface IAscendable<TPath> where TPath : IPath
    {
        TPath Ascend();
    }
}
