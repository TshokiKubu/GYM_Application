using GYMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMAPI.Repository
{
    public interface IMemberRepository
    {
        ICollection<Member> GetMembers();
        Member GetMember(int memberId);
        bool MemberExists(string name);
        bool MemberExists(int id);
        bool CreateMember(Member member);
        bool UpdateMember(Member member);
        bool DeleteMember(Member member);
        bool Save();
    }
}
