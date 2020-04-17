namespace Herkinds.FluentFiles.Navigation
{
    public interface IAscendable<TPath> where TPath : IPath
    {
        TPath Ascend();
    }
}
