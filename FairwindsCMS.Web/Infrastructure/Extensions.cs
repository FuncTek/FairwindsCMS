using System;

namespace FairwindsCMS.Web.Infrastructure
{
    public static class Extensions
    {
        public static int CalculateAge(this DateTime? birthDateTime)
        {
            return GetAge(birthDateTime);
        }

        public static int CalculateAge(this DateTime birthDateTime)
        {
            return GetAge(birthDateTime);
        }

        private static int GetAge(DateTime? birthDateTime)
        {
            DateTime now = DateTime.Now;
            int age = 0;

            if (!birthDateTime.HasValue)
            { return age; }

            age = now.Year - birthDateTime.Value.Year;

            if (age < 0)
            {
                return 0;
            }

            if (now.Month >= birthDateTime.Value.Month && now.Day >= birthDateTime.Value.Day)
            {
                return age;
            }
            else
            {
                age--;
                return age; 
            }
            
        }

        public static string GetLastFour(this string target)
        {
            if (string.IsNullOrWhiteSpace(target) || target.Length <= 4)
            {
                return target;
            }

            return target.Substring(target.Length - 4);
        }
    }
}
