using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Roots.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy MemberControl.xaml
    /// </summary>
    public partial class MemberControl : UserControl
    {


        public Branch Member
        {
            get { return (Branch)GetValue(MemberProperty); }
            set { SetValue(MemberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Member.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MemberProperty =
            DependencyProperty.Register("Member", typeof(Branch), typeof(MemberControl), new PropertyMetadata(
                new Branch { Firstname = "Imie", 
                             Lastname = "Nazwisko",   
                             TypeOfPersonalAnniversary = "Urodziny",
                             DayOfPersonalAnniversary = 1,
                             MonthOfPersonalAnniversary = 1,
                             PhoneNumber = "000 000 000"}, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MemberControl control = d as MemberControl;

            if (control != null)
            {
                control.nameAndSurname.Text = (e.NewValue as Branch).Firstname + " " + (e.NewValue as Branch).Lastname;
                control.phoneNumber.Text = (e.NewValue as Branch).PhoneNumber;
                control.typeOfPersonalAnniversary.Text = (e.NewValue as Branch).TypeOfPersonalAnniversary;
                control.dateOfPersonalAnniversary.Text = (e.NewValue as Branch).PersonalAnniversary;
            }

        }


        public MemberControl()
        {
            InitializeComponent();
        }
    }
}
