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
    /// Interaction logic for form_DoctorSchedule.xaml
    /// </summary>
    public partial class form_DoctorSchedule : Window
    {
        DataBaseConnection data = new DataBaseConnection();
        Controller cc = new Controller();
        Validation obj = new Validation();

        string login;
        string Dno;

        public form_DoctorSchedule(string login)
        {
            this.login = login;
            InitializeComponent();
        }
        
        private void adddetails()
        {
            try
            {

                DataTable dt1 = data.display("Select DID,fname from Login, Doctor where Login.username=Doctor.UID and UID='" + login + "'");
                Dno = dt1.Rows[0][0].ToString();
                txt_username.Text = dt1.Rows[0][1].ToString();



                DataTable dt = data.display("Select Sdate,Stime from Doctor,Doc_Schedule where Doctor.DID=Doc_Schedule.Dno and Dno='" + Dno + "' and sdate>='" + DateTime.Now + "'");

                if (dt.Rows.Count == 0)
                {
                    Schedule_1_date.Text = "No Schedules";
                    Schedule_2_date.Text = "No Schedules";
                    Schedule_3_date.Text = "No Schedules";
                    Schedule_4_date.Text = "No Schedules";
                    Schedule_5_date.Text = "No Schedules";
                    Schedule_6_date.Text = "No Schedules";

                }

                else if (dt.Rows.Count == 1)
                {
                    Schedule_2_date.Text = "No Schedules";
                    Schedule_3_date.Text = "No Schedules";
                    Schedule_4_date.Text = "No Schedules";
                    Schedule_5_date.Text = "No Schedules";
                    Schedule_6_date.Text = "No Schedules";


                    Schedule_1_date.Text = dt.Rows[0][0].ToString();
                    Schedule_1_time.Text = dt.Rows[0][1].ToString();

                }

                else if (dt.Rows.Count == 2)
                {
                    Schedule_3_date.Text = "No Schedules";
                    Schedule_4_date.Text = "No Schedules";
                    Schedule_5_date.Text = "No Schedules";
                    Schedule_6_date.Text = "No Schedules";

                    Schedule_1_date.Text = dt.Rows[0][0].ToString();
                    Schedule_1_time.Text = dt.Rows[0][1].ToString();

                    Schedule_2_date.Text = dt.Rows[1][0].ToString();
                    Schedule_2_time.Text = dt.Rows[1][1].ToString();
                }

                else if (dt.Rows.Count == 3)
                {
                    Schedule_4_date.Text = "No Schedules";
                    Schedule_5_date.Text = "No Schedules";
                    Schedule_6_date.Text = "No Schedules";

                    Schedule_1_date.Text = dt.Rows[0][0].ToString();
                    Schedule_1_time.Text = dt.Rows[0][1].ToString();

                    Schedule_2_date.Text = dt.Rows[1][0].ToString();
                    Schedule_2_time.Text = dt.Rows[1][1].ToString();

                    Schedule_3_date.Text = dt.Rows[2][0].ToString();
                    Schedule_3_time.Text = dt.Rows[2][1].ToString();

                }

                else if (dt.Rows.Count == 4)
                {
                    Schedule_5_date.Text = "No Schedules";
                    Schedule_6_date.Text = "No Schedules";

                    Schedule_1_date.Text = dt.Rows[0][0].ToString();
                    Schedule_1_time.Text = dt.Rows[0][1].ToString();

                    Schedule_2_date.Text = dt.Rows[1][0].ToString();
                    Schedule_2_time.Text = dt.Rows[1][1].ToString();

                    Schedule_3_date.Text = dt.Rows[2][0].ToString();
                    Schedule_3_time.Text = dt.Rows[2][1].ToString();

                    Schedule_4_date.Text = dt.Rows[3][0].ToString();
                    Schedule_4_time.Text = dt.Rows[3][1].ToString();
                }

                else if (dt.Rows.Count == 5)
                {
                    Schedule_6_date.Text = "No Schedules";

                    Schedule_1_date.Text = dt.Rows[0][0].ToString();
                    Schedule_1_time.Text = dt.Rows[0][1].ToString();

                    Schedule_2_date.Text = dt.Rows[1][0].ToString();
                    Schedule_2_time.Text = dt.Rows[1][1].ToString();

                    Schedule_3_date.Text = dt.Rows[2][0].ToString();
                    Schedule_3_time.Text = dt.Rows[2][1].ToString();

                    Schedule_4_date.Text = dt.Rows[3][0].ToString();
                    Schedule_4_time.Text = dt.Rows[3][1].ToString();

                    Schedule_5_date.Text = dt.Rows[4][0].ToString();
                    Schedule_5_time.Text = dt.Rows[4][1].ToString();
                }

                else if (dt.Rows.Count >= 6)
                {
                    Schedule_1_date.Text = dt.Rows[0][0].ToString();
                    Schedule_1_time.Text = dt.Rows[0][1].ToString();

                    Schedule_2_date.Text = dt.Rows[1][0].ToString();
                    Schedule_2_time.Text = dt.Rows[1][1].ToString();

                    Schedule_3_date.Text = dt.Rows[2][0].ToString();
                    Schedule_3_time.Text = dt.Rows[2][1].ToString();

                    Schedule_4_date.Text = dt.Rows[3][0].ToString();
                    Schedule_4_time.Text = dt.Rows[3][1].ToString();

                    Schedule_5_date.Text = dt.Rows[4][0].ToString();
                    Schedule_5_time.Text = dt.Rows[4][1].ToString();

                    Schedule_6_date.Text = dt.Rows[5][0].ToString();
                    Schedule_6_time.Text = dt.Rows[5][1].ToString();
                }


                DataTable dt2 = data.display("Select stime from doc_schedule where dno='" + Dno + "' and sdate>='" + DateTime.Now + "'");
                if (dt2.Rows.Count == 0)
                {
                    txt_schedule_next.Text = "No Schedule";

                }
                else
                {
                    txt_schedule_next.Text = dt2.Rows[0][0].ToString();
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

        private void btn_patients_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_DoctorPatients obj_doctorpatients = new form_DoctorPatients(cc.PassLogin());
            obj_doctorpatients.Show();
            this.Hide();
        }


        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            ClearCreate();
            if (doctor_schedule_date_picker.SelectedDate == null)
            {
                doctor_schedule_date_picker.Focus();
                txt_error_date_picker_date.Text = "Please Select Date";
                error_date_picker_date.Visibility = Visibility.Visible;

            }
            else if (cmb_schedule_time_slots.SelectedItem == null)
            {
                cmb_schedule_time_slots.Focus();
                txt_error_cmb_time_slots.Text = "Please Select time slots";
                error_cmb_time_slots.Visibility = Visibility.Visible;

            }
            else
            {
                string stime="", etime="";
                if (cmb_schedule_time_slots.SelectedIndex==0)
                {
                    stime = "07.00am";
                    etime = "10.00am";
                }
                else if (cmb_schedule_time_slots.SelectedIndex == 2)
                {
                    stime = "11.00am";
                    etime = "14.00pm";
                }
                else if (cmb_schedule_time_slots.SelectedIndex == 4)
                {
                    stime = "15.00pm";
                    etime = "18.00pm";
                }
                else if (cmb_schedule_time_slots.SelectedIndex == 6)
                {
                    stime = "19.00pm";
                    etime = "22.00pm";
                }
                string b = "Insert into Doc_schedule values ('" + Dno + "','" + doctor_schedule_date_picker.SelectedDate + "','" +stime + "','"+etime+"')";

                int i = data.Insert_Update_Delete(b);

                if (i == 1)
                {
                    MessageBox.Show("Schedule Updated successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    doctor_schedule_date_picker.SelectedDate = null;
                    cmb_schedule_time_slots.SelectedItem = null;

                }
                else
                    MessageBox.Show("Schedule Update Not Successfull. Please Check Again!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            ClearCreate();
            doctor_schedule_date_picker.SelectedDate = null;
            cmb_schedule_time_slots.SelectedItem = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adddetails();
            ClearCreate();
            ClearDelete();
            calender.DisplayDate = DateTime.Now;
        }
        private void ClearCreate()
        {
            error_date_picker_date.Visibility = Visibility.Collapsed;
            error_cmb_time_slots.Visibility = Visibility.Collapsed;
        }

        private void doctor_schedule_date_picker_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearCreate();
        }

        private void cmb_schedule_time_slots_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearCreate();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            ClearDelete();
            if (doctor_cancel_date_picker.SelectedDate == null)
            {
                doctor_cancel_date_picker.Focus();
                txt_error_date_pecker_cancel.Text = "Please Select Date";
                error_date_picker_cancel.Visibility = Visibility.Visible;

            }
            else if (cmb_shedle.SelectedItem == null)
            {
                cmb_shedle.Focus();
                txt_error_cmb_schedule.Text = "Please Select time slots";
                error_cmb_schedule.Visibility = Visibility.Visible;

            }
            else
            {
                string q = "Delete from Doc_Schedule where Dno='"+Dno+"' and stime='"+cmb_shedle.SelectedItem+"'";
                int c = data.Insert_Update_Delete(q);

                if (c == 1)
                    MessageBox.Show("Schedule Deleted successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Schedule Delete Not Successfull. Please Check Again!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void doctor_cancel_date_picker_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearDelete();
        }

        private void cmb_shedle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearDelete();
        }

        private void doctor_cancel_date_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            string Query = "Select Stime,etime from Doc_schedule where Dno = '" + Dno + "' and sdate='" + doctor_cancel_date_picker.SelectedDate.Value + "' ";

            DataTable dt = data.display(Query);
            if (dt.Rows.Count > 0)
            {

                for (int c = 0; c < (dt.Rows.Count); c++)
                {

                    cmb_shedle.Items.Add(dt.Rows[c][0].ToString());

                }


            }
            else
            {

            }
        }
        private void ClearDelete()
        {
            error_date_picker_cancel.Visibility = Visibility.Collapsed;
            error_cmb_schedule.Visibility = Visibility.Collapsed;
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Do you want to logout from the application?", "Confiremation", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
            form_DoctorReports obj = new form_DoctorReports(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_DoctorPatients obj = new form_DoctorPatients(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
