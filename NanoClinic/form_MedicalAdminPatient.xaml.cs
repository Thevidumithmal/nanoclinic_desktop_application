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
using System.Data;

namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_MedicalAdminPatient.xaml
    /// </summary>
    public partial class form_MedicalAdminPatient : Window
    {
        Validation obj = new Validation();
        DataBaseConnection data = new DataBaseConnection();
        Controller cc = new Controller();
        string login;
        public form_MedicalAdminPatient(string login)
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

        private void addDetials()
        {
            try
            {
                DataTable dt = data.display("Select tittle,Fname,sid from Login,Medical_staff where Login.username=Medical_staff.UID and UID='" + login + "'");
                string madminid = dt.Rows[0][2].ToString();
                txt_username.Text = (dt.Rows[0][0].ToString()) + "  " + (dt.Rows[0][1].ToString());
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
        private void btn_general_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminDashBoard obj_medicaladmindashboard = new form_MedicalAdminDashBoard(cc.PassLogin());
            obj_medicaladmindashboard.Show();
            this.Hide();
        }
        private void btn_profile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminProfile obj_medicaladminprofile = new form_MedicalAdminProfile(cc.PassLogin());
            obj_medicaladminprofile.Show();
            this.Hide();
        }

        private void btn_doctors_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminDoctors obj_medicaladmindoctors = new form_MedicalAdminDoctors(cc.PassLogin());
            obj_medicaladmindoctors.Show();
            this.Hide();
        }

        private void btn_appointments_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            form_MedicalAdminAppointments obj_medicaladminappointments = new form_MedicalAdminAppointments(cc.PassLogin());
            obj_medicaladminappointments.Show();
            this.Hide();
        }

        private int checkpatinetid(string var)
        {
            int c;
            DataTable dt = data.display("Select * from patient where pid COLLATE Latin1_General_CS_AS ='" + var+"'");
            if (dt.Rows.Count == 0)
            {
                c= 0;
            }
            else
            {
                c = 1;
            }
            return c;
           
        }
        private void btn_add_patient_Click(object sender, RoutedEventArgs e)
        {

            errorclearhealth();
            if ((obj.NullValidation(txt_patinet_idd.Text)) == 0)
            {
                txt_patinet_idd.Focus();
                txt_error_id.Text = "Enter a Valid Id!";
                error_id.Visibility = Visibility.Visible;
            }
            else if ((obj.NullValidation(txt_patient_height.Text)) == 0)
            {
                txt_patient_height.Focus();
                txt_error_height.Text = "Height cannot be blank!";
                error_height.Visibility = Visibility.Visible;
            }
            else if ((obj.LetterChck(txt_patient_height.Text)) == 0)
            {
                txt_patient_height.Focus();
                txt_error_height.Text = "Enter numbers only!";
                error_height.Visibility = Visibility.Visible;
            }
            else if ((obj.NullValidation(txt_patient_weight.Text)) == 0)
            {
                txt_patient_weight.Focus();
                txt_error_weight.Text = "Weight cannot be blank!";
                error_weight.Visibility = Visibility.Visible;
            }
            else if ((obj.LetterChck(txt_patient_weight.Text)) == 0)
            {
                txt_patient_weight.Focus();
                txt_error_weight.Text = "Enter numbers only!";
                error_weight.Visibility = Visibility.Visible;
            }
            else if ((obj.NullValidation(txt_patient_diabetes.Text)) == 0)
            {
                txt_patient_diabetes.Focus();
                txt_error_diabetes.Text = "Value cannot be blank!";
                error_daibetes.Visibility = Visibility.Visible;
            }
            else if ((obj.LetterChck(txt_patient_diabetes.Text)) == 0)
            {
                txt_patient_diabetes.Focus();
                txt_error_diabetes.Text = "Value cannot have letters!";
                error_daibetes.Visibility = Visibility.Visible;
            }
            else if ((obj.NullValidation(txt_patient_cholestorole.Text)) == 0)
            {
                txt_patient_cholestorole.Focus();
                txt_error_colesterole.Text = "Value cannot be blank!";
                error_cholestorole.Visibility = Visibility.Visible;
            }
            else if ((obj.LetterChck(txt_patient_cholestorole.Text)) == 0)
            {
                txt_patient_cholestorole.Focus();
                txt_error_colesterole.Text = "Value cannot have letters!";
                error_cholestorole.Visibility = Visibility.Visible;
            }
            else if (rdio_Patient_Allergic_yes.IsChecked == false & rdio_Patient_Allergic_no.IsChecked == false)
            {

                txt_error_LLERGIC.Text = "Please make a selection!";
                error_allergic.Visibility = Visibility.Visible;

            }
            else if ((obj.NullValidation(txt_patient_bloodpressure.Text)) == 0)
            {
                txt_patient_bloodpressure.Focus();
                txt_error_HB.Text = "Value cannot be blank!";
                error_HB.Visibility = Visibility.Visible;
            }
            else if ((obj.LetterChck(txt_patient_bloodpressure.Text)) == 0)
            {
                txt_patient_bloodpressure.Focus();
                txt_error_HB.Text = "Value cannot have letters!";
                error_HB.Visibility = Visibility.Visible;
            }
            else if (rdio_Patient_cancer_yes.IsChecked == false & rdio_Patient_cancer_no.IsChecked == false)
            {

                txt_error_cancer.Text = "Please make a selection!";
                error_cancer.Visibility = Visibility.Visible;

            }
            else if (rdio_Patient_depression_yes.IsChecked == false & rdio_Patient_depression_no.IsChecked == false)
            {

                txt_error_depression.Text = "Please make a selection!";
                error_depression.Visibility = Visibility.Visible;

            }
            else if (rdio_Patient_alcohol_yes.IsChecked == false & rdio_Patient_alcohol_no.IsChecked == false)
            {

                txt_error_alcohol.Text = "Please make a selection!";
                error_alcohol.Visibility = Visibility.Visible;

            }
            else if (rdio_Patient_smokig_yes.IsChecked == false & rdio_Patient_smokig_no.IsChecked == false)
            {

                txt_error_smorking.Text = "Please make a selection!";
                error_smorking.Visibility = Visibility.Visible;

            }
            else if (rdio_Patient_drug_yes.IsChecked == false & rdio_Patient_drug_no.IsChecked == false)
            {

                txt_error_drug.Text = "Please make a selection!";
                error_drug.Visibility = Visibility.Visible;

            }
            else
            {

               int c= checkpatinetid(txt_patinet_idd.Text);

                if (c==0)
                {
                    txt_patinet_idd.Focus();
                    txt_error_id.Text = "Enter a Valid Id!";
                    error_id.Visibility = Visibility.Visible;
                }
                else
                {
                    string cancer = "", allergic = "", cholesterol = "", smorking = "", diabetes = "", alcohol = "", drug = "", depression = "", hb = "";


                    if (rdio_Patient_cancer_yes.IsChecked == true)
                    {
                        cancer = "Yes";
                    }
                    else if (rdio_Patient_cancer_no.IsChecked == true)
                    {
                        cancer = "No";

                    }

                    if (rdio_Patient_Allergic_yes.IsChecked == true)
                    {
                        allergic = "Yes";
                    }
                    else if (rdio_Patient_Allergic_no.IsChecked == true)
                    {
                        allergic = "No";

                    }

                    if (rdio_Patient_depression_yes.IsChecked == true)
                    {
                        depression = "Yes";
                    }
                    else if (rdio_Patient_depression_no.IsChecked == true)
                    {
                        depression = "No";

                    }


                    if (rdio_Patient_alcohol_yes.IsChecked == true)
                    {
                        alcohol = "Yes";
                    }
                    else if (rdio_Patient_alcohol_no.IsChecked == true)
                    {
                        alcohol = "No";

                    }


                    if (rdio_Patient_smokig_yes.IsChecked == true)
                    {
                        smorking = "Yes";
                    }
                    else if (rdio_Patient_smokig_no.IsChecked == true)
                    {
                        smorking = "No";

                    }

                    if (rdio_Patient_drug_yes.IsChecked == true)
                    {
                        drug = "Yes";
                    }
                    else if (rdio_Patient_drug_no.IsChecked == true)
                    {
                        drug = "No";

                    }




                    if (Convert.ToDouble(txt_patient_cholestorole.Text) >= 100)
                    {
                        cholesterol = "Yes";
                    }
                    else
                    {
                        cholesterol = "No";

                    }

                    if (Convert.ToDouble(txt_patient_diabetes.Text) >= 115)
                    {
                        diabetes = "Yes";
                    }
                    else
                    {
                        diabetes = "No";

                    }

                    if (Convert.ToDouble(txt_patient_bloodpressure.Text) >= 205)
                    {
                        hb = "Yes";
                    }
                    else
                    {
                        hb = "No";

                    }


                    string q = "Insert into Patient_Health values('" + txt_patinet_idd.Text + "','" + txt_patient_height.Text + "','" + txt_patient_weight.Text + "','" + cancer + "','" + allergic + "','" + cholesterol + "','" + txt_patient_cholestorole.Text + "','" + smorking + "','" + diabetes + "','" + txt_patient_diabetes.Text + "','" + alcohol + "','" + drug + "','" + depression + "','" + hb + "','" + txt_patient_bloodpressure.Text + "','" + DateTime.Now + "')";


                    int d = data.Insert_Update_Delete(q);
                    if (d == 1)
                    {

                        MessageBox.Show("Updated Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


                    }
                    else
                    {

                        MessageBoxResult result=MessageBox.Show("Update Failed!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);


                        if (result == MessageBoxResult.OK)
                        {

                            dataclearhealth();


                            errorclearhealth();
                        }
                        else
                        {

                            dataclearhealth();


                            errorclearhealth();
                            form_MedicalAdminPatient obj = new form_MedicalAdminPatient(cc.PassLogin());
                            obj.Show();
                            this.Hide();
                        }

                    }



                }




            }







        }

        private void dataclearhealth()
        {

            txt_patinet_idd.Clear();
            txt_patient_height.Clear();
            txt_patient_weight.Clear();
            txt_patient_diabetes.Clear();
            txt_patient_cholestorole.Clear();
            txt_patient_bloodpressure.Clear();

            rdio_Patient_Allergic_yes.IsChecked = false;
            rdio_Patient_Allergic_no.IsChecked = false;

            rdio_Patient_cancer_yes.IsChecked = false;
            rdio_Patient_cancer_no.IsChecked = false;

            rdio_Patient_depression_yes.IsChecked = false;
            rdio_Patient_depression_no.IsChecked = false;

            rdio_Patient_alcohol_yes.IsChecked = false;
            rdio_Patient_alcohol_no.IsChecked = false;

            rdio_Patient_smokig_yes.IsChecked = false;
            rdio_Patient_smokig_no.IsChecked = false;

            rdio_Patient_drug_yes.IsChecked = false;
            rdio_Patient_drug_no.IsChecked = false;
        }

        private void errorclearhealth()
        {
            error_id.Visibility = Visibility.Collapsed;
            error_height.Visibility = Visibility.Collapsed;
            error_weight.Visibility = Visibility.Collapsed;
            error_daibetes.Visibility = Visibility.Collapsed;
            error_cholestorole.Visibility = Visibility.Collapsed;
            error_HB.Visibility = Visibility.Collapsed;
            error_allergic.Visibility = Visibility.Collapsed;
            error_cancer.Visibility = Visibility.Collapsed;
            error_depression.Visibility = Visibility.Collapsed;
            error_alcohol.Visibility = Visibility.Collapsed;
            error_smorking.Visibility = Visibility.Collapsed;
            error_drug.Visibility = Visibility.Collapsed;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
            addDetials();
            clearcal();
            dataclearhealth();
            error_update_patient_profile.Visibility = Visibility.Collapsed;
            error_new_appointments.Visibility = Visibility.Collapsed;
            error_delete_profile.Visibility = Visibility.Collapsed;
        }

        private void txt_patinet_idd_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            errorclearhealth();
        }

        private void txt_patient_height_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            errorclearhealth();
        }

        private void txt_patient_weight_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            errorclearhealth();
        }

        private void txt_patient_diabetes_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            errorclearhealth();
        }

        private void txt_patient_cholestorole_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            errorclearhealth();
        }

        private void txt_patient_bloodpressure_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            errorclearhealth();
        }

        private void rdio_Patient_Allergic_yes_Click(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
        }

        private void rdio_Patient_Allergic_no_Click(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
        }

        private void rdio_Patient_cancer_yes_Click(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
        }

        private void rdio_Patient_cancer_no_Click(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
        }

        private void rdio_Patient_depression_yes_Click(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
        }

        private void rdio_Patient_depression_no_Click(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
        }

        private void rdio_Patient_alcohol_yes_Click(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
        }

        private void rdio_Patient_alcohol_no_Click(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
        }

        private void rdio_Patient_smokig_yes_Click(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
        }

        private void rdio_Patient_smokig_no_Click(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
        }

        private void rdio_Patient_drug_yes_Click(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
        }

        private void rdio_Patient_drug_no_Click(object sender, RoutedEventArgs e)
        {
            errorclearhealth();
        }

        private void btn_new_patient_Click(object sender, RoutedEventArgs e)
        {
            cc.setPath(1);
            form_PatientRegistration_1 obj = new form_PatientRegistration_1();
            obj.Show();
            this.Hide();
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {

            clearcal();

            if (cmb_category_staff.SelectedItem == null)
            {
                cmb_category_staff.Focus();
                txt_error_cmb_desease.Text = "Please Select a category!";
                error_cmb_desease.Visibility = Visibility.Visible;
            }

            else if (staff_check_patinet_start_date.SelectedDate == null)
            {
                staff_check_patinet_start_date.Focus();
                txt_error_start.Text = "Please make a selection!";
                error_start.Visibility = Visibility.Visible;
            }
            else if (staff_check_patinet_end_date.SelectedDate == null)
            {
                staff_check_patinet_end_date.Focus();
                txt_error_date.Text = "Please make a selection!";
                error_date.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {

                    int c = checkpatinetid(txt_patinet_id_check.Text);

                    if (c == 0)
                    {
                        txt_patinet_id_check.Focus();
                        txt_error_id_check.Text = "Enter a Valid Id!";
                        error_id_check.Visibility = Visibility.Visible;
                    }
                    else
                    {

                        string m = "";
                        if (cmb_category_staff.SelectedIndex == 0)
                        {
                            m = "Rdia";
                        }
                        else if (cmb_category_staff.SelectedIndex == 2)
                        {
                            m = "Rcho";
                        }
                        else if (cmb_category_staff.SelectedIndex == 4)
                        {
                            m = "Rhb";
                        }
                        DataTable dt = data.display("Select Max(" + m + "),Min(" + m + "),Avg(" + m + ") from Patient_health where pno='" + txt_patinet_id_check.Text + "' and Hdate between '" + staff_check_patinet_start_date.Text + "' and '" + staff_check_patinet_end_date.Text + "'");


                        min.Text = dt.Rows[0][1].ToString();
                        max.Text = dt.Rows[0][0].ToString();
                        avg.Text = dt.Rows[0][2].ToString();
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
        private void clearcal()
        {
            error_id_check.Visibility = Visibility.Collapsed;
            error_start.Visibility = Visibility.Collapsed;
            error_date.Visibility = Visibility.Collapsed;
            error_cmb_desease.Visibility = Visibility.Collapsed;
            error_id_check.Visibility = Visibility.Collapsed;
        }
        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {



            clearcal();
            cmb_category_staff.SelectedItem = null;
            staff_check_patinet_start_date.SelectedDate = null;
            staff_check_patinet_end_date.SelectedDate = null;
        }

        private void txt_patinet_id_check_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clearcal();
        }

        private void cmb_category_staff_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clearcal();
        }

        private void staff_check_patinet_start_date_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clearcal();
        }

        private void staff_check_patinet_end_date_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clearcal();
        }

        private void btn_back_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_MedicalAdminDoctors obj = new form_MedicalAdminDoctors(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        private void btn_next_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            form_MedicalAdminAppointments obj = new form_MedicalAdminAppointments(cc.PassLogin());
            obj.Show();
            this.Hide();
        }

        

        private void btn_patient_profile_update_Click_1(object sender, RoutedEventArgs e)
        {
            int c = checkpatinetid(txt_patinet_id_check_update_pfile.Text);

            if (c == 0)
            {
                txt_patinet_id_check_update_pfile.Focus();
                txt_error_update_patient_profile.Text = "Enter a Valid Id!";
                error_update_patient_profile.Visibility = Visibility.Visible;
            }
            else
            {
                cc.setPath(1);
                cc.SetPno(txt_patinet_id_check_update_pfile.Text);
                form_PatientUpdateProfile_PatinetInfo obj = new form_PatientUpdateProfile_PatinetInfo(cc.PassLogin());
                obj.Show();
                this.Hide();
            }
        }

        private void btn_new_appointments_Click(object sender, RoutedEventArgs e)
        {

            int c = checkpatinetid(txt_patinet_id_new_appointments.Text);

            if (c == 0)
            {
                txt_patinet_id_new_appointments.Focus();
                txt_error_new_appointments.Text = "Enter a Valid Id!";
                error_new_appointments.Visibility = Visibility.Visible;
            }
            else
            {
                cc.setPath(1);
                cc.SetPno(txt_patinet_id_new_appointments.Text);
                form_PatientMakeAppointments obj = new form_PatientMakeAppointments(cc.PassLogin());
                obj.Show();
                this.Hide();
            }
        }

        private void txt_patinet_id_check_update_pfile_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_update_patient_profile.Visibility = Visibility.Collapsed;
            error_new_appointments.Visibility = Visibility.Collapsed;
            error_delete_profile.Visibility = Visibility.Collapsed;
        }

        private void txt_patinet_id_new_appointments_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_update_patient_profile.Visibility = Visibility.Collapsed;
            error_new_appointments.Visibility = Visibility.Collapsed;
            error_delete_profile.Visibility = Visibility.Collapsed;
        }

        private void txt_patinet_id_delete_appointments_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            error_update_patient_profile.Visibility = Visibility.Collapsed;
            error_new_appointments.Visibility = Visibility.Collapsed;
            error_delete_profile.Visibility = Visibility.Collapsed;
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_delete_profile_Click(object sender, RoutedEventArgs e)
        {
            error_delete_profile.Visibility = Visibility.Collapsed;

            int c = checkpatinetid(txt_patinet_id_deletepatient_profiles.Text);
            if (c == 0)
            {
                txt_patinet_id_deletepatient_profiles.Focus();
                txt_error_delete_profile.Text = "Enter a valid ID!";
                error_delete_profile.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to Delete  the Patient Profile?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {


                        DataTable dt = data.display("Select UID from Patient where PID='" + txt_patinet_id_deletepatient_profiles.Text + "'");
                        string uid = dt.Rows[0][0].ToString();


                        string q = "Delete from Patient_health where pno='" + txt_patinet_id_deletepatient_profiles.Text + "'";
                        string w = "Delete from appointment where pno='" + txt_patinet_id_deletepatient_profiles.Text + "'";
                        string u = "Delete from Gurdian where pno = '" + txt_patinet_id_deletepatient_profiles.Text + "'";
                        string t = "Delete from patient where pid='" + txt_patinet_id_deletepatient_profiles.Text + "'";
                        string r = "Delete from login where username='" + uid + "'";


                        int f = data.Insert_Update_Delete(t);
                        int g = data.Insert_Update_Delete(r);
                        int g1 = data.Insert_Update_Delete(q);
                        int g2 = data.Insert_Update_Delete(w);
                        int g3 = data.Insert_Update_Delete(u);


                        MessageBox.Show("You successfully deleted the Patient profile.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        txt_patinet_id_deletepatient_profiles.Clear();

                    }
                    else
                    {
                        txt_patinet_id_deletepatient_profiles.Clear();

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
    }
}
