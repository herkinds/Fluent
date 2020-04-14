namespace Herkinds.FluentFiles.Core.Navigation
{
    public interface IAscendable<TPath> where TPath : IPath
    {
        TPath Ascend();
    }
}
