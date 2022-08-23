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
using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_PatientRegistration_2.xaml
    /// </summary>
    public partial class form_PatientRegistration_2 : Window
    {
        DataBaseConnection data = new DataBaseConnection();
        Controller cc = new Controller();
        Validation obj = new Validation();


        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

        public form_PatientRegistration_2()
        {
            InitializeComponent();
        }
        //DataSet ds;
        //string strName, imageName;
        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            


            MessageBoxResult result = MessageBox.Show("Are yor sure to close the application? If it is ,Already entered Patient details will be deleted!", "Confirmation Message", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                


                DataTable dt = data.display("Select UID from Patient where Pid='" + cc.GetPno() + "'");
                int c = data.Insert_Update_Delete("Delete from Patient where Pid='"+cc.GetPno()+"'");
                int d = data.Insert_Update_Delete("Delete from Login where Username='" + dt.Rows[0][0] + "'");

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

        private void Clear()
        {
            error_gurdian_firstname.Visibility = Visibility.Collapsed;
            error_gurdian_nic.Visibility = Visibility.Collapsed;
            error_gurdian_address.Visibility = Visibility.Collapsed;
            error_gurdian_telephone.Visibility = Visibility.Collapsed;
            error_gurdian_checkbox.Visibility = Visibility.Collapsed;
        }

        private void btn_clearall_Click(object sender, RoutedEventArgs e)
        {
            
            txt_guardiannic.Clear();
            txt_guardianaddress.Clear();
            txt_guardiantelephone.Clear();
            checkbox_termsand_conditions.IsChecked = false;

            Clear();
        }

        

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            if ((obj.NullValidation(txt_guardianfirstname.Text)) == 0)
            {
                txt_guardianfirstname.Focus();
                txt_error_gurdian_firstname.Text = "Full Name Cannot be blank!";
                error_gurdian_firstname.Visibility = Visibility.Visible;
            }
            else if ((obj.NumberDigitValidation(txt_guardianfirstname.Text)) == 0)
            {
                txt_error_gurdian_firstname.Focus();
                txt_error_gurdian_firstname.Text = "Name cannot have Digits!";
                error_gurdian_firstname.Visibility = Visibility.Visible;
            }
            else if ((obj.NullValidation(txt_guardiannic.Text)) == 0)
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
                txt_error_gurdian_nic.Visibility = Visibility.Visible;
            }
            else if ((obj.NullValidation(txt_guardianaddress.Text)) == 0)
            {
                txt_guardianaddress.Focus();
                txt_error_gurdian_address.Text = "Address Cannot be blank!";
                error_gurdian_address.Visibility = Visibility.Visible;
            }
            else if ((obj.TPFormatValidation(txt_guardiantelephone.Text)) == 0)
            {
                txt_guardiantelephone.Focus();
                txt_error_gurdian_telephone.Text = "Incorrect Telephone Number!";
                error_gurdian_telephone.Visibility = Visibility.Visible;
            }
            else if (txt_guardiantelephone.Text.Length != 10)
            {
                txt_guardiantelephone.Focus();
                txt_error_gurdian_telephone.Text = "Entered Number is not a correct one!";
                error_gurdian_telephone.Visibility = Visibility.Visible;
            }
            else if ((checkbox_termsand_conditions.IsChecked) == false)
            {
                checkbox_termsand_conditions.Focus();
                error_gurdian_checkbox.Visibility = Visibility.Visible;
            }
            else
            {
                
                 string Pno=cc.GetPno();
                string q = "Insert into Gurdian values('"+Pno+"','"+ txt_guardianfirstname.Text+"','"+txt_guardiannic.Text+"','"+txt_guardianaddress.Text+"','"+txt_guardiantelephone.Text+"')";
                int f =data.Insert_Update_Delete(q);
                /*
                FileStream fs = new FileStream(imageName, FileMode.Open, FileAccess.Read);

                Initialize a byte array with size of stream
                byte[] imgByteArr = new byte[fs.Length];

                Read data from the file stream and put into the byte array
                fs.Read(imgByteArr, 0, Convert.ToInt32(fs.Length));

                Close a file stream
                fs.Close();



                string sql = "Update Patient set prof_img='" + imgByteArr + "',namep='"+strName+"' where Pid='" + Pno + "'";
                int c = data.Insert_Update_Delete(sql);
                if (c == 1)
                {
                    MessageBox.Show("Image added successfully.");
                    
                }

                */
                //Pass byte array into database
                /* 

                 if (result == 1)
                 {
                     MessageBox.Show("Image added successfully.");
                 }*/





                if (f == 1)
                {
                    MessageBox.Show("You have successfully entered Gurdian Details", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    if (cc.getPath() == 1)
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

                    sendemail();

                    

                }
                else
                {

                    MessageBoxResult result = MessageBox.Show(" Gurdain registration Failed!", "Error Information!", MessageBoxButton.OK, MessageBoxImage.Error);

                    if (result == MessageBoxResult.OK)
                    {

                        txt_guardiannic.Clear();
                        txt_guardianaddress.Clear();
                        txt_guardiantelephone.Clear();
                        checkbox_termsand_conditions.IsChecked = false;

                        Clear();
                    }
                    else
                    {
                        form_PatientRegistration_2 obj = new form_PatientRegistration_2();
                        obj.Show();
                        this.Hide();
                    }

                }
                   
            }
        }
        
        
        private void sendemail()
        {
            try
            {

                string to = "";
                string body = "";
                DataTable dt = data.display("Select pemail,ptitle,fname from Patient where Pid='" + cc.GetPno() + "'");
                DataTable dt1 = data.display("Select username,password,PID from Patient,Login where Patient.UID=Login.username and  Pid='" + cc.GetPno() + "'");
                if (dt.Rows.Count == 0 || dt1.Rows.Count == 0)
                {
                    to = "";
                    body = "Error!";

                }
                else
                {
                    to = dt.Rows[0][0].ToString();
                    body = "Dear " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString() + ",\n\nWe inform you that your registration has been Accepted and you do not need to take any action.\n\n\n\t\tUsername : " + dt1.Rows[0][0].ToString() + "\n\t\tPassword : " + dt1.Rows[0][1].ToString() + "\n\t\tPatient Id : " + dt1.Rows[0][2].ToString() + "\n\n\nThank You!\nInformation System,\nNano clinic.\n\nThis is a system generated email.\n(Do not reply).";


                }

                login = new NetworkCredential("nanoclinic11", "SSss11..");
                client = new SmtpClient("smtp.gmail.com");
                client.Port = Convert.ToInt32("587");
                client.EnableSsl = true;
                client.Credentials = login;
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
            catch(Exception)
            {
                MessageBox.Show("Error occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void txt_guardianfullname_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clear();
        }

        private void txt_guardiannic_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clear();
        }

        private void txt_guardianaddress_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clear();
        }

        private void txt_guardiantelephone_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clear();
        }

        private void checkbox_termsand_conditions_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Clear();
        }

        private void btn_profileImage_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            /*


            FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    strName = fldlg.SafeFileName;
                    imageName = fldlg.FileName;

                Uri fileUri = new Uri(imageName);
                image.ImageSource = new BitmapImage(fileUri);
                
                ImageSourceConverter isc = new ImageSourceConverter();
                image.SetValue(Image.SourceProperty, isc.ConvertFromString(imageName));
               
            }
                fldlg = null;*/
            
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}

