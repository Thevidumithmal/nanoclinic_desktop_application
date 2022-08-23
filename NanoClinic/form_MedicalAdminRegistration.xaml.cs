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
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
using System.Data;
namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_MedicalAdminRegistration.xaml
    /// </summary>
    public partial class form_MedicalAdminRegistration : Window
    {
        string login;
        Controller cc = new Controller();
        Validation obj_ma_reg = new Validation();

        DataBaseConnection data = new DataBaseConnection();

        NetworkCredential loginn;
        SmtpClient client;
        MailMessage msg;


        public form_MedicalAdminRegistration(string login)
        {
            this.login = login;
            InitializeComponent();
        }
        
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void btn_clearall_Click(object sender, RoutedEventArgs e)
        {
            clear();
            cmb_staff_title.SelectedItem = null;
            txt_staff_firstname.Clear();
            txt_staff_lastname.Clear();
            txt_stafff_age.Clear();
            txt_staff_address.Clear();
            txt_staff_email.Clear();
            txt_staff_nic.Clear();
            txt_staff_mobile.Clear();
            txt_staff_landphone.Clear();
            rdio_staffgender_male.IsChecked = true;
            rdio_staffcivilstatus_married.IsChecked = true;
            txt_staff_specialization.Clear();
            staff_dob_date_picker.SelectedDate = DateTime.Now;

        }

        private void clear()
        {
            error_staff_cmb.Visibility = Visibility.Collapsed;
            error_staff_first.Visibility = Visibility.Collapsed;
            erro_staff_last.Visibility = Visibility.Collapsed;
            error_staff_dob.Visibility = Visibility.Collapsed;
            error_staff_age.Visibility = Visibility.Collapsed;
            error_staff_address.Visibility = Visibility.Collapsed;
            error_staff_email.Visibility = Visibility.Collapsed;
            error_staff_nic.Visibility = Visibility.Collapsed;
            error_staff_mobile.Visibility = Visibility.Collapsed;
            error_staff_land.Visibility = Visibility.Collapsed;
            error_staff_gender.Visibility = Visibility.Collapsed;
            error_staff_civilstatus.Visibility = Visibility.Collapsed;
            error_staff_qualification.Visibility = Visibility.Collapsed;
            error_staff_checkbox.Visibility = Visibility.Collapsed;
        }


        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            clear();

            if (cmb_staff_title.SelectedItem == null)
            {
                cmb_staff_title.Focus();
                txt_error_staff_cmb.Text = "Please Make a selection!";
                error_staff_cmb.Visibility = Visibility.Visible;
            }

            else if (obj_ma_reg.NullValidation(txt_staff_firstname.Text) == 0)
            {
                txt_staff_firstname.Focus();
                txt_error_staff_first.Text = "Name cannot be blank!";
                error_staff_first.Visibility = Visibility.Visible;
            }
            else if ((obj_ma_reg.NumberDigitValidation(txt_staff_firstname.Text)) == 0)
            {
                txt_staff_firstname.Focus();
                txt_error_staff_first.Text = "First Name cannot have Digits!";
                error_staff_first.Visibility = Visibility.Visible;
            }

            else if (obj_ma_reg.NullValidation(txt_staff_lastname.Text) == 0)
            {
                txt_staff_lastname.Focus();
                txt_error_staff_last.Text = "Name cannot be blank!";
                erro_staff_last.Visibility = Visibility.Visible;
            }
            else if ((obj_ma_reg.NumberDigitValidation(txt_staff_lastname.Text)) == 0)
            {
                txt_staff_lastname.Focus();
                txt_error_staff_last.Text = "Last Name cannot have Digits!";
               erro_staff_last.Visibility = Visibility.Visible;
            }

            else if (staff_dob_date_picker.SelectedDate == null)
            {
                staff_dob_date_picker.Focus();
                txt_error_staff_dob.Text = "Select a valid Date of Birth!";
                error_staff_dob.Visibility = Visibility.Visible;
            }
            else if (obj_ma_reg.NullValidation(txt_staff_address.Text) == 0)
            {
                txt_staff_address.Focus();
                txt_error_staff_address.Text = "Address cannot be blank!";
                error_staff_address.Visibility = Visibility.Visible;
            }

            else if (obj_ma_reg.NullValidation(txt_staff_email.Text) == 0)
            {
                txt_staff_email.Focus();
                txt_error_staff_email.Text = "Email cannot be blank!";
                error_staff_email.Visibility = Visibility.Visible;
            }
            else if (obj_ma_reg.EmailFormatValidation(txt_staff_email.Text) == 0)
            {
                txt_staff_email.Focus();
                txt_error_staff_email.Text = "Please enter a valid Email Address!";
                error_staff_email.Visibility = Visibility.Visible;
            }
            else if ((txt_staff_email.Text.Any(char.IsUpper)))
            {
                txt_staff_email.Focus();
                txt_error_staff_email.Text = "Please Type a correct Email address!";
                error_staff_email.Visibility = Visibility.Visible;
            }
            else if (obj_ma_reg.NullValidation(txt_staff_nic.Text) == 0)
            {
                txt_staff_nic.Focus();
                txt_error_staff_nic.Text = "NIC cannot be blank!";
                error_staff_nic.Visibility = Visibility.Visible;
            }
            else if (txt_staff_nic.Text.Length > 12 || txt_staff_nic.Text.Length < 10)
            {
                txt_staff_nic.Focus();
                txt_error_staff_nic.Text = "Your NIC is not valid!";
                error_staff_nic.Visibility = Visibility.Visible;
            }
            else if (!(txt_staff_nic.Text.All(char.IsLetterOrDigit)))
            {

                txt_staff_nic.Focus();
                txt_error_staff_nic.Text = "Your NIC cannot have symbols";
                error_staff_nic.Visibility = Visibility.Visible;
            }

            else if (obj_ma_reg.NullValidation(txt_staff_mobile.Text) == 0)
            {
                txt_staff_mobile.Focus();
                txt_error_staff_mobile.Text = "Mobile phone number cannot be blank!";
                error_staff_mobile.Visibility = Visibility.Visible;
            }
            else if (obj_ma_reg.TPFormatValidation(txt_staff_mobile.Text) == 0)
            {
                txt_staff_mobile.Focus();
                txt_error_staff_mobile.Text = "Your mobile phone number is not valid!";
                error_staff_mobile.Visibility = Visibility.Visible;
            }
            else if (txt_staff_mobile.Text.Length != 10)
            {
                txt_staff_mobile.Focus();
                txt_error_staff_mobile.Text = "Entered Number is not a correct one!";
                error_staff_mobile.Visibility = Visibility.Visible;
            }
            else if (obj_ma_reg.NullValidation(txt_staff_landphone.Text) == 0)
            {
                txt_staff_landphone.Focus();
                txt_error_staff_land.Text = "Landphone number cannot be blank!";
                error_staff_land.Visibility = Visibility.Visible;
            }
            else if (obj_ma_reg.TPFormatValidation(txt_staff_landphone.Text) == 0)
            {
                txt_staff_landphone.Focus();
                txt_error_staff_land.Text = "Your land phone number is not valid!";
                error_staff_land.Visibility = Visibility.Visible;
            }
            else if (txt_staff_landphone.Text.Length != 10)
            {
                txt_staff_landphone.Focus();
                txt_error_staff_land.Text = "Entered Number is not a correct one!";
                error_staff_land.Visibility = Visibility.Visible;
            }
            else if (obj_ma_reg.NullValidation(txt_staff_specialization.Text) == 0)
            {
                txt_staff_specialization.Focus();
                txt_error_staff_qualification.Text = "Qualification cannot be blank!";
                error_staff_qualification.Visibility = Visibility.Visible;
            }
            else if (obj_ma_reg.NumberDigitValidation(txt_staff_specialization.Text) == 0)
            {
                txt_staff_specialization.Focus();
                txt_error_staff_qualification.Text = "Qualification cannot have Digits!";
                error_staff_qualification.Visibility = Visibility.Visible;
            }

            else if (rdio_staffgender_male.IsChecked == false & rdio_staffgender_female.IsChecked == false)
            {
                txt_error_staff_gender.Text = "Please make a selection";
                error_staff_gender.Visibility = Visibility.Visible;
            }

            else if (rdio_staffcivilstatus_married.IsChecked == false & rdio_staffcivilstatus_unmarried.IsChecked == false)
            {
                txt_error_staff_civilstatus.Text = "Please make a selection";
                error_staff_civilstatus.Visibility = Visibility.Visible;
            }
            else if ((checkbox_termsand_conditions.IsChecked) == false)
            {
                checkbox_termsand_conditions.Focus();
                error_staff_checkbox.Visibility = Visibility.Visible;
            }

            else
            {
                try
                {
                    string gender;
                    string civil;
                    string dob = staff_dob_date_picker.Text;
                    string title = "";
                    if (cmb_staff_title.SelectedIndex == 0)
                        title = "Mr";
                    else if (cmb_staff_title.SelectedIndex == 2)
                        title = "Mrs";
                    else if (cmb_staff_title.SelectedIndex == 4)
                        title = "Ms";
                    else if (cmb_staff_title.SelectedIndex == 8)
                        title = "Prof";

                    if (rdio_staffgender_male.IsChecked == true)
                        gender = "Male";
                    else
                        gender = "Female";
                    if (rdio_staffcivilstatus_unmarried.IsChecked == true)
                        civil = "Unmarried";
                    else
                        civil = "Married";
                    string sid = "M" + cc.CreateId();
                    string pass = cc.CreatePassword();
                    string uid = cc.CreateUsername();

                    string w = "Insert into Login values('" + uid + "','" + pass + "','Medical_staff')";
                    int f = data.Insert_Update_Delete(w);
                    cc.SetSno(sid);
                    string q = "Insert into  Medical_staff(Sid,uid,tittle,fname,lname,nic,cstatus,email,hq,telephone,landphone,gender,address,dob,age,reg_date) values ('" + sid + "','" + uid + "','" + title + "','" + txt_staff_firstname.Text + "','" + txt_staff_lastname.Text + "','" + txt_staff_nic.Text + "','" + civil + "','" + txt_staff_email.Text + "','" + txt_staff_specialization.Text + "','" + txt_staff_mobile.Text + "','" + txt_staff_landphone.Text + "','" + gender + "','" + txt_staff_address.Text + "','" + staff_dob_date_picker.SelectedDate.Value + "','" + txt_stafff_age.Text + "','" + DateTime.Now + "')";
                    int g = data.Insert_Update_Delete(q);

                    if (f == 1 & g == 1)
                    {
                        MessageBox.Show("Medical Staff registration has successfully completed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        sendemail();

                        form_AdminMedicalAdmin obj = new form_AdminMedicalAdmin(cc.PassLogin());
                        obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Registration Failed!", "Error Information!", MessageBoxButton.OK, MessageBoxImage.Error);

                        if (result == MessageBoxResult.OK)
                        {

                            cmb_staff_title.SelectedItem = null;
                            txt_staff_firstname.Clear();
                            txt_staff_lastname.Clear();
                            txt_stafff_age.Clear();
                            txt_staff_nic.Clear();
                            txt_staff_address.Clear();
                            txt_staff_email.Clear();
                            txt_staff_mobile.Clear();
                            txt_staff_landphone.Clear();
                            txt_staff_specialization.Clear();
                            rdio_staffgender_male.IsChecked = true;
                            rdio_staffcivilstatus_married.IsChecked = true;
                            staff_dob_date_picker.SelectedDate = DateTime.Now;

                            clear();


                            form_AdminMedicalAdmin obj = new form_AdminMedicalAdmin(cc.PassLogin());
                            obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            form_MedicalAdminRegistration obj = new form_MedicalAdminRegistration(cc.PassLogin());
                            obj.Show();
                            this.Hide();
                        }
                    }
                }
                catch (Exception)
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
                DataTable dt = data.display("Select email,tittle,fname from Medical_staff where sid='" + cc.GetSno() + "'");
                DataTable dt1 = data.display("Select username,password,SID from Medical_staff,Login where Medical_staff.UID=Login.username and  Sid='" + cc.GetSno() + "'");
                if (dt.Rows.Count == 0 || dt1.Rows.Count == 0)
                {
                    to = "";
                    body = "Error!";

                }
                else
                {
                    to = dt.Rows[0][0].ToString();
                    body = "Dear " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString() + ",\n\nWe inform you that your registration has been Accepted and you do not need to take any action.\n\n\n\t\tUsername : " + dt1.Rows[0][0].ToString() + "\n\t\tPassword : " + dt1.Rows[0][1].ToString() + "\n\t\tStaff Id : " + dt1.Rows[0][2].ToString() + "\n\n\nThank You!\nInformation System,\nNano clinic.\n\nThis is a system generated email.\n(Do not reply).";


                }

                loginn = new NetworkCredential("nanoclinic11", "SSss11..");
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
                MessageBox.Show("Error email  occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            staff_dob_date_picker.DisplayDate = DateTime.Now;
            clear();
        }

        private void cmb_staff_title_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_staff_firstname_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_staff_lastname_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void staff_dob_date_picker_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_staff_email_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_staff_address_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_stafff_age_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_staff_nic_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear(); 
        }

        private void txt_staff_mobile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_staff_landphone_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_staff_specialization_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void rdio_staffgender_male_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void rdio_staffgender_female_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void rdio_staffcivilstatus_married_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void rdio_staffcivilstatus_unmarried_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void btn_profileImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        private void staff_dob_date_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txt_stafff_age.Text = (DateTime.Now.Year - staff_dob_date_picker.SelectedDate.Value.Year).ToString();
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("You cannot clear values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void btn_back_Click_1(object sender, RoutedEventArgs e)
        {
            form_AdminMedicalAdmin obj = new form_AdminMedicalAdmin(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
