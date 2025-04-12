using System;
using System.Text.RegularExpressions;

namespace ElogView
{
    public static class UnitUtils
    {
        public static string NumberToVoltRep(double volt)
        {
            if (volt >= 1)
            {
                return string.Format("{0:G3}V", volt);
            }
            else
            {
                return string.Format("{0:G3}mV", volt * 1000.0);
            }

        }
        private static Regex mvregex = new Regex(@"^(\d+\.?\d*)mV$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static Regex vregex = new Regex(@"^(\d+\.?\d*)V$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static double VoltRepToNumber(string voltRep)
        {
            voltRep = voltRep.Trim();
            double volt;
            if (double.TryParse(voltRep, out volt))
            {
                return volt;
            }
            else
            {
                Match match;
                match = mvregex.Match(voltRep);
                if (match.Success)
                {
                    return double.Parse(match.Groups[1].Value) / 1000;
                }
                match = vregex.Match(voltRep);
                if (match.Success)
                {
                    return double.Parse(match.Groups[1].Value);
                }
                throw new Exception(voltRep + " はV/mV表現ではありません");
            }
        }

        public static string NormalizeVoltRep(string voltRep)
        {
            return NumberToVoltRep(VoltRepToNumber(voltRep));
        }
    }
}
