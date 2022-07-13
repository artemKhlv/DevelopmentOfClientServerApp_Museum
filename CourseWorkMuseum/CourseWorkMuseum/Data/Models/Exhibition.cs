using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkMuseum.Data.Models;


public class Exhibition
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    public int ExhibitionId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Date { get; set; }
    public string Genre { get; set; }



}
