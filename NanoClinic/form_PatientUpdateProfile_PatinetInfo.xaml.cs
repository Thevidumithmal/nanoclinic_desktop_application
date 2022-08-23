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
using System.Text.RegularExpressions;
using System.Data;

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_PatientUpdateProfile_PatinetInfo.xaml
    /// </summary>
    public partial class form_PatientUpdateProfile_PatinetInfo : Window
    {
        string login;
        string patientid;
        DataBaseConnection data = new DataBaseConnection();
        Validation obj_patientupdate = new Validation();
        Controller cc = new Controller();
        public form_PatientUpdateProfile_PatinetInfo(string login)
        {
            this.login = login;
            InitializeComponent();
            AddUpdateProfileDeatails();
        }
        

        
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void AddUpdateProfileDeatails()
        {
            try
            {
                if (cc.getPath() == 1)
                {




                    DataTable dt1 = data.display("Select DOB,Age,Paddress,pemail,PNIC, Lname,Gender,pcivilstatus,mobilephone,landphone,Ptitle,fname from Patient where PID='" + cc.GetPno() + "' ");
                    //DataTable dt1 = data.display("Select ");
                    cmb_title.Text = dt1.Rows[0][10].ToString();
                    txt_patient_firstname.Text = dt1.Rows[0][11].ToString();
                    patient_dob_date_picker.Text = dt1.Rows[0][0].ToString();
                    txt_patient_age.Text = dt1.Rows[0][1].ToString();
                    txt_patient_address.Text = dt1.Rows[0][2].ToString();
                    txt_patient_email.Text = dt1.Rows[0][3].ToString();
                    txt_patient_nic.Text = dt1.Rows[0][4].ToString();
                    txt_patient_lastname.Text = dt1.Rows[0][5].ToString();
                    txt_patient_landphone.Text = dt1.Rows[0][9].ToString();
                    txt_patient_mobile.Text = dt1.Rows[0][8].ToString();
                }
                else
                {
                    DataTable dt = data.display("Select Ptitle,Fname,PID from Login,patient where Login.username=Patient.UID and UID='" + login + "'");
                    patientid = dt.Rows[0][2].ToString();



                    DataTable dt1 = data.display("Select DOB,Age,Paddress,pemail,PNIC, Lname,Gender,pcivilstatus,mobilephone,landphone from Patient where PID='" + patientid + "' ");
                    //DataTable dt1 = data.display("Select ");
                    cmb_title.Text = dt.Rows[0][0].ToString();
                    txt_patient_firstname.Text = dt.Rows[0][1].ToString();
                    patient_dob_date_picker.Text = dt1.Rows[0][0].ToString();
                    txt_patient_age.Text = dt1.Rows[0][1].ToString();
                    txt_patient_address.Text = dt1.Rows[0][2].ToString();
                    txt_patient_email.Text = dt1.Rows[0][3].ToString();
                    txt_patient_nic.Text = dt1.Rows[0][4].ToString();
                    txt_patient_lastname.Text = dt1.Rows[0][5].ToString();
                    txt_patient_landphone.Text = dt1.Rows[0][9].ToString();
                    txt_patient_mobile.Text = dt1.Rows[0][8].ToString();
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
        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (cmb_title.SelectedItem == null)
            {
                cmb_title.Focus();
                txt_error_cmb.Text = "Please Make a selection!";
                error_cmb.Visibility = Visibility.Visible;
            }
            else if ((obj_patientupdate.NullValidation(txt_patient_firstname.Text)) == 0)
            {
                txt_patient_firstname.Focus();
                txt_error_first.Text = "First Name cannot be Blank!";
                error_first.Visibility = Visibility.Visible;
            }
            else if ((obj_patientupdate.NumberDigitValidation(txt_patient_firstname.Text)) == 0)
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
            else if ((obj_patientupdate.NullValidation(txt_patient_address.Text)) == 0)
            {
                txt_patient_address.Focus();
                txt_error_address.Text = "Address Cannot be a blank!";
                error_address.Visibility = Visibility.Visible;
            }
            else if ((obj_patientupdate.EmailFormatValidation(txt_patient_email.Text)) == 0)
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
            else if ((obj_patientupdate.NullValidation(txt_patient_nic.Text)) == 0)
            {
                txt_patient_nic.Focus();
                txt_error_nic.Text = "NIC Number cannot be blank!";
                error_nic.Visibility = Visibility.Visible;
            }
            else if (txt_patient_nic.Text.Length > 12 || txt_patient_nic.Text.Length < 9)
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
            else if ((obj_patientupdate.NullValidation(txt_patient_lastname.Text)) == 0)
            {
                txt_patient_lastname.Focus();
                txt_error_lastname.Text = "Last Name cannot be blank!";
                error_lastname.Visibility = Visibility.Visible;
            }
            else if ((obj_patientupdate.NumberDigitValidation(txt_patient_lastname.Text)) == 0)
            {
                txt_patient_lastname.Focus();
                txt_error_lastname.Text = "Last Name can only have Letters!";
                error_lastname.Visibility = Visibility.Visible;
            }
            else if ((obj_patientupdate.TPFormatValidation(txt_patient_mobile.Text)) == 0)
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
            else if ((obj_patientupdate.TPFormatValidation(txt_patient_landphone.Text)) == 0)
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
            else if (rdio_Patientgender_male.IsChecked == false & rdio_Patientgender_female.IsChecked == false)
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

                    string q = "";
                    if (cc.getPath() == 1)
                    {

                        q = "Update Patient set fname='" + txt_patient_firstname.Text + "',lname='" + txt_patient_lastname.Text + "',paddress='" + txt_patient_address.Text + "',ptitle='" + title + "',pnic='" + txt_patient_nic.Text + "',gender='" + gender + "',pcivilstatus='" + civil + "',landphone='" + txt_patient_landphone.Text + "',mobilephone='" + txt_patient_mobile.Text + "',dob='" + dob + "',age='" + txt_patient_age.Text + "',pemail='" + txt_patient_email.Text + "' where pid='" + cc.GetPno() + "'";
                        int c = data.Insert_Update_Delete(q);

                        if (c == 1)
                        {
                            MessageBox.Show("Successfully Updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                            form_MedicalAdminPatient obj = new form_MedicalAdminPatient(cc.PassLogin());
                            obj.Show();
                            this.Hide();

                        }

                        else
                        {
                            MessageBox.Show("Cannot Updated the profile!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

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

                    }
                    else
                    {
                        q = "Update Patient set fname='" + txt_patient_firstname.Text + "',lname='" + txt_patient_lastname.Text + "',paddress='" + txt_patient_address.Text + "',ptitle='" + title + "',pnic='" + txt_patient_nic.Text + "',gender='" + gender + "',pcivilstatus='" + civil + "',landphone='" + txt_patient_landphone.Text + "',mobilephone='" + txt_patient_mobile.Text + "',dob='" + dob + "',age='" + txt_patient_age.Text + "',pemail='" + txt_patient_email.Text + "' where pid='" + patientid + "'";

                        int c = data.Insert_Update_Delete(q);

                        if (c == 1)
                        {
                            MessageBox.Show("Successfully Updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                            form_PatientProfile obj = new form_PatientProfile(cc.PassLogin());
                            obj.Show();
                            this.Hide();

                        }

                        else
                        {
                            MessageBox.Show("Cannot Updated the profile!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

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
                    }


                }
                catch(Exception)
                {
                    MessageBox.Show("Error occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }


            /*catch(NotSupportedException)
            { MessageBox.Show("Please select an Image only", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error); }
            catch (Exception)
            { MessageBox.Show("Errors", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error); }*/
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

            rdio_Patientcivilstatus_unmarried.IsChecked = false;
            clear();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            clear();

            int c=cc.getPath();

            if (c == 1)
            {
                form_MedicalAdminPatient obj = new form_MedicalAdminPatient(cc.PassLogin());
                obj.Show();
                this.Hide();
            }
            else
            {
                form_PatientProfile obj_patientprofile = new form_PatientProfile(cc.PassLogin());
                obj_patientprofile.Show();
                this.Hide();
            }

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clear();
            patient_dob_date_picker.DisplayDateEnd = DateTime.Now;
            
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

        private void cmb_title_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_patient_firstname_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        private void txt_patient_mobile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_patient_landphone_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void rdio_Patientgender_male_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void rdio_Patientgender_female_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void rdio_Patientcivilstatus_married_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void rdio_Patientcivilstatus_unmarried_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
