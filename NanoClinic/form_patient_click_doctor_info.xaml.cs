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
    /// Interaction logic for form_patient_click_doctor_info.xaml
    /// </summary>
    /// 
    public partial class form_patient_click_doctor_info : Window
    {
        string docname="";
        DataBaseConnection data = new DataBaseConnection();
        public form_patient_click_doctor_info(string docname)
        {
            this.docname = docname;
            InitializeComponent();
            adddetails();
        }
        private void adddetails()
        {
            try
            {
                DataTable dt = data.display("select Dtitle,fname,lname,spec,hq,dtelephone,email from doctor where did='" + docname + "'");
                if (dt.Rows.Count == 0)
                {
                    txt_doctor_name.Text = "Not Updated";
                    txt_doctor_category.Text = "Not Updated";
                    txt_doctor_hq.Text = "Not Updated";
                    txt_doctor_mobile.Text = "Not Updated";
                    txt_doctor_email.Text = "Not Updated";
                }
                else
                {
                    txt_doctor_name.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
                    txt_doctor_category.Text = dt.Rows[0][3].ToString();
                    txt_doctor_hq.Text = dt.Rows[0][4].ToString();
                    txt_doctor_mobile.Text = dt.Rows[0][5].ToString();
                    txt_doctor_email.Text = dt.Rows[0][6].ToString();
                }
            }
            catch(IndexOutOfRangeException)
            {
                MessageBox.Show("Data cannot be accessed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (Exception)
            {
                MessageBox.Show("Error occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            
        }
    }
}
