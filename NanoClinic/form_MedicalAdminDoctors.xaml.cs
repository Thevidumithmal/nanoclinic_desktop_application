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

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_MedicalAdminDoctors.xaml
    /// </summary>
    public partial class form_MedicalAdminDoctors : Window
    {
        Controller cc = new Controller();
        Validation obj = new Validation();
        DataBaseConnection data = new DataBaseConnection();
        string login;
        string sno;
        public form_MedicalAdminDoctors(string login)
        {
            this.login = login;
            InitializeComponent();
        }
        private void addDetails()
        {
            try
            {

                DataTable dt = data.display("Select tittle,Fname,sid from Login,Medical_staff where Login.username=Medical_staff.UID and UID='" + login + "'");
                sno = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());


                DataTable dt1 = data.display("Select Count(*) from Doctor");
                DataTable dt2 = data.display("Select Count(*) from Doctor where reg_date='" + DateTime.Now + "'");
                DataTable dt3 = data.display("Select Count(*) from Doctor where reg_date!='" + DateTime.Now + "'");

                if (dt1.Rows.Count == 0)
                {
                    total_doctors.Text = "No Doctors";

                }
                else
                {

                    total_doctors.Text = dt1.Rows[0][0].ToString();

                }


                if (dt2.Rows.Count == 0)
                {
                    new_doctors.Text = "No Doctors";

                }
                else
                {
                    new_doctors.Text = dt2.Rows[0][0].ToString();

                }


                if (dt3.Rows.Count == 0)
                {
                    old_doctors.Text = "No Doctors";

                }
                else
                {
                    old_doctors.Text = dt3.Rows[0][0].ToString();

                }

                DataTable dt4 = data.display("Select Count(*) from Doc_schedule where sdate='" + DateTime.Now + "' and stime='07.00am' ");

                if (dt4.Rows.Count == 0)
                {
                    schedules7_10.Text = "No Doctors";

                }
                else
                {
                    schedules7_10.Text = dt4.Rows[0][0].ToString();

                }


                DataTable dt5 = data.display("Select Count(*) from Doc_schedule where sdate='" + DateTime.Now + "' and stime='11.00am' ");

                if (dt5.Rows.Count == 0)
                {
                    schedules11_14.Text = "No Doctors";

                }
                else
                {
                    schedules11_14.Text = dt5.Rows[0][0].ToString();

                }

                DataTable dt6 = data.display("Select Count(*) from Doc_schedule where sdate='" + DateTime.Now + "' and stime='15.00pm' ");

                if (dt6.Rows.Count == 0)
                {
                    schedules15_18.Text = "No Doctors";

                }
                else
                {
                    schedules15_18.Text = dt6.Rows[0][0].ToString();

                }
                DataTable dt7 = data.display("Select Count(*) from Doc_schedule where sdate='" + DateTime.Now + "' and stime='19.00pm' ");

                if (dt6.Rows.Count == 0)
                {
                    schedules19_22.Text = "No Doctors";

                }
                else
                {
                    schedules19_22.Text = dt7.Rows[0][0].ToString();

                }



                DataTable dt8 = data.display("Select Dtitle,Fname,Spec,Sdate,Stime from Doctor,Doc_Schedule where Doctor.DID=Doc_Schedule.Dno and sdate='" + DateTime.Now + "' and stime='07.00am'");

                if (dt8.Rows.Count == 0)
                {
                    doc_name1.Text = "No Schedules";
                    doc_name2.Text = "No Schedules";
                    doc_name3.Text = "No Schedules";

                }

                else if (dt8.Rows.Count == 1)
                {
                    doc_name2.Text = "No Schedules";
                    doc_name3.Text = "No Schedules";

                    doc_name1.Text = dt8.Rows[0][1].ToString() + " " + dt8.Rows[0][0].ToString();
                    cateogory1.Text = dt8.Rows[0][2].ToString();
                    time1.Text = dt8.Rows[0][4].ToString();
                }

                else if (dt8.Rows.Count == 2)
                {
                    doc_name3.Text = "No Schedules";

                    doc_name1.Text = dt8.Rows[0][1].ToString() + " " + dt8.Rows[0][0].ToString();
                    cateogory1.Text = dt8.Rows[0][2].ToString();
                    time1.Text = dt8.Rows[0][4].ToString();

                    doc_name2.Text = dt8.Rows[1][1].ToString() + " " + dt8.Rows[1][0].ToString();
                    cateogory2.Text = dt8.Rows[1][2].ToString();
                    time2.Text = dt8.Rows[1][4].ToString();
                }

                else if (dt8.Rows.Count == 3)
                {
                    doc_name1.Text = dt8.Rows[0][1].ToString() + " " + dt8.Rows[0][0].ToString();
                    cateogory1.Text = dt8.Rows[0][2].ToString();
                    time1.Text = dt8.Rows[0][4].ToString();

                    doc_name2.Text = dt8.Rows[1][1].ToString() + " " + dt8.Rows[1][0].ToString();
                    cateogory2.Text = dt8.Rows[1][2].ToString();
                    time2.Text = dt8.Rows[1][4].ToString();

                    doc_name3.Text = dt8.Rows[2][1].ToString() + " " + dt8.Rows[2][0].ToString();
                    cateogory3.Text = dt8.Rows[2][2].ToString();
                    time3.Text = dt8.Rows[2][4].ToString();
                }

                DataTable dt9 = data.display("Select Dtitle,Fname,Spec,Sdate,Stime from Doctor,Doc_Schedule where Doctor.DID=Doc_Schedule.Dno and sdate='" + DateTime.Now + "' and stime='11.00am'");

                if (dt9.Rows.Count == 0)
                {
                    doc_name4.Text = "No Schedules";
                    doc_name5.Text = "No Schedules";
                    doc_name6.Text = "No Schedules";

                }

                else if (dt9.Rows.Count == 1)
                {
                    doc_name5.Text = "No Schedules";
                    doc_name6.Text = "No Schedules";

                    doc_name4.Text = dt9.Rows[0][1].ToString() + " " + dt9.Rows[0][0].ToString();
                    cateogory4.Text = dt9.Rows[0][2].ToString();
                    time4.Text = dt9.Rows[0][4].ToString();
                }

                else if (dt9.Rows.Count == 2)
                {
                    doc_name6.Text = "No Schedules";

                    doc_name4.Text = dt9.Rows[0][1].ToString() + " " + dt9.Rows[0][0].ToString();
                    cateogory4.Text = dt9.Rows[0][2].ToString();
                    time4.Text = dt9.Rows[0][4].ToString();

                    doc_name5.Text = dt9.Rows[1][1].ToString() + " " + dt9.Rows[1][0].ToString();
                    cateogory5.Text = dt9.Rows[1][2].ToString();
                    time5.Text = dt9.Rows[1][4].ToString();
                }

                else if (dt9.Rows.Count == 3)
                {
                    doc_name4.Text = dt9.Rows[0][1].ToString() + " " + dt9.Rows[0][0].ToString();
                    cateogory4.Text = dt9.Rows[0][2].ToString();
                    time4.Text = dt9.Rows[0][4].ToString();

                    doc_name5.Text = dt9.Rows[1][1].ToString() + " " + dt9.Rows[1][0].ToString();
                    cateogory5.Text = dt9.Rows[1][2].ToString();
                    time5.Text = dt9.Rows[1][4].ToString();

                    doc_name6.Text = dt9.Rows[2][1].ToString() + " " + dt9.Rows[2][0].ToString();
                    cateogory6.Text = dt9.Rows[2][2].ToString();
                    time6.Text = dt9.Rows[2][4].ToString();
                }

                DataTable dt10 = data.display("Select Dtitle,Fname,Spec,Sdate,Stime from Doctor,Doc_Schedule where Doctor.DID=Doc_Schedule.Dno and sdate='" + DateTime.Now + "' and stime='15.00pm'");

                if (dt10.Rows.Count == 0)
                {
                    doc_name7.Text = "No Schedules";
                    doc_name8.Text = "No Schedules";
                    doc_name9.Text = "No Schedules";

                }

                else if (dt10.Rows.Count == 1)
                {
                    doc_name8.Text = "No Schedules";
                    doc_name9.Text = "No Schedules";

                    doc_name7.Text = dt10.Rows[0][1].ToString() + " " + dt10.Rows[0][0].ToString();
                    cateogory7.Text = dt10.Rows[0][2].ToString();
                    time7.Text = dt10.Rows[0][4].ToString();
                }

                else if (dt10.Rows.Count == 2)
                {
                    doc_name9.Text = "No Schedules";

                    doc_name7.Text = dt10.Rows[0][1].ToString() + " " + dt10.Rows[0][0].ToString();
                    cateogory7.Text = dt10.Rows[0][2].ToString();
                    time7.Text = dt10.Rows[0][4].ToString();

                    doc_name8.Text = dt10.Rows[1][1].ToString() + " " + dt10.Rows[1][0].ToString();
                    cateogory8.Text = dt10.Rows[1][2].ToString();
                    time8.Text = dt10.Rows[1][4].ToString();
                }

                else if (dt10.Rows.Count == 3)
                {
                    doc_name7.Text = dt10.Rows[0][1].ToString() + " " + dt10.Rows[0][0].ToString();
                    cateogory7.Text = dt10.Rows[0][2].ToString();
                    time7.Text = dt10.Rows[0][4].ToString();

                    doc_name8.Text = dt10.Rows[1][1].ToString() + " " + dt10.Rows[1][0].ToString();
                    cateogory8.Text = dt10.Rows[1][2].ToString();
                    time8.Text = dt10.Rows[1][4].ToString();

                    doc_name9.Text = dt10.Rows[2][1].ToString() + " " + dt10.Rows[2][0].ToString();
                    cateogory9.Text = dt10.Rows[2][2].ToString();
                    time9.Text = dt10.Rows[2][4].ToString();
                }

                DataTable dt11 = data.display("Select Dtitle,Fname,Spec,Sdate,Stime from Doctor,Doc_Schedule where Doctor.DID=Doc_Schedule.Dno and sdate='" + DateTime.Now + "' and stime='19.00pm'");

                if (dt11.Rows.Count == 0)
                {
                    doc_name10.Text = "No Schedules";
                    doc_name11.Text = "No Schedules";
                    doc_name12.Text = "No Schedules";

                }

                else if (dt11.Rows.Count == 1)
                {
                    doc_name11.Text = "No Schedules";
                    doc_name12.Text = "No Schedules";

                    doc_name10.Text = dt11.Rows[0][1].ToString() + " " + dt11.Rows[0][0].ToString();
                    cateogory10.Text = dt11.Rows[0][2].ToString();
                    time10.Text = dt11.Rows[0][4].ToString();
                }

                else if (dt11.Rows.Count == 2)
                {
                    doc_name12.Text = "No Schedules";

                    doc_name10.Text = dt11.Rows[0][1].ToString() + " " + dt11.Rows[0][0].ToString();
                    cateogory10.Text = dt11.Rows[0][2].ToString();
                    time10.Text = dt11.Rows[0][4].ToString();

                    doc_name11.Text = dt11.Rows[1][1].ToString() + " " + dt11.Rows[1][0].ToString();
                    cateogory11.Text = dt11.Rows[1][2].ToString();
                    time11.Text = dt11.Rows[1][4].ToString();
                }

                else if (dt11.Rows.Count == 3)
                {
                    doc_name10.Text = dt11.Rows[0][1].ToString() + " " + dt11.Rows[0][0].ToString();
                    cateogory10.Text = dt11.Rows[0][2].ToString();
                    time10.Text = dt11.Rows[0][4].ToString();

                    doc_name11.Text = dt11.Rows[1][1].ToString() + " " + dt11.Rows[1][0].ToString();
                    cateogory11.Text = dt11.Rows[1][2].ToString();
                    time11.Text = dt11.Rows[1][4].ToString();

                    doc_name12.Text = dt11.Rows[2][1].ToString() + " " + dt11.Rows[2][0].ToString();
                    cateogory12.Text = dt11.Rows[2][2].ToString();
                    time12.Text = dt11.Rows[2][4].ToString();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            addDetails();
            clear();
        }

        private void cmb_appointment_spec_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void cmb_appointment_doc_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void cmb_appointment_spec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string Query = "Select dno from Doc_schedule,doctor where Doc_schedule.dno=doctor.did and  sdate='" + DateTime.Now + "' and spec='" + cmb_appointment_spec.SelectedItem + "' ";

                DataTable dt = data.display(Query);
                if (dt.Rows.Count > 0)
                {

                    for (int c = 0; c < (dt.Rows.Count); c++)
                    {

                        cmb_appointment_doc.Items.Add(dt.Rows[c][0].ToString());

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
        private void clear()
        {
            error_cmb_doc.Visibility = Visibility.Collapsed;
            error_cmb_spec.Visibility = Visibility.Collapsed;
        }
        private void cmb_appointment_doc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            clear();
            if (cmb_appointment_spec.SelectedItem == null)
            {
                cmb_appointment_spec.Focus();
                txt_error_cmb_spec.Text = "Please Select Date";
                error_cmb_spec.Visibility = Visibility.Visible;

            }
            else if (cmb_appointment_doc.SelectedItem == null)
            {
                cmb_appointment_doc.Focus();
                txt_error_cmb_doc.Text = "Please Select time slots";
                error_cmb_doc.Visibility = Visibility.Visible;

            }
            else
            {
                try
                {

                    string Query = "Select fname,dtitle,spec,sdate,stime from Doc_schedule,doctor where Doc_schedule.dno=doctor.did and did='" + cmb_appointment_doc.SelectedItem + "' ";

                    DataTable dt = data.display(Query);
                    if (dt.Rows.Count == 0)
                    {
                        doc_name.Text = "No Schedules";


                    }

                    else if (dt.Rows.Count >= 1)
                    {


                        doc_name.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString();
                        doc_cat.Text = dt.Rows[0][2].ToString();
                        schedule_date.Text = dt.Rows[0][3].ToString();
                        schedule_time.Text = dt.Rows[0][4].ToString();
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
            form_MedicalAdminProfile obj = new form_MedicalAdminProfile(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_MedicalAdminPatient obj = new form_MedicalAdminPatient(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
    
}
