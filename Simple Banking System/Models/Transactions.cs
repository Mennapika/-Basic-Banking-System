using System.ComponentModel.DataAnnotations;

namespace Simple_Banking_System.Models
{
    public class Transactions
    {   [Key]
        public int TransferId { get; set; }
        [Display(Name = "Sender ID")]
        public string Sender { get; set; }
        [Required]
        [Display(Name = "Recevier ID")]
        public string Recevier { get; set; }
        [Required] 
        [Display(Name ="Transfer Amount")]
        public float TransferAmount { get; set; }

        [Display(Name = "Operation State ")]
        public string OperationState { get; set; }
        public DateTime Date { get; set; }


    }
}
