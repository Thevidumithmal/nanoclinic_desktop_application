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
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
using System.Data;


namespace NanoClinic
{ 
    /// <summary>
    /// Interaction logic for form_DoctorRegistration.xaml
    /// </summary>
    public partial class form_DoctorRegistration : Window
    {
        string login;
        Controller cc = new Controller();
        DataBaseConnection data = new DataBaseConnection();

        NetworkCredential loginn;
        SmtpClient client;
        MailMessage msg;

        public form_DoctorRegistration(string login)
        {
            this.login = login;
           InitializeComponent();
            
        }   
       
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        private void clear()
        {
            error_Doctor_cmb.Visibility = Visibility.Collapsed;
            error_Doctor_first.Visibility = Visibility.Collapsed;
            error_Doctor_last.Visibility = Visibility.Collapsed;
            error_Doctor_dob.Visibility = Visibility.Collapsed;
            error_Doctor_age.Visibility = Visibility.Collapsed;
            error_Doctor_address.Visibility = Visibility.Collapsed;
            error_Doctor_email.Visibility = Visibility.Collapsed;
            error_Doctor_nic.Visibility = Visibility.Collapsed;
            error_Doctor_mobile.Visibility = Visibility.Collapsed;
            error_Doctor_land.Visibility = Visibility.Collapsed;
            error_Doctor_gender.Visibility = Visibility.Collapsed;
            error_Doctor_civilstatus.Visibility = Visibility.Collapsed;
            error_Doctor_spec.Visibility = Visibility.Collapsed;
            error_Doctor_quilification.Visibility = Visibility.Collapsed;
            error_Doctor_checkbox.Visibility = Visibility.Collapsed;

        }

