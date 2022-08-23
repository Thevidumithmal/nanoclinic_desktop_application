using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NanoClinic
{
    class Validation
    {
        public int NullValidation(string a)
        {
            if (string.IsNullOrEmpty(a))
                return 0;
            else
                return 1;

        }

        public int EmailFormatValidation(string b) //check format of email
        {
            if (!Regex.IsMatch(b, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                return 0;
            else
                return 1;
        }
        public int NumberDigitValidation(string a)
        {
            if (a.All(char.IsLetter))
                return 1;
            else
                return 0;
        }

        public int TPFormatValidation(string c) //check format of telephone numbers
        {
            if (!(Regex.IsMatch(c, @"^(?:7|0|(?:\+94))[0-9]{8,9}$")))
                return 0;
            else
                return 1;
        }
        public int LetterChck(string c) //check format of telephone numbers
        {
            if (c.Any(char.IsLetter))
                return 0;
            else
                return 1;
        }

        //public int Format

        //if (txt_fname.Text.Any(char.IsDigit))
        //   {
        //        error_msg.Text = "First Name cannot have numbers";
        //        txt_fname.Focus();
        //    }

    }
}
