
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
using System.IO;
using System.Drawing.Imaging;


namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_PatientDashBoard.xaml
    /// </summary>
    public partial class form_PatientDashBoard : Window
    {
        DataBaseConnection data = new DataBaseConnection();
        Controller cc = new Controller();

        string doc1, doc2, doc3, doc4, doc5;

        string login;

        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public form_PatientDashBoard(string login)
        {

            InitializeComponent();

            this.login = login;

            

        }

        
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        private void Timer_Click(object sender, EventArgs e)

        {
            DateTime d;

            d = DateTime.Now;

            time.Text = d.Hour + " : " + d.Minute + " : " + d.Second;
        }
        private void TimerStart()
        {
            Timer.Tick += new EventHandler(Timer_Click);

            Timer.Interval = new TimeSpan(0, 0, 1);

            Timer.Start();
        }

        private void AddPatientDashboardDetails()
        {

            try
            {
                string pid = "";
                DataTable dt = data.display("Select Ptitle,Fname,pid from Login,patient where Login.username=Patient.UID and UID='" + login + "'");
                pid = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());
                txt_welcomepatient.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());


                /* DataTable dt1 = data.display("Select namep, prof_img from Login,patient where Login.username=Patient.UID and UID='" + login + "'");
                 DataTable dataTable = data.passprofile("Select namep, prof_img from Login, patient where Login.username = Patient.UID and UID = '" + login + "'");
                 foreach (DataRow row in dataTable.Rows)
                 {
                         //Store binary data read from the database in a byte array
                         byte[] blob = (byte[])row[1];
                         MemoryStream stream = new MemoryStream();
                         stream.Write(blob, 0, blob.Length);
                         stream.Position = 0;

                         System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                         BitmapImage bi = new BitmapImage();
                         bi.BeginInit();

                         MemoryStream ms = new MemoryStream();
                         img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                         ms.Seek(0, SeekOrigin.Begin);
                         bi.StreamSource = ms;
                         bi.EndInit();
                         btn_profileImage.ImageSource = bi;    
                 }
                  */

                string msg = "Not Updated";
                DataTable dt1 = data.display("Select dno,Fname,count(*) from doctor,Appointment where doctor.did=appointment.dno group by fname,dno order by count(*) desc ");

                if (dt1.Rows.Count == 0)
                {
                    doc_1_name.Text = msg;
                    doc_2_name.Text = msg;
                    doc_3_name.Text = msg;
                    doc_4_name.Text = msg;
                    doc_5_name.Text = msg;
                }
                else if (dt1.Rows.Count == 1)
                {
                    doc_1_name.Text = "Dr. " + dt1.Rows[0][1].ToString();
                    doc_2_name.Text = msg;
                    doc_3_name.Text = msg;
                    doc_4_name.Text = msg;
                    doc_5_name.Text = msg;
                    doc1 = dt1.Rows[0][0].ToString();
                }
                else if (dt1.Rows.Count == 2)
                {
                    doc_1_name.Text = "Dr. " + dt1.Rows[0][1].ToString();
                    doc_2_name.Text = "Dr. " + dt1.Rows[1][1].ToString();
                    doc_3_name.Text = msg;
                    doc_4_name.Text = msg;
                    doc_5_name.Text = msg;

                    doc1 = dt1.Rows[0][0].ToString();
                    doc2 = dt1.Rows[1][0].ToString();


                }
                else if (dt1.Rows.Count == 3)
                {
                    doc_1_name.Text = "Dr. " + dt1.Rows[0][1].ToString();
                    doc_2_name.Text = "Dr. " + dt1.Rows[1][1].ToString();
                    doc_3_name.Text = "Dr. " + dt1.Rows[2][1].ToString();
                    doc_4_name.Text = msg;
                    doc_5_name.Text = msg;

                    doc1 = dt1.Rows[0][0].ToString();
                    doc2 = dt1.Rows[1][0].ToString();
                    doc3 = dt1.Rows[2][0].ToString();
                }
                else if (dt1.Rows.Count == 4)
                {
                    doc_1_name.Text = "Dr. " + dt1.Rows[0][1].ToString();
                    doc_2_name.Text = "Dr. " + dt1.Rows[1][1].ToString();
                    doc_3_name.Text = "Dr. " + dt1.Rows[2][1].ToString();
                    doc_4_name.Text = "Dr. " + dt1.Rows[3][1].ToString();
                    doc_5_name.Text = msg;

                    doc1 = dt1.Rows[0][0].ToString();
                    doc2 = dt1.Rows[1][0].ToString();
                    doc3 = dt1.Rows[2][0].ToString();
                    doc4 = dt1.Rows[3][0].ToString();
                }
                else if (dt1.Rows.Count == 5)
                {
                    doc_1_name.Text = "Dr. " + dt1.Rows[0][1].ToString();
                    doc_2_name.Text = "Dr. " + dt1.Rows[1][1].ToString();
                    doc_3_name.Text = "Dr. " + dt1.Rows[2][1].ToString();
                    doc_4_name.Text = "Dr. " + dt1.Rows[3][1].ToString();
                    doc_5_name.Text = "Dr. " + dt1.Rows[4][1].ToString();

                    doc1 = dt1.Rows[0][0].ToString();
                    doc2 = dt1.Rows[1][0].ToString();
                    doc3 = dt1.Rows[2][0].ToString();
                    doc4 = dt1.Rows[3][0].ToString();
                    doc5 = dt1.Rows[4][0].ToString();
                }



                DataTable dt2 = data.display("select dno,adate from Appointment where pno='" + pid + "'");

                if (dt2.Rows.Count == 0)
                {
                    txt_next_doctor.Text = "No Appointments";

                }
                else
                {
                    txt_next_doctor.Text = dt2.Rows[0][0].ToString();
                    txt_next_date.Text = dt2.Rows[0][1].ToString();
                }


                DataTable dt3 = data.display("Select Count(*) from patient");

                if (dt3.Rows.Count == 0)
                {
                    txt_total_patients.Text = "Not Updated";

                }
                else
                {
                    txt_total_patients.Text = dt3.Rows[0][0].ToString();

                }



                DataTable dt4 = data.display("Select Count(*) from doctor");


                if (dt4.Rows.Count == 0)
                {
                    txt_total_doctorss.Text = "Not Updated";

                }
                else
                {
                    txt_total_doctorss.Text = dt4.Rows[0][0].ToString();

                }

                DataTable dt9 = data.display("Select Messagee from patient where pid='" + pid + "'");


                if (dt9.Rows.Count == 0)
                {
                    txt_announcement.Text = "No Announcements";

                }
                else
                {
                    txt_announcement.Text = dt9.Rows[0][0].ToString();
                }


                dt2.Dispose();
                dt1.Dispose();
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
        
        
        private void btn_profile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_PatientProfile obj_patientprofile = new form_PatientProfile(cc.PassLogin());
            obj_patientprofile.Show();
            this.Hide();
        }

        private void btn_appointment_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_PatientAppointments obj_patientappoinment = new form_PatientAppointments(cc.PassLogin());
            obj_patientappoinment.Show();
            this.Hide();
        }

        private void btn_health_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            form_PatientHealth obj_patienthealth = new form_PatientHealth(cc.PassLogin());
            obj_patienthealth.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            AddPatientDashboardDetails();
            calender.DisplayDate = DateTime.Now;
            TimerStart();

        }

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void profileImage_doc_2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_patient_click_doctor_info obj = new form_patient_click_doctor_info(doc2);
            obj.ShowDialog();
        }

        private void profileImage_doc_3_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_patient_click_doctor_info obj = new form_patient_click_doctor_info(doc3);
            obj.ShowDialog();
        }

        private void profileImage_doc_4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_patient_click_doctor_info obj = new form_patient_click_doctor_info(doc4);
            obj.ShowDialog();
        }

        private void profileImage_doc_5_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            

            form_patient_click_doctor_info obj = new form_patient_click_doctor_info(doc5);
            obj.ShowDialog();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {

           MessageBoxResult result= MessageBox.Show("Do you want to logout from the application?", "Confiremation", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
            form_PatientProfile obj_patientprofile = new form_PatientProfile(cc.PassLogin());
            obj_patientprofile.Show();
            this.Hide();
        }

        private void btn_profileImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_PatientProfile obj_patientprofile = new form_PatientProfile(cc.PassLogin());
            obj_patientprofile.Show();
            this.Hide();
        }
        
        private void profileImage_doc_1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            

            form_patient_click_doctor_info obj = new form_patient_click_doctor_info(doc1);
            obj.ShowDialog();
        }
    }
}
