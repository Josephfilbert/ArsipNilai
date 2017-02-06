using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArsipNilai
{
    public class CommonFunctions
    {
        public static bool IsNumeric(string str)
        {
            int dummy;
            return int.TryParse(str, out dummy);
        }

        public static void InvokeErrorMsg(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static int getNumDigits(int num)
        {
            return (int)Math.Ceiling(Math.Log10(num));
        }
    }
}
