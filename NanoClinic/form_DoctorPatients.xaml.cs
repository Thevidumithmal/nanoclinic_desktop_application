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
    /// Interaction logic for form_DoctorPatients.xaml
    /// </summary>

    public partial class form_DoctorPatients : Window
    {
        Validation obj = new Validation();
        Controller cc = new Controller();
        DataBaseConnection data = new DataBaseConnection();

        string login;

        public form_DoctorPatients(string login)
        {
            this.login = login;
            InitializeComponent();
        }

        private void adddetails()
        {
            try
            {

                DataTable dt = data.display("Select Dtitle,Fname,DID from Login,Doctor where Login.username=Doctor.UID and UID='" + login + "' ");
                string doctorid = dt.Rows[0][2].ToString();

                txt_username.Text = (dt.Rows[0][0].ToString()) + " " + (dt.Rows[0][1].ToString());

                DataTable dt1 = data.display("Select Pid from Patient ");

                if (dt1.Rows.Count > 0)
                {

                    for (int c = 0; c < (dt1.Rows.Count); c++)
                    {

                        cmb_patient.Items.Add(dt1.Rows[c][0].ToString());

                    }


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

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void clear()
        {
            error_cmb_pat.Visibility = Visibility.Collapsed;
            error_cmb_deases.Visibility = Visibility.Collapsed;
            error_start_date.Visibility = Visibility.Collapsed;
            error_end_date.Visibility = Visibility.Collapsed;
        }

        private void btn_general_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_DoctorDashBoard obj_doctordashboard = new form_DoctorDashBoard(cc.PassLogin());
            obj_doctordashboard.Show();
            this.Hide();
        }
        private void btn_profile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_DoctorProfile obj_doctorprofile = new form_DoctorProfile(cc.PassLogin());
            obj_doctorprofile.Show();
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

        private void cmb_patient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                clear();

                DataTable dt = data.display("Select Ptitle,Fname,DOB,Age,Paddress,pemail,PNIC,Lname,Gender,pcivilstatus,mobilephone,preg_date from Patient where PID='" + cmb_patient.SelectedItem + "'");
                if (dt.Rows.Count == 0)
                {
                    txt_patient_title.Text = "--";
                    txt_patient_firstname.Text = "--";
                    txt_patient_dob.Text = "--";
                    txt_patient_age.Text = "--";
                    txt_patient_address.Text = "--";
                    txt_patient_email_address.Text = "--";
                    txt_patient_nic.Text = "--";
                    txt_patient_lastname.Text = "--";
                    txt_patient_gender.Text = "--";
                    txt_patient_civilstatus.Text = "--";
                    txt_patient_mobile.Text = "--";
                    txt_patient_registereddate.Text = "--";


                    txt_patient_height.Text = "--";
                    txt_patient_weight.Text = "--";
                    txt_patient_diabetes.Text = "--";
                    txt_patient_cholestorole.Text = "--";
                    txt_patient_allergic.Text = "--";
                    txt_patient_bloodpressure.Text = "--";
                    txt_patient_cancer.Text = "--";
                    txt_patient_depression.Text = "--";
                    txt_patient_alcohole.Text = "--";
                    txt_patient_smoking.Text = "--";
                    txt_patient_druguse.Text = "--";


                }
                else
                {
                    txt_patient_title.Text = dt.Rows[0][0].ToString();
                    txt_patient_firstname.Text = dt.Rows[0][1].ToString();
                    txt_patient_dob.Text = dt.Rows[0][2].ToString();
                    txt_patient_age.Text = dt.Rows[0][3].ToString();
                    txt_patient_address.Text = dt.Rows[0][4].ToString();
                    txt_patient_email_address.Text = dt.Rows[0][5].ToString();
                    txt_patient_nic.Text = dt.Rows[0][6].ToString();
                    txt_patient_lastname.Text = dt.Rows[0][7].ToString();
                    txt_patient_gender.Text = dt.Rows[0][8].ToString();
                    txt_patient_civilstatus.Text = dt.Rows[0][9].ToString();
                    txt_patient_mobile.Text = dt.Rows[0][10].ToString();
                    txt_patient_registereddate.Text = dt.Rows[0][11].ToString();
                }


                DataTable dt2 = data.display("Select Height,Weight,Diabetes,cholesterol,Allergic,Hbloodpresssure,Cancer,Depression,Alcoholuse,Smorking,Druguse from Patient_Health where Pno='" + cmb_patient.SelectedItem + "' ");

                if (dt2.Rows.Count == 0)
                {
                    txt_patient_height.Text = "Not Updated";
                    txt_patient_weight.Text = "Not Updated";
                    txt_patient_diabetes.Text = "Not Updated";
                    txt_patient_cholestorole.Text = "Not Updated";
                    txt_patient_allergic.Text = "Not Updated";
                    txt_patient_bloodpressure.Text = "Not Updated";
                    txt_patient_cancer.Text = "Not Updated";
                    txt_patient_depression.Text = "Not Updated";
                    txt_patient_alcohole.Text = "Not Updated";
                    txt_patient_smoking.Text = "Not Updated";
                    txt_patient_druguse.Text = "Not Updated";
                }
                else
                {
                    txt_patient_height.Text = dt2.Rows[0][0].ToString();
                    txt_patient_weight.Text = dt2.Rows[0][1].ToString();
                    txt_patient_diabetes.Text = dt2.Rows[0][2].ToString();
                    txt_patient_cholestorole.Text = dt2.Rows[0][3].ToString();
                    txt_patient_allergic.Text = dt2.Rows[0][4].ToString();
                    txt_patient_bloodpressure.Text = dt2.Rows[0][5].ToString();
                    txt_patient_cancer.Text = dt2.Rows[0][6].ToString();
                    txt_patient_depression.Text = dt2.Rows[0][7].ToString();
                    txt_patient_alcohole.Text = dt2.Rows[0][8].ToString();
                    txt_patient_smoking.Text = dt2.Rows[0][9].ToString();
                    txt_patient_druguse.Text = dt2.Rows[0][10].ToString();
                }




                dt.Dispose();
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

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (cmb_patient.SelectedItem == null)
            {
                cmb_patient.Focus();
                txt_error_cmb_pat.Text = "Please Select a patient!";
                error_cmb_pat.Visibility = Visibility.Visible;
            }

            else if (cmb_problem_category.SelectedItem == null)
            {
                cmb_problem_category.Focus();
                txt_error_cmb_deases.Text = "Please Select a category!";
                error_cmb_deases.Visibility = Visibility.Visible;
            }

            else if (doctor_check_patinet_start_date.SelectedDate == null)
            {
                doctor_check_patinet_start_date.Focus();
                txt_error_start_date.Text = "Please make a selection!";
                error_start_date.Visibility = Visibility.Visible;
            }
            else if (doctor_check_patinet_end_date.SelectedDate == null)
            {
                doctor_check_patinet_end_date.Focus();
                txt_error_end_date.Text = "Please make a selection!";
                error_end_date.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {


                    string m = "";
                    if (cmb_problem_category.SelectedIndex == 0)
                    {
                        m = "Rdia";
                    }
                    else if (cmb_problem_category.SelectedIndex == 2)
                    {
                        m = "Rcho";
                    }
                    else if (cmb_problem_category.SelectedIndex == 4)
                    {
                        m = "Rhb";
                    }
                    DataTable dt = data.display("Select Max(" + m + "),Min(" + m + "),Avg(" + m + ") from Patient_health where pno='" + cmb_patient.SelectedItem + "' and Hdate between '" + doctor_check_patinet_start_date.Text + "' and '" + doctor_check_patinet_end_date.Text + "'");

                    if (dt.Rows.Count == 0)
                    {
                        min.Text = "Not Updated";
                        max.Text = "Not Updated";
                        avg.Text = "Not Updated";
                    }
                    else
                    {
                        min.Text = dt.Rows[0][1].ToString();
                        max.Text = dt.Rows[0][0].ToString();
                        avg.Text = dt.Rows[0][2].ToString();
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
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            clear();
            cmb_patient.SelectedItem = null;
            cmb_problem_category.SelectedItem = null;
            doctor_check_patinet_start_date.SelectedDate = null;
            doctor_check_patinet_end_date.SelectedDate = null;

            txt_patient_height.Text = "--";
            txt_patient_weight.Text = "--";
            txt_patient_diabetes.Text = "--";
            txt_patient_cholestorole.Text = "--";
            txt_patient_allergic.Text = "--";
            txt_patient_bloodpressure.Text = "--";
            txt_patient_cancer.Text = "--";
            txt_patient_depression.Text = "--";
            txt_patient_alcohole.Text = "--";
            txt_patient_smoking.Text = "--";
            txt_patient_druguse.Text = "--";

            avg.Clear();
            max.Clear();
            min.Clear();


        }

        private void cmb_patient_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void cmb_problem_category_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void doctor_check_patinet_start_date_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void doctor_check_patinet_end_date_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adddetails();
            clear();
        }

        private void btn_back_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_DoctorSchedule obj = new form_DoctorSchedule(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}



