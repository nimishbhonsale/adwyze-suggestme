using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adwyze.SuggestMe.Repository.SqlServer.Mapping
{

    [Table("SearchHistory")]
    public partial class SearchHistory
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Keyword { get; set; }

        public int? UserId { get; set; }

        public DateTime? UpdateDate { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
