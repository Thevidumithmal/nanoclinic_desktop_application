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
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using System.Data;

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_AdminProfile.xaml
    /// </summary>
    public partial class form_AdminProfile : Window
    {
        Controller cc = new Controller();
        string login;
        DataBaseConnection data = new DataBaseConnection();
        Validation obj = new Validation();

        public form_AdminProfile(string login)
        {
            InitializeComponent();
            this.login = login;
            
        }

        private void AddAdminProfileDetails()
        {
            try
            {

                DataTable dt = data.display("Select Title, Fname,aid from login, Admin where login.username = '" + login + "' ");
                string Adminid = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());
                profile_name_admin.Text = txt_username.Text;

                DataTable dt1 = data.display("Select DOB, Age, Address, Email, NIC, Lname, Gender, Telephone, Reg_date,landphone from Admin where AID = '" + Adminid + "' ");

                txt_admin_title.Text = dt.Rows[0][0].ToString();
                txt_admin_firstname.Text = dt.Rows[0][1].ToString();
                txt_admin_dob.Text = dt1.Rows[0][0].ToString();
                txt_admin_age.Text = dt1.Rows[0][1].ToString();
                txt_admin_address.Text = dt1.Rows[0][2].ToString();
                txt_admin_email_address.Text = dt1.Rows[0][3].ToString();
                txt_admin_nic.Text = dt1.Rows[0][4].ToString();
                txt_admin_lastname.Text = dt1.Rows[0][5].ToString();
                txt_admin_gender.Text = dt1.Rows[0][6].ToString();
                txt_admin_registereddate.Text = dt1.Rows[0][8].ToString();
                txt_admin_mobile.Text = dt1.Rows[0][7].ToString();
                txt_admin_land.Text = dt1.Rows[0][9].ToString();


                dt.Dispose();
                dt1.Dispose();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Data cannot be accessed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void btn_admin_general_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_AdminDashBoard obj_admindashboard = new form_AdminDashBoard(cc.PassLogin());
            obj_admindashboard.Show();
            this.Hide();
        }

        private void btn_admin_doctors_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_AdminDoctors obj_admindoctors = new form_AdminDoctors(cc.PassLogin());
            obj_admindoctors.Show();
            this.Hide();
        }

        private void btn_admin_medicaladmins_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_AdminMedicalAdmin obj_adminmedicaladmin = new form_AdminMedicalAdmin(cc.PassLogin());
            obj_adminmedicaladmin.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddAdminProfileDetails();
        }

        private void btn_delete_profile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Do you want to Delete  the Profile?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DataTable dt = data.display("Select AID from Login,Admin where Login.username=Admin.UID and UID='" + login + "'");
                    string adminid = dt.Rows[0][0].ToString();


                    string t = "Delete from Doctor where did='" + adminid + "'";
                    string r = "Delete from login where username='" + login + "'";


                    int f = data.Insert_Update_Delete(t);
                    int g = data.Insert_Update_Delete(r);


                    MessageBox.Show("You successfully deleted the profile.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    Application.Current.Shutdown();


                }
                else
                {

                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Data cannot be accessed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to logout from the application?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                cc.CancellOGIN();
                form_Login obj = new form_Login();
                obj.Show();
                this.Hide();
            }
            else
            {

            }
        }

        private void btn_back_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_AdminDashBoard obj = new form_AdminDashBoard(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_AdminDoctors obj = new form_AdminDoctors(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
