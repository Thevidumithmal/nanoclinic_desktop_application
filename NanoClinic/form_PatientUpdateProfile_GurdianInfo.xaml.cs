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
    /// Interaction logic for form_PatientUpdateProfile_GurdianInfo.xaml
    /// </summary>
    public partial class form_PatientUpdateProfile_GurdianInfo : Window
    {
        DataBaseConnection obj = new DataBaseConnection();
        Controller cc = new Controller();
        Validation obj1 = new Validation();
        string login;
        string patientid;
        public form_PatientUpdateProfile_GurdianInfo(string login)
        {
            this.login = login;
            InitializeComponent();
            addgurdiandetails();
        }


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void btn_clearall_Click(object sender, RoutedEventArgs e)
        {
            txt_guardianfullname.Clear();
            txt_guardiannic.Clear();
            txt_guardianaddress.Clear();
            txt_guardiantelephone.Clear();
            clear();
        }
        private void clear()
        {
            error_gurdian_fullname.Visibility = Visibility.Collapsed;
            error_gurdian_nic.Visibility = Visibility.Collapsed;
            error_gurdian_address.Visibility = Visibility.Collapsed;
            error_gurdian_telephone.Visibility = Visibility.Collapsed;
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            form_PatientProfile obj_patientprofile = new form_PatientProfile(cc.PassLogin());
            obj_patientprofile.Show();
            this.Hide();
        }

        private void addgurdiandetails()
        {
            try
            {

                DataTable dt = obj.display("Select PID from Login,patient where Login.username=Patient.UID and UID='" + login + "'");
                patientid = dt.Rows[0][0].ToString();



                DataTable dt1 = obj.display("Select Gname,Nic,Gaddresss,Telephone from Gurdian where Pno='" + patientid + "' ");
                //DataTable dt1 = data.display("Select ");
                txt_guardianfullname.Text = dt1.Rows[0][0].ToString();
                txt_guardiannic.Text = dt1.Rows[0][1].ToString();
                txt_guardianaddress.Text = dt1.Rows[0][2].ToString();
                txt_guardiantelephone.Text = dt1.Rows[0][3].ToString();
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
        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            clear();

            if ((obj1.NullValidation(txt_guardianfullname.Text)) == 0)
            {
                txt_guardianfullname.Focus();
                txt_error_gurdian_fullname.Text = "Full Name Cannot be blank!";
                error_gurdian_fullname.Visibility = Visibility.Visible;
            }
            else if ((obj1.NumberDigitValidation(txt_guardianfullname.Text)) == 0)
            {
                txt_guardianfullname.Focus();
                txt_error_gurdian_fullname.Text = "Name cannot have Digits!";
                error_gurdian_fullname.Visibility = Visibility.Visible;
            }
            else if ((obj1.NullValidation(txt_guardiannic.Text)) == 0)
            {
                txt_guardiannic.Focus();
                txt_error_gurdian_nic.Text = "NIC Number cannot be a blank one!";
                error_gurdian_nic.Visibility = Visibility.Visible;
            }
            else if (txt_guardiannic.Text.Length > 12 || txt_guardiannic.Text.Length < 10)
            {
                txt_guardiannic.Focus();
                txt_error_gurdian_nic.Text = "NIC is an Incorrect one!";
                error_gurdian_nic.Visibility = Visibility.Visible;
            }
            else if (!(txt_guardiannic.Text.All(char.IsLetterOrDigit)))
            {

                txt_guardiannic.Focus();
                txt_error_gurdian_nic.Text = "Your NIC cannot have symbols";
                error_gurdian_nic.Visibility = Visibility.Visible;
            }
            else if ((obj1.NullValidation(txt_guardianaddress.Text)) == 0)
            {
                txt_guardianaddress.Focus();
                txt_error_gurdian_address.Text = "Address Cannot be blank!";
                error_gurdian_address.Visibility = Visibility.Visible;
            }
            else if ((obj1.TPFormatValidation(txt_guardiantelephone.Text)) == 0)
            {
                txt_guardiantelephone.Focus();
                txt_error_gurdian_telephone.Text = "Incorrect Telephone Number!";
                error_gurdian_telephone.Visibility = Visibility.Visible;
            }
            
            else
            {
                string p = "Update Gurdian set Gname='" + txt_guardianfullname.Text + "', NIC='" + txt_guardiannic.Text + "',Gaddresss ='" + txt_guardianaddress.Text + "', Telephone ='" + txt_guardiantelephone.Text + "' where Pno='"+patientid+"'";
                
                int f = obj.Insert_Update_Delete(p);

                if (f == 1)
                {
                    MessageBox.Show("Successfully Updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    form_PatientProfile obj = new form_PatientProfile(cc.PassLogin());
                    obj.Show();
                    this.Hide();

                }

                else
                {
                    MessageBox.Show("Cannot Updated the profile!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

                    txt_guardianfullname.Clear();
                    txt_guardiannic.Clear();
                    txt_guardianaddress.Clear();
                    txt_guardiantelephone.Clear();
                    clear();


                }
            }

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

        private void txt_guardianfullname_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_guardiannic_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_guardianaddress_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void txt_guardiantelephone_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
