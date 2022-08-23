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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.ComponentModel;

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_PatientAppointments.xaml
    /// </summary>
    public partial class form_PatientAppointments : Window
    {
        DataBaseConnection data = new DataBaseConnection();
        Controller cc = new Controller();
        string login;
        string patientid;
        


        public form_PatientAppointments( string login)
        {
            this.login = login;
            InitializeComponent();
            AddPatientAppintmentsDetails();
            

           
           /* Sortby.ItemsSource = new string[] { "Name", "Country", "Age" };
            SortDir.ItemsSource = Enum.GetNames<ListSortDirection>();
            MyList.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));*/
        }

        /* public void SortList()
         {
             var SortProperty = Sortby.SelectedItem.ToString();
             var SortDirection = SortDir.SelectedItem.ToString() == "Ascending" ? ListSortDirection.Ascending : ListSortDirection.Descending;

             MyList.Items.SortDescriptions[0] = new SortDescription(SortProperty,SortDirection);



         }*/


        
        
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void AddPatientAppintmentsDetails()
        {

            try
            {

                DataTable dt = data.display("Select Ptitle,Fname,PID from Login,patient where Login.username=Patient.UID and UID='" + login + "'");
                patientid = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());


                DataTable dt2 = data.display("Select spec,Count(*) from Appointment,doctor where appointment.dno=doctor.did and pno='" + patientid + "'  group by spec");

                if (dt2.Rows.Count == 0)
                    doughnut1("Not Updated", 0, "Not Updated", 0, "Not Updated", 0, "Not Updated", 0, "Not Updated", 0);
                else if (dt2.Rows.Count == 1)
                    doughnut1(dt2.Rows[0][0].ToString(), Convert.ToInt32(dt2.Rows[0][1]), "Not Updated", 0, "Not Updated", 0, "Not Updated", 0, "Not Updated", 0);
                else if (dt2.Rows.Count == 2)
                    doughnut1(dt2.Rows[0][0].ToString(), Convert.ToInt32(dt2.Rows[0][1]), dt2.Rows[1][0].ToString(), Convert.ToInt32(dt2.Rows[1][1]), "Not Updated", 0, "Not Updated", 0, "Not Updated", 0);
                else if (dt2.Rows.Count == 3)
                    doughnut1(dt2.Rows[0][0].ToString(), Convert.ToInt32(dt2.Rows[0][1]), dt2.Rows[1][0].ToString(), Convert.ToInt32(dt2.Rows[1][1]), dt2.Rows[2][0].ToString(), Convert.ToInt32(dt2.Rows[2][1]), "Not Updated", 0, "Not Updated", 0);
                else if (dt2.Rows.Count == 4)
                    doughnut1(dt2.Rows[0][0].ToString(), Convert.ToInt32(dt2.Rows[0][1]), dt2.Rows[1][0].ToString(), Convert.ToInt32(dt2.Rows[1][1]), dt2.Rows[2][0].ToString(), Convert.ToInt32(dt2.Rows[2][1]), dt2.Rows[3][0].ToString(), Convert.ToInt32(dt2.Rows[3][1]), "Not Updated", 0);
                else if (dt2.Rows.Count == 5)
                    doughnut1(dt2.Rows[0][0].ToString(), Convert.ToInt32(dt2.Rows[0][1]), dt2.Rows[1][0].ToString(), Convert.ToInt32(dt2.Rows[1][1]), dt2.Rows[2][0].ToString(), Convert.ToInt32(dt2.Rows[2][1]), dt2.Rows[3][0].ToString(), Convert.ToInt32(dt2.Rows[3][1]), dt2.Rows[4][0].ToString(), Convert.ToInt32(dt2.Rows[4][1]));


                DataTable dt3 = data.display("Select dno,Count(*) from Appointment where Pno='" + patientid + "' group by dno");

                if (dt3.Rows.Count == 0)
                    doughnut2("Not Updated", 0, "Not Updated", 0, "Not Updated", 0, "Not Updated", 0, "Not Updated", 0);
                else if (dt3.Rows.Count == 1)
                    doughnut2(dt3.Rows[0][0].ToString(), Convert.ToInt32(dt3.Rows[0][1]), "Not Updated", 0, "Not Updated", 0, "Not Updated", 0, "Not Updated", 0);
                else if (dt3.Rows.Count == 2)
                    doughnut2(dt3.Rows[0][0].ToString(), Convert.ToInt32(dt3.Rows[0][1]), dt3.Rows[1][0].ToString(), Convert.ToInt32(dt3.Rows[1][1]), "Not Updated", 0, "Not Updated", 0, "Not Updated", 0);
                else if (dt3.Rows.Count == 3)
                    doughnut2(dt3.Rows[0][0].ToString(), Convert.ToInt32(dt3.Rows[0][1]), dt3.Rows[1][0].ToString(), Convert.ToInt32(dt3.Rows[1][1]), dt3.Rows[2][0].ToString(), Convert.ToInt32(dt3.Rows[2][1]), "Not Updated", 0, "Not Updated", 0);
                else if (dt3.Rows.Count == 4)
                    doughnut2(dt3.Rows[0][0].ToString(), Convert.ToInt32(dt3.Rows[0][1]), dt3.Rows[1][0].ToString(), Convert.ToInt32(dt3.Rows[1][1]), dt3.Rows[2][0].ToString(), Convert.ToInt32(dt3.Rows[2][1]), dt3.Rows[3][0].ToString(), Convert.ToInt32(dt3.Rows[3][1]), "Not Updated", 0);
                else if (dt3.Rows.Count == 5)
                    doughnut2(dt3.Rows[0][0].ToString(), Convert.ToInt32(dt3.Rows[0][1]), dt3.Rows[1][0].ToString(), Convert.ToInt32(dt3.Rows[1][1]), dt3.Rows[2][0].ToString(), Convert.ToInt32(dt3.Rows[2][1]), dt3.Rows[3][0].ToString(), Convert.ToInt32(dt3.Rows[3][1]), dt3.Rows[4][0].ToString(), Convert.ToInt32(dt3.Rows[4][1]));




                DataTable dt4 = data.display("select Dno,adate from Appointment where pno='" + patientid + "'");

                if (dt2.Rows.Count == 0)
                {
                    txt_next_doctor.Text = "No Appointments";

                }
                else
                {
                    txt_next_doctor.Text = dt4.Rows[0][0].ToString();
                    txt_next_date.Text = dt4.Rows[0][1].ToString();
                }


                DataTable dt5 = data.display("Select Count(*) from Appointment where pno='" + patientid + "'");
                txt_total_appointment.Text = dt5.Rows[0][0].ToString();


                DataTable dt6 = data.display("Select Count(*) from Appointment where pno='" + patientid + "' and adate!='" + DateTime.Now + "'");
                txt_old_appointment.Text = dt6.Rows[0][0].ToString();

                DataTable dt7 = data.display("Select Count(*) from Appointment where pno='" + patientid + "' and adate='" + DateTime.Now + "'");
                txt_new_appointment.Text = dt7.Rows[0][0].ToString();

                dt4.Dispose();
                dt5.Dispose();
                dt6.Dispose();
                dt7.Dispose();
                dt3.Dispose();

                DataTable dt8 = data.display("select Dno,adate from Appointment where pno='" + patientid + "'");

                if (dt8.Rows.Count == 0)
                {
                    appointment_1_doc_name.Text = "No Appointments";
                    appointment_2_doc_name.Text = "No Appointments";
                    appointment_3_doc_name.Text = "No Appointments";
                    appointment_4_doc_name.Text = "No Appointments";
                    appointment_5_doc_name.Text = "No Appointments";

                }
                else if (dt8.Rows.Count == 1)
                {
                    appointment_1_doc_name.Text = dt8.Rows[0][0].ToString();
                    appointment_1_time.Text = dt8.Rows[0][1].ToString();

                    appointment_2_doc_name.Text = "No Appointments";
                    appointment_3_doc_name.Text = "No Appointments";
                    appointment_4_doc_name.Text = "No Appointments";
                    appointment_5_doc_name.Text = "No Appointments";

                }
                else if (dt8.Rows.Count == 2)
                {
                    appointment_1_doc_name.Text = dt8.Rows[0][0].ToString();
                    appointment_1_time.Text = dt8.Rows[0][1].ToString();

                    appointment_2_doc_name.Text = dt8.Rows[1][0].ToString();
                    appointment_2_time.Text = dt8.Rows[1][1].ToString();

                    appointment_3_doc_name.Text = "No Appointments";
                    appointment_4_doc_name.Text = "No Appointments";
                    appointment_5_doc_name.Text = "No Appointments";

                }
                else if (dt8.Rows.Count == 3)
                {
                    appointment_1_doc_name.Text = dt8.Rows[0][0].ToString();
                    appointment_1_time.Text = dt8.Rows[0][1].ToString();

                    appointment_2_doc_name.Text = dt8.Rows[1][0].ToString();
                    appointment_2_time.Text = dt8.Rows[1][1].ToString();

                    appointment_3_doc_name.Text = dt8.Rows[2][0].ToString();
                    appointment_3_time.Text = dt8.Rows[2][1].ToString();

                    appointment_4_doc_name.Text = "No Appointments";
                    appointment_5_doc_name.Text = "No Appointments";

                }
                else if (dt8.Rows.Count == 4)
                {
                    appointment_1_doc_name.Text = dt8.Rows[0][0].ToString();
                    appointment_1_time.Text = dt8.Rows[0][1].ToString();

                    appointment_2_doc_name.Text = dt8.Rows[1][0].ToString();
                    appointment_2_time.Text = dt8.Rows[1][1].ToString();

                    appointment_3_doc_name.Text = dt8.Rows[2][0].ToString();
                    appointment_3_time.Text = dt8.Rows[2][1].ToString();

                    appointment_4_doc_name.Text = dt8.Rows[3][0].ToString();
                    appointment_4_time.Text = dt8.Rows[3][1].ToString();

                    appointment_5_doc_name.Text = "No Appointments";

                }
                else if (dt8.Rows.Count == 5 || dt8.Rows.Count > 5)
                {
                    appointment_1_doc_name.Text = dt8.Rows[0][0].ToString();
                    appointment_1_time.Text = dt8.Rows[0][1].ToString();

                    appointment_2_doc_name.Text = dt8.Rows[1][0].ToString();
                    appointment_2_time.Text = dt8.Rows[1][1].ToString();

                    appointment_3_doc_name.Text = dt8.Rows[2][0].ToString();
                    appointment_3_time.Text = dt8.Rows[2][1].ToString();

                    appointment_4_doc_name.Text = dt8.Rows[3][0].ToString();
                    appointment_4_time.Text = dt8.Rows[3][1].ToString();

                    appointment_5_doc_name.Text = dt8.Rows[4][0].ToString();
                    appointment_5_time.Text = dt8.Rows[4][1].ToString();

                }

                DataTable dt1 = data.display("Select stime from Appointment where pno='"+patientid+"' and adate='"+DateTime.Now+"' ");

                if (dt1.Rows.Count > 0)
                {

                    for (int c = 0; c < (dt1.Rows.Count); c++)
                    {

                        cmb_appointment.Items.Add(dt1.Rows[c][0].ToString());

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
        private void btn_general_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_PatientDashBoard obj_patientdashboard = new form_PatientDashBoard(cc.PassLogin());
            obj_patientdashboard.Show();
            this.Hide();
        }

        private void btn_profile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_PatientProfile obj_patientprofile = new form_PatientProfile(cc.PassLogin());
            obj_patientprofile.Show();
            this.Hide();
        }

        private void btn_health_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_PatientHealth obj_patienthealth = new form_PatientHealth(cc.PassLogin());
            obj_patienthealth.Show();
            this.Hide();
        }

        /*-------------------------- Live Charts -------------------------- */


        
        
        public void doughnut1(string a1,int a2,string b1,int b2,string c1, int c2,string d1,int d2,string e1,int e2)
        {
            seriesCollection1 = new SeriesCollection
            {
                new PieSeries
                {
                    Title=a1,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(a2) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Red,
                },
                 new PieSeries
                {
                    Title=b1,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(b2) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Orange,
                },
                  new PieSeries
                {
                    Title=c1,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(c2) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Yellow,
                },
                   new PieSeries
                {
                    Title=d1,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(d2) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Green,
                },
                    new PieSeries
                {
                    Title=e1,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(e2) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Blue,
                },
                



            };

            DataContext = this;
        }
        public void doughnut2(string a1, int a2, string b1, int b2, string c1, int c2, string d1, int d2, string e1, int e2)
        {
            seriesCollection2 = new SeriesCollection
            {
                new PieSeries
                {
                    Title=a1,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(a2) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Red,
                },
                 new PieSeries
                {
                    Title=b1,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(b2) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Orange,
                },
                  new PieSeries
                {
                    Title=c1,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(c2) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Yellow,
                },
                   new PieSeries
                {
                    Title=d1,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(d2) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Green,
                },
                    new PieSeries
                {
                    Title=e1,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(e2) },
                    DataLabels=true,
                    Fill=System.Windows.Media.Brushes.Blue,
                },




            };

            DataContext = this;
        }

        public SeriesCollection seriesCollection1 { get; set; }
        public SeriesCollection seriesCollection2 { get; set; }
   
       

        private void btn_back_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_PatientProfile obj_patientprofile = new form_PatientProfile(cc.PassLogin());
            obj_patientprofile.Show();
            this.Hide();
        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_PatientHealth obj_patienthealth = new form_PatientHealth(cc.PassLogin());
            obj_patienthealth.Show();
            this.Hide();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            calender.DisplayDate = DateTime.Now;
            error_cmb_delete_appointment.Visibility = Visibility.Collapsed;

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
        
        private void btn_make_appointments_Click(object sender, RoutedEventArgs e)
        {
            form_PatientMakeAppointments obj = new form_PatientMakeAppointments(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            error_cmb_delete_appointment.Visibility = Visibility.Collapsed;



            if (cmb_appointment.SelectedItem == null)
            {
                cmb_appointment.Focus();
                txt_error_cmb_delete_appointment.Text = "Please make a selection!";
                error_cmb_delete_appointment.Visibility = Visibility.Visible;
            }
            
            else
            {
                MessageBoxResult result = MessageBox.Show("Do you want to Delete the appointment?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int f = data.Insert_Update_Delete("Delete from  Appointment where pno='" + patientid + "' and adate='" + DateTime.Now + "' and stime='" + cmb_appointment.SelectedItem + "'");



                    if (f == 1)
                    {
                        MessageBox.Show("You successfully deleted the Appointment", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {

                    }

                    cmb_appointment.SelectedItem = null;
                    error_cmb_delete_appointment.Visibility = Visibility.Collapsed;


                }
                else
                {

                }



                


            }
        }

        private void cmb_appointment_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_cmb_delete_appointment.Visibility = Visibility.Collapsed;

        }
    }
}
