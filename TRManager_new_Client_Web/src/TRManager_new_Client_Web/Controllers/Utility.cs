using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRManager_new_Client_Web.Models;

namespace TRManager_new_Client_Web.Controllers
{
    public class Utility
    {
        public static Form getFormById(int id, List<Form> list)
        {
            foreach (Form f in list)
            {
                if (f.getId() == id) return f;
            }
            return null;

        }
        public static Form getFormByName(string form, List<Form> list)
        {
            foreach (Form f in list)
            {
                if (f.name.Equals(form)) return f;
            }
            return null;
        }
        public static Teacher getTeacherByAbbreviation(string abbrev, List<Teacher> list)
        {
            foreach (Teacher t in list)
            {
                if (t.abbreviation.Equals(abbrev)) return t;
            }
            return null;
        }

        public static String cleanString(String e)
        {
            string x = RemoveDiacritics(rewriteUmlauts(e));
            return x;
        }
        public static String rewriteUmlauts(String e)
        {
            e = e.Replace("ä", "ae");
            e = e.Replace("ß", "ss");
            e = e.Replace("ö", "oe");
            e = e.Replace("ü", "ue");
            e = e.Replace("Ä", "AE");
            e = e.Replace("Ö", "OE");
            e = e.Replace("Ü", "UE");
            return e;
        }
        public static String RemoveDiacritics(String s)
        {
            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }
    }
}
