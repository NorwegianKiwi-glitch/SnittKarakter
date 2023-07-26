using System;
using System.Collections.Generic;

namespace SnittKarakter
{
    public class Course
    {
        public string Name { get; set; }
        public decimal StudyPoints { get; set; }
        public string Grade { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Velkommen til SnittKarakter. I denne applikasjonen kan du regne ut din gjennomsnittkarakter fra høyere utdanning i Norge\n");

            List<Course> courses = new List<Course>();
            string input;

            while (true)
            {
                Console.WriteLine($"Skriv inn navn på faget/kurs (skriv 'Ferdig' for å avslutte): ");
                input = Console.ReadLine();

                if (input.Equals("Ferdig", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var kurs = input;

                decimal studiepoeng;
                while (true)
                {
                    Console.WriteLine($"Hvor mange studiepoeng er {kurs}");
                    if (decimal.TryParse(Console.ReadLine(), out studiepoeng))
                        break;
                    else
                        Console.WriteLine("Ugyldig format. Prøv å skriv med ',' i stedet for '.'");
                }

                Console.WriteLine($"Hvilken karakter fikk du i kurset for {kurs}");
                var karakter = Console.ReadLine();

                courses.Add(new Course { Name = kurs, StudyPoints = studiepoeng, Grade = karakter });
            }

            // Print the table
            PrintTable(courses);

            // Calculate karakterpoeng and studiepoeng sums
            decimal karakterPoengSum = 0;
            decimal studiePoengSum = 0;

            foreach (var course in courses)
            {
                karakterPoengSum += CalculateKarakterPoeng(course.Grade, course.StudyPoints);
                studiePoengSum += course.StudyPoints;
            }

            // Calculate the average
            decimal snittKarakter = CalculateSnittKarakter(karakterPoengSum, studiePoengSum);

			// Antall studiepoeng
			// Console.WriteLine($"Du har {studiePoengSum} og mangler {180 - studiePoengSum} for å kunne ta en master.");

            // Display the result
            Console.WriteLine($"\nGjennomsnittskarakter: {snittKarakter:F2}");

            // Check if the snittKarakter qualifies for master studies
            if (snittKarakter >= 5.0m && studiePoengSum >= 180)
            {
                Console.WriteLine("Du har A i snitt FUCKING NERD! og kvalifiserer deg til masterstudium.");
            }
			else if (snittKarakter >= 5.0m && studiePoengSum < 180)
			{
				Console.WriteLine($"Du har A i snitt men mangler {180 - studiePoengSum} for å kvalifisere deg til masterstudium");
			}
			else if (snittKarakter >= 3.5m && studiePoengSum >= 180)
			{
				Console.WriteLine("Du har B i snitt og kvalifiserer deg til masterstudium.");
			}
			else if (snittKarakter >= 3.5m && studiePoengSum < 180)
			{
				Console.WriteLine($"Du har B i snitt men mangler {180 - studiePoengSum} for å kvalifisere deg til masterstudium");
			}
            else if (snittKarakter >= 2.5m && studiePoengSum >= 180)
            {
                Console.WriteLine("Du har C i snitt og kvalifiserer deg til masterstudium.");
            }
			else if (snittKarakter >= 2.5m && studiePoengSum < 180)
			{
				Console.WriteLine($"Du har C i snitt men mangler {180 - studiePoengSum} for å kvalifisere deg til masterstudium");
			}
			else if (snittKarakter >= 1.5m && studiePoengSum >= 180)
			{
				Console.WriteLine("Du har D i snitt, men nok studiepoeng og kvalifiserer deg ikke til masterstudium");
			}
			else if (snittKarakter >= 1.5m && studiePoengSum < 180)
			{
				Console.WriteLine($"Du har D i snitt og mangler {180 - studiePoengSum} for å kvalifisere deg til masterstudium");
			}
			else if (snittKarakter < 1.5m && studiePoengSum >= 180)
			{
				Console.WriteLine("Du har E i snitt, men nok studiepoeng og kvalifiserer deg ikke til masterstudium");
			}
            else
            {
                Console.WriteLine($"Du har E i snitt og mangler {180 - studiePoengSum} for å kvalifisere deg til masterstudium");
            }
        }

        static void PrintTable(List<Course> courses)
        {
            Console.WriteLine("\nFag/kurs\t studiepoeng\t karakter");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Name}\t\t {course.StudyPoints}\t\t {course.Grade}");
            }
        }

        static decimal CalculateKarakterPoeng(string karakter, decimal studiepoeng)
        {
            int karakterA = 5;
            int karakterB = 4;
            int karakterC = 3;
            int karakterD = 2;
            int karakterE = 1;

            if (karakter == "A" || karakter == "a")
            {
                return karakterA * studiepoeng;
            }
            else if (karakter == "B" || karakter == "b")
            {
                return karakterB * studiepoeng;
            }
            else if (karakter == "C" || karakter == "c")
            {
                return karakterC * studiepoeng;
            }
            else if (karakter == "D" || karakter == "d")
            {
                return karakterD * studiepoeng;
            }
            else if (karakter == "E" || karakter == "e")
            {
                return karakterE * studiepoeng;
            }
            else
            {
                return 0; // Handle invalid input or return a default value.
            }
        }

        static decimal CalculateSnittKarakter(decimal karakterPoengSum, decimal studiePoengSum)
        {
            if (studiePoengSum == 0)
                return 0; // To avoid division by zero

            return karakterPoengSum / studiePoengSum;
        }
    }
}
