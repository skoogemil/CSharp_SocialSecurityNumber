using System;
using System.Globalization;

namespace CSharp_SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your social security number (YYDDMMXXXX):");

            string socialSecurityNumber = Console.ReadLine();

            int genderNumber = int.Parse (socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));

            bool isFemale = genderNumber % 2 == 0;

            string gender = isFemale ? "Female" : "Male";
            
            DateTime birthDate = DateTime.ParseExact(socialSecurityNumber.Substring(socialSecurityNumber.Length -10, 6), "yyMMdd" , CultureInfo.InvariantCulture);

            int age = DateTime.Now.Year - birthDate.Year;

            if ((birthDate.Month > DateTime.Now.Month) || (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
            {
                age--;
            }


            Console.WriteLine($"This is a {gender}, and the age is {age}.");
            
        }
    }
}
