using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Entitys;

[Table(name:"Users")]
public class TodoEntity
{
    [Key]
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; } = Guid.NewGuid();

    public string Title { get; set; }

    public string Description { get; set; }
    
}