using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    public class Folder
    {
        public Folder() { }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        [ForeignKey("folders")]
        public int? FolderId {  get; set; }

        public List<Folder>? Folders { get; set; }
    }
}
