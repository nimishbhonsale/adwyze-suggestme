
namespace Adwyze.LastFm.Client.Shared.Rest
{
    /// <summary>
    /// Rest wrapper extensions
    /// </summary>
    public static class RestWrapperExtension
    {
        /// <summary>
        /// Methods the specified wrapper.
        /// </summary>
        /// <param name="wrapper">The wrapper.</param>
        /// <param name="method">The method.</param>
        /// <returns>Fluent wrapper</returns>
        public static FluentRestWrapper Method(this RestWrapper wrapper, string method)
        {
            return new FluentRestWrapper(wrapper, method);
        }
    }
}
