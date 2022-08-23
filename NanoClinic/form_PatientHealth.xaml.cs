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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_PatientHealth.xaml
    /// </summary>
    public partial class form_PatientHealth : Window
    {
        Controller cc = new Controller();
        DataBaseConnection data = new DataBaseConnection();
        string login;
        string patientid;

        public form_PatientHealth(string login)
        {
            InitializeComponent();
            this.login = login;
            


        
        }
       
        private void AddPatientHealthDetails()
        {

            try
            {
                DataTable dt = data.display("Select Ptitle,Fname,PID from Login,patient where Login.username=Patient.UID and UID='" + login + "'");
                patientid = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());

                DataTable dt1 = data.display("Select Height,Weight,Diabetes,Cholesterol,Allergic,Hbloodpresssure, Cancer,Depression,Alcoholuse,smorking,Druguse from Patient_Health where Pno='" + patientid + "' and Height>=( select max(Height) from Patient_health where Pno = '" + patientid + "') ");

                if (dt1.Rows.Count == 0)
                {
                    txt_patient_height.Text = "Not yet updated";
                    txt_patient_weight.Text = "Not yet updated";
                    txt_patient_diabetes.Text = "Not yet updated";
                    txt_patient_cholestorole.Text = "Not yet updated";
                    txt_patient_allergic.Text = "Not yet updated";
                    txt_patient_bloodpressure.Text = "Not yet updated";
                    txt_patient_cancer.Text = "Not yet updated";
                    txt_patient_depression.Text = "Not yet updated";
                    txt_patient_alcohole.Text = "Not yet updated";
                    txt_patient_smoking.Text = "Not yet updated";
                    txt_patient_druguse.Text = "Not yet updated";
                }
                else
                {
                    txt_patient_height.Text = dt1.Rows[0][0].ToString();
                    txt_patient_weight.Text = dt1.Rows[0][1].ToString();
                    txt_patient_diabetes.Text = dt1.Rows[0][2].ToString();
                    txt_patient_cholestorole.Text = dt1.Rows[0][3].ToString();
                    txt_patient_allergic.Text = dt1.Rows[0][4].ToString();
                    txt_patient_bloodpressure.Text = dt1.Rows[0][5].ToString();
                    txt_patient_cancer.Text = dt1.Rows[0][6].ToString();
                    txt_patient_depression.Text = dt1.Rows[0][7].ToString();
                    txt_patient_alcohole.Text = dt1.Rows[0][8].ToString();
                    txt_patient_smoking.Text = dt1.Rows[0][9].ToString();
                    txt_patient_druguse.Text = dt1.Rows[0][10].ToString();
                }
                dt.Dispose();
                dt1.Dispose();

                DataTable dt2 = data.display("Select rcho,rdia,rhb,hdate from patient_health where pno='" + patientid + "' order by hdate desc");

                if (dt2.Rows.Count == 0)
                    barchart(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                else if (dt2.Rows.Count == 1)
                    barchart(Convert.ToDouble(dt2.Rows[0][0]), Convert.ToDouble(dt2.Rows[0][1]), Convert.ToDouble(dt2.Rows[0][2]), 0, 0, 0, 0, 0, 0, 0, 0, 0);
                else if (dt2.Rows.Count == 2)
                    barchart(Convert.ToDouble(dt2.Rows[0][0]), Convert.ToDouble(dt2.Rows[0][1]), Convert.ToDouble(dt2.Rows[0][2]), Convert.ToDouble(dt2.Rows[1][0]), Convert.ToDouble(dt2.Rows[1][1]), Convert.ToDouble(dt2.Rows[1][2]), 0, 0, 0, 0, 0, 0);
                else if (dt2.Rows.Count == 3)
                    barchart(Convert.ToDouble(dt2.Rows[0][0]), Convert.ToDouble(dt2.Rows[0][1]), Convert.ToDouble(dt2.Rows[0][2]), Convert.ToDouble(dt2.Rows[1][0]), Convert.ToDouble(dt2.Rows[1][1]), Convert.ToDouble(dt2.Rows[1][2]), Convert.ToDouble(dt2.Rows[2][0]), Convert.ToDouble(dt2.Rows[2][1]), Convert.ToDouble(dt2.Rows[2][2]), 0, 0, 0);
                else if (dt2.Rows.Count == 3 || dt2.Rows.Count > 3)
                    barchart(Convert.ToDouble(dt2.Rows[0][0]), Convert.ToDouble(dt2.Rows[0][1]), Convert.ToDouble(dt2.Rows[0][2]), Convert.ToDouble(dt2.Rows[1][0]), Convert.ToDouble(dt2.Rows[1][1]), Convert.ToDouble(dt2.Rows[1][2]), Convert.ToDouble(dt2.Rows[2][0]), Convert.ToDouble(dt2.Rows[2][1]), Convert.ToDouble(dt2.Rows[2][2]), Convert.ToDouble(dt2.Rows[3][0]), Convert.ToDouble(dt2.Rows[3][1]), Convert.ToDouble(dt2.Rows[3][2]));


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

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void btn_general_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {     
            form_PatientDashBoard obj_patientdashboard = new form_PatientDashBoard(cc.PassLogin());
            obj_patientdashboard.Show();
            this.Hide();
        }

        private void btn_profile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_PatientProfile obj_patientprofile = new form_PatientProfile(cc.PassLogin()); ;
            obj_patientprofile.Show();
            this.Hide();
        }

        private void btn_appointment_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_PatientAppointments obj_patientappoinment = new form_PatientAppointments(cc.PassLogin()); ;
            obj_patientappoinment.Show();
            this.Hide();
        }

        private void btn_back_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_PatientAppointments obj_patientappoinment = new form_PatientAppointments(cc.PassLogin()); ;
            obj_patientappoinment.Show();
            this.Hide();
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

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            clear();

            if (cmb_HealthProblem.SelectedItem == null)
            {
                cmb_HealthProblem.Focus();
                txt_error_cmb_desese.Text = "Please Select a Category!";
                error_cmb_deases.Visibility = Visibility.Visible;
            }
            else if (start_date_picker.SelectedDate == null)
            {
                start_date_picker.Focus();
                txt_error_starting_date.Text = "Please select a starting date!";
                error_startingdate.Visibility = Visibility.Visible;
            }
            else if (end_date_picker.SelectedDate == null)
            {
                end_date_picker.Focus();
                txt_error_end_date.Text = "Please select a ending date!";
                error_enddate.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    string m = "";
                    if (cmb_HealthProblem.SelectedIndex == 0)
                    {
                        m = "Rdia";
                    }
                    else if (cmb_HealthProblem.SelectedIndex == 2)
                    {
                        m = "Rcho";
                    }
                    else if (cmb_HealthProblem.SelectedIndex == 4)
                    {
                        m = "Rhb";
                    }
                    DataTable dt = data.display("Select Max(" + m + "),Min(" + m + "),Avg(" + m + ") from Patient_health where pno='" + patientid + "' and Hdate between '" + start_date_picker.Text + "' and '" + end_date_picker.Text + "'");


                    min.Text = dt.Rows[0][1].ToString();
                    max.Text = dt.Rows[0][0].ToString();
                    avg.Text = dt.Rows[0][2].ToString();

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
        private void clear()
        {
            error_cmb_deases.Visibility = Visibility.Collapsed;
            error_startingdate.Visibility = Visibility.Collapsed;
            error_enddate.Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AddPatientHealthDetails();
            clear();
           
        }

        private void barchart(double c1,double d1,double b1, double c2, double d2, double b2, double c3, double d3, double b3, double c4, double d4, double b4)
        {

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title="Cholestorole",
                    Values = new ChartValues<double>{c1,c2,c3,c4}
                }
            };

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Diabetes",
                Values = new ChartValues<double> { d1, d2, d3, d4 }
            });
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Blood Pressure",
                Values = new ChartValues<double> { b1, b2, b3, b4 }
            });

            BarLabels = new[] { "Test 1", "Test 2", "Test 3", "Test 4" };
            Formatter = value => value.ToString("N");

            DataContext = this;


        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] BarLabels { get; set; }

        public Func<double, string> Formatter { get; set; }

        private void cmb_HealthProblem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void start_date_picker_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void end_date_picker_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clear();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
