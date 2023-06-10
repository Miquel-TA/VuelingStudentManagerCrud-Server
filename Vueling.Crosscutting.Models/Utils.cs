using System;

namespace Vueling.Crosscutting.Models
{
    public static class Utils
    {
        public static short GetAgeFromBirthday(DateTime birthday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthday.Year;

            if (birthday > today.AddYears(-age))
            {
                age--;
            }
            return Convert.ToInt16(age);
        }

        public static bool VerifyDateTime(DateTime birthday)
        {
            if (birthday < DateTime.Now.AddYears(-120) || birthday > DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool VerifyName(string name)
        {
            if (name.Length == 0 || name.Length > 100) return false;

            foreach (char letter in name)
            {
                bool valid =
                    (letter >= 'A' && letter <= 'Z') ||
                    (letter >= 'a' && letter <= 'z') ||
                    letter == '\'' ||
                    letter == '.' ||
                    letter == ',' ||
                    letter == ' ' ||
                    letter == '-' ||
                    letter >= 160;

                if (!valid)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