        private void btn_clearall_Click(object sender, RoutedEventArgs e)
        {
            cmb_doctortitle.SelectedItem = null;
            txt_doctor_firstname.Clear();
            txt_doctor_lastname.Clear();
            txt_doctor_age.Clear();
            txt_Doctor_nic.Clear();
            txt_doctor_address.Clear();
            txt_doctor_email.Clear();
            txt_Doctor_mobile.Clear();
            txt_Doctor_landphone.Clear();
            cmb_docto_spec.SelectedItem = null;
            rdio_Doctorgender_male.IsChecked = true;
            rdio_Doctorcivilstatus_married.IsChecked = true;
            txt_Doctor_qualification.Clear();
            doctor_dob_date_picker.SelectedDate = DateTime.Now;

            clear();

        }
    
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            form_AdminDoctors obj = new form_AdminDoctors(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void doctor_dob_date_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txt_doctor_age.Text = (DateTime.Now.Year - doctor_dob_date_picker.SelectedDate.Value.Year).ToString();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("You cannot clear values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void cmb_doctortitle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_doctor_firstname_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_doctor_lastname_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void doctor_dob_date_picker_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_doctor_age_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_doctor_address_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_doctor_email_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_Doctor_nic_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_Doctor_mobile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_Doctor_landphone_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void rdio_Doctorgender_male_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void rdio_Doctorgender_female_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void rdio_Doctorcivilstatus_married_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void rdio_Doctorcivilstatus_unmarried_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }


        private void checkbox_termsand_conditions_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }
        Validation objva1 = new Validation();
        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            clear();

            if (cmb_doctortitle.SelectedItem == null)
            {
                cmb_doctortitle.Focus();
                txt_error_Doctor_cmb.Text = "Please Make a selection!";
                error_Doctor_cmb.Visibility = Visibility.Visible;
            }
            else if ((objva1.NullValidation(txt_doctor_firstname.Text)) == 0)
            {
                txt_doctor_firstname.Focus();
                txt_error_Doctor_first.Text = "First Name cannot be Blank!";
                error_Doctor_first.Visibility = Visibility.Visible;

            }
            else if ((objva1.NumberDigitValidation(txt_doctor_firstname.Text)) == 0)
            {
                txt_doctor_firstname.Focus();
                txt_error_Doctor_first.Text = "First Name cannot have Digits!";
                error_Doctor_first.Visibility = Visibility.Visible;
            }
            else if ((objva1.NullValidation(txt_doctor_lastname.Text)) == 0)
            {
                txt_doctor_lastname.Focus();
                txt_error_Doctor_last.Text = "Last Name cannot be blank!";
                error_Doctor_last.Visibility = Visibility.Visible;
            }
            else if ((objva1.NumberDigitValidation(txt_doctor_lastname.Text)) == 0)
            {
                txt_doctor_lastname.Focus();
                txt_error_Doctor_last.Text = "Last Name cannot have letters!";
                error_Doctor_last.Visibility = Visibility.Visible;
            }
            else if ((objva1.NullValidation(txt_doctor_age.Text)) == 0)
            {
                txt_doctor_age.Focus();
                txt_error_Doctor_aggee.Text = "Age cannot be a Null value!";
                error_Doctor_age.Visibility = Visibility.Visible;
            }
            else if ((objva1.NumberDigitValidation(txt_doctor_age.Text)) == 1)
            {
                txt_doctor_age.Focus();
                txt_error_Doctor_aggee.Text = "Age cannot have Letters!";
                error_Doctor_age.Visibility = Visibility.Visible;
            }
            else if ((objva1.NullValidation(txt_doctor_address.Text)) == 0)
            {

                txt_doctor_address.Focus();
                txt_error_Doctor_address.Text = "Address Cannot be a blank!";
                error_Doctor_address.Visibility = Visibility.Visible;
            }
            else if ((objva1.EmailFormatValidation(txt_doctor_email.Text)) == 0)
            {
                txt_doctor_email.Focus();
                txt_error_Doctor_email.Text = "Please Type a correct Email address!";
                error_Doctor_email.Visibility = Visibility.Visible;
            }
            else if ((txt_doctor_email.Text.Any(char.IsUpper)))
            {
                txt_doctor_email.Focus();
                txt_error_Doctor_email.Text = "Please Type a correct Email address!";
                error_Doctor_email.Visibility = Visibility.Visible;
            }
            else if ((objva1.NullValidation(txt_Doctor_nic.Text)) == 0)
            {
                txt_Doctor_nic.Focus();
                txt_error_Doctor_nic.Text = "NIC Number cannot be blank!";
                error_Doctor_nic.Visibility = Visibility.Visible;

            }
            else if (!(txt_Doctor_nic.Text.All(char.IsLetterOrDigit)))
            {

                txt_Doctor_nic.Focus();
                txt_error_Doctor_nic.Text = "Your NIC cannot have symbols";
                error_Doctor_nic.Visibility = Visibility.Visible;
            }
            else if (txt_Doctor_nic.Text.Length > 12 || txt_Doctor_nic.Text.Length < 10)
            {
                txt_Doctor_nic.Focus();
                txt_error_Doctor_nic.Text = "Your NIC is an Incorrect one!";
                error_Doctor_nic.Visibility = Visibility.Visible;

            }

            else if ((objva1.TPFormatValidation(txt_Doctor_mobile.Text)) == 0)
            {
                txt_Doctor_mobile.Focus();
                txt_error_Doctor_mobile.Text = "Entered Number is not a corrent one!";
                error_Doctor_mobile.Visibility = Visibility.Visible;

            }
            else if (txt_Doctor_mobile.Text.Length != 10)
            {
                txt_Doctor_mobile.Focus();
                txt_error_Doctor_mobile.Text = "Entered Number is not a correct one!";
                error_Doctor_mobile.Visibility = Visibility.Visible;
            }
            else if ((objva1.TPFormatValidation(txt_Doctor_landphone.Text)) == 0)
            {
                txt_Doctor_landphone.Focus();
                txt_error_Doctor_land.Text = "Entered Number is not a corrent one!";
                error_Doctor_land.Visibility = Visibility.Visible;
            }
            else if (txt_Doctor_landphone.Text.Length != 10)
            {
                txt_Doctor_landphone.Focus();
                txt_error_Doctor_land.Text = "Entered Number is not a correct one!";
                error_Doctor_land.Visibility = Visibility.Visible;
            }
            else if (rdio_Doctorgender_female.IsChecked == false & rdio_Doctorgender_male.IsChecked == false)
            {

                txt_error_Doctor_gender.Text = "Please make a selection!";
                error_Doctor_gender.Visibility = Visibility.Visible;

            }
            else if (rdio_Doctorcivilstatus_unmarried.IsChecked == false & rdio_Doctorcivilstatus_married.IsChecked == false)
            {
                txt_error_Doctor_civilstatus.Text = "Please make a selection!";
                error_Doctor_civilstatus.Visibility = Visibility.Visible;

            }
              else if (cmb_docto_spec.SelectedItem==null)
              {
                  cmb_docto_spec.Focus();
                  txt_error_Doctor_spec.Text = "Please make Selection!";
                  error_Doctor_spec.Visibility = Visibility.Visible;
              }

            else if ((objva1.NullValidation(txt_Doctor_qualification.Text)) == 0)
            {
                txt_Doctor_qualification.Focus();
                txt_error_Doctor_quilification.Text = "Last Name cannot be blank!";
                error_Doctor_quilification.Visibility = Visibility.Visible;
            }

            else if (doctor_dob_date_picker.SelectedDate == null)
            {

                doctor_dob_date_picker.Focus();
                txt_error_Doctor_age.Text = "Entered Date is not a correct one!";
                error_Doctor_dob.Visibility = Visibility.Visible;
            }
            else if ((checkbox_termsand_conditions.IsChecked) == false)
            {
                checkbox_termsand_conditions.Focus();
                error_Doctor_checkbox.Visibility = Visibility.Visible;
            }

            else
            {
                try
                {
                    string gender;
                    string civil;
                    string spec = "";
                    string dob = doctor_dob_date_picker.Text;
                    string title = "";
                    if (cmb_doctortitle.SelectedIndex == 0)
                        title = "Mr";
                    else if (cmb_doctortitle.SelectedIndex == 2)
                        title = "Mrs";
                    else if (cmb_doctortitle.SelectedIndex == 4)
                        title = "Ms";
                    else if (cmb_doctortitle.SelectedIndex == 8)
                        title = "Prof";

                    if (rdio_Doctorgender_male.IsChecked == true)
                        gender = "Male";
                    else
                        gender = "Female";
                    if (rdio_Doctorcivilstatus_unmarried.IsChecked == true)
                        civil = "Unmarried";
                    else
                        civil = "Married";

                    if (cmb_docto_spec.SelectedIndex == 0)
                        spec = "Neurology";
                    else if (cmb_doctortitle.SelectedIndex == 2)
                        spec = "Cardiology";
                    else if (cmb_doctortitle.SelectedIndex == 4)
                        spec = "Surgeon";
                    else if (cmb_doctortitle.SelectedIndex == 6)
                        spec = "Pediatrics";
                    else if (cmb_doctortitle.SelectedIndex == 8)
                        spec = "Physician";

                    string did = "D" + cc.CreateId();
                    string pass = cc.CreatePassword();
                    string uid = cc.CreateUsername();


                    string w = "Insert into Login values('" + uid + "','" + pass + "','Doctor')";
                    int f = data.Insert_Update_Delete(w);
                    cc.SetDno(did);
                string q = "Insert into Doctor(Did,fname,lname,daddress,dtitle,dnic,ddob,dtelephone,dcivilstatus,email,landphone,spec,reg_date,hq,gender,uid,age) values ('" + did + "','" + txt_doctor_firstname.Text + "','" + txt_doctor_lastname.Text + "','" + txt_doctor_address.Text + "','" + title + "','" + txt_Doctor_nic.Text + "','" + doctor_dob_date_picker.SelectedDate.Value + "','" + txt_Doctor_mobile.Text + "','" + civil + "','" + txt_doctor_email.Text + "','" + txt_Doctor_landphone.Text + "','" + spec + "','" + DateTime.Now + "','" + txt_Doctor_qualification.Text + "','" + gender + "','" + uid + "','" + txt_doctor_age.Text + "')";
                    int g = data.Insert_Update_Delete(q);

                    if (f == 1 & g == 1)
                    {

                        MessageBox.Show("Doctor registration has successfully completed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                        cmb_doctortitle.SelectedItem = null;
                        txt_doctor_firstname.Clear();
                        txt_doctor_lastname.Clear();
                        txt_doctor_age.Clear();
                        txt_Doctor_nic.Clear();
                        txt_doctor_address.Clear();
                        txt_doctor_email.Clear();
                        txt_Doctor_mobile.Clear();
                        txt_Doctor_landphone.Clear();
                        cmb_docto_spec.SelectedItem = null;
                        rdio_Doctorgender_male.IsChecked = true;
                        rdio_Doctorcivilstatus_married.IsChecked = true;
                        txt_Doctor_qualification.Clear();
                        doctor_dob_date_picker.SelectedDate = DateTime.Now;

                        sendemail();

                        form_AdminDoctors obj = new form_AdminDoctors(cc.PassLogin());
                        obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Registration Failed!", "Error Information!", MessageBoxButton.OK, MessageBoxImage.Error);

                        if (result == MessageBoxResult.OK)
                        {

                            cmb_doctortitle.SelectedItem = null;
                            txt_doctor_firstname.Clear();
                            txt_doctor_lastname.Clear();
                            txt_doctor_age.Clear();
                            txt_Doctor_nic.Clear();
                            txt_doctor_address.Clear();
                            txt_doctor_email.Clear();
                            txt_Doctor_mobile.Clear();
                            txt_Doctor_landphone.Clear();
                            cmb_docto_spec.SelectedItem = null;
                            rdio_Doctorgender_male.IsChecked = true;
                            rdio_Doctorcivilstatus_married.IsChecked = true;
                            txt_Doctor_qualification.Clear();
                            doctor_dob_date_picker.SelectedDate = DateTime.Now;

                            clear();

                            form_AdminDoctors obj = new form_AdminDoctors(cc.PassLogin());
                            obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            form_DoctorRegistration obj = new form_DoctorRegistration(cc.PassLogin());
                            obj.Show();
                            this.Hide();
                        }
                    }
                }
                
               catch(Exception)
                {
                    MessageBox.Show("Error occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }

        }
        private void sendemail()
        {
            try
            {

                string to = "";
                string body = "";
                DataTable dt = data.display("Select email,dtitle,fname from Doctor where did='" + cc.GetDno() + "'");
                DataTable dt1 = data.display("Select username,password,dID from Doctor,Login where Doctor.UID=Login.username and  did='" + cc.GetDno() + "'");
                if (dt.Rows.Count == 0 || dt1.Rows.Count == 0)
                {
                    to = "";
                    body = "Error!";

                }
                else
                {
                    to = dt.Rows[0][0].ToString();
                    body = "Dear " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString() + ",\n\nWe inform you that your registration has been Accepted and you do not need to take any action.\n\n\n\t\tUsername : " + dt1.Rows[0][0].ToString() + "\n\t\tPassword : " + dt1.Rows[0][1].ToString() + "\n\t\tDocotr Id : " + dt1.Rows[0][2].ToString() + "\n\n\nThank You!\nInformation System,\nNano clinic.\n\nThis is a system generated email.\n(Do not reply).";

                }

                loginn = new NetworkCredential("nanoclinic11", "SSss11..");//email name
                client = new SmtpClient("smtp.gmail.com");
                client.Port = Convert.ToInt32("587");
                client.EnableSsl = true;
                client.Credentials = loginn;
                msg = new MailMessage { From = new MailAddress("nanoclinic11" + "smtp.gmail.com".Replace("smtp.", "@"), "Nano Clinic", Encoding.UTF8) };
                msg.To.Add(new MailAddress(to));
                if (!string.IsNullOrEmpty(""))
                    msg.To.Add(new MailAddress(""));
                msg.Subject = "USER CREDENTIALS";
                msg.Body = body;
                msg.BodyEncoding = Encoding.UTF8;
                msg.Priority = MailPriority.Normal;
                msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                string userstate = "Sending....";
                client.SendAsync(msg, userstate);
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

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            doctor_dob_date_picker.DisplayDate = DateTime.Now;
            clear();
        }

        private void cmb_docto_spec_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_Doctor_qualification_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
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

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
