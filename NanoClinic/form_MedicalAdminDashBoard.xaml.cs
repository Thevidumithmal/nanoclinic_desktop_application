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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Data;

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_MedicalAdminDashBoard.xaml
    /// </summary>
    public partial class form_MedicalAdminDashBoard : Window
    {
        Controller cc = new Controller();
        DataBaseConnection data = new DataBaseConnection();
        Validation obj = new Validation();
        string login;
        string sno;
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public form_MedicalAdminDashBoard(string login)
        {
            this.login = login;
            InitializeComponent(); 
        }

        private void clock()
        {
            Timer.Tick += new EventHandler(Timer_Click);

            Timer.Interval = new TimeSpan(0, 0, 1);

            Timer.Start();
        }
        private void Timer_Click(object sender, EventArgs e)

        {
            DateTime d;

            d = DateTime.Now;

            time.Text = d.Hour + " : " + d.Minute + " : " + d.Second;
        }
        private void addDetails()
        {

            try
            {
                DataTable dt = data.display("Select tittle,Fname,sid from Login,Medical_staff where Login.username=Medical_staff.UID and UID='" + login + "'");
                sno = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());

                txt_welcomestaff.Text = "St. " + dt.Rows[0][1].ToString();

                DataTable dt1 = data.display("Select Count(*) from patient");
                if (dt1.Rows.Count == 0)
                {
                    txt_total_patients.Text = "No patients";

                }
                else
                {
                    txt_total_patients.Text = dt1.Rows[0][0].ToString();

                }

                DataTable dt2 = data.display("Select Count(*) from appointment where adate='" + DateTime.Now + "' ");
                if (dt2.Rows.Count == 0)
                {
                    txt_total_appointments.Text = "No appointments";

                }
                else
                {
                    txt_total_appointments.Text = dt2.Rows[0][0].ToString();

                }


                DataTable dt3 = data.display("Select Count(*) from Doctor");

                if (dt3.Rows.Count == 0)
                {
                    txt_total_doctors.Text = "No Doctors";

                }
                else
                {
                    txt_total_doctors.Text = dt3.Rows[0][0].ToString();

                }

                DataTable dt4 = data.display("Select fname,dtelephone from doctor");

                if (dt4.Rows.Count == 0)
                {
                    txt_doc_name1.Text = "Not Updated";
                    txt_Doctor_num1.Text = "---";

                    txt_doc_name2.Text = "Not Updated";
                    txt_Doctor_num2.Text = "---";

                    txt_doc_name3.Text = "Not Updated";
                    txt_Doctor_num3.Text = "---";

                    txt_doc_name4.Text = "Not Updated";
                    txt_Doctor_num4.Text = "---";
                }
                else if (dt4.Rows.Count == 1)
                {
                    txt_doc_name1.Text = "Dr. " + dt4.Rows[0][0].ToString();
                    txt_Doctor_num1.Text = dt4.Rows[0][1].ToString();

                    txt_doc_name2.Text = "Not Updated";
                    txt_Doctor_num2.Text = "---";

                    txt_doc_name3.Text = "Not Updated";
                    txt_Doctor_num3.Text = "---";

                    txt_doc_name4.Text = "Not Updated";
                    txt_Doctor_num4.Text = "---";
                }
                else if (dt4.Rows.Count == 2)
                {
                    txt_doc_name1.Text = "Dr. " + dt4.Rows[0][0].ToString();
                    txt_Doctor_num1.Text = dt4.Rows[0][1].ToString();

                    txt_doc_name2.Text = "Dr. " + dt4.Rows[1][0].ToString();
                    txt_Doctor_num2.Text = dt4.Rows[1][1].ToString();

                    txt_doc_name3.Text = "Not Updated";
                    txt_Doctor_num3.Text = "---";

                    txt_doc_name4.Text = "Not Updated";
                    txt_Doctor_num4.Text = "---";
                }
                else if (dt4.Rows.Count == 3)
                {
                    txt_doc_name1.Text = "Dr. " + dt4.Rows[0][0].ToString();
                    txt_Doctor_num1.Text = dt4.Rows[0][1].ToString();

                    txt_doc_name2.Text = "Dr. " + dt4.Rows[1][0].ToString();
                    txt_Doctor_num2.Text = dt4.Rows[1][1].ToString();

                    txt_doc_name3.Text = "Dr. " + dt4.Rows[2][0].ToString();
                    txt_Doctor_num3.Text = dt4.Rows[2][1].ToString();

                    txt_doc_name4.Text = "Not Updated";
                    txt_Doctor_num4.Text = "---";
                }
                else if (dt4.Rows.Count == 4 || dt4.Rows.Count > 4)
                {
                    txt_doc_name1.Text = "Dr. " + dt4.Rows[0][0].ToString();
                    txt_Doctor_num1.Text = dt4.Rows[0][1].ToString();

                    txt_doc_name2.Text = "Dr. " + dt4.Rows[1][0].ToString();
                    txt_Doctor_num2.Text = dt4.Rows[1][1].ToString();

                    txt_doc_name3.Text = "Dr. " + dt4.Rows[2][0].ToString();
                    txt_Doctor_num3.Text = dt4.Rows[2][1].ToString();

                    txt_doc_name4.Text = "Dr. " + dt4.Rows[3][0].ToString();
                    txt_Doctor_num4.Text = dt4.Rows[3][1].ToString();
                }

                DataTable dt5 = data.display("Select fname,telephone from Medical_staff");

                if (dt5.Rows.Count == 0)
                {
                    txt_staff_name1.Text = "Not Updated";
                    txt_staff_num1.Text = "---";

                    txt_staff_name2.Text = "Not Updated";
                    txt_staff_num2.Text = "---";

                    txt_staff_name3.Text = "Not Updated";
                    txt_staff_num3.Text = "---";

                    txt_staff_name4.Text = "Not Updated";
                    txt_staff_num4.Text = "---";
                }
                else if (dt5.Rows.Count == 1)
                {
                    txt_staff_name1.Text = "St. " + dt5.Rows[0][0].ToString();
                    txt_staff_num1.Text = dt5.Rows[0][1].ToString();

                    txt_staff_name2.Text = "Not Updated";
                    txt_staff_num2.Text = "---";

                    txt_staff_name3.Text = "Not Updated";
                    txt_staff_num3.Text = "---";

                    txt_staff_name4.Text = "Not Updated";
                    txt_staff_num4.Text = "---";
                }
                else if (dt5.Rows.Count == 2)
                {
                    txt_staff_name1.Text = "St. " + dt5.Rows[0][0].ToString();
                    txt_staff_num1.Text = dt5.Rows[0][1].ToString();

                    txt_staff_name2.Text = "St. " + dt5.Rows[1][0].ToString();
                    txt_staff_num2.Text = dt5.Rows[1][1].ToString();

                    txt_staff_name3.Text = "Not Updated";
                    txt_staff_num3.Text = "---";

                    txt_staff_name4.Text = "Not Updated";
                    txt_staff_num4.Text = "---";
                }
                else if (dt5.Rows.Count == 3)
                {
                    txt_staff_name1.Text = "St. " + dt5.Rows[0][0].ToString();
                    txt_staff_num1.Text = dt5.Rows[0][1].ToString();

                    txt_staff_name2.Text = "St. " + dt5.Rows[1][0].ToString();
                    txt_staff_num2.Text = dt5.Rows[1][1].ToString();

                    txt_staff_name3.Text = "St. " + dt5.Rows[2][0].ToString();
                    txt_staff_num3.Text = dt5.Rows[2][1].ToString();

                    txt_staff_name4.Text = "Not Updated";
                    txt_staff_num4.Text = "---";
                }
                else if (dt5.Rows.Count == 4 || dt5.Rows.Count > 4)
                {
                    txt_staff_name1.Text = "St. " + dt5.Rows[0][0].ToString();
                    txt_staff_num1.Text = dt5.Rows[0][1].ToString();

                    txt_staff_name2.Text = "St. " + dt5.Rows[1][0].ToString();
                    txt_staff_num2.Text = dt5.Rows[1][1].ToString();

                    txt_staff_name3.Text = "St. " + dt5.Rows[2][0].ToString();
                    txt_staff_num3.Text = dt5.Rows[2][1].ToString();

                    txt_staff_name4.Text = "St. " + dt5.Rows[3][0].ToString();
                    txt_staff_num4.Text = dt5.Rows[3][1].ToString();
                }

                DataTable dt6 = data.display("Select fname,telephone from admin");

                if (dt6.Rows.Count == 0)
                {
                    txt_admin_name1.Text = "Not Updated";
                    txt_admin_num1.Text = "---";

                    txt_admin_name2.Text = "Not Updated";
                    txt_admin_num2.Text = "---";

                    txt_admin_name3.Text = "Not Updated";
                    txt_admin_num3.Text = "---";

                    txt_admin_name4.Text = "Not Updated";
                    txt_admin_num4.Text = "---";
                }
                else if (dt6.Rows.Count == 1)
                {
                    txt_admin_name1.Text = "Ad. " + dt6.Rows[0][0].ToString();
                    txt_admin_num1.Text = dt6.Rows[0][1].ToString();

                    txt_admin_name2.Text = "Not Updated";
                    txt_admin_num2.Text = "---";

                    txt_admin_name3.Text = "Not Updated";
                    txt_admin_num3.Text = "---";

                    txt_admin_name4.Text = "Not Updated";
                    txt_admin_num4.Text = "---";
                }
                else if (dt6.Rows.Count == 2)
                {
                    txt_admin_name1.Text = "Ad. " + dt6.Rows[0][0].ToString();
                    txt_admin_num1.Text = dt6.Rows[0][1].ToString();

                    txt_admin_name2.Text = "Ad. " + dt6.Rows[1][0].ToString();
                    txt_admin_num2.Text = dt6.Rows[1][1].ToString();

                    txt_admin_name3.Text = "Not Updated";
                    txt_admin_num3.Text = "---";

                    txt_admin_name4.Text = "Not Updated";
                    txt_admin_num4.Text = "---";
                }
                else if (dt6.Rows.Count == 3)
                {
                    txt_admin_name1.Text = "Ad. " + dt6.Rows[0][0].ToString();
                    txt_admin_num1.Text = dt6.Rows[0][1].ToString();

                    txt_admin_name2.Text = "Ad. " + dt6.Rows[1][0].ToString();
                    txt_admin_num2.Text = dt6.Rows[1][1].ToString();

                    txt_admin_name3.Text = "Ad. " + dt6.Rows[2][0].ToString();
                    txt_admin_num3.Text = dt6.Rows[2][1].ToString();

                    txt_admin_name4.Text = "Not Updated";
                    txt_admin_num4.Text = "---";
                }
                else if (dt6.Rows.Count == 4 || dt6.Rows.Count > 4)
                {
                    txt_admin_name1.Text = "Ad. " + dt6.Rows[0][0].ToString();
                    txt_admin_num1.Text = dt6.Rows[0][1].ToString();

                    txt_admin_name2.Text = "Ad. " + dt6.Rows[1][0].ToString();
                    txt_admin_num2.Text = dt6.Rows[1][1].ToString();

                    txt_admin_name3.Text = "Ad. " + dt6.Rows[2][0].ToString();
                    txt_admin_num3.Text = dt6.Rows[2][1].ToString();

                    txt_admin_name4.Text = "Ad. " + dt6.Rows[3][0].ToString();
                    txt_admin_num4.Text = dt6.Rows[3][1].ToString();
                }

                DataTable dt7 = data.display("Select Count(*) from Patient where Preg_date='" + DateTime.Now + "'");
                DataTable dt8 = data.display("Select Count(*) from Patient where Preg_date!='" + DateTime.Now + "'");


                if (dt1.Rows.Count == 0)
                {
                    doughnut(0, 0, 0);

                }
                else if (dt1.Rows.Count == 1)
                {
                    if (dt7.Rows.Count == 0)
                    {
                        doughnut(Convert.ToInt32(dt1.Rows[0][0]), 0, Convert.ToInt32(dt8.Rows[0][0]));

                    }
                    else if (dt8.Rows.Count == 0)
                    {
                        doughnut(Convert.ToInt32(dt1.Rows[0][0]), Convert.ToInt32(dt7.Rows[0][0]), 0);

                    }
                    else
                    {
                        doughnut(Convert.ToInt32(dt1.Rows[0][0]), Convert.ToInt32(dt7.Rows[0][0]), Convert.ToInt32(dt8.Rows[0][0]));

                    }

                }





                DataTable dt9 = data.display("Select Messagee from Medical_staff where sid='" + sno + "'");


                if (dt9.Rows.Count == 0)
                {
                    txt_announcements_staff.Text = "No Announcements";

                }
                else
                {
                    txt_announcements_staff.Text = dt9.Rows[0][0].ToString();
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
        private int checkpatinetid(string var)
        {
            int c;
            DataTable dt = data.display("Select * from Patient where pid COLLATE Latin1_General_CS_AS ='" + var + "'");
            if (dt.Rows.Count == 0)
            {
                c = 0;
            }
            else
            {
                c = 1;
            }
            return c;

        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void btn_profile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_MedicalAdminProfile obj_medicaladminprofile = new form_MedicalAdminProfile(cc.PassLogin());
            obj_medicaladminprofile.Show();
            this.Hide();
        }

        private void btn_doctors_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminDoctors obj_medicaladmindoctors = new form_MedicalAdminDoctors(cc.PassLogin()) ;
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
        public void doughnut(int a, int b, int c)
        {
            seriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title="Total",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(a) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Green,
                },
                 new PieSeries
                {
                    Title="Today",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(b) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Brown,
                },
                  new PieSeries
                {
                    Title="Old",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(c) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.DeepPink,
                },
            };

            DataContext = this;
        }


        public SeriesCollection seriesCollection { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clock();
            calender.DisplayDate = DateTime.Now;
            addDetails();
            error_patient_message.Visibility = Visibility.Collapsed;
            error_patient_id_message.Visibility = Visibility.Collapsed;
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

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_MedicalAdminProfile obj = new form_MedicalAdminProfile(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_patient_send_message_Click(object sender, RoutedEventArgs e)
        {
            error_patient_message.Visibility = Visibility.Collapsed;
            error_patient_id_message.Visibility = Visibility.Collapsed;


            int c = checkpatinetid(txt_staff_id_notice_check.Text);

            if (c == 0)
            {
                txt_staff_id_notice_check.Focus();
                txt_error_patinet_id_message.Text = "Enter a Valid Id!";
                error_patient_id_message.Visibility = Visibility.Visible;
            }
            else if ((obj.NullValidation(txt_patient_notes.Text)) == 0)
            {
                txt_patient_notes.Focus();
                txt_error_patient_message.Text = "Message cannot be blank!";
                error_patient_message.Visibility = Visibility.Visible;
            }
            else
            {



                int f = data.Insert_Update_Delete("Update Patient set messagee='" + txt_patient_notes.Text + "' where pid='" + txt_staff_id_notice_check.Text + "'");

                txt_patient_notes.Clear();
                txt_staff_id_notice_check.Clear();
                MessageBox.Show("Message has successfully sent.", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);


            }

        }

        private void txt_patient_notes_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_patient_message.Visibility = Visibility.Collapsed;
            error_patient_id_message.Visibility = Visibility.Collapsed;
        }

        private void txt_staff_id_notice_check_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_patient_message.Visibility = Visibility.Collapsed;
            error_patient_id_message.Visibility = Visibility.Collapsed;
        }
    }
}
