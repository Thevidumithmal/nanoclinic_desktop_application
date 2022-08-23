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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Data;

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_AdminDashBoard.xaml
    /// </summary>
    public partial class form_AdminDashBoard : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        Validation obj = new Validation();
        DataBaseConnection data = new DataBaseConnection();
        Controller cc = new Controller();
        string ano;
        string login;

        public form_AdminDashBoard(string login)
        {
            InitializeComponent();
            this.login = login;
            
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
                DataTable dt = data.display("Select title,Fname,aid from Login,Admin where Login.username=Admin.UID and UID='" + login + "'");
                ano = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());



                DataTable dt1 = data.display("Select Count(*) from patient");
                if (dt1.Rows.Count == 0)
                {
                    txt_total_patients.Text = "No patients";

                }
                else
                {
                    txt_total_patients.Text = dt1.Rows[0][0].ToString();

                }

                DataTable dt2 = data.display("Select Count(*) from Medical_staff  ");
                if (dt2.Rows.Count == 0)
                {
                    txt_total_nurses.Text = "No Staffs";

                }
                else
                {
                    txt_total_nurses.Text = dt2.Rows[0][0].ToString();

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




                DataTable dt4 = data.display("Select Count(*) from patient where Preg_date='" + DateTime.Now + "'");
                if (dt4.Rows.Count == 0)
                {
                    txt_new_patients.Text = "No patients";

                }
                else
                {
                    txt_new_patients.Text = dt4.Rows[0][0].ToString();

                }

                DataTable dt5 = data.display("Select Count(*) from Medical_staff where reg_date='" + DateTime.Now + "' ");
                if (dt5.Rows.Count == 0)
                {
                    txt_new_nurses.Text = "No Staff";

                }
                else
                {
                    txt_new_nurses.Text = dt5.Rows[0][0].ToString();

                }


                DataTable dt6 = data.display("Select Count(*) from Doctor where reg_date='" + DateTime.Now + "'");

                if (dt6.Rows.Count == 0)
                {
                    txt_new_doctors.Text = "No Doctors";

                }
                else
                {
                    txt_new_doctors.Text = dt6.Rows[0][0].ToString();

                }



                DataTable dt7 = data.display("Select fname,dtelephone from doctor");

                if (dt7.Rows.Count == 0)
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
                else if (dt7.Rows.Count == 1)
                {
                    txt_doc_name1.Text = "Dr. " + dt7.Rows[0][0].ToString();
                    txt_Doctor_num1.Text = dt7.Rows[0][1].ToString();

                    txt_doc_name2.Text = "Not Updated";
                    txt_Doctor_num2.Text = "---";

                    txt_doc_name3.Text = "Not Updated";
                    txt_Doctor_num3.Text = "---";

                    txt_doc_name4.Text = "Not Updated";
                    txt_Doctor_num4.Text = "---";
                }
                else if (dt7.Rows.Count == 2)
                {
                    txt_doc_name1.Text = "Dr. " + dt7.Rows[0][0].ToString();
                    txt_Doctor_num1.Text = dt7.Rows[0][1].ToString();

                    txt_doc_name2.Text = "Dr. " + dt7.Rows[1][0].ToString();
                    txt_Doctor_num2.Text = dt7.Rows[1][1].ToString();

                    txt_doc_name3.Text = "Not Updated";
                    txt_Doctor_num3.Text = "---";

                    txt_doc_name4.Text = "Not Updated";
                    txt_Doctor_num4.Text = "---";
                }
                else if (dt7.Rows.Count == 3)
                {
                    txt_doc_name1.Text = "Dr. " + dt7.Rows[0][0].ToString();
                    txt_Doctor_num1.Text = dt7.Rows[0][1].ToString();

                    txt_doc_name2.Text = "Dr. " + dt7.Rows[1][0].ToString();
                    txt_Doctor_num2.Text = dt7.Rows[1][1].ToString();

                    txt_doc_name3.Text = "Dr. " + dt7.Rows[2][0].ToString();
                    txt_Doctor_num3.Text = dt7.Rows[2][1].ToString();

                    txt_doc_name4.Text = "Not Updated";
                    txt_Doctor_num4.Text = "---";
                }
                else if (dt7.Rows.Count == 4 || dt7.Rows.Count > 4)
                {
                    txt_doc_name1.Text = "Dr. " + dt7.Rows[0][0].ToString();
                    txt_Doctor_num1.Text = dt7.Rows[0][1].ToString();

                    txt_doc_name2.Text = "Dr. " + dt7.Rows[1][0].ToString();
                    txt_Doctor_num2.Text = dt7.Rows[1][1].ToString();

                    txt_doc_name3.Text = "Dr. " + dt7.Rows[2][0].ToString();
                    txt_Doctor_num3.Text = dt7.Rows[2][1].ToString();

                    txt_doc_name4.Text = "Dr. " + dt7.Rows[3][0].ToString();
                    txt_Doctor_num4.Text = dt7.Rows[3][1].ToString();
                }





                DataTable dt8 = data.display("Select fname,telephone from Medical_staff");

                if (dt8.Rows.Count == 0)
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
                else if (dt8.Rows.Count == 1)
                {
                    txt_staff_name1.Text = "St. " + dt8.Rows[0][0].ToString();
                    txt_staff_num1.Text = dt8.Rows[0][1].ToString();

                    txt_staff_name2.Text = "Not Updated";
                    txt_staff_num2.Text = "---";

                    txt_staff_name3.Text = "Not Updated";
                    txt_staff_num3.Text = "---";

                    txt_staff_name4.Text = "Not Updated";
                    txt_staff_num4.Text = "---";
                }
                else if (dt8.Rows.Count == 2)
                {
                    txt_staff_name1.Text = "St. " + dt8.Rows[0][0].ToString();
                    txt_staff_num1.Text = dt8.Rows[0][1].ToString();

                    txt_staff_name2.Text = "St. " + dt8.Rows[1][0].ToString();
                    txt_staff_num2.Text = dt8.Rows[1][1].ToString();

                    txt_staff_name3.Text = "Not Updated";
                    txt_staff_num3.Text = "---";

                    txt_staff_name4.Text = "Not Updated";
                    txt_staff_num4.Text = "---";
                }
                else if (dt8.Rows.Count == 3)
                {
                    txt_staff_name1.Text = "St. " + dt8.Rows[0][0].ToString();
                    txt_staff_num1.Text = dt8.Rows[0][1].ToString();

                    txt_staff_name2.Text = "St. " + dt8.Rows[1][0].ToString();
                    txt_staff_num2.Text = dt8.Rows[1][1].ToString();

                    txt_staff_name3.Text = "St. " + dt8.Rows[2][0].ToString();
                    txt_staff_num3.Text = dt8.Rows[2][1].ToString();

                    txt_staff_name4.Text = "Not Updated";
                    txt_staff_num4.Text = "---";
                }
                else if (dt8.Rows.Count == 4 || dt8.Rows.Count > 4)
                {
                    txt_staff_name1.Text = "St. " + dt8.Rows[0][0].ToString();
                    txt_staff_num1.Text = dt8.Rows[0][1].ToString();

                    txt_staff_name2.Text = "St. " + dt8.Rows[1][0].ToString();
                    txt_staff_num2.Text = dt8.Rows[1][1].ToString();

                    txt_staff_name3.Text = "St. " + dt8.Rows[2][0].ToString();
                    txt_staff_num3.Text = dt8.Rows[2][1].ToString();

                    txt_staff_name4.Text = "St. " + dt8.Rows[3][0].ToString();
                    txt_staff_num4.Text = dt8.Rows[3][1].ToString();
                }



                int p1 = 0, p2 = 0, p3 = 0, p4 = 0, d1 = 0, d2 = 0, d3 = 0, d4 = 0, s1 = 0, s2 = 0, s3 = 0, s4 = 0;

                DataTable dt9 = data.display("Select Month(preg_date),count(*) from patient where Year(preg_date)='" + DateTime.Now.Year + "' group by Month(preg_date)  order by month(preg_date) desc");
                DataTable dt10 = data.display("Select Month(reg_date),count(*) from Doctor where Year(reg_date)='" + DateTime.Now.Year + "' group by Month(reg_date)  order by month(reg_date) desc");
                DataTable dt11 = data.display("Select Month(reg_date),count(*) from Medical_staff where Year(reg_date)='" + DateTime.Now.Year + "' group by Month(reg_date)  order by month(reg_date) desc");

                if (dt9.Rows.Count == 0)
                {
                    p1 = 0;
                    p2 = 0;
                    p3 = 0;
                    p4 = 0;
                }
                else if (dt9.Rows.Count == 1)
                {
                    p1 = Convert.ToInt32(dt9.Rows[0][1]);
                    p2 = 0;
                    p3 = 0;
                    p4 = 0;
                }
                else if (dt9.Rows.Count == 2)
                {
                    p1 = Convert.ToInt32(dt9.Rows[0][1]);
                    p2 = Convert.ToInt32(dt9.Rows[1][1]);
                    p3 = 0;
                    p4 = 0;
                }
                else if (dt9.Rows.Count == 3)
                {
                    p1 = Convert.ToInt32(dt9.Rows[0][1]);
                    p2 = Convert.ToInt32(dt9.Rows[1][1]);
                    p3 = Convert.ToInt32(dt9.Rows[2][1]);
                    p4 = 0;
                }
                else if (dt9.Rows.Count >= 3)
                {
                    p1 = Convert.ToInt32(dt9.Rows[0][1]);
                    p2 = Convert.ToInt32(dt9.Rows[1][1]);
                    p3 = Convert.ToInt32(dt9.Rows[2][1]);
                    p4 = Convert.ToInt32(dt9.Rows[3][1]);
                }

                if (dt10.Rows.Count == 0)
                {
                    d1 = 0;
                    d2 = 0;
                    d3 = 0;
                    d4 = 0;
                }
                else if (dt10.Rows.Count == 1)
                {
                    d1 = Convert.ToInt32(dt10.Rows[0][1]);
                    d2 = 0;
                    d3 = 0;
                    d4 = 0;
                }
                else if (dt10.Rows.Count == 2)
                {
                    d1 = Convert.ToInt32(dt10.Rows[0][1]);
                    d2 = Convert.ToInt32(dt10.Rows[1][1]);
                    d3 = 0;
                    d4 = 0;
                }
                else if (dt10.Rows.Count == 3)
                {
                    d1 = Convert.ToInt32(dt10.Rows[0][1]);
                    d2 = Convert.ToInt32(dt10.Rows[1][1]);
                    d3 = Convert.ToInt32(dt10.Rows[2][1]);
                    d4 = 0;
                }
                else if (dt10.Rows.Count >= 3)
                {
                    d1 = Convert.ToInt32(dt10.Rows[0][1]);
                    d2 = Convert.ToInt32(dt10.Rows[1][1]);
                    d3 = Convert.ToInt32(dt10.Rows[2][1]);
                    d4 = Convert.ToInt32(dt10.Rows[3][1]);
                }




                if (dt11.Rows.Count == 0)
                {
                    s1 = 0;
                    s2 = 0;
                    s3 = 0;
                    s4 = 0;
                }
                else if (dt11.Rows.Count == 1)
                {
                    s1 = Convert.ToInt32(dt11.Rows[0][1]);
                    s2 = 0;
                    s3 = 0;
                    s4 = 0;
                }
                else if (dt11.Rows.Count == 2)
                {
                    s1 = Convert.ToInt32(dt11.Rows[0][1]);
                    s2 = Convert.ToInt32(dt11.Rows[1][1]);
                    s3 = 0;
                    s4 = 0;
                }
                else if (dt11.Rows.Count == 3)
                {
                    s1 = Convert.ToInt32(dt11.Rows[0][1]);
                    s2 = Convert.ToInt32(dt11.Rows[1][1]);
                    s3 = Convert.ToInt32(dt11.Rows[2][1]);
                    s4 = 0;
                }
                else if (dt11.Rows.Count >= 3)
                {
                    s1 = Convert.ToInt32(dt11.Rows[0][1]);
                    s2 = Convert.ToInt32(dt11.Rows[1][1]);
                    s3 = Convert.ToInt32(dt11.Rows[2][1]);
                    s4 = Convert.ToInt32(dt11.Rows[3][1]);
                }

                barchart(p1, p2, p3, p4, d1, d2, d3, d4, s1, s2, s3, s4);
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

        private void btn_admin_profile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_AdminProfile obj_adminprofile = new form_AdminProfile(cc.PassLogin());
            obj_adminprofile.Show();
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
        private void barchart(int p1, int p2, int p3, int p4, int d1, int d2, int d3, int d4,int s1, int s2, int s3, int s4)
        {

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title="Patients",
                    Values = new ChartValues<double>{p1, p2, p3, p4}
                }
            };

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Doctors",
                Values = new ChartValues<double> { d1, d2, d3, d4 }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Staff",
                Values = new ChartValues<double> { s1, s2, s3, s4 }
            });

            BarLabels = new[] { "This Month", "Last Month", "Last Month2", "Last Month3" };
            Formatter = value => value.ToString("N");

            DataContext = this;


        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] BarLabels { get; set; }

        public Func<double, string> Formatter { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clock();
            calender.DisplayDate = DateTime.Now;
            addDetails();
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
            form_AdminProfile obj = new form_AdminProfile(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
