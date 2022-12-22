using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static GYMAPI.Models.Member;

namespace GYMAPI.Models.Dtos
{
    public class MemberDto
    {

       public int MemberId { get; set; }
     //   [Required]
        public string Name { get; set; }
      //  [Required]
        public string Surname { get; set; }
      //  [Required]
        public string Email { get; set; }

      //  public enum SubscriptionPlan { Monthly, Yearly, Others }
        public SubscriptionPlan Subscription { get; set; }       

       // public DateTime DateCreated { get; set; }
    }
}
