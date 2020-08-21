using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roots.DataAccesLayer
{
    public static class DataAccess
    {
        public static string GetFilePath()
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<MembersDatabase>();

                List<MembersDatabase> membersDatabases = connection.Table<MembersDatabase>().ToList();

                return membersDatabases.Last<MembersDatabase>().MembersDatabaseName;
            }
        }

        public static List<Branch> ReadDatabase(string filePath)
        {
            List<Branch> familyMemberList;
            if (filePath != null)
            {
                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(filePath))
                {
                    connection.CreateTable<Branch>();

                    familyMemberList = (connection.Table<Branch>().ToList()).OrderBy(familyMember => familyMember.MonthOfPersonalAnniversary)
                                                                            .ThenBy(familyMember => familyMember.DayOfPersonalAnniversary).ToList();
                    foreach (var member in familyMemberList)
                    {
                        member.SetPersonalAnniversary();
                    }

                }
            } else
            {
                familyMemberList = new List<Branch>();
            }

            using (SQLite.SQLiteConnection connectionToMembersList = new SQLite.SQLiteConnection(App.databasePath))
            {
                connectionToMembersList.CreateTable<MembersDatabase>();

                connectionToMembersList.Insert(new MembersDatabase(filePath));
            }

            return familyMemberList;
        }

        public static void DeleteFromDatabase( Branch selectedMember, bool confirmationResult, string filePath)
        {
            if (confirmationResult == true && filePath != null)
            {
                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(filePath))
                {
                    connection.CreateTable<Branch>();
                    connection.Delete(selectedMember);
                }
            }
        }
    }
}
