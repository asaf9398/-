using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02_Asaf_319094322_Liat_207918608
{
    public static class InputValidator
    {
        public static bool IsValidMoveFormat(string i_Input)
        {
            return i_Input.Contains(">") && i_Input.Length >= 5; // לדוגמה: Fa>Fb
        }
    }

}
