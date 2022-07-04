using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLI.API.Domain
{
    [Table("Report")]
    public class Reports
    {
        [Key]
        public int Id { get; set; }
        public string? NameExport { get; set; }
        public DateTime GetDateTimeExport { get; set; }
        public string? UserNameExport { get; set; }
        public string? LocalName { get; set; }
    }
}
