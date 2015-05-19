using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyChocolates
{
    class Library
    {

        public static int CHOCOLATE_QUALITY_CONTROL = 2;

        public static void onlyAllowNumerics(Object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt64(((TextBox)sender).Text);
            }
            catch (FormatException ex)
            {
                Regex digitsOnly = new Regex(@"[^\d]");
                ((TextBox)sender).Text = digitsOnly.Replace(((TextBox)sender).Text.ToString(), "");
            }
            if (((TextBox)sender).Text.Length == 0)
                ((TextBox)sender).Text = "0";
        }

        public static void onlyAllowFloats(Object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(((TextBox)sender).Text);
            }
            catch (FormatException ex)
            {
                ((TextBox)sender).Text = wipeToDouble(((TextBox)sender).Text);
            }
            if (((TextBox)sender).Text.Length == 0)
                ((TextBox)sender).Text = "0";
        }

        public static void formatMoney(Object sender, EventArgs e)
        {
            try
            {
                Convert.ToDecimal(((TextBox)sender).Text);
            }
            catch (FormatException ex)
            {
                onlyAllowFloats(sender, e);
            }
            catch (InvalidCastException ex)
            {
                Convert.ToDecimal(((Label)sender).Text);
            }
            if (sender is TextBox)
            {
                ((TextBox)sender).Text = String.Format("{0:0.00}", Convert.ToDecimal(((TextBox)sender).Text));
            }
            else if (sender is Label)
            {
                ((Label)sender).Text = String.Format("{0:0.00}", Convert.ToDecimal(((Label)sender).Text));
            }
        }

        public static void onlyAllowAlphabetics(Object sender, EventArgs e)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            ((TextBox)sender).Text = rgx.Replace(((TextBox)sender).Text, "");
        }

        private static String wipeToDouble(String line)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            String returnString = line;
            int firstPeriod = returnString.IndexOf(".");
            returnString = digitsOnly.Replace(returnString, "");
            if (firstPeriod != -1)
                returnString = returnString.Insert(Math.Min(firstPeriod, returnString.Length), ".");
            if (returnString.Length == 1 && returnString.Equals("."))
                returnString = "0";
            return returnString;
        }

        public static String traverseTableForInitials(TableLayoutPanel table)
        {
            String storedInitials = "";

            foreach (Control c in table.Controls)
            {
                if (c is TextBox)
                {
                    storedInitials += c.Text + "|";
                }
            }

            return storedInitials;
        }

        public static String traverseTableForYesNoNA(TableLayoutPanel table)
        {
            String complete = "";

            foreach (Control c in table.Controls)
            {
                if (c is ComboBox)
                {
                    switch (c.Text)
                    {
                        case ("Yes"):
                            complete += "0";
                            break;
                        case ("No"):
                            complete += "1";
                            break;
                        case ("N/A"):
                            complete += "2";
                            break;
                        default:
                            break;
                    }
                }
            }

            return complete;
        }

        public static void setupCheckListTable(TableLayoutPanel table, String initials, String completed)
        {
            char[] delimiter = { '|' };
            String[] initialsArray = initials.Split(delimiter);

            List<ComboBox> boxes = new List<ComboBox>();
            foreach (Control c in table.Controls)
            {
                if (c is ComboBox)
                {
                    boxes.Add((ComboBox)c);
                }
            }

            for (int i = 0; i < completed.Length; i++)
            {
                TextBox name = new TextBox();
                name.Text = initialsArray[i];
                name.Enabled = false;
                boxes.ElementAt(i).SelectedIndex = Convert.ToInt16(completed.Substring(i, 1));
                table.Controls.Add(name);
            }
        }

    }
}
