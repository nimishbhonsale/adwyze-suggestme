namespace Adwyze.SuggestMe.Helpers.ConnectionManager
{
    /// <summary>
    /// Db provider. Currently support for Mongo and Sql Server
    /// </summary>
    public enum DbProvider
    {
        /// <summary>
        /// No Sql support using Mongo Db
        /// </summary>
        Mongo = 0,

        /// <summary>
        /// Sql support using Sql Server Db
        /// </summary>
        SqlServer = 1
    }
}