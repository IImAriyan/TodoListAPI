using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Entitys;

[Table(name:"Users")]
public class TodoEntity
{
    [Key]
    [Required]
    public Guid ID { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
    
}