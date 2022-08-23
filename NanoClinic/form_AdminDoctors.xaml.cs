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
    /// Interaction logic for form_AdminDoctors.xaml
    /// </summary>
    public partial class form_AdminDoctors : Window
    {
        Controller cc = new Controller();
        Validation obj = new Validation();
        DataBaseConnection data = new DataBaseConnection();
        string login;
        string ano;
        public form_AdminDoctors(string login)
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
                DataTable dt = data.display("Select title,Fname,aid from Login,Admin where Login.username=Admin.UID and UID='" + login + "'");
                ano = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());


                DataTable dt1 = data.display("Select Count(*) from Doctor");

                if (dt1.Rows.Count == 0)
                {
                    txt_total_doctors.Text = "No Doctors";

                }
                else
                {
                    txt_total_doctors.Text = dt1.Rows[0][0].ToString();

                }

                DataTable dt2 = data.display("Select Count(*) from Doc_schedule");

                if (dt2.Rows.Count == 0)
                {
                    txt_total_schedules.Text = "No Schedules";

                }
                else
                {
                    txt_total_schedules.Text = dt2.Rows[0][0].ToString();

                }

                DataTable dt3 = data.display("Select Count(*) from Doc_schedule");
                DataTable dt4 = data.display("Select Count(*) from Doc_schedule where Sdate='" + DateTime.Now + "'");
                DataTable dt5 = data.display("Select Count(*) from Doc_schedule where Sdate!='" + DateTime.Now + "'");


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



                DataTable dt6 = data.display("Select stime,count(*) from Doc_schedule  group by stime");


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


                DataTable dt7 = data.display("Select Month(sdate),count(*) from Doc_schedule  group by month(sdate) having month(sdate)='" + DateTime.Now.Month + "' order by month(sdate) desc");

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

        private void btn_admin_medicaladmins_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_AdminMedicalAdmin obj_adminmedicaladmin = new form_AdminMedicalAdmin(cc.PassLogin());
            obj_adminmedicaladmin.Show();
            this.Hide();
        }

        private void btn_new_doctors_Click(object sender, RoutedEventArgs e)
        {
            form_DoctorRegistration obj = new form_DoctorRegistration(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            addDetails();
            error_update_doctor_profile.Visibility = Visibility.Collapsed;
            error_delete_doctor_profile.Visibility = Visibility.Collapsed;
            error_doctor_message.Visibility = Visibility.Collapsed;
            error_doctor_id_message.Visibility = Visibility.Collapsed;

        }

        private int checkpatinetid(string var)
        {
            int c;
            DataTable dt = data.display("Select * from Doctor where did COLLATE Latin1_General_CS_AS ='" + var + "'");
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
        private void btn_doctor_profile_update_Click(object sender, RoutedEventArgs e)
        {

            error_update_doctor_profile.Visibility = Visibility.Collapsed;

            int c = checkpatinetid(txt_doctor_id_check_update_pfile.Text);

            if (c == 0)
            {
                txt_doctor_id_check_update_pfile.Focus();
                txt_error_update_doctor_profile.Text = "Enter a Valid Id!";
                error_update_doctor_profile.Visibility = Visibility.Visible;
            }
            else
            {
                cc.setPath(1);
                cc.SetDno(txt_doctor_id_check_update_pfile.Text);
                form_doctorUpdateProfile obj = new form_doctorUpdateProfile(cc.PassLogin());
                obj.Show();
                this.Hide();
            }
        }

        private void txt_doctor_id_check_update_pfile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_update_doctor_profile.Visibility = Visibility.Collapsed;

        }

        private void btn_doctr_send_message_Click(object sender, RoutedEventArgs e)
        {
            error_doctor_message.Visibility = Visibility.Collapsed;
            error_doctor_id_message.Visibility = Visibility.Collapsed;

            int c = checkpatinetid(txt_doctor_id_notice_check.Text);

            if (c == 0)
            {
                txt_doctor_id_notice_check.Focus();
                txt_error_doctor_id_message.Text = "Enter a Valid Id!";
                error_doctor_id_message.Visibility = Visibility.Visible;
            }
            else if ((obj.NullValidation(txt_doctor_notes.Text)) == 0)
            {
                txt_doctor_notes.Focus();
                txt_error_doctor_message.Text = "Message cannot be blank!";
                error_doctor_message.Visibility = Visibility.Visible;
            }
            else
            {



                int f = data.Insert_Update_Delete("Update Doctor set messagee='"+txt_doctor_notes.Text+"' where did='"+txt_doctor_id_notice_check.Text+"'");

                txt_doctor_notes.Clear();
                txt_doctor_id_notice_check.Clear();



                MessageBox.Show("Message has successfully sent.", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);


            }
        }

        private void txt_doctor_id_notice_check_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_doctor_message.Visibility = Visibility.Collapsed;
            error_doctor_id_message.Visibility = Visibility.Collapsed;
        }

        private void txt_doctor_notes_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_doctor_message.Visibility = Visibility.Collapsed;
            error_doctor_id_message.Visibility = Visibility.Collapsed;
        }

        private void btn_back_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_AdminProfile obj = new form_AdminProfile(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_AdminMedicalAdmin obj = new form_AdminMedicalAdmin(cc.PassLogin());
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

        private void btn_doctor_profile_delete_Click(object sender, RoutedEventArgs e)
        {
            error_delete_doctor_profile.Visibility = Visibility.Collapsed;

            int c = checkpatinetid(txt_doctor_id_check_delete_pfile.Text);
            if (c == 0)
            {
                txt_doctor_id_check_delete_pfile.Focus();
                txt_error_delete_doctor_profile.Text = "Enter a valid ID!";
                error_delete_doctor_profile.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to Delete  the Doctor Profile?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {


                        DataTable dt = data.display("Select UID from Doctor where dID='" + txt_doctor_id_check_delete_pfile.Text + "'");
                        string uid = dt.Rows[0][0].ToString();


                        string u = "Delete from Doc_Schedule where dno = '" + txt_doctor_id_check_delete_pfile.Text + "'";
                        string t = "Delete from Doctor where did='" + txt_doctor_id_check_delete_pfile.Text + "'";
                        string r = "Delete from login where username='" + uid + "'";


                        int f = data.Insert_Update_Delete(u);
                        int g = data.Insert_Update_Delete(t);
                        int g1 = data.Insert_Update_Delete(r);


                        if (f==1 & g==1 & g1==1)
                        {
                            MessageBox.Show("You successfully deleted the Patient profile.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        }

                        txt_doctor_id_check_delete_pfile.Clear();

                    }
                    else
                    {
                        txt_doctor_id_check_delete_pfile.Clear();

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

        private void txt_doctor_id_check_delete_pfile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_delete_doctor_profile.Visibility = Visibility.Collapsed;

        }
    }
    
}
