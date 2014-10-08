using System;

namespace Adwyze.SuggestMe.Entities.History
{
    /// <summary>
    /// history Dto
    /// </summary>
    public class History
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Keyword
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// Search Date (UTC)
        /// </summary>
        public DateTime SearchDate { get; set; }
        
    }
}