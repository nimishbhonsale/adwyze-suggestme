namespace Adwyze.SuggestMe.Repository.Contracts.Connection
{
    /// <summary>
    /// Connection Manager abstraction
    /// </summary>
    public interface IConnectionManager
    {
        /// <summary>
        /// Gets the connection string for database
        /// </summary>
        /// <returns>Connection string</returns>
        string GetConnectionString();
    }
}
