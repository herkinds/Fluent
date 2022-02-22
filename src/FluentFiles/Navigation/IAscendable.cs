namespace Herkinds.FluentFiles.Navigation
{
    /// <summary>
    /// Defines the possibility to ascend to a higher <see cref="IPath"/>.
    /// </summary>
    /// <typeparam name="TPath">The path type which can be ascended to.</typeparam>
    public interface IAscendable<TPath>
        where TPath : IPath
    {
        /// <summary>
        /// Ascend to the higher <see cref="IPath"/>.
        /// </summary>
        /// <returns>The <see cref="IPath"/> which is ascended to.</returns>
        TPath Ascend();
    }
}
