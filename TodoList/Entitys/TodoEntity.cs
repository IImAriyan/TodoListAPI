using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace TodoList.Entitys;

[Table(name:"Users")]
public class TodoEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [SwaggerIgnore]
    public Guid ID { get; set; } = Guid.NewGuid();
    
    public string Title { get; set; }

    public string Description { get; set; }
    
}