using System.ComponentModel.DataAnnotations.Schema;

namespace finshark.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int? StockId { get; set; }

        // Navigation Property
        #nullable enable
        public Stock? Stock { get; set; }

    }
}