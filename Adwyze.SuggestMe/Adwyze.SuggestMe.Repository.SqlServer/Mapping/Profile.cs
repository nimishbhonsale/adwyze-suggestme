using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adwyze.SuggestMe.Repository.SqlServer.Mapping
{
    [Table("Profile")]
    public partial class Profile
    {
        public Profile()
        {
            SearchHistories = new HashSet<SearchHistory>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string UserId { get; set; }

        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<SearchHistory> SearchHistories { get; set; }
    }
}
