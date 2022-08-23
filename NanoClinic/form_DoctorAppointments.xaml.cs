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
    /// Interaction logic for form_DoctorAppointments.xaml
    /// </summary>
    public partial class form_DoctorAppointments : Window
    {
        string login;string dno;
        Controller cc = new Controller();
        DataBaseConnection data = new DataBaseConnection();

        public form_DoctorAppointments(string login)
        {
            InitializeComponent();
            this.login = login;
            
        }
        
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void btn_general_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_DoctorDashBoard obj_doctordashboard = new form_DoctorDashBoard(cc.PassLogin()) ;
            obj_doctordashboard.Show();
            this.Hide();
        }
        
        private void btn_profile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_DoctorProfile obj_doctorprofile = new form_DoctorProfile(cc.PassLogin());
            obj_doctorprofile.Show();
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
                    doughnut(0, 0, 0);

                }
                else
                {

                    if (dt3.Rows.Count == 0)
                    {
                        doughnut(Convert.ToInt32(dt1.Rows[0][0]), Convert.ToInt32(dt2.Rows[0][0]), 0);

                    }
                    else if (dt2.Rows.Count == 0)
                    {
                        doughnut(Convert.ToInt32(dt1.Rows[0][0]), 0, Convert.ToInt32(dt3.Rows[0][0]));

                    }
                    else
                    {
                        doughnut(Convert.ToInt32(dt1.Rows[0][0]), Convert.ToInt32(dt2.Rows[0][0]), Convert.ToInt32(dt3.Rows[0][0]));

                    }
                }

                txt_tottal_appointments.Text = dt1.Rows[0][0].ToString();
                txt_today_appointments.Text = dt2.Rows[0][0].ToString();

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

        public void doughnut(int a, int b, int c)
        {
            seriesCollection = new SeriesCollection
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


        public SeriesCollection seriesCollection { get; set; }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {

            clear();
            if (date_picker_schedule.SelectedDate == null)
            {
                date_picker_schedule.Focus();
               txt_error_date.Text = "Please choose a date!";
               error_date.Visibility = Visibility.Visible;
            }

            else if(cmb_doc_schedule.SelectedItem == null)
            {
                cmb_doc_schedule.Focus();
                txt_error_cmb_schedule.Text = "Please choose a time slot!";
                error_cmb_schedule.Visibility = Visibility.Visible;
            }

            else
            {
                try
                {

                    DataTable dt = data.display("Select Pno from Appointment where Adate = '" + date_picker_schedule.SelectedDate.Value + "' AND  stime = '" + cmb_doc_schedule.SelectedItem + "' ");

                    if (dt.Rows.Count == 0)
                    {
                        appointment_1_id.Text = "No Appointments";
                        appointment_2_id.Text = "No Appointments";
                        appointment_3_id.Text = "No Appointments";
                        appointment_4_id.Text = "No Appointments";
                        appointment_5_id.Text = "No Appointments";
                        appointment_6_id.Text = "No Appointments";
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        appointment_1_id.Text = dt.Rows[0][0].ToString();
                        appointment_2_id.Text = "No Appointments";
                        appointment_3_id.Text = "No Appointments";
                        appointment_4_id.Text = "No Appointments";
                        appointment_5_id.Text = "No Appointments";
                        appointment_6_id.Text = "No Appointments";
                    }
                    else if (dt.Rows.Count == 2)
                    {
                        appointment_1_id.Text = dt.Rows[0][0].ToString();
                        appointment_2_id.Text = dt.Rows[1][0].ToString();
                        appointment_3_id.Text = "No Appointments";
                        appointment_4_id.Text = "No Appointments";
                        appointment_5_id.Text = "No Appointments";
                        appointment_6_id.Text = "No Appointments";
                    }
                    else if (dt.Rows.Count == 3)
                    {
                        appointment_1_id.Text = dt.Rows[0][0].ToString();
                        appointment_2_id.Text = dt.Rows[1][0].ToString();
                        appointment_3_id.Text = dt.Rows[2][0].ToString();
                        appointment_4_id.Text = "No Appointments";
                        appointment_5_id.Text = "No Appointments";
                        appointment_6_id.Text = "No Appointments";
                    }
                    else if (dt.Rows.Count == 4)
                    {
                        appointment_1_id.Text = dt.Rows[0][0].ToString();
                        appointment_2_id.Text = dt.Rows[1][0].ToString();
                        appointment_3_id.Text = dt.Rows[2][0].ToString();
                        appointment_4_id.Text = dt.Rows[3][0].ToString();
                        appointment_5_id.Text = "No Appointments";
                        appointment_6_id.Text = "No Appointments";
                    }
                    else if (dt.Rows.Count == 5)
                    {
                        appointment_1_id.Text = dt.Rows[0][0].ToString();
                        appointment_2_id.Text = dt.Rows[1][0].ToString();
                        appointment_3_id.Text = dt.Rows[2][0].ToString();
                        appointment_4_id.Text = dt.Rows[3][0].ToString();
                        appointment_5_id.Text = dt.Rows[4][0].ToString();
                        appointment_6_id.Text = "No Appointments";
                    }
                    else if (dt.Rows.Count == 6 || dt.Rows.Count > 6)
                    {
                        appointment_1_id.Text = dt.Rows[0][0].ToString();
                        appointment_2_id.Text = dt.Rows[1][0].ToString();
                        appointment_3_id.Text = dt.Rows[2][0].ToString();
                        appointment_4_id.Text = dt.Rows[3][0].ToString();
                        appointment_5_id.Text = dt.Rows[4][0].ToString();
                        appointment_6_id.Text = dt.Rows[5][0].ToString();
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
        private void clear()
        {
            error_date.Visibility = Visibility.Collapsed;
            error_cmb_schedule.Visibility = Visibility.Collapsed;
        }

        private void date_picker_schedule_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                cmb_doc_schedule.Items.Clear();


                string Query = "Select Stime,etime from Doc_schedule where Dno = '" + dno + "' and sdate='" + date_picker_schedule.SelectedDate.Value + "' ";

                DataTable dt = data.display(Query);
                if (dt.Rows.Count > 0)
                {

                    for (int c = 0; c < (dt.Rows.Count); c++)
                    {

                        cmb_doc_schedule.Items.Add(dt.Rows[c][0].ToString());

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

        private void btn_back_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_DoctorProfile obj = new form_DoctorProfile(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_DoctorReports obj = new form_DoctorReports(cc.PassLogin());
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            addDetails();
            clear();
        }

        private void date_picker_schedule_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();

        }

        private void cmb_doc_schedule_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();

        }

        private void app_1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (appointment_1_id.Text != "No Appointments")
                {
                    DataTable dt1 = data.display("Select Height,Weight,Diabetes,Cholesterol,Allergic,Hbloodpresssure, Cancer,Depression,Alcoholuse,smorking,Druguse from Patient_Health where Pno='" + appointment_1_id.Text + "' and Height>=any( select max(Height) from Patient_health where Pno = '" + appointment_1_id.Text + "') ");
                    if (dt1.Rows.Count == 0)
                    {
                        txt_patient_height.Text = "Not yet updated";
                        txt_patient_weight.Text = "Not yet updated";
                        txt_patient_diabetes.Text = "Not yet updated";
                        txt_patient_cholestorole.Text = "Not yet updated";
                        txt_patient_allergic.Text = "Not yet updated";
                        txt_patient_bloodpressure.Text = "Not yet updated";
                        txt_patient_cancer.Text = "Not yet updated";
                        txt_patient_depression.Text = "Not yet updated";
                        txt_patient_alcohole.Text = "Not yet updated";
                        txt_patient_smoking.Text = "Not yet updated";
                        txt_patient_druguse.Text = "Not yet updated";
                    }
                    else
                    {
                        txt_patient_height.Text = dt1.Rows[0][0].ToString();
                        txt_patient_weight.Text = dt1.Rows[0][1].ToString();
                        txt_patient_diabetes.Text = dt1.Rows[0][2].ToString();
                        txt_patient_cholestorole.Text = dt1.Rows[0][3].ToString();
                        txt_patient_allergic.Text = dt1.Rows[0][4].ToString();
                        txt_patient_bloodpressure.Text = dt1.Rows[0][5].ToString();
                        txt_patient_cancer.Text = dt1.Rows[0][6].ToString();
                        txt_patient_depression.Text = dt1.Rows[0][7].ToString();
                        txt_patient_alcohole.Text = dt1.Rows[0][8].ToString();
                        txt_patient_smoking.Text = dt1.Rows[0][9].ToString();
                        txt_patient_druguse.Text = dt1.Rows[0][10].ToString();
                    }

                    DataTable dt2 = data.display("Select fname,lname,Age,Paddress,mobilephone,landphone from Patient where PID='" + appointment_1_id.Text + "' ");
                    DataTable dt3 = data.display("Select Gname,telephone from Gurdian where Pno='" + appointment_1_id.Text + "' ");

                    if (dt2.Rows.Count == 0 || dt3.Rows.Count == 0)
                    {
                        txt_patient_name.Text = "Not yet updated";

                        txt_patient_age.Text = "Not yet updated";
                        txt_patien_address.Text = "Not yet updated";
                        txt_patient_mobile.Text = "Not yet updated";
                        txt_patient_tel.Text = "Not yet updated";

                        txt_patient_gurdian_name.Text = "Not yet updated";
                        txt_patient_gurdian_tel.Text = "Not yet updated";
                    }
                    else
                    {
                        txt_patient_name.Text = dt2.Rows[0][0].ToString() + " " + dt2.Rows[0][1].ToString();

                        txt_patient_age.Text = dt2.Rows[0][2].ToString();
                        txt_patien_address.Text = dt2.Rows[0][3].ToString();
                        txt_patient_mobile.Text = dt2.Rows[0][4].ToString();
                        txt_patient_tel.Text = dt2.Rows[0][5].ToString();


                        txt_patient_gurdian_name.Text = dt3.Rows[0][0].ToString();
                        txt_patient_gurdian_tel.Text = dt3.Rows[0][1].ToString();
                    }





                }
                else
                {
                    txt_patient_height.Text = "Not yet updated";
                    txt_patient_weight.Text = "Not yet updated";
                    txt_patient_diabetes.Text = "Not yet updated";
                    txt_patient_cholestorole.Text = "Not yet updated";
                    txt_patient_allergic.Text = "Not yet updated";
                    txt_patient_bloodpressure.Text = "Not yet updated";
                    txt_patient_cancer.Text = "Not yet updated";
                    txt_patient_depression.Text = "Not yet updated";
                    txt_patient_alcohole.Text = "Not yet updated";
                    txt_patient_smoking.Text = "Not yet updated";
                    txt_patient_druguse.Text = "Not yet updated";

                    txt_patient_name.Text = "Not yet updated";
                    txt_patient_age.Text = "Not yet updated";
                    txt_patien_address.Text = "Not yet updated";
                    txt_patient_mobile.Text = "Not yet updated";
                    txt_patient_tel.Text = "Not yet updated";
                    txt_patient_gurdian_name.Text = "Not yet updated";
                    txt_patient_gurdian_tel.Text = "Not yet updated";
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

        private void app_2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (appointment_2_id.Text != "No Appointments")
                {
                    DataTable dt1 = data.display("Select Height,Weight,Diabetes,Cholesterol,Allergic,Hbloodpresssure, Cancer,Depression,Alcoholuse,smorking,Druguse from Patient_Health where Pno='" + appointment_2_id + "' and Height>=( select max(Height) from Patient_health where Pno = '" + appointment_2_id.Text + "') ");
                    if (dt1.Rows.Count == 0)
                    {
                        txt_patient_height.Text = "Not yet updated";
                        txt_patient_weight.Text = "Not yet updated";
                        txt_patient_diabetes.Text = "Not yet updated";
                        txt_patient_cholestorole.Text = "Not yet updated";
                        txt_patient_allergic.Text = "Not yet updated";
                        txt_patient_bloodpressure.Text = "Not yet updated";
                        txt_patient_cancer.Text = "Not yet updated";
                        txt_patient_depression.Text = "Not yet updated";
                        txt_patient_alcohole.Text = "Not yet updated";
                        txt_patient_smoking.Text = "Not yet updated";
                        txt_patient_druguse.Text = "Not yet updated";
                    }
                    else
                    {
                        txt_patient_height.Text = dt1.Rows[0][0].ToString();
                        txt_patient_weight.Text = dt1.Rows[0][1].ToString();
                        txt_patient_diabetes.Text = dt1.Rows[0][2].ToString();
                        txt_patient_cholestorole.Text = dt1.Rows[0][3].ToString();
                        txt_patient_allergic.Text = dt1.Rows[0][4].ToString();
                        txt_patient_bloodpressure.Text = dt1.Rows[0][5].ToString();
                        txt_patient_cancer.Text = dt1.Rows[0][6].ToString();
                        txt_patient_depression.Text = dt1.Rows[0][7].ToString();
                        txt_patient_alcohole.Text = dt1.Rows[0][8].ToString();
                        txt_patient_smoking.Text = dt1.Rows[0][9].ToString();
                        txt_patient_druguse.Text = dt1.Rows[0][10].ToString();
                    }

                    DataTable dt2 = data.display("Select fname,lname,Age,Paddress,mobilephone,landphone from Patient where PID='" + appointment_2_id.Text + "' ");
                    DataTable dt3 = data.display("Select Gname,telephone from Gurdian where Pno='" + appointment_2_id.Text + "' ");



                    if (dt2.Rows.Count == 0 || dt3.Rows.Count == 0)
                    {
                        txt_patient_name.Text = "Not yet updated";

                        txt_patient_age.Text = "Not yet updated";
                        txt_patien_address.Text = "Not yet updated";
                        txt_patient_mobile.Text = "Not yet updated";
                        txt_patient_tel.Text = "Not yet updated";

                        txt_patient_gurdian_name.Text = "Not yet updated";
                        txt_patient_gurdian_tel.Text = "Not yet updated";
                    }
                    else
                    {
                        txt_patient_name.Text = dt2.Rows[0][0].ToString() + " " + dt2.Rows[0][1].ToString();

                        txt_patient_age.Text = dt2.Rows[0][2].ToString();
                        txt_patien_address.Text = dt2.Rows[0][3].ToString();
                        txt_patient_mobile.Text = dt2.Rows[0][4].ToString();
                        txt_patient_tel.Text = dt2.Rows[0][5].ToString();


                        txt_patient_gurdian_name.Text = dt3.Rows[0][0].ToString();
                        txt_patient_gurdian_tel.Text = dt3.Rows[0][1].ToString();
                    }
                }
                else
                {
                    txt_patient_height.Text = "Not yet updated";
                    txt_patient_weight.Text = "Not yet updated";
                    txt_patient_diabetes.Text = "Not yet updated";
                    txt_patient_cholestorole.Text = "Not yet updated";
                    txt_patient_allergic.Text = "Not yet updated";
                    txt_patient_bloodpressure.Text = "Not yet updated";
                    txt_patient_cancer.Text = "Not yet updated";
                    txt_patient_depression.Text = "Not yet updated";
                    txt_patient_alcohole.Text = "Not yet updated";
                    txt_patient_smoking.Text = "Not yet updated";
                    txt_patient_druguse.Text = "Not yet updated";

                    txt_patient_name.Text = "Not yet updated";
                    txt_patient_age.Text = "Not yet updated";
                    txt_patien_address.Text = "Not yet updated";
                    txt_patient_mobile.Text = "Not yet updated";
                    txt_patient_tel.Text = "Not yet updated";
                    txt_patient_gurdian_name.Text = "Not yet updated";
                    txt_patient_gurdian_tel.Text = "Not yet updated";
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

        private void app_3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (appointment_3_id.Text != "No Appointments")
                {
                    DataTable dt1 = data.display("Select Height,Weight,Diabetes,Cholesterol,Allergic,Hbloodpresssure, Cancer,Depression,Alcoholuse,smorking,Druguse from Patient_Health where Pno='" + appointment_3_id + "' and Height>=( select max(Height) from Patient_health where Pno = '" + appointment_3_id.Text + "') ");
                    if (dt1.Rows.Count == 0)
                    {
                        txt_patient_height.Text = "Not yet updated";
                        txt_patient_weight.Text = "Not yet updated";
                        txt_patient_diabetes.Text = "Not yet updated";
                        txt_patient_cholestorole.Text = "Not yet updated";
                        txt_patient_allergic.Text = "Not yet updated";
                        txt_patient_bloodpressure.Text = "Not yet updated";
                        txt_patient_cancer.Text = "Not yet updated";
                        txt_patient_depression.Text = "Not yet updated";
                        txt_patient_alcohole.Text = "Not yet updated";
                        txt_patient_smoking.Text = "Not yet updated";
                        txt_patient_druguse.Text = "Not yet updated";
                    }
                    else
                    {
                        txt_patient_height.Text = dt1.Rows[0][0].ToString();
                        txt_patient_weight.Text = dt1.Rows[0][1].ToString();
                        txt_patient_diabetes.Text = dt1.Rows[0][2].ToString();
                        txt_patient_cholestorole.Text = dt1.Rows[0][3].ToString();
                        txt_patient_allergic.Text = dt1.Rows[0][4].ToString();
                        txt_patient_bloodpressure.Text = dt1.Rows[0][5].ToString();
                        txt_patient_cancer.Text = dt1.Rows[0][6].ToString();
                        txt_patient_depression.Text = dt1.Rows[0][7].ToString();
                        txt_patient_alcohole.Text = dt1.Rows[0][8].ToString();
                        txt_patient_smoking.Text = dt1.Rows[0][9].ToString();
                        txt_patient_druguse.Text = dt1.Rows[0][10].ToString();
                    }

                    DataTable dt2 = data.display("Select fname,lname,Age,Paddress,mobilephone,landphone from Patient where PID='" + appointment_3_id.Text + "' ");
                    DataTable dt3 = data.display("Select Gname,telephone from Gurdian where Pno='" + appointment_3_id.Text + "' ");




                    if (dt2.Rows.Count == 0 || dt3.Rows.Count == 0)
                    {
                        txt_patient_name.Text = "Not yet updated";

                        txt_patient_age.Text = "Not yet updated";
                        txt_patien_address.Text = "Not yet updated";
                        txt_patient_mobile.Text = "Not yet updated";
                        txt_patient_tel.Text = "Not yet updated";

                        txt_patient_gurdian_name.Text = "Not yet updated";
                        txt_patient_gurdian_tel.Text = "Not yet updated";
                    }
                    else
                    {
                        txt_patient_name.Text = dt2.Rows[0][0].ToString() + " " + dt2.Rows[0][1].ToString();

                        txt_patient_age.Text = dt2.Rows[0][2].ToString();
                        txt_patien_address.Text = dt2.Rows[0][3].ToString();
                        txt_patient_mobile.Text = dt2.Rows[0][4].ToString();
                        txt_patient_tel.Text = dt2.Rows[0][5].ToString();


                        txt_patient_gurdian_name.Text = dt3.Rows[0][0].ToString();
                        txt_patient_gurdian_tel.Text = dt3.Rows[0][1].ToString();
                    }

                }
                else
                {
                    txt_patient_height.Text = "Not yet updated";
                    txt_patient_weight.Text = "Not yet updated";
                    txt_patient_diabetes.Text = "Not yet updated";
                    txt_patient_cholestorole.Text = "Not yet updated";
                    txt_patient_allergic.Text = "Not yet updated";
                    txt_patient_bloodpressure.Text = "Not yet updated";
                    txt_patient_cancer.Text = "Not yet updated";
                    txt_patient_depression.Text = "Not yet updated";
                    txt_patient_alcohole.Text = "Not yet updated";
                    txt_patient_smoking.Text = "Not yet updated";
                    txt_patient_druguse.Text = "Not yet updated";

                    txt_patient_name.Text = "Not yet updated";
                    txt_patient_age.Text = "Not yet updated";
                    txt_patien_address.Text = "Not yet updated";
                    txt_patient_mobile.Text = "Not yet updated";
                    txt_patient_tel.Text = "Not yet updated";
                    txt_patient_gurdian_name.Text = "Not yet updated";
                    txt_patient_gurdian_tel.Text = "Not yet updated";
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

        private void app_4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (appointment_4_id.Text != "No Appointments")
                {
                    DataTable dt1 = data.display("Select Height,Weight,Diabetes,Cholesterol,Allergic,Hbloodpresssure, Cancer,Depression,Alcoholuse,smorking,Druguse from Patient_Health where Pno='" + appointment_4_id + "' and Height>=( select max(Height) from Patient_health where Pno = '" + appointment_4_id.Text + "') ");
                    if (dt1.Rows.Count == 0)
                    {
                        txt_patient_height.Text = "Not yet updated";
                        txt_patient_weight.Text = "Not yet updated";
                        txt_patient_diabetes.Text = "Not yet updated";
                        txt_patient_cholestorole.Text = "Not yet updated";
                        txt_patient_allergic.Text = "Not yet updated";
                        txt_patient_bloodpressure.Text = "Not yet updated";
                        txt_patient_cancer.Text = "Not yet updated";
                        txt_patient_depression.Text = "Not yet updated";
                        txt_patient_alcohole.Text = "Not yet updated";
                        txt_patient_smoking.Text = "Not yet updated";
                        txt_patient_druguse.Text = "Not yet updated";
                    }
                    else
                    {
                        txt_patient_height.Text = dt1.Rows[0][0].ToString();
                        txt_patient_weight.Text = dt1.Rows[0][1].ToString();
                        txt_patient_diabetes.Text = dt1.Rows[0][2].ToString();
                        txt_patient_cholestorole.Text = dt1.Rows[0][3].ToString();
                        txt_patient_allergic.Text = dt1.Rows[0][4].ToString();
                        txt_patient_bloodpressure.Text = dt1.Rows[0][5].ToString();
                        txt_patient_cancer.Text = dt1.Rows[0][6].ToString();
                        txt_patient_depression.Text = dt1.Rows[0][7].ToString();
                        txt_patient_alcohole.Text = dt1.Rows[0][8].ToString();
                        txt_patient_smoking.Text = dt1.Rows[0][9].ToString();
                        txt_patient_druguse.Text = dt1.Rows[0][10].ToString();
                    }

                    DataTable dt2 = data.display("Select fname,lname,Age,Paddress,mobilephone,landphone from Patient where PID='" + appointment_4_id.Text + "' ");
                    DataTable dt3 = data.display("Select Gname,telephone from Gurdian where Pno='" + appointment_4_id.Text + "' ");






                    if (dt2.Rows.Count == 0 || dt3.Rows.Count == 0)
                    {
                        txt_patient_name.Text = "Not yet updated";

                        txt_patient_age.Text = "Not yet updated";
                        txt_patien_address.Text = "Not yet updated";
                        txt_patient_mobile.Text = "Not yet updated";
                        txt_patient_tel.Text = "Not yet updated";

                        txt_patient_gurdian_name.Text = "Not yet updated";
                        txt_patient_gurdian_tel.Text = "Not yet updated";
                    }
                    else
                    {
                        txt_patient_name.Text = dt2.Rows[0][0].ToString() + " " + dt2.Rows[0][1].ToString();

                        txt_patient_age.Text = dt2.Rows[0][2].ToString();
                        txt_patien_address.Text = dt2.Rows[0][3].ToString();
                        txt_patient_mobile.Text = dt2.Rows[0][4].ToString();
                        txt_patient_tel.Text = dt2.Rows[0][5].ToString();


                        txt_patient_gurdian_name.Text = dt3.Rows[0][0].ToString();
                        txt_patient_gurdian_tel.Text = dt3.Rows[0][1].ToString();
                    }


                }
                else
                {
                    txt_patient_height.Text = "Not yet updated";
                    txt_patient_weight.Text = "Not yet updated";
                    txt_patient_diabetes.Text = "Not yet updated";
                    txt_patient_cholestorole.Text = "Not yet updated";
                    txt_patient_allergic.Text = "Not yet updated";
                    txt_patient_bloodpressure.Text = "Not yet updated";
                    txt_patient_cancer.Text = "Not yet updated";
                    txt_patient_depression.Text = "Not yet updated";
                    txt_patient_alcohole.Text = "Not yet updated";
                    txt_patient_smoking.Text = "Not yet updated";
                    txt_patient_druguse.Text = "Not yet updated";

                    txt_patient_name.Text = "Not yet updated";
                    txt_patient_age.Text = "Not yet updated";
                    txt_patien_address.Text = "Not yet updated";
                    txt_patient_mobile.Text = "Not yet updated";
                    txt_patient_tel.Text = "Not yet updated";
                    txt_patient_gurdian_name.Text = "Not yet updated";
                    txt_patient_gurdian_tel.Text = "Not yet updated";
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

        private void app_5_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (appointment_5_id.Text != "No Appointments")
                {
                    DataTable dt1 = data.display("Select Height,Weight,Diabetes,Cholesterol,Allergic,Hbloodpresssure, Cancer,Depression,Alcoholuse,smorking,Druguse from Patient_Health where Pno='" + appointment_5_id + "' and Height>=( select max(Height) from Patient_health where Pno = '" + appointment_5_id.Text + "') ");
                    if (dt1.Rows.Count == 0)
                    {
                        txt_patient_height.Text = "Not yet updated";
                        txt_patient_weight.Text = "Not yet updated";
                        txt_patient_diabetes.Text = "Not yet updated";
                        txt_patient_cholestorole.Text = "Not yet updated";
                        txt_patient_allergic.Text = "Not yet updated";
                        txt_patient_bloodpressure.Text = "Not yet updated";
                        txt_patient_cancer.Text = "Not yet updated";
                        txt_patient_depression.Text = "Not yet updated";
                        txt_patient_alcohole.Text = "Not yet updated";
                        txt_patient_smoking.Text = "Not yet updated";
                        txt_patient_druguse.Text = "Not yet updated";
                    }
                    else
                    {
                        txt_patient_height.Text = dt1.Rows[0][0].ToString();
                        txt_patient_weight.Text = dt1.Rows[0][1].ToString();
                        txt_patient_diabetes.Text = dt1.Rows[0][2].ToString();
                        txt_patient_cholestorole.Text = dt1.Rows[0][3].ToString();
                        txt_patient_allergic.Text = dt1.Rows[0][4].ToString();
                        txt_patient_bloodpressure.Text = dt1.Rows[0][5].ToString();
                        txt_patient_cancer.Text = dt1.Rows[0][6].ToString();
                        txt_patient_depression.Text = dt1.Rows[0][7].ToString();
                        txt_patient_alcohole.Text = dt1.Rows[0][8].ToString();
                        txt_patient_smoking.Text = dt1.Rows[0][9].ToString();
                        txt_patient_druguse.Text = dt1.Rows[0][10].ToString();
                    }

                    DataTable dt2 = data.display("Select fname,lname,Age,Paddress,mobilephone,landphone from Patient where PID='" + appointment_5_id.Text + "' ");
                    DataTable dt3 = data.display("Select Gname,telephone from Gurdian where Pno='" + appointment_5_id.Text + "' ");






                    if (dt2.Rows.Count == 0 || dt3.Rows.Count == 0)
                    {
                        txt_patient_name.Text = "Not yet updated";

                        txt_patient_age.Text = "Not yet updated";
                        txt_patien_address.Text = "Not yet updated";
                        txt_patient_mobile.Text = "Not yet updated";
                        txt_patient_tel.Text = "Not yet updated";

                        txt_patient_gurdian_name.Text = "Not yet updated";
                        txt_patient_gurdian_tel.Text = "Not yet updated";
                    }
                    else
                    {
                        txt_patient_name.Text = dt2.Rows[0][0].ToString() + " " + dt2.Rows[0][1].ToString();

                        txt_patient_age.Text = dt2.Rows[0][2].ToString();
                        txt_patien_address.Text = dt2.Rows[0][3].ToString();
                        txt_patient_mobile.Text = dt2.Rows[0][4].ToString();
                        txt_patient_tel.Text = dt2.Rows[0][5].ToString();


                        txt_patient_gurdian_name.Text = dt3.Rows[0][0].ToString();
                        txt_patient_gurdian_tel.Text = dt3.Rows[0][1].ToString();
                    }


                }
                else
                {
                    txt_patient_height.Text = "Not yet updated";
                    txt_patient_weight.Text = "Not yet updated";
                    txt_patient_diabetes.Text = "Not yet updated";
                    txt_patient_cholestorole.Text = "Not yet updated";
                    txt_patient_allergic.Text = "Not yet updated";
                    txt_patient_bloodpressure.Text = "Not yet updated";
                    txt_patient_cancer.Text = "Not yet updated";
                    txt_patient_depression.Text = "Not yet updated";
                    txt_patient_alcohole.Text = "Not yet updated";
                    txt_patient_smoking.Text = "Not yet updated";
                    txt_patient_druguse.Text = "Not yet updated";

                    txt_patient_name.Text = "Not yet updated";
                    txt_patient_age.Text = "Not yet updated";
                    txt_patien_address.Text = "Not yet updated";
                    txt_patient_mobile.Text = "Not yet updated";
                    txt_patient_tel.Text = "Not yet updated";
                    txt_patient_gurdian_name.Text = "Not yet updated";
                    txt_patient_gurdian_tel.Text = "Not yet updated";
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

        private void app_6_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (appointment_6_id.Text != "No Appointments")
                {
                    DataTable dt1 = data.display("Select Height,Weight,Diabetes,Cholesterol,Allergic,Hbloodpresssure, Cancer,Depression,Alcoholuse,smorking,Druguse from Patient_Health where Pno='" + appointment_6_id + "' and Height>=( select max(Height) from Patient_health where Pno = '" + appointment_6_id.Text + "') ");
                    if (dt1.Rows.Count == 0)
                    {
                        txt_patient_height.Text = "Not yet updated";
                        txt_patient_weight.Text = "Not yet updated";
                        txt_patient_diabetes.Text = "Not yet updated";
                        txt_patient_cholestorole.Text = "Not yet updated";
                        txt_patient_allergic.Text = "Not yet updated";
                        txt_patient_bloodpressure.Text = "Not yet updated";
                        txt_patient_cancer.Text = "Not yet updated";
                        txt_patient_depression.Text = "Not yet updated";
                        txt_patient_alcohole.Text = "Not yet updated";
                        txt_patient_smoking.Text = "Not yet updated";
                        txt_patient_druguse.Text = "Not yet updated";
                    }
                    else
                    {
                        txt_patient_height.Text = dt1.Rows[0][0].ToString();
                        txt_patient_weight.Text = dt1.Rows[0][1].ToString();
                        txt_patient_diabetes.Text = dt1.Rows[0][2].ToString();
                        txt_patient_cholestorole.Text = dt1.Rows[0][3].ToString();
                        txt_patient_allergic.Text = dt1.Rows[0][4].ToString();
                        txt_patient_bloodpressure.Text = dt1.Rows[0][5].ToString();
                        txt_patient_cancer.Text = dt1.Rows[0][6].ToString();
                        txt_patient_depression.Text = dt1.Rows[0][7].ToString();
                        txt_patient_alcohole.Text = dt1.Rows[0][8].ToString();
                        txt_patient_smoking.Text = dt1.Rows[0][9].ToString();
                        txt_patient_druguse.Text = dt1.Rows[0][10].ToString();
                    }

                    DataTable dt2 = data.display("Select fname,lname,Age,Paddress,mobilephone,landphone from Patient where PID='" + appointment_6_id.Text + "' ");
                    DataTable dt3 = data.display("Select Gname,telephone from Gurdian where Pno='" + appointment_6_id.Text + "' ");




                    if (dt2.Rows.Count == 0 || dt3.Rows.Count == 0)
                    {
                        txt_patient_name.Text = "Not yet updated";

                        txt_patient_age.Text = "Not yet updated";
                        txt_patien_address.Text = "Not yet updated";
                        txt_patient_mobile.Text = "Not yet updated";
                        txt_patient_tel.Text = "Not yet updated";

                        txt_patient_gurdian_name.Text = "Not yet updated";
                        txt_patient_gurdian_tel.Text = "Not yet updated";
                    }
                    else
                    {
                        txt_patient_name.Text = dt2.Rows[0][0].ToString() + " " + dt2.Rows[0][1].ToString();

                        txt_patient_age.Text = dt2.Rows[0][2].ToString();
                        txt_patien_address.Text = dt2.Rows[0][3].ToString();
                        txt_patient_mobile.Text = dt2.Rows[0][4].ToString();
                        txt_patient_tel.Text = dt2.Rows[0][5].ToString();


                        txt_patient_gurdian_name.Text = dt3.Rows[0][0].ToString();
                        txt_patient_gurdian_tel.Text = dt3.Rows[0][1].ToString();
                    }
                }
                else
                {
                    txt_patient_height.Text = "Not yet updated";
                    txt_patient_weight.Text = "Not yet updated";
                    txt_patient_diabetes.Text = "Not yet updated";
                    txt_patient_cholestorole.Text = "Not yet updated";
                    txt_patient_allergic.Text = "Not yet updated";
                    txt_patient_bloodpressure.Text = "Not yet updated";
                    txt_patient_cancer.Text = "Not yet updated";
                    txt_patient_depression.Text = "Not yet updated";
                    txt_patient_alcohole.Text = "Not yet updated";
                    txt_patient_smoking.Text = "Not yet updated";
                    txt_patient_druguse.Text = "Not yet updated";

                    txt_patient_name.Text = "Not yet updated";
                    txt_patient_age.Text = "Not yet updated";
                    txt_patien_address.Text = "Not yet updated";
                    txt_patient_mobile.Text = "Not yet updated";
                    txt_patient_tel.Text = "Not yet updated";
                    txt_patient_gurdian_name.Text = "Not yet updated";
                    txt_patient_gurdian_tel.Text = "Not yet updated";
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


