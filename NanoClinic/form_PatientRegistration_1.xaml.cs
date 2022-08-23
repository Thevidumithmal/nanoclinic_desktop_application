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

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_PatientRegistration_1.xaml
    /// </summary>
    /// 
    
    public partial class form_PatientRegistration_1 : Window
    {

        Controller cc = new Controller();
        DataBaseConnection data = new DataBaseConnection();
        Validation objval = new Validation();


        public form_PatientRegistration_1()
        {
            InitializeComponent();
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
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void clear()
        {
            error_cmb.Visibility = Visibility.Collapsed;
            error_first.Visibility = Visibility.Collapsed;
            error_dob.Visibility = Visibility.Collapsed;
            error_age.Visibility = Visibility.Collapsed;
            error_address.Visibility = Visibility.Collapsed;
            error_email.Visibility = Visibility.Collapsed;
            error_nic.Visibility = Visibility.Collapsed;
            error_lastname.Visibility = Visibility.Collapsed;
            error_gender.Visibility = Visibility.Collapsed;
            error_civilstatus.Visibility = Visibility.Collapsed;
            error_mobile.Visibility = Visibility.Collapsed;
            error_land.Visibility = Visibility.Collapsed;
        }

        private void btn_clearall_Click(object sender, RoutedEventArgs e)
        { 
            
            cmb_title.SelectedItem = null;
            txt_patient_firstname.Clear();
            txt_patient_lastname.Clear();
            txt_patient_age.Clear();
            txt_patient_nic.Clear();
            txt_patient_address.Clear();
            txt_patient_email.Clear();
            txt_patient_mobile.Clear();
            txt_patient_landphone.Clear();
            rdio_Patientgender_male.IsChecked = true;
            rdio_Patientcivilstatus_married.IsChecked = true;
            patient_dob_date_picker.SelectedDate = DateTime.Now;

            clear();

        }
        private void btn_next_Click(object sender, RoutedEventArgs e)
        {

            clear();

            if (cmb_title.SelectedItem == null)
            {
                cmb_title.Focus();
                txt_error_cmb.Text = "Please Make a selection!";
                error_cmb.Visibility = Visibility.Visible;
            }
            else if ((objval.NullValidation(txt_patient_firstname.Text))==0)
            {
                txt_patient_firstname.Focus();
                txt_error_first.Text = "First Name cannot be Blank!";
                error_first.Visibility = Visibility.Visible;
            }
            else if ((objval.NumberDigitValidation(txt_patient_firstname.Text)) == 0)
            {
                txt_patient_firstname.Focus();
                txt_error_first.Text = "First Name can only have Letters!";
                error_first.Visibility = Visibility.Visible;
            }
            else if (patient_dob_date_picker.SelectedDate == null)
            {
                patient_dob_date_picker.Focus();
                txt_error_dob.Text = "Please choose your date of birth!";
                error_dob.Visibility = Visibility.Visible;
            }
            else if ((objval.NullValidation(txt_patient_address.Text)) == 0)
            {
                txt_patient_address.Focus();
                txt_error_address.Text = "Address Cannot be a blank!";
                error_address.Visibility = Visibility.Visible;
            }
            else if ((objval.EmailFormatValidation(txt_patient_email.Text)) == 0)
            {
                txt_patient_email.Focus();
                txt_error_email.Text = "Please Type a correct Email address!";
                error_email.Visibility = Visibility.Visible;
            }
            else if ((txt_patient_email.Text.Any(char.IsUpper)))
            {
                txt_patient_email.Focus();
                txt_error_email.Text = "Please Type a correct Email address!";
                error_email.Visibility = Visibility.Visible;
            }
            else if ((objval.NullValidation(txt_patient_nic.Text)) == 0)
            {
                txt_patient_nic.Focus();
                txt_error_nic.Text = "NIC Number cannot be blank!";
                error_nic.Visibility = Visibility.Visible;
            }
            else if (txt_patient_nic.Text.Length > 12 || txt_patient_nic.Text.Length<9)
            {
                txt_patient_nic.Focus();
                txt_error_nic.Text = "Your NIC is an Incorrect one!";
                error_nic.Visibility = Visibility.Visible;
            }
            else if (!(txt_patient_nic.Text.All(char.IsLetterOrDigit)))
            {

                txt_patient_nic.Focus();
                txt_error_nic.Text = "Your NIC cannot have symbols";
                error_nic.Visibility = Visibility.Visible;
            }
            else if ((objval.NullValidation(txt_patient_lastname.Text)) == 0)
            {
                txt_patient_lastname.Focus();
                txt_error_lastname.Text = "Last Name cannot be blank!";
                error_lastname.Visibility = Visibility.Visible;
            }
            else if ((objval.NumberDigitValidation(txt_patient_lastname.Text)) == 0)
            {
                txt_patient_lastname.Focus();
                txt_error_lastname.Text = "Last Name can only have Letters!";
                error_lastname.Visibility = Visibility.Visible;
            }
            else if ((objval.TPFormatValidation(txt_patient_mobile.Text))==0 )
            {
                txt_patient_mobile.Focus();
                txt_error_mobile.Text = "Entered Number is not a correct one!";
                error_mobile.Visibility = Visibility.Visible;
            }
            else if (txt_patient_mobile.Text.Length != 10)
            {
                txt_patient_mobile.Focus();
                txt_error_mobile.Text = "Entered Number is not a correct one!";
                error_mobile.Visibility = Visibility.Visible;
            }
            else if((objval.TPFormatValidation(txt_patient_landphone.Text)) == 0)
            {
                txt_patient_landphone.Focus();
                txt_error_land.Text = "Entered Number is not a correct one!";
                error_land.Visibility = Visibility.Visible;
            }
            else if (txt_patient_landphone.Text.Length != 10)
            {
                txt_patient_landphone.Focus();
                txt_error_land.Text = "Entered Number is not a correct one!";
                error_land.Visibility = Visibility.Visible;
            }
            else if(rdio_Patientgender_male.IsChecked==false & rdio_Patientgender_female.IsChecked == false)
            {               
                txt_error_gender.Text = "Please make a selection";
                error_gender.Visibility = Visibility.Visible;
            }
            else if (rdio_Patientcivilstatus_married.IsChecked == false & rdio_Patientcivilstatus_unmarried.IsChecked == false)
            {
                txt_error_civilstatus.Text = "Please make a selection";
                error_civilstatus.Visibility = Visibility.Visible;
            }
            else
            {

                try
                {
                    string gender;
                    string civil;
                    string dob = patient_dob_date_picker.Text;
                    string title = "";
                    if (cmb_title.SelectedIndex == 0)
                        title = "Mr";
                    else if (cmb_title.SelectedIndex == 2)
                        title = "Mrs";
                    else if (cmb_title.SelectedIndex == 4)
                        title = "Ms";
                    else if (cmb_title.SelectedIndex == 6)
                        title = "Prof";
                    else if (cmb_title.SelectedIndex == 8)
                        title = "Rev";
                    else if (cmb_title.SelectedIndex == 10)
                        title = "Dr";

                    if (rdio_Patientgender_male.IsChecked == true)
                        gender = "Male";
                    else
                        gender = "Female";

                    if (rdio_Patientcivilstatus_unmarried.IsChecked == true)
                        civil = "Unmarried";
                    else
                        civil = "Married";

                    string pid = "P" + cc.CreateId();
                    string pass = cc.CreatePassword();
                    string uid = cc.CreateUsername();


                    string q = "Insert into Patient (pid,uid,fname,lname,paddress,ptitle,preg_date,pnic,gender,pcivilstatus,landphone,mobilephone,dob,age,pemail) values('" + pid + "','" + uid + "','" + txt_patient_firstname.Text + "','" + txt_patient_lastname.Text + "','" + txt_patient_address.Text + "','" + title + "','" + DateTime.Now.ToShortDateString() + "','" + txt_patient_nic.Text + "','" + gender + "','" + civil + "','" + txt_patient_landphone.Text + "','" + txt_patient_mobile.Text + "','" + dob + "','" + txt_patient_age.Text + "','" + txt_patient_email.Text + "')";
                    string w = "Insert into Login values('" + uid + "','" + pass + "','Patient')";
                    
                        int c = data.Insert_Update_Delete(w);
                        int f = data.Insert_Update_Delete(q);
                    

                    if (c == 1 & f == 1)
                    {
                        MessageBox.Show("You have successfully Registered Please Enter Gurdian Details.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        cc.SetPno(pid);


                        form_PatientRegistration_2 obj = new form_PatientRegistration_2();
                        obj.Show();
                        this.Hide();
                    }

                    else
                    {


                        MessageBoxResult result = MessageBox.Show("Registration Failed!", "Error Information!", MessageBoxButton.OK, MessageBoxImage.Error);

                        if (result == MessageBoxResult.OK)
                        {

                            cmb_title.SelectedItem = null;
                            txt_patient_firstname.Clear();
                            txt_patient_lastname.Clear();
                            txt_patient_age.Clear();
                            txt_patient_nic.Clear();
                            txt_patient_address.Clear();
                            txt_patient_email.Clear();
                            txt_patient_mobile.Clear();
                            txt_patient_landphone.Clear();
                            rdio_Patientgender_female.IsChecked = false;
                            rdio_Patientcivilstatus_unmarried.IsChecked = false;
                            patient_dob_date_picker.SelectedDate = DateTime.Now;
                            clear();
                        }
                        else
                        {
                            form_Login obj = new form_Login();
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

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            int c=cc.getPath();

            if (c == 1)
            {
                form_MedicalAdminPatient obj = new form_MedicalAdminPatient(cc.PassLogin());
                obj.Show();
                this.Hide();
            }
            else
            {
                form_Login obj = new form_Login();
                obj.Show();
                this.Hide();
            }
            
        }


        private void patient_dob_date_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txt_patient_age.Text = (DateTime.Now.Year - patient_dob_date_picker.SelectedDate.Value.Year).ToString();
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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clear();
            patient_dob_date_picker.DisplayDateEnd = DateTime.Now;
        }

        private void txt_patient_firstname_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void cmb_title_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void patient_dob_date_picker_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_patient_age_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_patient_address_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_patient_email_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();

        }

        private void txt_patient_nic_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_patient_lastname_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void rdio_Patientgender_male_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();

        }

        private void rdio_Patientgender_female_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void rdio_Patientcivilstatus_married_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void rdio_Patientcivilstatus_unmarried_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_patient_mobile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_patient_landphone_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
