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
    /// Interaction logic for form_PatientProfile.xaml
    /// </summary>
    public partial class form_PatientProfile : Window
    {
        Controller cc = new Controller();
        string login;
        DataBaseConnection data = new DataBaseConnection();
        public form_PatientProfile(string login)
        {
            InitializeComponent();
            this.login = login;
            AddPatientProfileDetails();
        }
        
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        private void AddPatientProfileDetails()
        {
            try
            {

                DataTable dt = data.display("Select Ptitle,Fname,PID from Login,patient where Login.username=Patient.UID and UID='" + login + "'");
                string patientid = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());
                profile_name.Text = txt_username.Text;

                DataTable dt1 = data.display("Select DOB,Age,Paddress,pemail,PNIC, Lname,Gender,pcivilstatus,mobilephone,preg_date from Patient where PID='" + patientid + "' ");

                txt_patient_title.Text = dt.Rows[0][0].ToString();
                txt_patient_firstname.Text = dt.Rows[0][1].ToString();
                txt_patient_dob.Text = dt1.Rows[0][0].ToString();
                txt_patient_age.Text = dt1.Rows[0][1].ToString();
                txt_patient_address.Text = dt1.Rows[0][2].ToString();
                txt_patient_email_address.Text = dt1.Rows[0][3].ToString();
                txt_patient_nic.Text = dt1.Rows[0][4].ToString();
                txt_patient_lastname.Text = dt1.Rows[0][5].ToString();
                txt_patient_gender.Text = dt1.Rows[0][6].ToString();
                txt_patient_civilstatus.Text = dt1.Rows[0][7].ToString();
                txt_patient_mobile.Text = dt1.Rows[0][8].ToString();
                txt_patient_registereddate.Text = dt1.Rows[0][9].ToString();

                DataTable dt2 = data.display("Select Gname,nic,gaddresss,telephone from Gurdian where Pno='" + patientid + "' ");

                txt_patient_guardian_name.Text = dt2.Rows[0][0].ToString();
                txt_patient_guardian_nic.Text = dt2.Rows[0][1].ToString();
                txt_patient_guardian_address.Text = dt2.Rows[0][2].ToString();
                txt_gurdians_telephone.Text = dt2.Rows[0][3].ToString();
                dt.Dispose();
                dt1.Dispose();
                dt2.Dispose();

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
            
            form_PatientDashBoard obj_patientdashboard = new form_PatientDashBoard(cc.PassLogin());
            obj_patientdashboard.Show();
            this.Hide();
        }

        private void btn_appointment_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_PatientAppointments obj_patientappoinment = new form_PatientAppointments(cc.PassLogin());
            obj_patientappoinment.Show();
            this.Hide();
        }

        private void btn_health_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_PatientHealth obj_patienthealth = new form_PatientHealth(cc.PassLogin());
            obj_patienthealth.Show();
            this.Hide();
        }

        private void btn_update_patient_details_Click(object sender, RoutedEventArgs e)
        {

            form_PatientUpdateProfile_PatinetInfo obj_updatepatientdetails = new form_PatientUpdateProfile_PatinetInfo(cc.PassLogin());
            obj_updatepatientdetails.Show();
            this.Hide();
        }

        private void btn_update_guardain_details_Click(object sender, RoutedEventArgs e)
        {

            form_PatientUpdateProfile_GurdianInfo obj_updateguardiandetails = new form_PatientUpdateProfile_GurdianInfo(cc.PassLogin());
            obj_updateguardiandetails.Show();
            this.Hide();
        }

        private void btn_back_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_PatientDashBoard obj_patientdashboard = new form_PatientDashBoard(cc.PassLogin());
            obj_patientdashboard.Show();
            this.Hide();
        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_PatientAppointments obj_patientappoinment = new form_PatientAppointments(cc.PassLogin());
            obj_patientappoinment.Show();
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

        private void btn_delete_profile_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                MessageBoxResult result = MessageBox.Show("Do you want to Delete  the Profile?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DataTable dt = data.display("Select PID from Login,patient where Login.username=Patient.UID and UID='" + login + "'");
                    string patientid = dt.Rows[0][0].ToString();
                    string q = "Delete from Patient_health where pno='" + patientid + "'";
                    string w = "Delete from appointment where pno='" + patientid + "'";
                    string u = "Delete from Gurdian where pno = '" + patientid + "'";
                    string t = "Delete from patient where pid='" + patientid + "'";
                    string r = "Delete from login where username='" + login + "'";

                    var data1 = new DataBaseConnection();
                    var data2 = new DataBaseConnection();
                    var data3 = new DataBaseConnection();
                    var data4 = new DataBaseConnection();
                    var data5 = new DataBaseConnection();

                    int c = data1.Insert_Update_Delete(q);
                    int d = data2.Insert_Update_Delete(w);
                    int p = data3.Insert_Update_Delete(u);
                    int f = data4.Insert_Update_Delete(t);
                    int g = data5.Insert_Update_Delete(r);


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

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
