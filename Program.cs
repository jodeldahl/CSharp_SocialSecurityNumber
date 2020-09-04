using System;
using System.Globalization;
using System.Xml.Serialization;

namespace SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "";
            string lastName = "";
            string socialSecurityNumber;
            string generation = "";

            // Userinput through command.
            if (args.Length > 1)
            {
                // If input from user is already done
                firstName = args[0];
                lastName = args[1];
                socialSecurityNumber = args[2];
            }
            else
            {
                // Ask for firstname:
                Console.Write("Please enter your firstname: ");
                firstName = Console.ReadLine();

                // Ask for lastname:
                Console.Write("Please enter your lastname: ");
                lastName = Console.ReadLine();

                // Ask for sccial security number:
                Console.Write("Social Security Number (YYYYMMDD-XXXX): ");
                socialSecurityNumber = Console.ReadLine();

                Console.Clear();
            }

            string gender;

            int genderNumber = int.Parse(socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1));

            bool isFemale = genderNumber % 2 == 0;

            gender = isFemale ? "Female" : "Male";

            DateTime birthDate = DateTime.ParseExact(socialSecurityNumber.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture);

            int age = DateTime.Now.Year - birthDate.Year;

            if ((birthDate.Month > DateTime.Now.Month) || (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
            {
                age--;
            }

            // Determine name of generation according to: 
            //"https://en.wikipedia.org/wiki/Generation#/media/File:Generation_timeline.svg"

            if (1883 <= birthDate.Year && 1900 >= birthDate.Year)
            { 
                generation = "The Lost Generation";
            }

            else if (1901 <= birthDate.Year && 1927 >= birthDate.Year)
            { 
                generation = "The Greatest";
            }

            else if (1928 <= birthDate.Year && 1945 >= birthDate.Year)
            { 
                generation = "The Silent Generation";
            }

            else if (1946 <= birthDate.Year && 1964 >= birthDate.Year)
            { 
                generation = "The Baby Boomers";
            }

            else if (1965 <= birthDate.Year && 1980 >= birthDate.Year)
            { 
                generation = "The Generation X";
            }

            else if (1981 <= birthDate.Year && 1996 >= birthDate.Year)
            { 
                generation = "The Millennials";
            }

            else if (1997 <= birthDate.Year && 2012 >= birthDate.Year)
            {
                generation = "The Zoomers";
            }

            else if (2013 <= birthDate.Year && 2025 >= birthDate.Year)
            {
                generation = "The Generation Alpha";
            }

            else
            {
                generation = "Unknown generation";
            }

                // Print formatted output to screen.
                Console.WriteLine($"Name:\t\t\t{firstName} {lastName}" +
                $"\nSocial Security Number:\t{socialSecurityNumber}" +
                $"\nGender:\t\t\t{gender}" +
                $"\nAge:\t\t\t{age}" +
                $"\nGeneration:\t\t{generation}");
        }
    }
}
