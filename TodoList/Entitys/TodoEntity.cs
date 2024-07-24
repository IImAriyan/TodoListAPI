using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Entitys;

[Table(name:"Users")]
public class TodoEntity
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; } = new Guid();

    public string Title { get; set; }

    public string Description { get; set; }
    
}