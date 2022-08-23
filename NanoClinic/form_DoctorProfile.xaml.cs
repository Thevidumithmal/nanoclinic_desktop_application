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
using System.Data;

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_DoctorProfile.xaml
    /// </summary>
    public partial class form_DoctorProfile : Window
    {
        Controller cc = new Controller();
        string login;
        DataBaseConnection data = new DataBaseConnection();

        public form_DoctorProfile(string login)
        {
            InitializeComponent();
            this.login = login;
        }
        
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        
        private void AddDoctorProfileDetail()
        {
            try
            {
                DataTable dt = data.display("Select Dtitle,Fname,DID from Login,Doctor where Login.username=Doctor.UID and UID='" + login + "' ");
                string doctorid = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + " " + (dt.Rows[0][1].ToString());
                profile_name_doctor.Text = txt_username.Text;

                DataTable dt1 = data.display("Select DDOB, age, Daddress, Email, DNIC, Lname, Gender,spec, Dcivilstatus, Dtelephone,landphone,hq, Reg_date from Doctor where DID = '" + doctorid + "' ");

                txt_Doctor_title.Text = dt.Rows[0][0].ToString();
                txt_Doctor_firstname.Text = dt.Rows[0][1].ToString();
                txt_Doctor_dob.Text = dt1.Rows[0][0].ToString();
                txt_Doctor_age.Text = dt1.Rows[0][1].ToString();
                txt_Doctor_address.Text = dt1.Rows[0][2].ToString();
                txt_Doctor_email_address.Text = dt1.Rows[0][3].ToString();
                txt_Doctor_Registerdate.Text = dt1.Rows[0][12].ToString();
                txt_Doctor_spec.Text = dt1.Rows[0][7].ToString();
                txt_Doctor_nic.Text = dt1.Rows[0][4].ToString();
                txt_Doctor_lastname.Text = dt1.Rows[0][5].ToString();
                txt_Doctor_gender.Text = dt1.Rows[0][6].ToString();
                txt_Doctor_civilstatus.Text = dt1.Rows[0][8].ToString();
                txt_Doctor_mobile.Text = dt1.Rows[0][9].ToString();
                txt_Doctor_land.Text = dt1.Rows[0][10].ToString();
                txt_Doctor_hq.Text = dt1.Rows[0][11].ToString();

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
            
            form_DoctorDashBoard obj_doctordashboard = new form_DoctorDashBoard(cc.PassLogin());
            obj_doctordashboard.Show();
            this.Hide();
        }

        private void btn_appointment_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_DoctorAppointments obj_doctorappoinment = new form_DoctorAppointments(cc.PassLogin());
            obj_doctorappoinment.Show();
            this.Hide();
        }

        private void btn_reports_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_DoctorReports obj_doctorreports = new form_DoctorReports(cc.PassLogin());
            obj_doctorreports.Show();
            this.Hide();
        }

        private void btn_schedule_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_DoctorSchedule obj_doctorschedule = new form_DoctorSchedule(cc.PassLogin());
            obj_doctorschedule.Show();
            this.Hide();
        }

        private void btn_patients_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_DoctorPatients obj_doctorpatients = new form_DoctorPatients(cc.PassLogin());
            obj_doctorpatients.Show();
            this.Hide();
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

        private void btn_update_doctor_details_Click(object sender, RoutedEventArgs e)
        {
            form_doctorUpdateProfile obj = new form_doctorUpdateProfile(cc.PassLogin());
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
                    DataTable dt = data.display("Select DID from Login,doctor where Login.username=doctor.UID and UID='" + login + "'");
                    string doctorid = dt.Rows[0][0].ToString();

                    string u = "Delete from Doc_Schedule where dno = '" + doctorid + "'";
                    string t = "Delete from Doctor where did='" + doctorid + "'";
                    string r = "Delete from login where username='" + login + "'";

                    int p = data.Insert_Update_Delete(u);
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

        private void btn_back_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_DoctorDashBoard obj = new form_DoctorDashBoard(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_DoctorAppointments obj = new form_DoctorAppointments(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddDoctorProfileDetail();

        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
