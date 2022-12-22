using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GYMAPI.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }                 
        public double Amount { get; set; }
        public DateTime RenewalDate { get; set; } = DateTime.Now;

        public int MemberId { get; set; }
        public Member Member { get; set; }
    } 
}
