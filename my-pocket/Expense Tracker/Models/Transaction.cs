using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MY_POCKET.Models;

public class Transaction
{
    [Key]
    public int TransactionId { set; get; }

    public int CategoryId {set; get; }
    public Category? Category { set; get; }
    
   
    public int Amount { set; get; }
    
    [Column(TypeName = "varchar(75)")]
    public string? Note { set; get; }
    [Column(TypeName = "datetime2")]
    public DateTime Date { set; get; } 
}