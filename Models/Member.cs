using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GYMAPI.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }           
      
        public enum SubscriptionPlan { Monthly, Yearly, Others }      
        
        public SubscriptionPlan Subscription { get; set; }

       // [Required]
       // public int PaymentId { get; set; }

      //  [ForeignKey("PaymentId")]
     //   public Payment Payment { get; set; }

        public DateTime DateCreated { get; set; }  = DateTime.Now;

        public ICollection<Payment> Payments { get; set; }

    }
}
