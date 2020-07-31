using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roots
{
    public static class AnniverseryMessageManager
    {

        private static string names;
        public static string Names
        {
            get { return names; }
            set { names = value; }
        }

        private static int actualMonth;
        public static int ActualMonth
        {
            get { return actualMonth; }
            set { actualMonth = value; }
        }

        private static List<Branch> thisMonthMembersAnniversarys;
        public static List<Branch> ThisMonthMembersAnniversary
        {
            get { return thisMonthMembersAnniversarys; }
            set { thisMonthMembersAnniversarys = value; }
        }

        public static string ShowAnniversary(List<Branch> familyMemberList)
        {
            ActualMonth = DateTime.Now.Month;
            ThisMonthMembersAnniversary = familyMemberList.Where(familyMember => (familyMember.MonthOfPersonalAnniversary == ActualMonth)).ToList();
            Names = "W tym miesiący urodziny lub imieniny mają: ";
            foreach (var selectedMember in ThisMonthMembersAnniversary)
            {
                Names = Names + "\n" + " " + selectedMember.Firstname + " " + selectedMember.Lastname + " " + " " + selectedMember.TypeOfPersonalAnniversary + " " + selectedMember.PersonalAnniversary;
            }
            return Names;
        }
    }
}
