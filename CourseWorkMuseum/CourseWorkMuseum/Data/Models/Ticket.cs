using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseWorkMuseum.Data.Models;


public class Ticket
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    
    public int TicketId { get; set; }
    public string NameOfExhibitions { get; set; }
    public string Date { get; set; }
    public string Price { get; set; }
    public string Benefits { get; set; }

    

}