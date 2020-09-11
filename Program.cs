using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharp_SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName, socialSecurityNumber;
            FetchInputFromUser(args, out firstName, out lastName, out socialSecurityNumber);

            Gender gender = GetGender(socialSecurityNumber);

            int age = CalculateAge(socialSecurityNumber);

            string generation = GetGeneration(socialSecurityNumber);

            ReportResultFromUserInput(firstName, lastName, socialSecurityNumber, gender, age, generation);
        }

        private static void ReportResultFromUserInput(string firstName, string lastName, string socialSecurityNumber, Gender gender, int age, string generation)
        {
            var builder = new StringBuilder();
            builder
                .Append('*', 10)
                .Append(" Output result ")
                .Append('*', 10);

            Console.WriteLine(builder);

            Console.WriteLine(@$"
Name:                   {firstName.Trim()} {lastName.Trim()}
Social security number: {socialSecurityNumber.Substring(2, 10)}
Gender:                 {gender}
Age:                    {age}
Generation:             {generation}");

            Console.WriteLine("\nPress any button to end program....");
            Console.ReadKey();
        }

        private static void FetchInputFromUser(string[] args, out string firstName, out string lastName, out string socialSecurityNumber)
        {
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

                Console.Write("Enter your social security number (yyyyMMdd-XXXX):");

                Regex regex = new Regex(@"\d{8}-\d{4}");

                do
                {
                    socialSecurityNumber = Console.ReadLine();
                    if (!regex.IsMatch(socialSecurityNumber))
                    {
                        Console.Write("Wrong input! Please try again:");
                    }

                } while (!regex.IsMatch(socialSecurityNumber));
            }
            Console.Clear();
        }

        private static string GetGeneration(string socialSecurityNumber)
        {
            string birthDateString = socialSecurityNumber.Substring(0, 4);
            DateTime birthDate = DateTime.ParseExact(birthDateString, "yyyy", CultureInfo.InvariantCulture);

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

            string generation =
                birthDate.Year >= SilentGenerationBegin && birthDate.Year <= SilentGenerationEnds ? "Silent generation" :
                birthDate.Year >= BabyBoomersBegin && birthDate.Year <= BabyBoomersEnds ? "Baby boomers" :
                birthDate.Year >= GenerationZBegin && birthDate.Year <= GenerationZEnds ? "Generation Z" :
                birthDate.Year >= GenerationAlphaBegin ? "Genaration Alpha" : "";

            if (birthDate.Year >= GenerationXBegin && birthDate.Year <= GenerationXEnds)
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
                    generation = "Millennial";
                }
            }

            return generation;
        }

        private static int CalculateAge(string socialSecurityNumber)
        {
            string birthDateString = socialSecurityNumber.Substring(0, 8);
            DateTime birthDate = DateTime.ParseExact(birthDateString, "yyyyMMdd", CultureInfo.InvariantCulture);
            int age = DateTime.Now.Year - birthDate.Year;
            if ((birthDate.Month > DateTime.Now.Month) || (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
            {
                age--;
            }
            return age;
        }

        private static Gender GetGender(string socialSecurityNumber)
        {
            int genderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));

            Gender gender;

            if (genderNumber % 2 == 0)
            {
                gender = Gender.Female;
            }
            else
            {
                gender = Gender.Male;
            }      
            return gender;
        }
    }
    enum Gender
    {
        Female,
        Male
    }
}
