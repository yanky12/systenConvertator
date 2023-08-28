using System;


    public class Convertator
    { 
        public string ConvertFrom10(int value, int @base) 
        {
            string[] bigger = { "A", "B", "C", "D", "E", "F" };
            string s = "";
            while (value > 0)
            {
                int remainder = value % @base;
                if (value % @base < 10)
                {
                    s = (remainder).ToString() + s;
                    value = value / @base;
                }
                else
                {
                    s = (bigger[remainder % 10]) + s;
                    value = value / @base;
                }
            }
            return s;
        }
        public int ConvertTo10(string value, int @base)
        {

            string valueReverse = "";
            for (int i = value.Length - 1; i >= 0; i--)
            {
                valueReverse += value[i];
            }
            char[] bigger = { 'A', 'B', 'C', 'D', 'E', 'F' };
            double summ = 0;
            for (int i = 0; i < valueReverse.Length; i++)
            {
                if (valueReverse[i] >= '0' && valueReverse[i] <= '9')
                {
                    double temp = int.Parse(valueReverse[i].ToString()) * Math.Pow((double)@base, (double)i);
                    summ += temp;
                }
                else
                {
                    int d = 10 + Array.IndexOf(bigger, valueReverse[i]);
                    double temp = d * Math.Pow((double)@base, (double)i);
                    summ += temp;
                }

            }
            return (int)summ;
        }  
    }
