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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_AdminMedicalAdmin.xaml
    /// </summary>
    public partial class form_AdminMedicalAdmin : Window
    {
        string login;
        string ano;
        Controller cc = new Controller();
        Validation obj = new Validation();
        DataBaseConnection data = new DataBaseConnection();

        public form_AdminMedicalAdmin(string login)
        {
            this.login = login;
            InitializeComponent();
        }
        private void addDetails()
        {
            try
            {
                DataTable dt = data.display("Select title,Fname,aid from Login,Admin where Login.username=Admin.UID and UID='" + login + "'");
                ano = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());


                DataTable dt1 = data.display("Select Count(*) from Medical_staff");

                if (dt1.Rows.Count == 0)
                {
                    txt_total_staffs.Text = "No Staffs";

                }
                else
                {
                    txt_total_staffs.Text = dt1.Rows[0][0].ToString();

                }

                DataTable dt2 = data.display("Select Count(*) from Appointment");

                if (dt2.Rows.Count == 0)
                {
                    txt_total_appointmentss.Text = "No Appointments";

                }
                else
                {
                    txt_total_appointmentss.Text = dt2.Rows[0][0].ToString();

                }

                DataTable dt3 = data.display("Select Count(*) from Appointment");
                DataTable dt4 = data.display("Select Count(*) from Appointment where adate='" + DateTime.Now + "'");
                DataTable dt5 = data.display("Select Count(*) from Appointment where adate!='" + DateTime.Now + "'");


                if (dt3.Rows.Count == 0)
                {
                    doughnut1(0, 0, 0);

                }
                else
                {

                    if (dt5.Rows.Count == 0)
                    {
                        doughnut1(Convert.ToInt32(dt3.Rows[0][0]), Convert.ToInt32(dt4.Rows[0][0]), 0);

                    }
                    else if (dt4.Rows.Count == 0)
                    {
                        doughnut1(Convert.ToInt32(dt3.Rows[0][0]), 0, Convert.ToInt32(dt5.Rows[0][0]));

                    }
                    else
                    {
                        doughnut1(Convert.ToInt32(dt3.Rows[0][0]), Convert.ToInt32(dt4.Rows[0][0]), Convert.ToInt32(dt5.Rows[0][0]));

                    }
                }



                DataTable dt6 = data.display("Select stime,count(*) from Appointment  group by stime");


                if (dt6.Rows.Count == 0)
                {
                    doughnut2("NO", 0, "NO", 0, "NO", 0, "NO", 0);

                }
                else if (dt6.Rows.Count == 1)
                {
                    doughnut2(dt6.Rows[0][0].ToString(), Convert.ToInt32(dt6.Rows[0][1]), "NO", 0, "NO", 0, "NO", 0);

                }
                else if (dt6.Rows.Count == 2)
                {
                    doughnut2(dt6.Rows[0][0].ToString(), Convert.ToInt32(dt6.Rows[0][1]), dt6.Rows[1][0].ToString(), Convert.ToInt32(dt6.Rows[1][1]), "NO", 0, "NO", 0);

                }
                else if (dt6.Rows.Count == 3)
                {
                    doughnut2(dt6.Rows[0][0].ToString(), Convert.ToInt32(dt6.Rows[0][1]), dt6.Rows[1][0].ToString(), Convert.ToInt32(dt6.Rows[1][1]), dt6.Rows[2][0].ToString(), Convert.ToInt32(dt6.Rows[2][1]), "NO", 0);

                }
                else if (dt6.Rows.Count == 4)
                {
                    doughnut2(dt6.Rows[0][0].ToString(), Convert.ToInt32(dt6.Rows[0][1]), dt6.Rows[1][0].ToString(), Convert.ToInt32(dt6.Rows[1][1]), dt6.Rows[2][0].ToString(), Convert.ToInt32(dt6.Rows[2][1]), dt6.Rows[3][0].ToString(), Convert.ToInt32(dt6.Rows[3][1]));

                }


                DataTable dt7 = data.display("Select Month(adate),count(*) from Appointment  group by month(adate) having month(adate)='" + DateTime.Now.Month + "' order by month(adate) desc");

                if (dt7.Rows.Count == 0)
                {
                    doughnut3(0, 0, 0);

                }
                else if (dt7.Rows.Count == 1)
                {
                    doughnut3(Convert.ToInt32(dt7.Rows[0][1]), 0, 0);

                }
                else if (dt7.Rows.Count == 2)
                {
                    doughnut3(Convert.ToInt32(dt7.Rows[0][1]), Convert.ToInt32(dt7.Rows[1][1]), 0);

                }
                else if (dt7.Rows.Count == 3)
                {
                    doughnut3(Convert.ToInt32(dt7.Rows[0][1]), Convert.ToInt32(dt7.Rows[1][1]), Convert.ToInt32(dt7.Rows[2][1]));

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


        public void doughnut1(int a, int b, int c)
        {
            seriesCollection1 = new SeriesCollection
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


        public SeriesCollection seriesCollection1 { get; set; }

        public void doughnut2(string a, int a1, string b, int b1, string c, int c1, string d, int d1)
        {
            seriesCollection2 = new SeriesCollection
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
        public SeriesCollection seriesCollection2 { get; set; }

        public void doughnut3(int a, int b, int c)
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
                    Fill=System.Windows.Media.Brushes.Red,
                },


            };

            DataContext = this;
        }
        public SeriesCollection seriesCollection3 { get; set; }
       
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

        private void btn_new_staff_Click(object sender, RoutedEventArgs e)
        {
            form_MedicalAdminRegistration obj = new form_MedicalAdminRegistration(cc.PassLogin());
            obj.Show();
            this.Hide();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            addDetails();
            error_update_staff_profile.Visibility = Visibility.Collapsed;
            error_delete_staff_profile.Visibility = Visibility.Collapsed;
            error_staff_message.Visibility = Visibility.Collapsed;
            error_staff_id_message.Visibility = Visibility.Collapsed;
        }
        private int checkpatinetid(string var)
        {
            int c;
            DataTable dt = data.display("Select * from Medical_staff where sid COLLATE Latin1_General_CS_AS ='" + var + "'");
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
        private void btn_new_staffs_Click(object sender, RoutedEventArgs e)
        {
            form_MedicalAdminRegistration obj = new form_MedicalAdminRegistration(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_staff_profile_update_Click(object sender, RoutedEventArgs e)
        {
            error_update_staff_profile.Visibility = Visibility.Collapsed;

            int c = checkpatinetid(txt_staff_id_check_update_pfile.Text);

            if (c == 0)
            {
                txt_staff_id_check_update_pfile.Focus();
                txt_error_update_staff_profile.Text = "Enter a Valid Id!";
                error_update_staff_profile.Visibility = Visibility.Visible;
            }
            else
            {
                cc.setPath(1);
                cc.SetSno(txt_staff_id_check_update_pfile.Text);
                form_MedicalStaffUpdateProfile obj = new form_MedicalStaffUpdateProfile(cc.PassLogin());
                obj.Show();
                this.Hide();
            }
        }

        private void txt_staff_id_check_update_pfile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_update_staff_profile.Visibility = Visibility.Collapsed;

        }

        private void txt_staff_notes_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_staff_message.Visibility = Visibility.Collapsed;
            error_staff_id_message.Visibility = Visibility.Collapsed;

        }

        private void txt_staff_id_notice_check_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_staff_message.Visibility = Visibility.Collapsed;
            error_staff_id_message.Visibility = Visibility.Collapsed;

        }

        private void btn_staff_send_message_Click(object sender, RoutedEventArgs e)
        {
            error_staff_id_message.Visibility = Visibility.Collapsed;
            error_staff_message.Visibility = Visibility.Collapsed;


            int c = checkpatinetid(txt_staff_id_notice_check.Text);

            if (c == 0)
            {
                txt_staff_id_notice_check.Focus();
                txt_error_staff_id_message.Text = "Enter a Valid Id!";
                error_staff_id_message.Visibility = Visibility.Visible;
            }
            else if ((obj.NullValidation(txt_staff_notes.Text)) == 0)
            {
                txt_staff_notes.Focus();
                txt_error_staff_message.Text = "Message cannot be blank!";
                error_staff_message.Visibility = Visibility.Visible;
            }
            else
            {



                int f = data.Insert_Update_Delete("Update Medical_staff set messagee='" + txt_staff_notes.Text + "' where sid='" + txt_staff_id_notice_check.Text + "'");

                txt_staff_notes.Clear();
                txt_staff_id_notice_check.Clear();
                MessageBox.Show("Message has successfully sent.", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);


            }


        }

        private void btn_back_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_AdminDoctors obj = new form_AdminDoctors(cc.PassLogin());
            obj.Show();
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

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_staff_profile_delete_Click(object sender, RoutedEventArgs e)
        {
            error_delete_staff_profile.Visibility = Visibility.Collapsed;

            int c = checkpatinetid(txt_staff_id_check_delete_pfile.Text);
            if (c == 0)
            {
                txt_staff_id_check_delete_pfile.Focus();
                txt_error_delete_staff_profile.Text = "Enter a valid ID!";
                error_delete_staff_profile.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to Delete  the Staff Profile?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {


                        DataTable dt = data.display("Select UID from Medical_staff where sID='" + txt_staff_id_check_delete_pfile.Text + "'");
                        string uid = dt.Rows[0][0].ToString();


                        string t = "Delete from Medical_staff where sid='" + txt_staff_id_check_delete_pfile.Text + "'";
                        string r = "Delete from login where username='" + uid + "'";


                        int g = data.Insert_Update_Delete(t);
                        int g1 = data.Insert_Update_Delete(r);


                        if (g == 1 & g1 == 1)
                        {
                            MessageBox.Show("You successfully deleted the Staff profile.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        }

                        txt_staff_id_check_delete_pfile.Clear();

                    }
                    else
                    {
                        txt_staff_id_check_delete_pfile.Clear();

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

        private void txt_staff_id_check_delete_pfile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_delete_staff_profile.Visibility = Visibility.Collapsed;
        }
    }
}
