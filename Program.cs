using System;
using System.Globalization;

namespace CSharp_SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            string socialSecurityNumber;

            if (args.Length > 0)
            {
                firstName = args[0];
                lastName = args[1];
                socialSecurityNumber = args[2];
            }
            else
            {
                Console.Write("Enter your first name:");
                firstName = Console.ReadLine();

                Console.Write("Enter your last name:");
                lastName = Console.ReadLine();

                Console.Write("Please enter your social security number (yyyyMMddXXXX):");
                socialSecurityNumber = Console.ReadLine();
            }

            int genderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));

            bool isFemale = genderNumber % 2 == 0;

            string gender = isFemale ? "Female" : "Male";

            DateTime birthDate = DateTime.ParseExact(socialSecurityNumber.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture);

            int age = DateTime.Now.Year - birthDate.Year;

            if ((birthDate.Month > DateTime.Now.Month) || (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
            {
                age--;
            }

            const int SilentGenerationBegin = 1925;
            const int SilentGenerationEnds = 1945;
            const int BabyBoomersBegin = 1946;
            const int BabyBoomersEnds = 1964;
            const int GenerationXBegin = 1965;
            const int GenerationXEnds = 1979;
            const int XennialsBegin = 1977;
            const int XennialsEnds = 1983;
            const int MillennialsBegin = 1980;
            const int MillennialsEnds = 1995;
            const int GenerationZBegin = 1996;
            const int GenerationZEnds = 2010;
            const int GenerationAlphaBegin = 2011;

            string generation= "";

            if (birthDate.Year >= SilentGenerationBegin && birthDate.Year <= SilentGenerationEnds)
            {
                generation = "Silent generation";
            }
            else if (birthDate.Year >= BabyBoomersBegin && birthDate.Year <= BabyBoomersEnds)
            {
                generation = "Baby boomers";
            }
            else if (birthDate.Year >= GenerationXBegin && birthDate.Year <= GenerationXEnds)
            {
                if (birthDate.Year >= XennialsBegin && birthDate.Year <= XennialsEnds)
                {
                    generation = "Xennial or Generation X";
                }
                else
                {
                    generation = "Generation X";
                }
            }
            else if (birthDate.Year >= MillennialsBegin && birthDate.Year <= MillennialsEnds)
            {
                if (birthDate.Year >= XennialsBegin && birthDate.Year <= XennialsEnds)
                {
                    generation = "Xennial or Millennial";
                }
                else
                {
                    generation ="Millennial";
                }
            }
            else if (birthDate.Year >= GenerationZBegin && birthDate.Year <= GenerationZEnds)
            {
                generation = "Generation Z";
            }
            else if (birthDate.Year >= GenerationAlphaBegin)
            {
                generation = "Generation Alpha";
            }

            Console.Clear();
            Console.WriteLine(@$"
Name:                   {firstName} {lastName}
Social security number: {socialSecurityNumber}
Gender:                 {gender}
Age:                    {age}
Generation:             {generation}");
 
        }
    }
}
