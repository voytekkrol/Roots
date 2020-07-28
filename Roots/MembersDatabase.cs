using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roots
{
    public class MembersDatabase
    {
		private int id;
		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private string membersDatabaseName;

		public string MembersDatabaseName
		{
			get { return membersDatabaseName; }
			set { membersDatabaseName = value; }
		}

		public MembersDatabase()
		{

		}
		public MembersDatabase(string membersDatabaseName)
		{
			this.MembersDatabaseName = membersDatabaseName;
		}
	}
}
