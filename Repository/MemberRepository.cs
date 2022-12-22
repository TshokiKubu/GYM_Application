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
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _db;
      
        public MemberRepository(ApplicationDbContext db)
        {
            _db = db;         
        }

        public bool CreateMember(Member member)
        {
            _db.Members.Add(member);
            return Save();
        }

        public bool DeleteMember(Member member)
        {
            _db.Members.Remove(member);
            return Save();
        }

        public Member GetMember(int memberId)
        {
            return _db.Members.FirstOrDefault(a => a.MemberId == memberId);
        }

        public ICollection<Member> GetMembers()
        {
            return _db.Members.OrderBy(a => a.Name).ToList();
        }

        public bool MemberExists(string name)
        {
            bool value = _db.Members.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool MemberExists(int id)
        {
            return _db.Members.Any(a => a.MemberId == id);
        }

        public bool Save()  
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateMember(Member member)
        {
            _db.Members.Update(member);
            return Save();
        }
    }
}
