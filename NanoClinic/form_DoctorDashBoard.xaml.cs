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
using MaterialDesignThemes.Wpf;
using System.Data;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_DoctorDashBoard.xaml
    /// </summary>
    public partial class form_DoctorDashBoard : Window
    {
        string login;
        DataBaseConnection data = new DataBaseConnection();
        Controller cc = new Controller();
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public form_DoctorDashBoard(string login)
        {

            this.login = login;
            InitializeComponent();
            
        }

        

       
        private void Timer_Click(object sender, EventArgs e)

        {
            DateTime d;

            d = DateTime.Now;

            time.Text = d.Hour + " : " + d.Minute + " : " + d.Second;
        }
        private void timer()
        {
            Timer.Tick += new EventHandler(Timer_Click);

            Timer.Interval = new TimeSpan(0, 0, 1);

            Timer.Start();
        }
        private void AddDoctorDashboardDetails()
        {
            try
            {
                DataTable dt = data.display("Select Dtitle,Fname,did from Login,Doctor where Login.username=Doctor.UID and UID='" + login + "'");
                string dno = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());

                txt_welcomedoctor.Text = "Dr. " + dt.Rows[0][1].ToString();



                DataTable dt1 = data.display("Select Count(*) from patient");

                if (dt1.Rows.Count == 0)
                {
                    txt_total_patients.Text = "No patients";

                }
                else
                {
                    txt_total_patients.Text = dt1.Rows[0][0].ToString();

                }

                DataTable dt2 = data.display("Select Count(*) from appointment where dno='" + dt.Rows[0][2] + "'");
                if (dt2.Rows.Count == 0)
                {
                    txt_total_appointments.Text = "No appointments";

                }
                else
                {
                    txt_total_appointments.Text = dt2.Rows[0][0].ToString();

                }



                DataTable dt3 = data.display("Select Count(*) from Doc_schedule where dno='" + dno + "'");

                if (dt3.Rows.Count == 0)
                {
                    txt_total_schedules.Text = "No schedules";

                }
                else
                {
                    txt_total_schedules.Text = dt3.Rows[0][0].ToString();

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
                    doughnut1(0, 0, 0);

                }
                else if (dt1.Rows.Count == 1)
                {
                    if (dt7.Rows.Count == 0)
                    {
                        doughnut1(Convert.ToInt32(dt1.Rows[0][0]), 0, Convert.ToInt32(dt8.Rows[0][0]));

                    }
                    else if (dt8.Rows.Count == 0)
                    {
                        doughnut1(Convert.ToInt32(dt1.Rows[0][0]), Convert.ToInt32(dt7.Rows[0][0]), 0);

                    }
                    else
                    {
                        doughnut1(Convert.ToInt32(dt1.Rows[0][0]), Convert.ToInt32(dt7.Rows[0][0]), Convert.ToInt32(dt8.Rows[0][0]));

                    }

                }


                DataTable dt9 = data.display("Select Messagee from Doctor where did='" + dno + "'");


                if (dt9.Rows.Count == 0)
                {
                    txt_announcements_appointments.Text = "No Announcements";

                }
                else
                {
                    txt_announcements_appointments.Text = dt9.Rows[0][0].ToString();
                }





                dt.Dispose();

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

        private void btn_patients_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_DoctorPatients obj_doctorpatients = new form_DoctorPatients(cc.PassLogin());
            obj_doctorpatients.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            calender.DisplayDate = DateTime.Now;
            timer();
            AddDoctorDashboardDetails();
        }



        public void doughnut1(int a,int b,int c)
        {
            seriesCollection1 = new SeriesCollection
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


        public SeriesCollection seriesCollection1 { get; set; }

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

        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_DoctorProfile obj = new form_DoctorProfile(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
