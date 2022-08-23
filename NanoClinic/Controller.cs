using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoClinic
{
    class Controller
    {
        static string login="";
        static string Pno = "";
        static string Dno = "";
        static string Sno = "";
        static int path=0;

        public void CreateLogin(string l)
        {
            login = l;
        }
        public string PassLogin()
        {
            return login;
        }
        public void CancellOGIN()
        {
            login = null;
        }
        public string  CreatePassword()
        {
            
                int length = 8;
                const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
            try
            {
                while (0 < length--)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                }
                
            }
            catch (Exception)
            {

            }
            
            return (res.ToString());
        }
        public string CreateUsername()
        {
          
            
                int length = 12;
                const string valid = "abcdefghijklmnopqrstuvwxyz";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                while (0 < length--)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                }
                return (res.ToString());
            
        }
        public string CreateId()
        {

            int length = 4;
            const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return (res.ToString());
        }
        public void SetPno(string no)
        {
            Pno = no;
        }
        public string GetPno()
        {
            return Pno;
        }

        public void setPath(int c)
        {
            path = 0;
            path = c;
        }
        public int getPath()
        {
            return path;
        }

        public void SetDno(string no)
        {
            Dno = no;
        }
        public string GetDno()
        {
            return Dno;
        }
        public void SetSno(string no)
        {
            Sno = no;
        }
        public string GetSno()
        {
            return Sno;
        }
    }
}
