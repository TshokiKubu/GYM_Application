using GYMAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GYMAPI.Repository
{
    public interface IPaymentRepository
    {
        ICollection<Payment> GetPayments();
        bool CreatePayment(Payment payment);
        bool Save();
    }
}
