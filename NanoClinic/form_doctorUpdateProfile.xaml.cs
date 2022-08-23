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
    /// Interaction logic for form_doctorUpdateProfile.xaml
    /// </summary>
    public partial class form_doctorUpdateProfile : Window
    {
        string login;
        Controller cc = new Controller();
        DataBaseConnection data = new DataBaseConnection();
        Validation obj = new Validation();
        string Doctorid;
        public form_doctorUpdateProfile(string login)
        {
            this.login = login;
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

        private void doctor_dob_date_picker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txt_doctor_age.Text = (DateTime.Now.Year - doctor_dob_date_picker.SelectedDate.Value.Year).ToString();
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("You cannot clear values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("Error occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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

        private void cmb_docto_spec_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void rdio_Doctorgender_female_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void rdio_Doctorgender_male_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void rdio_Doctorcivilstatus_unmarried_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void rdio_Doctorcivilstatus_married_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void txt_Doctor_qualification_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void btn_clearall_Click(object sender, RoutedEventArgs e)
        {
            clear();
            cmb_doctortitle.SelectedItem = null;
            txt_doctor_firstname.Clear();
            txt_doctor_lastname.Clear();
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

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            form_DoctorProfile obj = new form_DoctorProfile(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            clear();
            if (cmb_doctortitle.SelectedItem == null)
            {
                cmb_doctortitle.Focus();
                txt_error_Doctor_cmb.Text = "Please Make a selection!";
                error_Doctor_cmb.Visibility = Visibility.Visible;
            }
            else if ((obj.NullValidation(txt_doctor_firstname.Text)) == 0)
            {
                txt_doctor_firstname.Focus();
                txt_error_Doctor_first.Text = "First Name cannot be Blank!";
                error_Doctor_first.Visibility = Visibility.Visible;

            }
            else if ((obj.NumberDigitValidation(txt_doctor_firstname.Text)) == 0)
            {
                txt_doctor_firstname.Focus();
                txt_error_Doctor_first.Text = "First Name cannot have Digits!";
                error_Doctor_first.Visibility = Visibility.Visible;
            }
            else if ((obj.NullValidation(txt_doctor_lastname.Text)) == 0)
            {
                txt_doctor_lastname.Focus();
                txt_error_Doctor_last.Text = "Last Name cannot be blank!";
                error_Doctor_last.Visibility = Visibility.Visible;
            }
            else if ((obj.NumberDigitValidation(txt_doctor_lastname.Text)) == 0)
            {
                txt_doctor_lastname.Focus();
                txt_error_Doctor_last.Text = "Last Name cannot have Digits!";
                error_Doctor_last.Visibility = Visibility.Visible;
            }
            else if ((obj.NullValidation(txt_doctor_address.Text)) == 0)
            {

                txt_doctor_address.Focus();
                txt_error_Doctor_address.Text = "Address Cannot be a blank!";
                error_Doctor_address.Visibility = Visibility.Visible;
            }
            else if ((obj.EmailFormatValidation(txt_doctor_email.Text)) == 0)
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
            else if ((obj.NullValidation(txt_Doctor_nic.Text)) == 0)
            {
                txt_Doctor_nic.Focus();
                txt_error_Doctor_nic.Text = "NIC Number cannot be blank!";
                error_Doctor_nic.Visibility = Visibility.Visible;

            }
            else if (txt_Doctor_nic.Text.Length > 12 || txt_Doctor_nic.Text.Length < 10)
            {
                txt_Doctor_nic.Focus();
                txt_error_Doctor_nic.Text = "Your NIC is an Incorrect one!";
                error_Doctor_nic.Visibility = Visibility.Visible;

            }
            else if (!(txt_Doctor_nic.Text.All(char.IsLetterOrDigit)))
            {

                txt_Doctor_nic.Focus();
                txt_error_Doctor_nic.Text = "Your NIC cannot have symbols";
                error_Doctor_nic.Visibility = Visibility.Visible;
            }
            else if ((obj.TPFormatValidation(txt_Doctor_mobile.Text)) == 0)
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
            else if ((obj.TPFormatValidation(txt_Doctor_landphone.Text)) == 0)
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
            else if (cmb_docto_spec.SelectedItem == null)
            {
                cmb_docto_spec.Focus();
                txt_error_Doctor_spec.Text = "Please make Selection!";
                error_Doctor_spec.Visibility = Visibility.Visible;
            }

            else if ((obj.NullValidation(txt_Doctor_qualification.Text)) == 0)
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

                    if (cc.getPath() == 1)
                    {
                        string q = "Update Doctor set fname='" + txt_doctor_firstname.Text + "',lname='" + txt_doctor_lastname.Text + "',daddress='" + txt_doctor_address.Text + "',Dtitle='" + title + "',Dnic='" + txt_Doctor_nic.Text + "',gender='" + gender + "',Dcivilstatus='" + civil + "',landphone='" + txt_Doctor_landphone.Text + "',dtelephone='" + txt_Doctor_mobile.Text + "',ddob='" + doctor_dob_date_picker.SelectedDate.Value + "',age='" + txt_doctor_age.Text + "',email='" + txt_doctor_email.Text + "',spec='" + spec + "',hq='" + txt_Doctor_qualification.Text + "' where did='" + cc.GetDno() + "'";

                        int g = data.Insert_Update_Delete(q);

                        if (g == 1)
                            MessageBox.Show("Update successfully completed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        else
                        {



                            MessageBoxResult result = MessageBox.Show("Update Failed!", "Error Information!", MessageBoxButton.OK, MessageBoxImage.Error);

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

                                form_AdminDoctors obj = new form_AdminDoctors(cc.PassLogin());
                                obj.Show();
                                this.Hide();

                            }
                            else
                            {
                                form_doctorUpdateProfile obj = new form_doctorUpdateProfile(cc.PassLogin());
                                obj.Show();
                                this.Hide();
                            }
                        }
                    }
                    else
                    {
                        string q = "Update Doctor set fname='" + txt_doctor_firstname.Text + "',lname='" + txt_doctor_lastname.Text + "',daddress='" + txt_doctor_address.Text + "',Dtitle='" + title + "',Dnic='" + txt_Doctor_nic.Text + "',gender='" + gender + "',Dcivilstatus='" + civil + "',landphone='" + txt_Doctor_landphone.Text + "',dtelephone='" + txt_Doctor_mobile.Text + "',ddob='" + doctor_dob_date_picker.SelectedDate.Value + "',age='" + txt_doctor_age.Text + "',email='" + txt_doctor_email.Text + "',spec='" + spec + "',hq='" + txt_Doctor_qualification.Text + "' where did='" + Doctorid + "'";

                        int g = data.Insert_Update_Delete(q);

                        if (g == 1)
                            MessageBox.Show("Update successfully completed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        else
                        {



                            MessageBoxResult result = MessageBox.Show("Update Failed!", "Error Information!", MessageBoxButton.OK, MessageBoxImage.Error);

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

                                form_DoctorProfile obj = new form_DoctorProfile(cc.PassLogin());
                                obj.Show();
                                this.Hide();

                            }
                            else
                            {
                                form_doctorUpdateProfile obj = new form_doctorUpdateProfile(cc.PassLogin());
                                obj.Show();
                                this.Hide();
                            }
                        }
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    MessageBox.Show("Data cannot be accessed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch(Exception)
                {
                    MessageBox.Show("Error occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }


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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddDoctorDetails();
            doctor_dob_date_picker.DisplayDate = DateTime.Now;

            clear();
        }
        private void AddDoctorDetails()
        {
            try
            {

                if (cc.getPath() == 1)
                {

                    DataTable dt1 = data.display("Select DDOB,Age,Daddress,email,DNIC, Lname,Gender,Dcivilstatus,Dtelephone,landphone,spec,hq,Dtitle,fname from Doctor where DID='" + cc.GetDno() + "' ");
                    //DataTable dt1 = data.display("Select ");
                    cmb_doctortitle.Text = dt1.Rows[0][12].ToString();
                    txt_doctor_firstname.Text = dt1.Rows[0][13].ToString();
                    doctor_dob_date_picker.Text = dt1.Rows[0][0].ToString();
                    txt_doctor_age.Text = dt1.Rows[0][1].ToString();
                    txt_doctor_address.Text = dt1.Rows[0][2].ToString();
                    txt_doctor_email.Text = dt1.Rows[0][3].ToString();
                    txt_Doctor_nic.Text = dt1.Rows[0][4].ToString();
                    txt_doctor_lastname.Text = dt1.Rows[0][5].ToString();
                    txt_Doctor_landphone.Text = dt1.Rows[0][9].ToString();
                    txt_Doctor_mobile.Text = dt1.Rows[0][8].ToString();
                    txt_Doctor_qualification.Text = dt1.Rows[0][11].ToString();
                    cmb_docto_spec.Text = dt1.Rows[0][10].ToString();
                }
                else
                {
                    DataTable dt = data.display("Select Dtitle,Fname,dID from Login,doctor where Login.username=doctor.UID and UID='" + login + "'");
                    Doctorid = dt.Rows[0][2].ToString();



                    DataTable dt1 = data.display("Select DDOB,Age,Daddress,email,DNIC, Lname,Gender,Dcivilstatus,Dtelephone,landphone,spec,hq from Doctor where DID='" + Doctorid + "' ");
                    //DataTable dt1 = data.display("Select ");
                    cmb_doctortitle.Text = dt.Rows[0][0].ToString();
                    txt_doctor_firstname.Text = dt.Rows[0][1].ToString();
                    doctor_dob_date_picker.Text = dt1.Rows[0][0].ToString();
                    txt_doctor_age.Text = dt1.Rows[0][1].ToString();
                    txt_doctor_address.Text = dt1.Rows[0][2].ToString();
                    txt_doctor_email.Text = dt1.Rows[0][3].ToString();
                    txt_Doctor_nic.Text = dt1.Rows[0][4].ToString();
                    txt_doctor_lastname.Text = dt1.Rows[0][5].ToString();
                    txt_Doctor_landphone.Text = dt1.Rows[0][9].ToString();
                    txt_Doctor_mobile.Text = dt1.Rows[0][8].ToString();
                    txt_Doctor_qualification.Text = dt1.Rows[0][11].ToString();
                    cmb_docto_spec.Text = dt1.Rows[0][10].ToString();
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
