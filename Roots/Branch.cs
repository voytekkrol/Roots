using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roots
{
    public class Branch
    {
		
		private int id;
		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get { return id; }
			set { id = value; }
		}


		private string firstname;

		public string Firstname
		{
			get { return firstname; }
			set { firstname = value; }
		}

		private string lastname;

		public string Lastname
		{
			get { return lastname; }
			set { lastname = value; }
		}

		private string phoneNumber;

		public string PhoneNumber
		{
			get { return phoneNumber; }
			set { phoneNumber = value; }
		}

		private string personalAniversary;

		public string PersonalAnniversary
		{
			get { return personalAniversary; }
			set { personalAniversary = value; }
		}


		private string typeOfPersonalAnniversary;

		public string TypeOfPersonalAnniversary
		{
			get { return typeOfPersonalAnniversary; }
			set { typeOfPersonalAnniversary = value; }
		}


		public void SetPersonalAnniversary()
		{
			string nameOfMonth;

			switch (MonthOfPersonalAnniversary )
			{
				case 1:
					nameOfMonth = "Styczeń";
					break;
				case 2:
					nameOfMonth = "Luty";
					break;
				case 3:
					nameOfMonth = "Marzec";
					break;
				case 4:
					nameOfMonth = "Kwiecień";
					break;
				case 5:
					nameOfMonth = "Maj";
					break;
				case 6:
					nameOfMonth = "Czerwiec";
					break;
				case 7:
					nameOfMonth = "Lipiec";
					break;
				case 8:
					nameOfMonth = "Sierpień";
					break;
				case 9:
					nameOfMonth = "Wrzesień";
					break;
				case 10:
					nameOfMonth = "Październik";
					break;
				case 11:
					nameOfMonth = "Listopad";
					break;
				case 12:
					nameOfMonth = "Grudzień";
					break;

				default:
					nameOfMonth = "Nie wybrano miesiąca";
					break;

			}
			if (DayOfPersonalAnniversary < 10)
			{
				PersonalAnniversary = string.Format("0{0,1}  {1,3}", DayOfPersonalAnniversary, nameOfMonth);
			} 
			else
			{
				PersonalAnniversary = string.Format("{0,2}  {1,3}", DayOfPersonalAnniversary, nameOfMonth);
			}
		}

		private int dayOfPersonalAnniversary;

		public int DayOfPersonalAnniversary
		{
			get { return dayOfPersonalAnniversary; }
			set 
			{ 
				dayOfPersonalAnniversary = value;
				SetPersonalAnniversary();
			}
		}

		private int monthOfPersonalAnniversary;

		public int MonthOfPersonalAnniversary
		{
			get { return monthOfPersonalAnniversary; }
			set 
			{ 
				monthOfPersonalAnniversary = value;
				SetPersonalAnniversary();
			}
		}


	}
}
