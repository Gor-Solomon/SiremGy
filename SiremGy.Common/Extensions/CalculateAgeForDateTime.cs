using System;
using System.Collections.Generic;
using System.Text;

namespace SiremGy.Common.Extensions
{
    public static class CalculateAgeForDateTime
    {
        public static int CalculateAge(this DateTime birthdate)
        {
            var age = DateTime.Today.Year - birthdate.Year;
            
            if (birthdate.AddYears(age) > DateTime.Today)
            {
                age--;
            }

            return age;
        }
    }
}
