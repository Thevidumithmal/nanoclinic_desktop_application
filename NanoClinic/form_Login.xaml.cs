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
    /// Interaction logic for form_Login.xaml
    /// </summary>
    public partial class form_Login : Window

    {

        DataBaseConnection obj1 = new DataBaseConnection();
        Validation obj2 = new Validation();
        Controller obj3 = new Controller();

        public form_Login()
        {
            InitializeComponent();
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
           
            Application.Current.Shutdown();
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        
        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {


            string q = "";
            int c;
            if (cmb_type.SelectedItem == null)
            {
                cmb_type.Focus();
                txt_error_username.Text = "Please Make a selection!";
                error_username.Visibility = Visibility.Visible;
            }
            else if ((obj2.NullValidation(txt_username.Text)) == 0)
            {
                txt_username.Focus();
                txt_error_username.Text = "Username cannot be Blank!";
                error_username.Visibility = Visibility.Visible;
            }
            else if ((txt_password.Password.Length != 8))
            {
                txt_password.Focus();
                txt_error_username.Text = "Invalid Password!";
                error_username.Visibility = Visibility.Visible;
            }
            else
            {

                try
                {
                    if (cmb_type.SelectedIndex == 0)
                {
                    
                        q = "Select count(*) from Login where username COLLATE Latin1_General_CS_AS ='" + txt_username.Text + "' and password COLLATE Latin1_General_CS_AS ='" + txt_password.Password + "' and login_type='Patient'";
                        c = obj1.CheckLogin(q);
                        if (c == 1)
                        {
                            obj3.CreateLogin(txt_username.Text);

                            form_PatientDashBoard obj = new form_PatientDashBoard(obj3.PassLogin());
                            obj.Show();
                            this.Hide();

                        }
                        else
                        {
                            txt_username.Focus();
                            txt_error_username.Text = "Invalid username or password!";
                            error_username.Visibility = Visibility.Visible;
                        }
                    }
                else if (cmb_type.SelectedIndex == 2)
                    {
                        q = "Select count(*) from Login where username COLLATE Latin1_General_CS_AS ='" + txt_username.Text + "' and password COLLATE Latin1_General_CS_AS ='" + txt_password.Password + "' and login_type='Doctor'";
                        c = obj1.CheckLogin(q);
                        if (c == 1)
                        {
                            obj3.CreateLogin(txt_username.Text);
                            form_DoctorDashBoard obj = new form_DoctorDashBoard(obj3.PassLogin());
                            obj.Show();
                            this.Hide();

                        }
                        else
                        {

                            txt_username.Focus();
                            txt_error_username.Text = "Invalid username or password!";
                            error_username.Visibility = Visibility.Visible;
                        }
                    }
                    else if (cmb_type.SelectedIndex == 4)
                    {
                        q = "Select count(*) from Login where username COLLATE Latin1_General_CS_AS ='" + txt_username.Text + "' and password COLLATE Latin1_General_CS_AS ='" + txt_password.Password + "' and login_type='Medical_Staff'";
                        c = obj1.CheckLogin(q);
                        if (c == 1)
                        {
                            obj3.CreateLogin(txt_username.Text);
                            form_MedicalAdminDashBoard obj = new form_MedicalAdminDashBoard(obj3.PassLogin());
                            obj.Show();
                            this.Hide();

                        }
                        else
                        {

                            txt_username.Focus();
                            txt_error_username.Text = "Invalid username or password!";
                            error_username.Visibility = Visibility.Visible;
                        }

                    }
                    else if (cmb_type.SelectedIndex == 6)
                    {
                        q = "Select count(*) from Login where username COLLATE Latin1_General_CS_AS ='" + txt_username.Text + "' and password COLLATE Latin1_General_CS_AS ='" + txt_password.Password + "' and login_type='Admin'";
                        c = obj1.CheckLogin(q);
                        if (c == 1)
                        {
                            obj3.CreateLogin(txt_username.Text);
                            form_AdminDashBoard obj = new form_AdminDashBoard(obj3.PassLogin());
                            obj.Show();
                            this.Hide();

                        }
                        else
                        {

                            txt_username.Focus();
                            txt_error_username.Text = "Invalid username or password!";
                            error_username.Visibility = Visibility.Visible;
                        }
                    }

                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("You cannot enter Null Values!", "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
                }
                catch (Exception)
                {
                    MessageBox.Show("Error occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

            
           
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            form_PatientRegistration_1 objj = new form_PatientRegistration_1();
            objj.Show();
            this.Hide();
        }
        public void Clear()
        {
            error_username.Visibility = Visibility.Collapsed;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void cmb_type_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clear();
        }

        private void txt_username_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clear();
        }

        private void txt_password_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}


