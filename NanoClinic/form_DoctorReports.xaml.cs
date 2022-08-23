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
    /// Interaction logic for form_DoctorReports.xaml
    /// </summary>
    public partial class form_DoctorReports : Window
    {
        string login;string dno;
        DataBaseConnection data = new DataBaseConnection();
        Controller cc = new Controller();
        public form_DoctorReports(string login)
        {
            this.login = login;
            InitializeComponent();   
        }
        
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        private void addDetails()
        {

            try
            {

                DataTable dt = data.display("Select Dtitle,Fname,did from Login,Doctor where Login.username=Doctor.UID and UID='" + login + "'");
                dno = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());

                DataTable dt1 = data.display("Select Count(*) from Appointment where dno='" + dt.Rows[0][2] + "'");
                DataTable dt2 = data.display("Select Count(*) from Appointment where dno='" + dt.Rows[0][2] + "' and adate='" + DateTime.Now + "'");
                DataTable dt3 = data.display("Select Count(*) from Appointment where dno='" + dt.Rows[0][2] + "' and adate!='" + DateTime.Now + "'");

                if (dt1.Rows.Count == 0)
                {
                    doughnut1(0, 0, 0);
                }
                else
                {

                    if (dt3.Rows.Count == 0)
                    {
                        doughnut1(Convert.ToInt32(dt1.Rows[0][0]), Convert.ToInt32(dt2.Rows[0][0]), 0);

                    }
                    else if (dt2.Rows.Count == 0)
                    {
                        doughnut1(Convert.ToInt32(dt1.Rows[0][0]), 0, Convert.ToInt32(dt3.Rows[0][0]));

                    }
                    else
                    {
                        doughnut1(Convert.ToInt32(dt1.Rows[0][0]), Convert.ToInt32(dt2.Rows[0][0]), Convert.ToInt32(dt3.Rows[0][0]));

                    }
                }


                DataTable dt4 = data.display("Select stime,count(*) from Appointment where dno='" + dt.Rows[0][2] + "' group by stime");

                if (dt4.Rows.Count == 0)
                {
                    doughnut2("NO", 0, "NO", 0, "NO", 0, "NO", 0);

                }
                else if (dt4.Rows.Count == 1)
                {
                    doughnut2(dt4.Rows[0][0].ToString(), Convert.ToInt32(dt4.Rows[0][1]), "NO", 0, "NO", 0, "NO", 0);

                }
                else if (dt4.Rows.Count == 2)
                {
                    doughnut2(dt4.Rows[0][0].ToString(), Convert.ToInt32(dt4.Rows[0][1]), dt4.Rows[1][0].ToString(), Convert.ToInt32(dt4.Rows[1][1]), "NO", 0, "NO", 0);

                }
                else if (dt4.Rows.Count == 3)
                {
                    doughnut2(dt4.Rows[0][0].ToString(), Convert.ToInt32(dt4.Rows[0][1]), dt4.Rows[1][0].ToString(), Convert.ToInt32(dt4.Rows[1][1]), dt4.Rows[2][0].ToString(), Convert.ToInt32(dt4.Rows[2][1]), "NO", 0);

                }
                else if (dt4.Rows.Count == 4)
                {
                    doughnut2(dt4.Rows[0][0].ToString(), Convert.ToInt32(dt4.Rows[0][1]), dt4.Rows[1][0].ToString(), Convert.ToInt32(dt4.Rows[1][1]), dt4.Rows[2][0].ToString(), Convert.ToInt32(dt4.Rows[2][1]), dt4.Rows[3][0].ToString(), Convert.ToInt32(dt4.Rows[3][1]));

                }




                DataTable dt5 = data.display("Select Month(adate),count(*) from Appointment where dno='" + dt.Rows[0][2] + "' group by month(adate) having month(adate)='" + DateTime.Now.Month + "' order by month(adate) desc");

                if (dt5.Rows.Count == 0)
                {
                    doughnut3(0, 0, 0);

                }
                else if (dt5.Rows.Count == 1)
                {
                    doughnut3(Convert.ToInt32(dt5.Rows[0][1]), 0, 0);

                }
                else if (dt5.Rows.Count == 2)
                {
                    doughnut3(Convert.ToInt32(dt5.Rows[0][1]), Convert.ToInt32(dt5.Rows[1][1]), 0);

                }
                else if (dt5.Rows.Count == 3)
                {
                    doughnut3(Convert.ToInt32(dt5.Rows[0][1]), Convert.ToInt32(dt5.Rows[1][1]), Convert.ToInt32(dt5.Rows[2][1]));

                }
                DataTable dt6 = data.display("Select Count(*) from Doc_schedule where dno='" + dno + "'");
                DataTable dt7 = data.display("Select Count(*) from Doc_schedule where dno='" + dno + "' and Sdate='" + DateTime.Now + "'");
                DataTable dt8 = data.display("Select Count(*) from Doc_schedule where dno='" + dno + "' and Sdate!='" + DateTime.Now + "'");


                if (dt6.Rows.Count == 0)
                {
                    doughnut4(0, 0, 0);

                }
                else
                {

                    if (dt8.Rows.Count == 0)
                    {
                        doughnut4(Convert.ToInt32(dt6.Rows[0][0]), Convert.ToInt32(dt7.Rows[0][0]), 0);

                    }
                    else if (dt7.Rows.Count == 0)
                    {
                        doughnut4(Convert.ToInt32(dt6.Rows[0][0]), 0, Convert.ToInt32(dt8.Rows[0][0]));

                    }
                    else
                    {
                        doughnut4(Convert.ToInt32(dt6.Rows[0][0]), Convert.ToInt32(dt7.Rows[0][0]), Convert.ToInt32(dt8.Rows[0][0]));

                    }
                }

                DataTable dt9 = data.display("Select stime,count(*) from Doc_schedule where dno='" + dno + "' group by stime");


                if (dt9.Rows.Count == 0)
                {
                    doughnut5("NO", 0, "NO", 0, "NO", 0, "NO", 0);

                }
                else if (dt9.Rows.Count == 1)
                {
                    doughnut5(dt9.Rows[0][0].ToString(), Convert.ToInt32(dt9.Rows[0][1]), "NO", 0, "NO", 0, "NO", 0);

                }
                else if (dt9.Rows.Count == 2)
                {
                    doughnut5(dt9.Rows[0][0].ToString(), Convert.ToInt32(dt9.Rows[0][1]), dt9.Rows[1][0].ToString(), Convert.ToInt32(dt9.Rows[1][1]), "NO", 0, "NO", 0);

                }
                else if (dt9.Rows.Count == 3)
                {
                    doughnut5(dt9.Rows[0][0].ToString(), Convert.ToInt32(dt9.Rows[0][1]), dt9.Rows[1][0].ToString(), Convert.ToInt32(dt9.Rows[1][1]), dt9.Rows[2][0].ToString(), Convert.ToInt32(dt9.Rows[2][1]), "NO", 0);

                }
                else if (dt9.Rows.Count == 4)
                {
                    doughnut5(dt9.Rows[0][0].ToString(), Convert.ToInt32(dt9.Rows[0][1]), dt9.Rows[1][0].ToString(), Convert.ToInt32(dt9.Rows[1][1]), dt9.Rows[2][0].ToString(), Convert.ToInt32(dt9.Rows[2][1]), dt9.Rows[3][0].ToString(), Convert.ToInt32(dt9.Rows[3][1]));

                }




                DataTable dt10 = data.display("Select Month(sdate),count(*) from Doc_schedule where dno='" + dno + "' group by month(sdate) having month(sdate)='" + DateTime.Now.Month + "' order by month(sdate) desc");

                if (dt10.Rows.Count == 0)
                {
                    doughnut6(0, 0, 0);

                }
                else if (dt10.Rows.Count == 1)
                {
                    doughnut6(Convert.ToInt32(dt10.Rows[0][1]), 0, 0);

                }
                else if (dt10.Rows.Count == 2)
                {
                    doughnut6(Convert.ToInt32(dt10.Rows[0][1]), Convert.ToInt32(dt10.Rows[1][1]), 0);

                }
                else if (dt10.Rows.Count == 3)
                {
                    doughnut6(Convert.ToInt32(dt10.Rows[0][1]), Convert.ToInt32(dt10.Rows[1][1]), Convert.ToInt32(dt10.Rows[2][1]));

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
        public void doughnut1(int a,int b,int c)
        {
            seriesCollection1 = new SeriesCollection
            {

                  new PieSeries
                {
                    Title="Total",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(a) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Red,
                },
                   new PieSeries
                {
                    Title="New",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(b) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Green,
                },
                    new PieSeries
                {
                    Title="Old",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(c) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Blue,
                },
                 
            };

            DataContext = this;
        }


        public SeriesCollection seriesCollection1 { get; set; }

        public void doughnut2(string a,int a1,string b,int b1,string c,int c1,string d,int d1)
        {
            seriesCollection2 = new SeriesCollection
            {

                  new PieSeries
                {
                    Title=a,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(a1) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Brown,
                },
                   new PieSeries
                {
                    Title=b,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(b1) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Green,
                },
                    new PieSeries
                {
                    Title=c,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(c1) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Blue,
                },
                        new PieSeries
                {
                    Title=d,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(d1) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Purple,
                },

            };

            DataContext = this;
        }
        public SeriesCollection seriesCollection2 { get; set; }

        public void doughnut3(int a,int b,int c)
        {
            seriesCollection3 = new SeriesCollection
            {

                  new PieSeries
                {
                    Title="Last Month",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(a) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Brown,
                },
                   new PieSeries
                {
                    Title="Last 2 Months",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(b) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Green,
                },
                    new PieSeries
                {
                    Title="Last 3 Months",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(c) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Blue,
                },
                        

            };

            DataContext = this;
        }
        public SeriesCollection seriesCollection3 { get; set; }


        public void doughnut4(int a, int b, int c)
        {
            seriesCollection4 = new SeriesCollection
            {

                  new PieSeries
                {
                    Title="Total",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(a) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Pink,
                },
                   new PieSeries
                {
                    Title="New",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(b) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Silver,
                },
                    new PieSeries
                {
                    Title="Old",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(c) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Blue,
                },

            };

            DataContext = this;
        }


        public SeriesCollection seriesCollection4 { get; set; }

        public void doughnut5(string a, int a1, string b, int b1, string c, int c1, string d, int d1)
        {
            seriesCollection5 = new SeriesCollection
            {

                  new PieSeries
                {
                    Title=a,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(a1) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Red,
                },
                   new PieSeries
                {
                    Title=b,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(b1) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Green,
                },
                    new PieSeries
                {
                    Title=c,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(c1) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Navy,
                },
                        new PieSeries
                {
                    Title=d,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(d1) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Purple,
                },

            };

            DataContext = this;
        }
        public SeriesCollection seriesCollection5 { get; set; }

        public void doughnut6(int a, int b, int c)
        {
            seriesCollection6 = new SeriesCollection
            {

                  new PieSeries
                {
                    Title="Last Month",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(a) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Brown,
                },
                   new PieSeries
                {
                    Title="Last 2 Months",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(b) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Green,
                },
                    new PieSeries
                {
                    Title="Last 3 Months",
                    Values=new ChartValues<ObservableValue> {new ObservableValue(c) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Red,
                },


            };

            DataContext = this;
        }
        public SeriesCollection seriesCollection6 { get; set; }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (date_picker_start.SelectedDate == null)
            {
                date_picker_start.Focus();
                txt_error_starting_date.Text = "Please select a starting date!";
                error_startingdate.Visibility = Visibility.Visible;
            }
            else if (date_picker_end.SelectedDate == null)
            {
                date_picker_end.Focus();
                txt_error_end_date.Text = "Please select a starting date!";
                error_enddate.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {

                    DataTable dt = data.display("Select count(*) from appointment where dno='" + dno + "' and adate between '" + date_picker_start.SelectedDate.Value + "' and '" + date_picker_end.SelectedDate.Value + "'");

                    appointments_num.Text = dt.Rows[0][0].ToString();

                    DataTable dt1 = data.display("Select count(*) from Doc_schedule where dno='" + dno + "' and sdate between '" + date_picker_start.Text + "' and '" + date_picker_end.Text + "'");

                    schedule_num.Text = dt1.Rows[0][0].ToString();

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
        private void clear()
        {
            error_startingdate.Visibility = Visibility.Collapsed;
            error_enddate.Visibility = Visibility.Collapsed;
        }

         private void date_picker_start_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void date_picker_end_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clear();
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

        private void btn_back_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_DoctorAppointments obj = new form_DoctorAppointments(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
