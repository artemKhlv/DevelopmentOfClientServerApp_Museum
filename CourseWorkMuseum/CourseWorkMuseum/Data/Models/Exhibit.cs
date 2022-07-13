using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkMuseum.Data.Models;

public class Exhibit
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    public int ExhibitId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
  


}

