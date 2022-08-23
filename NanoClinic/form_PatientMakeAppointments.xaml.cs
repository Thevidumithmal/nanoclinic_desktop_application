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
    /// Interaction logic for form_PatientMakeAppointments.xaml
    /// </summary>
    public partial class form_PatientMakeAppointments : Window
    {

        string login;
        DataBaseConnection data = new DataBaseConnection();
        Controller cc = new Controller();


        public form_PatientMakeAppointments(string login)
        {
            this.login = login;
            InitializeComponent();
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
        

        private void AddScheduleDetails()
        {

            try
            {

                // string name="No Shedules", date="Empty", cat="Empty", time="Empty";
                DataTable dt = data.display("Select Dtitle,Fname,Spec,Sdate,Stime,Did from Doctor,Doc_Schedule where Doctor.DID=Doc_Schedule.Dno");

                if (dt.Rows.Count == 0)
                {
                    appointment_1_name.Text = "No Schedules";
                    appointment_2_name.Text = "No Schedules";
                    appointment_3_name.Text = "No Schedules";
                    appointment_4_name.Text = "No Schedules";
                    appointment_5_name.Text = "No Schedules";
                    appointment_6_name.Text = "No Schedules";
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";
                }

                else if (dt.Rows.Count == 1)
                {
                    appointment_2_name.Text = "No Schedules";
                    appointment_3_name.Text = "No Schedules";
                    appointment_4_name.Text = "No Schedules";
                    appointment_5_name.Text = "No Schedules";
                    appointment_6_name.Text = "No Schedules";
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();
                }

                else if (dt.Rows.Count == 2)
                {
                    appointment_3_name.Text = "No Schedules";
                    appointment_4_name.Text = "No Schedules";
                    appointment_5_name.Text = "No Schedules";
                    appointment_6_name.Text = "No Schedules";
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();
                }

                else if (dt.Rows.Count == 3)
                {
                    appointment_4_name.Text = "No Schedules";
                    appointment_5_name.Text = "No Schedules";
                    appointment_6_name.Text = "No Schedules";
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();


                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();
                }

                else if (dt.Rows.Count == 4)
                {
                    appointment_5_name.Text = "No Schedules";
                    appointment_6_name.Text = "No Schedules";
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();


                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    appointment_4_name.Text = dt.Rows[3][1].ToString() + " " + dt.Rows[3][0].ToString() + " " + dt.Rows[3][5].ToString();
                    appointment_4_cat.Text = dt.Rows[3][2].ToString();
                    appointment_4_date.Text = dt.Rows[3][3].ToString();
                    appointment_4_time.Text = dt.Rows[3][4].ToString();
                }

                else if (dt.Rows.Count == 5)
                {
                    appointment_6_name.Text = "No Schedules";
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    appointment_4_name.Text = dt.Rows[3][1].ToString() + " " + dt.Rows[3][0].ToString() + " " + dt.Rows[3][5].ToString();
                    appointment_4_cat.Text = dt.Rows[3][2].ToString();
                    appointment_4_date.Text = dt.Rows[3][3].ToString();
                    appointment_4_time.Text = dt.Rows[3][4].ToString();

                    appointment_5_name.Text = dt.Rows[4][1].ToString() + " " + dt.Rows[4][0].ToString() + " " + dt.Rows[4][5].ToString();
                    appointment_5_cat.Text = dt.Rows[4][2].ToString();
                    appointment_5_date.Text = dt.Rows[4][3].ToString();
                    appointment_5_time.Text = dt.Rows[4][4].ToString();
                }

                else if (dt.Rows.Count == 6)
                {
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    appointment_4_name.Text = dt.Rows[3][1].ToString() + " " + dt.Rows[3][0].ToString() + " " + dt.Rows[3][5].ToString();
                    appointment_4_cat.Text = dt.Rows[3][2].ToString();
                    appointment_4_date.Text = dt.Rows[3][3].ToString();
                    appointment_4_time.Text = dt.Rows[3][4].ToString();

                    appointment_5_name.Text = dt.Rows[4][1].ToString() + " " + dt.Rows[4][0].ToString() + " " + dt.Rows[4][5].ToString();
                    appointment_5_cat.Text = dt.Rows[4][2].ToString();
                    appointment_5_date.Text = dt.Rows[4][3].ToString();
                    appointment_5_time.Text = dt.Rows[4][4].ToString();

                    appointment_6_name.Text = dt.Rows[5][1].ToString() + " " + dt.Rows[5][0].ToString() + " " + dt.Rows[5][5].ToString();
                    appointment_6_cat.Text = dt.Rows[5][2].ToString();
                    appointment_6_date.Text = dt.Rows[5][3].ToString();
                    appointment_6_time.Text = dt.Rows[5][4].ToString();
                }

                else if (dt.Rows.Count == 7)
                {
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    appointment_4_name.Text = dt.Rows[3][1].ToString() + " " + dt.Rows[3][0].ToString() + " " + dt.Rows[3][5].ToString();
                    appointment_4_cat.Text = dt.Rows[3][2].ToString();
                    appointment_4_date.Text = dt.Rows[3][3].ToString();
                    appointment_4_time.Text = dt.Rows[3][4].ToString();

                    appointment_5_name.Text = dt.Rows[4][1].ToString() + " " + dt.Rows[4][0].ToString() + " " + dt.Rows[4][5].ToString();
                    appointment_5_cat.Text = dt.Rows[4][2].ToString();
                    appointment_5_date.Text = dt.Rows[4][3].ToString();
                    appointment_5_time.Text = dt.Rows[4][4].ToString();

                    appointment_6_name.Text = dt.Rows[5][1].ToString() + " " + dt.Rows[5][0].ToString() + " " + dt.Rows[5][5].ToString();
                    appointment_6_cat.Text = dt.Rows[5][2].ToString();
                    appointment_6_date.Text = dt.Rows[5][3].ToString();
                    appointment_6_time.Text = dt.Rows[5][4].ToString();

                    appointment_7_name.Text = dt.Rows[6][1].ToString() + " " + dt.Rows[6][0].ToString() + " " + dt.Rows[6][5].ToString();
                    appointment_7_cat.Text = dt.Rows[6][2].ToString();
                    appointment_7_date.Text = dt.Rows[6][3].ToString();
                    appointment_7_time.Text = dt.Rows[6][4].ToString();
                }

                else if (dt.Rows.Count == 8)
                {
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    appointment_4_name.Text = dt.Rows[3][1].ToString() + " " + dt.Rows[3][0].ToString() + " " + dt.Rows[3][5].ToString();
                    appointment_4_cat.Text = dt.Rows[3][2].ToString();
                    appointment_4_date.Text = dt.Rows[3][3].ToString();
                    appointment_4_time.Text = dt.Rows[3][4].ToString();

                    appointment_5_name.Text = dt.Rows[4][1].ToString() + " " + dt.Rows[4][0].ToString() + " " + dt.Rows[4][5].ToString();
                    appointment_5_cat.Text = dt.Rows[4][2].ToString();
                    appointment_5_date.Text = dt.Rows[4][3].ToString();
                    appointment_5_time.Text = dt.Rows[4][4].ToString();

                    appointment_6_name.Text = dt.Rows[5][1].ToString() + " " + dt.Rows[5][0].ToString() + " " + dt.Rows[5][5].ToString();
                    appointment_6_cat.Text = dt.Rows[5][2].ToString();
                    appointment_6_date.Text = dt.Rows[5][3].ToString();
                    appointment_6_time.Text = dt.Rows[5][4].ToString();

                    appointment_7_name.Text = dt.Rows[6][1].ToString() + " " + dt.Rows[6][0].ToString() + " " + dt.Rows[6][5].ToString();
                    appointment_7_cat.Text = dt.Rows[6][2].ToString();
                    appointment_7_date.Text = dt.Rows[6][3].ToString();
                    appointment_7_time.Text = dt.Rows[6][4].ToString();

                    appointment_8_name.Text = dt.Rows[7][1].ToString() + " " + dt.Rows[7][0].ToString() + " " + dt.Rows[7][5].ToString();
                    appointment_8_cat.Text = dt.Rows[7][2].ToString();
                    appointment_8_date.Text = dt.Rows[7][3].ToString();
                    appointment_8_time.Text = dt.Rows[7][4].ToString();
                }

                else if (dt.Rows.Count >= 9)
                {
                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    appointment_4_name.Text = dt.Rows[3][1].ToString() + " " + dt.Rows[3][0].ToString() + " " + dt.Rows[3][5].ToString();
                    appointment_4_cat.Text = dt.Rows[3][2].ToString();
                    appointment_4_date.Text = dt.Rows[3][3].ToString();
                    appointment_4_time.Text = dt.Rows[3][4].ToString();

                    appointment_5_name.Text = dt.Rows[4][1].ToString() + " " + dt.Rows[4][0].ToString() + " " + dt.Rows[4][5].ToString();
                    appointment_5_cat.Text = dt.Rows[4][2].ToString();
                    appointment_5_date.Text = dt.Rows[4][3].ToString();
                    appointment_5_time.Text = dt.Rows[4][4].ToString();

                    appointment_6_name.Text = dt.Rows[5][1].ToString() + " " + dt.Rows[5][0].ToString() + " " + dt.Rows[5][5].ToString();
                    appointment_6_cat.Text = dt.Rows[5][2].ToString();
                    appointment_6_date.Text = dt.Rows[5][3].ToString();
                    appointment_6_time.Text = dt.Rows[5][4].ToString();

                    appointment_7_name.Text = dt.Rows[6][1].ToString() + " " + dt.Rows[6][0].ToString() + " " + dt.Rows[6][5].ToString();
                    appointment_7_cat.Text = dt.Rows[6][2].ToString();
                    appointment_7_date.Text = dt.Rows[6][3].ToString();
                    appointment_7_time.Text = dt.Rows[6][4].ToString();

                    appointment_8_name.Text = dt.Rows[7][1].ToString() + " " + dt.Rows[7][0].ToString() + " " + dt.Rows[7][5].ToString();
                    appointment_8_cat.Text = dt.Rows[7][2].ToString();
                    appointment_8_date.Text = dt.Rows[7][3].ToString();
                    appointment_8_time.Text = dt.Rows[7][4].ToString();

                    appointment_9_name.Text = dt.Rows[8][1].ToString() + " " + dt.Rows[8][0].ToString() + " " + dt.Rows[8][5].ToString();
                    appointment_9_cat.Text = dt.Rows[8][2].ToString();
                    appointment_9_date.Text = dt.Rows[8][3].ToString();
                    appointment_9_time.Text = dt.Rows[8][4].ToString();
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
            appointment_1_name.Clear();
            appointment_1_cat.Clear();
            appointment_1_date.Clear();
            appointment_1_time.Clear();

            appointment_2_name.Clear();
            appointment_2_cat.Clear();
            appointment_2_date.Clear();
            appointment_2_time.Clear();

            appointment_3_name.Clear();
            appointment_3_cat.Clear();
            appointment_3_date.Clear();
            appointment_3_time.Clear();

            appointment_4_name.Clear();
            appointment_4_cat.Clear();
            appointment_4_date.Clear();
            appointment_4_time.Clear();

            appointment_5_name.Clear();
            appointment_5_cat.Clear();
            appointment_5_date.Clear();
            appointment_5_time.Clear();

            appointment_6_name.Clear();
            appointment_6_cat.Clear();
            appointment_6_date.Clear();
            appointment_6_time.Clear();

            appointment_7_name.Clear();
            appointment_7_cat.Clear();
            appointment_7_date.Clear();
            appointment_7_time.Clear();

            appointment_8_name.Clear();
            appointment_8_cat.Clear();
            appointment_8_date.Clear();
            appointment_8_time.Clear();

            appointment_9_name.Clear();
            appointment_9_cat.Clear();
            appointment_9_date.Clear();
            appointment_9_time.Clear();



        }

        private void cmb_appointment_spec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clear();

            try
            {
                string m = "";
                if (cmb_appointment_spec.SelectedIndex == 0)
                    m = "Neurology";
                else if (cmb_appointment_spec.SelectedIndex == 2)
                    m = "Cardiology";
                else if (cmb_appointment_spec.SelectedIndex == 4)
                    m = "Surgeon";
                else if (cmb_appointment_spec.SelectedIndex == 6)
                    m = "Pediatrics";
                else if (cmb_appointment_spec.SelectedIndex == 8)
                    m = "Physician";

                DataTable dt = data.display("Select Dtitle,Fname,Spec,Sdate,Stime,Did from Doctor,Doc_Schedule where Doctor.DID=Doc_Schedule.Dno and Spec='" + m + "'");

                if (dt.Rows.Count == 0)
                {
                    cmb_appointment_doc.Items.Clear();
                    appointment_1_name.Text = "No Schedules";
                    appointment_2_name.Text = "No Schedules";
                    appointment_3_name.Text = "No Schedules";
                    appointment_4_name.Text = "No Schedules";
                    appointment_5_name.Text = "No Schedules";
                    appointment_6_name.Text = "No Schedules";
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";
                }

                else if (dt.Rows.Count == 1)
                {
                    cmb_appointment_doc.Items.Clear();
                    appointment_2_name.Text = "No Schedules";
                    appointment_3_name.Text = "No Schedules";
                    appointment_4_name.Text = "No Schedules";
                    appointment_5_name.Text = "No Schedules";
                    appointment_6_name.Text = "No Schedules";
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    cmb_appointment_doc.Items.Add(dt.Rows[0][5].ToString());
                }

                else if (dt.Rows.Count == 2)
                {
                    cmb_appointment_doc.Items.Clear();
                    appointment_3_name.Text = "No Schedules";
                    appointment_4_name.Text = "No Schedules";
                    appointment_5_name.Text = "No Schedules";
                    appointment_6_name.Text = "No Schedules";
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    cmb_appointment_doc.Items.Add(dt.Rows[0][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[1][5].ToString());
                }

                else if (dt.Rows.Count == 3)
                {
                    cmb_appointment_doc.Items.Clear();
                    appointment_4_name.Text = "No Schedules";
                    appointment_5_name.Text = "No Schedules";
                    appointment_6_name.Text = "No Schedules";
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();


                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    cmb_appointment_doc.Items.Add(dt.Rows[0][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[1][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[2][5].ToString());
                }

                else if (dt.Rows.Count == 4)
                {
                    cmb_appointment_doc.Items.Clear();
                    appointment_5_name.Text = "No Schedules";
                    appointment_6_name.Text = "No Schedules";
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();


                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    appointment_4_name.Text = dt.Rows[3][1].ToString() + " " + dt.Rows[3][0].ToString() + " " + dt.Rows[3][5].ToString();
                    appointment_4_cat.Text = dt.Rows[3][2].ToString();
                    appointment_4_date.Text = dt.Rows[3][3].ToString();
                    appointment_4_time.Text = dt.Rows[3][4].ToString();

                    cmb_appointment_doc.Items.Add(dt.Rows[0][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[1][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[2][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[3][5].ToString());
                }

                else if (dt.Rows.Count == 5)
                {
                    cmb_appointment_doc.Items.Clear();
                    appointment_6_name.Text = "No Schedules";
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    appointment_4_name.Text = dt.Rows[3][1].ToString() + " " + dt.Rows[3][0].ToString() + " " + dt.Rows[3][5].ToString();
                    appointment_4_cat.Text = dt.Rows[3][2].ToString();
                    appointment_4_date.Text = dt.Rows[3][3].ToString();
                    appointment_4_time.Text = dt.Rows[3][4].ToString();

                    appointment_5_name.Text = dt.Rows[4][1].ToString() + " " + dt.Rows[4][0].ToString() + " " + dt.Rows[4][5].ToString();
                    appointment_5_cat.Text = dt.Rows[4][2].ToString();
                    appointment_5_date.Text = dt.Rows[4][3].ToString();
                    appointment_5_time.Text = dt.Rows[4][4].ToString();

                    cmb_appointment_doc.Items.Add(dt.Rows[0][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[1][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[2][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[3][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[4][5].ToString());

                }

                else if (dt.Rows.Count == 6)
                {
                    cmb_appointment_doc.Items.Clear();
                    appointment_7_name.Text = "No Schedules";
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    appointment_4_name.Text = dt.Rows[3][1].ToString() + " " + dt.Rows[3][0].ToString() + " " + dt.Rows[3][5].ToString();
                    appointment_4_cat.Text = dt.Rows[3][2].ToString();
                    appointment_4_date.Text = dt.Rows[3][3].ToString();
                    appointment_4_time.Text = dt.Rows[3][4].ToString();

                    appointment_5_name.Text = dt.Rows[4][1].ToString() + " " + dt.Rows[4][0].ToString() + " " + dt.Rows[4][5].ToString();
                    appointment_5_cat.Text = dt.Rows[4][2].ToString();
                    appointment_5_date.Text = dt.Rows[4][3].ToString();
                    appointment_5_time.Text = dt.Rows[4][4].ToString();

                    appointment_6_name.Text = dt.Rows[5][1].ToString() + " " + dt.Rows[5][0].ToString() + " " + dt.Rows[5][5].ToString();
                    appointment_6_cat.Text = dt.Rows[5][2].ToString();
                    appointment_6_date.Text = dt.Rows[5][3].ToString();
                    appointment_6_time.Text = dt.Rows[5][4].ToString();

                    cmb_appointment_doc.Items.Add(dt.Rows[0][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[1][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[2][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[3][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[4][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[5][5].ToString());
                }

                else if (dt.Rows.Count == 7)
                {
                    cmb_appointment_doc.Items.Clear();
                    appointment_8_name.Text = "No Schedules";
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    appointment_4_name.Text = dt.Rows[3][1].ToString() + " " + dt.Rows[3][0].ToString() + " " + dt.Rows[3][5].ToString();
                    appointment_4_cat.Text = dt.Rows[3][2].ToString();
                    appointment_4_date.Text = dt.Rows[3][3].ToString();
                    appointment_4_time.Text = dt.Rows[3][4].ToString();

                    appointment_5_name.Text = dt.Rows[4][1].ToString() + " " + dt.Rows[4][0].ToString() + " " + dt.Rows[4][5].ToString();
                    appointment_5_cat.Text = dt.Rows[4][2].ToString();
                    appointment_5_date.Text = dt.Rows[4][3].ToString();
                    appointment_5_time.Text = dt.Rows[4][4].ToString();

                    appointment_6_name.Text = dt.Rows[5][1].ToString() + " " + dt.Rows[5][0].ToString() + " " + dt.Rows[5][5].ToString();
                    appointment_6_cat.Text = dt.Rows[5][2].ToString();
                    appointment_6_date.Text = dt.Rows[5][3].ToString();
                    appointment_6_time.Text = dt.Rows[5][4].ToString();

                    appointment_7_name.Text = dt.Rows[6][1].ToString() + " " + dt.Rows[6][0].ToString() + " " + dt.Rows[6][5].ToString();
                    appointment_7_cat.Text = dt.Rows[6][2].ToString();
                    appointment_7_date.Text = dt.Rows[6][3].ToString();
                    appointment_7_time.Text = dt.Rows[6][4].ToString();

                    cmb_appointment_doc.Items.Add(dt.Rows[0][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[1][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[2][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[3][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[4][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[5][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[6][5].ToString());
                }

                else if (dt.Rows.Count == 8)
                {
                    cmb_appointment_doc.Items.Clear();
                    appointment_9_name.Text = "No Schedules";

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    appointment_4_name.Text = dt.Rows[3][1].ToString() + " " + dt.Rows[3][0].ToString() + " " + dt.Rows[3][5].ToString();
                    appointment_4_cat.Text = dt.Rows[3][2].ToString();
                    appointment_4_date.Text = dt.Rows[3][3].ToString();
                    appointment_4_time.Text = dt.Rows[3][4].ToString();

                    appointment_5_name.Text = dt.Rows[4][1].ToString() + " " + dt.Rows[4][0].ToString() + " " + dt.Rows[4][5].ToString();
                    appointment_5_cat.Text = dt.Rows[4][2].ToString();
                    appointment_5_date.Text = dt.Rows[4][3].ToString();
                    appointment_5_time.Text = dt.Rows[4][4].ToString();

                    appointment_6_name.Text = dt.Rows[5][1].ToString() + " " + dt.Rows[5][0].ToString() + " " + dt.Rows[5][5].ToString();
                    appointment_6_cat.Text = dt.Rows[5][2].ToString();
                    appointment_6_date.Text = dt.Rows[5][3].ToString();
                    appointment_6_time.Text = dt.Rows[5][4].ToString();

                    appointment_7_name.Text = dt.Rows[6][1].ToString() + " " + dt.Rows[6][0].ToString() + " " + dt.Rows[6][5].ToString();
                    appointment_7_cat.Text = dt.Rows[6][2].ToString();
                    appointment_7_date.Text = dt.Rows[6][3].ToString();
                    appointment_7_time.Text = dt.Rows[6][4].ToString();

                    appointment_8_name.Text = dt.Rows[7][1].ToString() + " " + dt.Rows[7][0].ToString() + " " + dt.Rows[7][5].ToString();
                    appointment_8_cat.Text = dt.Rows[7][2].ToString();
                    appointment_8_date.Text = dt.Rows[7][3].ToString();
                    appointment_8_time.Text = dt.Rows[7][4].ToString();

                    cmb_appointment_doc.Items.Add(dt.Rows[0][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[1][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[2][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[3][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[4][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[5][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[6][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[7][5].ToString());
                }

                else if (dt.Rows.Count == 9)
                {
                    cmb_appointment_doc.Items.Clear();

                    appointment_1_name.Text = dt.Rows[0][1].ToString() + " " + dt.Rows[0][0].ToString() + " " + dt.Rows[0][5].ToString();
                    appointment_1_cat.Text = dt.Rows[0][2].ToString();
                    appointment_1_date.Text = dt.Rows[0][3].ToString();
                    appointment_1_time.Text = dt.Rows[0][4].ToString();

                    appointment_2_name.Text = dt.Rows[1][1].ToString() + " " + dt.Rows[1][0].ToString() + " " + dt.Rows[1][5].ToString();
                    appointment_2_cat.Text = dt.Rows[1][2].ToString();
                    appointment_2_date.Text = dt.Rows[1][3].ToString();
                    appointment_2_time.Text = dt.Rows[1][4].ToString();

                    appointment_3_name.Text = dt.Rows[2][1].ToString() + " " + dt.Rows[2][0].ToString() + " " + dt.Rows[2][5].ToString();
                    appointment_3_cat.Text = dt.Rows[2][2].ToString();
                    appointment_3_date.Text = dt.Rows[2][3].ToString();
                    appointment_3_time.Text = dt.Rows[2][4].ToString();

                    appointment_4_name.Text = dt.Rows[3][1].ToString() + " " + dt.Rows[3][0].ToString() + " " + dt.Rows[3][5].ToString();
                    appointment_4_cat.Text = dt.Rows[3][2].ToString();
                    appointment_4_date.Text = dt.Rows[3][3].ToString();
                    appointment_4_time.Text = dt.Rows[3][4].ToString();

                    appointment_5_name.Text = dt.Rows[4][1].ToString() + " " + dt.Rows[4][0].ToString() + " " + dt.Rows[4][5].ToString();
                    appointment_5_cat.Text = dt.Rows[4][2].ToString();
                    appointment_5_date.Text = dt.Rows[4][3].ToString();
                    appointment_5_time.Text = dt.Rows[4][4].ToString();

                    appointment_6_name.Text = dt.Rows[5][1].ToString() + " " + dt.Rows[5][0].ToString() + " " + dt.Rows[5][5].ToString();
                    appointment_6_cat.Text = dt.Rows[5][2].ToString();
                    appointment_6_date.Text = dt.Rows[5][3].ToString();
                    appointment_6_time.Text = dt.Rows[5][4].ToString();

                    appointment_7_name.Text = dt.Rows[6][1].ToString() + " " + dt.Rows[6][0].ToString() + " " + dt.Rows[6][5].ToString();
                    appointment_7_cat.Text = dt.Rows[6][2].ToString();
                    appointment_7_date.Text = dt.Rows[6][3].ToString();
                    appointment_7_time.Text = dt.Rows[6][4].ToString();

                    appointment_8_name.Text = dt.Rows[7][1].ToString() + " " + dt.Rows[7][0].ToString() + " " + dt.Rows[7][5].ToString();
                    appointment_8_cat.Text = dt.Rows[7][2].ToString();
                    appointment_8_date.Text = dt.Rows[7][3].ToString();
                    appointment_8_time.Text = dt.Rows[7][4].ToString();

                    appointment_9_name.Text = dt.Rows[8][1].ToString() + " " + dt.Rows[8][0].ToString() + " " + dt.Rows[8][5].ToString();
                    appointment_9_cat.Text = dt.Rows[8][2].ToString();
                    appointment_9_date.Text = dt.Rows[8][3].ToString();
                    appointment_9_time.Text = dt.Rows[8][4].ToString();

                    cmb_appointment_doc.Items.Add(dt.Rows[0][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[1][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[2][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[3][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[4][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[5][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[6][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[7][5].ToString());
                    cmb_appointment_doc.Items.Add(dt.Rows[8][5].ToString());
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

        

        private void btn_clearall_Click_1(object sender, RoutedEventArgs e)
        {
            ClearErrors();
            cmb_ppointment_time_slot.SelectedItem = null;
            cmb_appointment_spec.SelectedItem = null;
            cmb_appointment_doc.Items.Clear();
            txt_make_appointments_name.Clear();
            patinet_appointmentdate_picker.SelectedDate = null; ;
        }

        Validation obj = new Validation();

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_appointment_spec.SelectedItem == null)
            {
                cmb_appointment_spec.Focus();
                txt_error_cmb_spec.Text = "Please Select a Specialization!";
                error_cmb_spec.Visibility = Visibility.Visible;
            }

            else if(cmb_appointment_doc.SelectedItem == null)
            {
                cmb_appointment_doc.Focus();
                txt_error_cmb_doc.Text = "Please Select a Doctor!";
                error_cmb_doc.Visibility = Visibility.Visible;
            }
            else if (cmb_ppointment_time_slot.SelectedItem == null)
            {
                cmb_ppointment_time_slot.Focus();
                txt_error_cmb_slot.Text = "Please Select a Time Slot!";
                error_cmb_slot.Visibility = Visibility.Visible;
            }

            else if(obj.NullValidation(txt_make_appointments_name.Text)==0)
            {
                txt_make_appointments_name.Focus();
                txt_error_name.Text = "Please Enter Your Name!";
                error_name.Visibility = Visibility.Visible;
            }
           
            else if ((obj.NumberDigitValidation(txt_make_appointments_name.Text)) == 0)
            {
                txt_make_appointments_name.Focus();
                txt_error_name.Text = "Name cannot have Digits!";
                error_name.Visibility = Visibility.Visible;
            }

            else if (patinet_appointmentdate_picker.SelectedDate == null)
            {
                patinet_appointmentdate_picker.Focus();
                txt_error_date.Text = "Entered Date is not a correct one!";
                error_date.Visibility = Visibility.Visible;
            }

            else
            {
                try
                {

                    string stime = "", etime = "";
                    if (cmb_ppointment_time_slot.SelectedIndex == 0)
                    {
                        stime = "07.00am";
                        etime = "10.00am";
                    }
                    else if (cmb_ppointment_time_slot.SelectedIndex == 2)
                    {
                        stime = "11.00am";
                        etime = "14.00pm";
                    }
                    else if (cmb_ppointment_time_slot.SelectedIndex == 4)
                    {
                        stime = "15.00pm";
                        etime = "18.00pm";
                    }
                    else if (cmb_ppointment_time_slot.SelectedIndex == 6)
                    {
                        stime = "19.00pm";
                        etime = "22.00pm";
                    }

                    if (cc.getPath() == 1)
                    {

                        string a = "Insert into Appointment (Pno,Dno, Name, Adate,stime,etime) values ('" + cc.GetPno() + "' , '" + cmb_appointment_doc.SelectedItem + "','" + txt_make_appointments_name.Text + "', '" + patinet_appointmentdate_picker.SelectedDate.Value + "','" + stime + "','" + etime + "') ";

                        int i = data.Insert_Update_Delete(a);

                        if (i == 1)
                        {
                            MessageBox.Show("Appointment Scheduled Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                            form_PatientAppointments obj = new form_PatientAppointments(cc.PassLogin());
                            obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Appointment Could not be Scheduled!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

                        }

                    }
                    else
                    {
                        DataTable dt = data.display("Select PID from Login,patient where Login.username=Patient.UID and UID='" + login + "'");
                        string pno = dt.Rows[0][0].ToString();

                        string a = "Insert into Appointment (Pno,Dno, Name, Adate,stime,etime) values ('" + pno + "' , '" + cmb_appointment_doc.SelectedItem + "','" + txt_make_appointments_name.Text + "', '" + patinet_appointmentdate_picker.SelectedDate.Value + "','" + stime + "','" + etime + "') ";

                        int i = data.Insert_Update_Delete(a);

                        if (i == 1)
                            MessageBox.Show("Appointment Scheduled Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        else
                            MessageBox.Show("Appointment Could not be Scheduled!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error occurred!\nPlease Check again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }


            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ClearErrors();
            AddScheduleDetails();
        }
        private void ClearErrors()
        {
            error_cmb_spec.Visibility = Visibility.Collapsed;
            error_cmb_doc.Visibility = Visibility.Collapsed;
            error_name.Visibility = Visibility.Collapsed;
            error_date.Visibility = Visibility.Collapsed;
            error_cmb_slot.Visibility = Visibility.Collapsed;
            
        }


        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            if (cc.getPath() == 1)
            {
                form_MedicalAdminPatient obj = new form_MedicalAdminPatient(login);
                obj.Show();
                this.Hide();
            }
            else
            {
                form_PatientAppointments obj = new form_PatientAppointments(login);
                obj.Show();
                this.Hide();
            }
          
        }

        private void cmb_appointment_spec_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearErrors();
        }

        private void cmb_appointment_doc_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearErrors();
        }

        private void txt_make_appointments_name_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearErrors();
        }

        private void patinet_appointmentdate_picker_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearErrors();
        }

        private void cmb_ppointment_time_slot_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ClearErrors();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
