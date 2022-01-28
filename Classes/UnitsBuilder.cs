using System;


namespace OblikConfigurator
{
    internal static class UnitsBuilder
    {
        public static string Build(sbyte unit, string unitname)
        {
            string[] prefixes = { "", "к", "М", "Г", "Т" };
            int index = unit / 3;
            string prefix = prefixes[index];
            float coef = (float)Math.Pow(10, unit - 3 * index);
            return $"{prefix}{unitname}" + ((coef == 1) ? "" : $" · {coef}");
        }
    }
}
