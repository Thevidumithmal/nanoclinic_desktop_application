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
    /// Interaction logic for form_MedicalAdminProfile.xaml
    /// </summary>
    public partial class form_MedicalAdminProfile : Window
    {
        Controller cc = new Controller();
        string login;
        DataBaseConnection data = new DataBaseConnection();

        public form_MedicalAdminProfile(string login)
        {
            InitializeComponent();
            this.login = login;
            
        }

        

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void AddMedicalStaffProfileDetails()
        {
            try
            {
                DataTable dt = data.display("Select tittle,Fname,sid from Login,Medical_staff where Login.username=Medical_staff.UID and UID='" + login + "'");
                string madminid = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());
                profile_name_staff.Text = txt_username.Text;

                DataTable dt1 = data.display("Select DOB, Age, Address, EMail, Reg_date, NIC, Lname, Gender, Cstatus, Telephone, Landphone, HQ  from Medical_staff where SID = '" + madminid + "' ");

                txt_staff_title.Text = dt.Rows[0][0].ToString();
                txt_staff_firstname.Text = dt.Rows[0][1].ToString();
                txt_staff_dob.Text = dt1.Rows[0][0].ToString();
                txt_staff_age.Text = dt1.Rows[0][1].ToString();
                txt_staff_address.Text = dt1.Rows[0][2].ToString();
                txt_staff_email_address.Text = dt1.Rows[0][3].ToString();
                txt_staff_Registerdate.Text = dt1.Rows[0][4].ToString();
                txt_staff_nic.Text = dt1.Rows[0][5].ToString();
                txt_staff_lastname.Text = dt1.Rows[0][6].ToString();
                txt_staff_gender.Text = dt1.Rows[0][7].ToString();
                txt_staff_civilstatus.Text = dt1.Rows[0][8].ToString();
                txt_staff_mobile.Text = dt1.Rows[0][9].ToString();
                txt_staff_land.Text = dt1.Rows[0][10].ToString();
                txt_staff_hq.Text = dt1.Rows[0][11].ToString();

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

        private void btn_general_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminDashBoard obj_medicaladmindashboard = new form_MedicalAdminDashBoard(cc.PassLogin());
            obj_medicaladmindashboard.Show();
            this.Hide();
        }

        private void btn_doctors_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminDoctors obj_medicaladmindoctors = new form_MedicalAdminDoctors(cc.PassLogin());
            obj_medicaladmindoctors.Show();
            this.Hide();
        }

        private void btn_patients_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminPatient obj_medicaladminpatient = new form_MedicalAdminPatient(cc.PassLogin());
            obj_medicaladminpatient.Show();
            this.Hide();
        }

        private void btn_appointments_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminAppointments obj_medicaladminappointments = new form_MedicalAdminAppointments(cc.PassLogin());
            obj_medicaladminappointments.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddMedicalStaffProfileDetails();
        }

        private void btn_update_staff_details_Click(object sender, RoutedEventArgs e)
        {
            form_MedicalStaffUpdateProfile obj = new form_MedicalStaffUpdateProfile(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_delete_profile_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                MessageBoxResult result = MessageBox.Show("Do you want to Delete  the Profile?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DataTable dt = data.display("Select SID from Login,Medical_staff where Login.username=Medical_staff.UID and UID='" + login + "'");
                    string staffid = dt.Rows[0][0].ToString();


                    string t = "Delete from Medical_staff where sid='" + staffid + "'";
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
            form_MedicalAdminDashBoard obj = new form_MedicalAdminDashBoard(cc.PassLogin()) ;
            obj.Show();
            this.Hide();
        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_MedicalAdminDoctors obj = new form_MedicalAdminDoctors(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
