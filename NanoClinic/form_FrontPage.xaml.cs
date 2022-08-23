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
using System.Windows.Threading;


namespace NanoClinic
{
    /// <summary>
    /// Interaction logic for form_FrontPage.xaml
    /// </summary>
    public partial class form_FrontPage : Window
    {

        DispatcherTimer dt = new DispatcherTimer();

        public form_FrontPage()
        {
            InitializeComponent();
            Process();
        }

        private void dt_Tick(object Sender, EventArgs e)
        {
            form_Login db = new form_Login();
            db.Show();

            dt.Stop();
            this.Hide();
        }
        private void Process()
        {
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 10);
            dt.Start();
        }


    }
}
