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
    /// Interaction logic for form_MedicalStaffUpdateProfile.xaml
    /// </summary>
    public partial class form_MedicalStaffUpdateProfile : Window
    {
        string login;
        Controller cc = new Controller();
        DataBaseConnection data = new DataBaseConnection();
        Validation obj = new Validation();
        string staffid;
        public form_MedicalStaffUpdateProfile(string login)
        {
            this.login = login;
            InitializeComponent();
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

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            form_MedicalAdminProfile obj = new form_MedicalAdminProfile(cc.PassLogin());
            obj.Show();
            this.Hide();
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

            else if (obj.NullValidation(txt_staff_firstname.Text) == 0)
            {
                txt_staff_firstname.Focus();
                txt_error_staff_first.Text = "Name cannot be blank!";
                error_staff_first.Visibility = Visibility.Visible;
            }
            else if ((obj.NumberDigitValidation(txt_staff_firstname.Text)) == 0)
            {
                txt_staff_firstname.Focus();
                txt_error_staff_first.Text = "First Name cannot have Digits!";
                error_staff_first.Visibility = Visibility.Visible;
            }

            else if (obj.NullValidation(txt_staff_lastname.Text) == 0)
            {
                txt_staff_lastname.Focus();
                txt_error_staff_last.Text = "Name cannot be blank!";
                erro_staff_last.Visibility = Visibility.Visible;
            }
            else if ((obj.NumberDigitValidation(txt_staff_lastname.Text)) == 0)
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

            else if (obj.NullValidation(txt_staff_address.Text) == 0)
            {
                txt_staff_address.Focus();
                txt_error_staff_address.Text = "Address cannot be blank!";
                error_staff_address.Visibility = Visibility.Visible;
            }

            else if (obj.NullValidation(txt_staff_email.Text) == 0)
            {
                txt_staff_email.Focus();
                txt_error_staff_email.Text = "Email cannot be blank!";
                error_staff_email.Visibility = Visibility.Visible;
            }
            else if (obj.EmailFormatValidation(txt_staff_email.Text) == 0)
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
            else if (obj.NullValidation(txt_staff_nic.Text) == 0)
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
            else if (obj.NullValidation(txt_staff_mobile.Text) == 0)
            {
                txt_staff_mobile.Focus();
                txt_error_staff_mobile.Text = "Mobile phone number cannot be blank!";
                error_staff_mobile.Visibility = Visibility.Visible;
            }
            else if (obj.TPFormatValidation(txt_staff_mobile.Text) == 0)
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
            else if (obj.NullValidation(txt_staff_landphone.Text) == 0)
            {
                txt_staff_landphone.Focus();
                txt_error_staff_land.Text = "Landphone number cannot be blank!";
                error_staff_land.Visibility = Visibility.Visible;
            }
            else if (obj.TPFormatValidation(txt_staff_landphone.Text) == 0)
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
            else if (obj.NullValidation(txt_staff_specialization.Text) == 0)
            {
                txt_staff_specialization.Focus();
                txt_error_staff_qualification.Text = "Qualification cannot be blank!";
                error_staff_qualification.Visibility = Visibility.Visible;
            }
            else if (obj.NumberDigitValidation(txt_staff_specialization.Text) == 0)
            {
                txt_staff_specialization.Focus();
                txt_staff_specialization.Text = "Qualification cannot have Digits!";
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


                    if (cc.getPath() == 1)
                    {
                        string q = "Update Medical_staff set fname='" + txt_staff_firstname.Text + "',lname='" + txt_staff_lastname.Text + "',address='" + txt_staff_address.Text + "',tittle='" + title + "',nic='" + txt_staff_nic.Text + "',gender='" + gender + "',cstatus='" + civil + "',landphone='" + txt_staff_landphone.Text + "',telephone='" + txt_staff_mobile.Text + "',dob='" + staff_dob_date_picker.SelectedDate.Value + "',age='" + txt_stafff_age.Text + "',email='" + txt_staff_email.Text + "',hq='" + txt_staff_specialization.Text + "' where sid='" + cc.GetSno() + "'";

                        int g = data.Insert_Update_Delete(q);

                        if (g == 1)
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

                            MessageBox.Show("Update successfully completed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                            form_AdminMedicalAdmin obj = new form_AdminMedicalAdmin(cc.PassLogin());
                            obj.Show();
                            this.Hide();


                        }
                        else
                        {
                            MessageBoxResult result = MessageBox.Show("Update Failed!", "Error Information!", MessageBoxButton.OK, MessageBoxImage.Error);

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
                            }
                            else
                            {
                                form_MedicalStaffUpdateProfile obj = new form_MedicalStaffUpdateProfile(cc.PassLogin());
                                obj.Show();
                                this.Hide();
                            }

                        }

                    }
                    else
                    {
                        string q = "Update Medical_staff set fname='" + txt_staff_firstname.Text + "',lname='" + txt_staff_lastname.Text + "',address='" + txt_staff_address.Text + "',tittle='" + title + "',nic='" + txt_staff_nic.Text + "',gender='" + gender + "',cstatus='" + civil + "',landphone='" + txt_staff_landphone.Text + "',telephone='" + txt_staff_mobile.Text + "',dob='" + staff_dob_date_picker.SelectedDate.Value + "',age='" + txt_stafff_age.Text + "',email='" + txt_staff_email.Text + "',hq='" + txt_staff_specialization.Text + "' where sid='" + staffid + "'";

                        int g = data.Insert_Update_Delete(q);

                        if (g == 1)
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

                            MessageBox.Show("Update successfully completed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                            form_MedicalAdminProfile obj = new form_MedicalAdminProfile(cc.PassLogin());
                            obj.Show();
                            this.Hide();


                        }
                        else
                        {
                            MessageBoxResult result = MessageBox.Show("Update Failed!", "Error Information!", MessageBoxButton.OK, MessageBoxImage.Error);

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
                            }
                            else
                            {
                                form_MedicalStaffUpdateProfile obj = new form_MedicalStaffUpdateProfile(cc.PassLogin());
                                obj.Show();
                                this.Hide();
                            }
                        }
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

        private void txt_stafff_age_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_staff_address_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_staff_email_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        private void txt_staff_specialization_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();

        }

        private void staff_dob_date_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txt_stafff_age.Text = (DateTime.Now.Year - staff_dob_date_picker.SelectedDate.Value.Year).ToString();
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
        private void AddStaffDetails()
        {
            try
            {

                if (cc.getPath() == 1)
                {


                    DataTable dt1 = data.display("Select DOB, Age, Address, EMail, NIC, Lname, Telephone, Landphone, HQ,tittle,fname  from Medical_staff where SID = '" + cc.GetSno() + "' ");

                    cmb_staff_title.Text = dt1.Rows[0][9].ToString();
                    txt_staff_firstname.Text = dt1.Rows[0][10].ToString();
                    staff_dob_date_picker.Text = dt1.Rows[0][0].ToString();
                    txt_stafff_age.Text = dt1.Rows[0][1].ToString();
                    txt_staff_address.Text = dt1.Rows[0][2].ToString();
                    txt_staff_email.Text = dt1.Rows[0][3].ToString();
                    txt_staff_nic.Text = dt1.Rows[0][4].ToString();
                    txt_staff_lastname.Text = dt1.Rows[0][5].ToString();
                    txt_staff_landphone.Text = dt1.Rows[0][7].ToString();
                    txt_staff_mobile.Text = dt1.Rows[0][6].ToString();
                    txt_staff_specialization.Text = dt1.Rows[0][8].ToString();
                }
                else
                {
                    DataTable dt = data.display("Select tittle,Fname,sID from Login,Medical_staff where Login.username=Medical_staff.UID and UID='" + login + "'");
                    staffid = dt.Rows[0][2].ToString();



                    DataTable dt1 = data.display("Select DOB, Age, Address, EMail, NIC, Lname, Telephone, Landphone, HQ  from Medical_staff where SID = '" + staffid + "' ");

                    cmb_staff_title.Text = dt.Rows[0][0].ToString();
                    txt_staff_firstname.Text = dt.Rows[0][1].ToString();
                    staff_dob_date_picker.Text = dt1.Rows[0][0].ToString();
                    txt_stafff_age.Text = dt1.Rows[0][1].ToString();
                    txt_staff_address.Text = dt1.Rows[0][2].ToString();
                    txt_staff_email.Text = dt1.Rows[0][3].ToString();
                    txt_staff_nic.Text = dt1.Rows[0][4].ToString();
                    txt_staff_lastname.Text = dt1.Rows[0][5].ToString();
                    txt_staff_landphone.Text = dt1.Rows[0][7].ToString();
                    txt_staff_mobile.Text = dt1.Rows[0][6].ToString();
                    txt_staff_specialization.Text = dt1.Rows[0][8].ToString();
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddStaffDetails();
            clear();
            staff_dob_date_picker.DisplayDate = DateTime.Now;

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
