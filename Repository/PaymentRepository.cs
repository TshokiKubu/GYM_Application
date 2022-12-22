using GYMAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMAPI.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _db;

        public PaymentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreatePayment(Payment payment)
        {
            _db.Payments.Add(payment);
            return Save();
        }

        public ICollection<Payment> GetPayments()
        {
            return _db.Payments.Include(c => c.PaymentId).OrderBy(a => a.Amount).ToList();
        }


        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
