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
    /// Interaction logic for form_MedicalAdminAppointments.xaml
    /// </summary>
    public partial class form_MedicalAdminAppointments : Window
    {
        Controller cc = new Controller();
        Validation obj = new Validation();
        string login;
        string sno;
        DataBaseConnection data = new DataBaseConnection();
        public form_MedicalAdminAppointments(string login)
        {
            this.login = login;
            InitializeComponent();
        }
       
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void btn_general_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminDashBoard obj_medicaladmindashboard = new form_MedicalAdminDashBoard(cc.PassLogin());
            obj_medicaladmindashboard.Show();
            this.Hide();
        }

        private void btn_profile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminProfile obj_medicaladminprofile = new form_MedicalAdminProfile(cc.PassLogin());
            obj_medicaladminprofile.Show();
            this.Hide();
        }

        private void btn_doctors_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminDoctors obj_medicaladmindoctors = new form_MedicalAdminDoctors(cc.PassLogin());
            obj_medicaladmindoctors.Show();
            this.Hide();
        }


        private void btn_patients_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminPatient obj_medicaladminpatient = new form_MedicalAdminPatient(cc.PassLogin());
            obj_medicaladminpatient.Show();
            this.Hide();
        }
        private void addDetails()
        {
            try
            {

                DataTable dt = data.display("Select tittle,Fname,sid from Login,Medical_staff where Login.username=Medical_staff.UID and UID='" + login + "'");
                sno = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());


                DataTable dt1 = data.display("Select Count(*) from Appointment");
                DataTable dt2 = data.display("Select Count(*) from Appointment where adate='" + DateTime.Now + "'");
                DataTable dt3 = data.display("Select Count(*) from Appointment where adate!='" + DateTime.Now + "'");

                if (dt1.Rows.Count == 0)
                {
                    total_Appointments.Text = "No Appointments";

                }
                else
                {

                    total_Appointments.Text = dt1.Rows[0][0].ToString();

                }


                if (dt2.Rows.Count == 0)
                {
                    new_Appointments.Text = "No Appointments";

                }
                else
                {
                    new_Appointments.Text = dt2.Rows[0][0].ToString();

                }


                if (dt3.Rows.Count == 0)
                {
                    old_Appointments.Text = "No Appointments";

                }
                else
                {
                    old_Appointments.Text = dt3.Rows[0][0].ToString();

                }

                DataTable dt4 = data.display("Select Count(*) from Appointment where adate='" + DateTime.Now + "' and stime='07.00am' ");

                if (dt4.Rows.Count == 0)
                {
                    Appointments7_10.Text = "No Appointments";

                }
                else
                {
                    Appointments7_10.Text = dt4.Rows[0][0].ToString();

                }


                DataTable dt5 = data.display("Select Count(*) from Appointment where adate='" + DateTime.Now + "' and stime='11.00am' ");

                if (dt5.Rows.Count == 0)
                {
                    Appointments11_14.Text = "No Appointments";

                }
                else
                {
                    Appointments11_14.Text = dt5.Rows[0][0].ToString();

                }

                DataTable dt6 = data.display("Select Count(*) from Appointment where adate='" + DateTime.Now + "' and stime='15.00pm' ");

                if (dt6.Rows.Count == 0)
                {
                    Appointments15_18.Text = "No Appointments";

                }
                else
                {
                    Appointments15_18.Text = dt6.Rows[0][0].ToString();

                }
                DataTable dt7 = data.display("Select Count(*) from Appointment where adate='" + DateTime.Now + "' and stime='19.00pm' ");

                if (dt6.Rows.Count == 0)
                {
                    Appointments19_22.Text = "No Appointments";

                }
                else
                {
                    Appointments19_22.Text = dt7.Rows[0][0].ToString();

                }


                cmb_doc_name.Items.Clear();

                string Query = "Select did from Doc_schedule,doctor where Doc_schedule.Dno=Doctor.Did and sdate='" + DateTime.Now + "' ";

                DataTable dt8 = data.display(Query);
                if (dt.Rows.Count > 0)
                {

                    for (int c = 0; c < (dt8.Rows.Count); c++)
                    {

                        cmb_doc_name.Items.Add(dt8.Rows[c][0].ToString());

                    }


                }
                else
                {

                }

                DataTable dt9 = data.display("Select Count(*) from Appointment");
                int x = 0, y = 0;
                if (dt9.Rows.Count == 0)
                {
                    

                }
                else
                {
                    x = Convert.ToInt32(dt9.Rows[0][0]);

                }
                DataTable dt10 = data.display("Select Count(*) from Appointment where adate='"+DateTime.Now+"'");
                if (dt10.Rows.Count == 0)
                {


                }
                else
                {
                    y = Convert.ToInt32(dt10.Rows[0][0]);

                }

                barchart(x, y);

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
        private void barchart(int x,int y)
        {

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title="Appointments",
                    Values = new ChartValues<double>{x,y}
                }
            };


            BarLabels = new[] { "Total", "Today"};
            Formatter = value => value.ToString("N");

            DataContext = this;


        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] BarLabels { get; set; }

        public Func<double, string> Formatter { get; set; }
        private void clear()
        {
            error_cmb_doctor.Visibility = Visibility.Collapsed;
            error_cmb_timeslots.Visibility = Visibility.Collapsed;
        }
        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            cmb_doc_name.SelectedItem = null;
            clear();
            cmb_time_slots.SelectedItem = null;
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {

            clear();
            if (cmb_doc_name.SelectedItem == null)
            {
                cmb_doc_name.Focus();
                txt_error_cmb_doctor.Text = "Please choose a date!";
                error_cmb_doctor.Visibility = Visibility.Visible;
            }

            else if (cmb_time_slots.SelectedItem == null)
            {
                cmb_time_slots.Focus();
                txt_error_cmb_timeslots.Text = "Please choose a time slot!";
                error_cmb_timeslots.Visibility = Visibility.Visible;
            }

            else
            {
                try
                {

                    string stime = "";
                    if (cmb_time_slots.SelectedIndex == 0)
                    {
                        stime = "07.00am";
                    }
                    else if (cmb_time_slots.SelectedIndex == 2)
                    {
                        stime = "11.00am";
                    }
                    else if (cmb_time_slots.SelectedIndex == 4)
                    {
                        stime = "15.00pm";
                    }
                    else if (cmb_time_slots.SelectedIndex == 6)
                    {
                        stime = "19.00pm";
                    }


                    DataTable dt = data.display("Select Pno from Appointment where Adate = '" + DateTime.Now + "' AND  stime = '" + stime + "' and dno='" + cmb_doc_name.Text + "' ");
                    DataTable dt1 = data.display("Select Count(*) from Appointment where Adate = '" + DateTime.Now + "' AND  stime = '" + stime + "' and dno='" + cmb_doc_name.Text + "' ");


                    if (dt1.Rows.Count == 0)
                    {
                        total_appoinments.Text = "No Appointments";
                    }
                    else
                    {
                        total_appoinments.Text = dt1.Rows[0][0].ToString();

                    }

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

        private void app_1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (appointment_1_id.Text != "No Appointments")
                {
                    DataTable dt3 = data.display("Select Gname,telephone from Gurdian where Pno='" + appointment_1_id.Text + "' ");

                    DataTable dt2 = data.display("Select fname,lname,Age,Paddress,mobilephone,landphone from Patient where PID='" + appointment_1_id.Text + "' ");
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

                    DataTable dt3 = data.display("Select Gname,telephone from Gurdian where Pno='" + appointment_2_id.Text + "' ");

                    DataTable dt2 = data.display("Select fname,lname,Age,Paddress,mobilephone,landphone from Patient where PID='" + appointment_2_id.Text + "' ");
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
                    DataTable dt3 = data.display("Select Gname,telephone from Gurdian where Pno='" + appointment_3_id.Text + "' ");

                    DataTable dt2 = data.display("Select fname,lname,Age,Paddress,mobilephone,landphone from Patient where PID='" + appointment_3_id.Text + "' ");
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

                    DataTable dt3 = data.display("Select Gname,telephone from Gurdian where Pno='" + appointment_4_id.Text + "' ");

                    DataTable dt2 = data.display("Select fname,lname,Age,Paddress,mobilephone,landphone from Patient where PID='" + appointment_4_id.Text + "' ");
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
                    DataTable dt3 = data.display("Select Gname,telephone from Gurdian where Pno='" + appointment_5_id.Text + "' ");

                    DataTable dt2 = data.display("Select fname,lname,Age,Paddress,mobilephone,landphone from Patient where PID='" + appointment_5_id.Text + "' ");
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

                    DataTable dt3 = data.display("Select Gname,telephone from Gurdian where Pno='" + appointment_6_id.Text + "' ");

                    DataTable dt2 = data.display("Select fname,lname,Age,Paddress,mobilephone,landphone from Patient where PID='" + appointment_6_id.Text + "' ");
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            addDetails();
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

        private void btn_back_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_MedicalAdminPatient obj = new form_MedicalAdminPatient(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
