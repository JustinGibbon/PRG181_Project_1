using System;
using System.Collections;

//Sean Botha - 577288
//Conrad Joubert - 577417
//Edwin le Cointre - 577328
//Frank Peter Smal - 577298
//Justin Gibbon - 577407

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            int employed = 0;
            int yearsAtJob = 0;
            int yearsAtResidence = 0;
            double salary = 0;
            double debt = 0;
            int numOfChildren = 0;
            ArrayList arr = new ArrayList();
            int applicable = 0;
            int nonApplicable = 0;
            char stop;

            Console.WriteLine("What do you want to do today:\n" +
                "1:Capture Details\n" +
                "2:Check credit qualification\n" +
                "3:Show qualification stats\n" +
                "4:Exit the program");
            int option = Convert.ToInt32(Console.ReadLine());

            while (option !=4)
            {
                switch ((options)option)
                {
                    case options.option1:
                        stop = 'y';
                        while (stop == 'Y' || stop == 'y')
                        {
                            Console.WriteLine("Enter the applicant's name");
                            name = Console.ReadLine();

                            Console.WriteLine("Is the applicant employed:\n1:Yes\n2:No");
                            employed = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the amount of years at the job");
                            yearsAtJob = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the amount of years at current residence");
                            yearsAtResidence = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the salary");
                            salary = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the amount of debt");
                            debt = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("Enter the amount of children the applicant has");
                            numOfChildren = Convert.ToInt32(Console.ReadLine());

                            if (checkQuali(employed, yearsAtJob, yearsAtResidence, salary, debt, numOfChildren).Equals(" is applicable"))
                            {
                                arr.Add(name + checkQuali(employed, yearsAtJob, yearsAtResidence, salary, debt, numOfChildren));
                                applicable++;
                            }
                            else
                            {
                                nonApplicable++;
                            }
                            Console.WriteLine("Do you want to enter another applicant:\nY: Yes\nN: No");
                            stop = Convert.ToChar(Console.ReadLine());
                        }
                        break;

                    case options.option2:
                        Console.WriteLine("Total applicable: " + applicable);
                        Console.WriteLine("Total non applicable: " + nonApplicable);
                        break;

                    case options.option3:
                        Console.WriteLine(showStats(arr, employed, yearsAtJob, yearsAtResidence, salary, debt, numOfChildren));
                        break;

                    default:
                        Console.WriteLine("Invalid option has been chosen");
                        break;
                }

                Console.WriteLine("What do you want to do today:\n" +
                                  "1:Capture Details\n" +
                                  "2:Check credit qualification\n" +
                                  "3:Show qualification stats\n" +
                                  "4:Exit the program");
                option = Convert.ToInt32(Console.ReadLine());
            }
        }
        static string checkQuali(int e, int yJ, int yR, double s, double d, int c)
        {
            string app = " is not applicable";
            if (e == 1 && yJ >= 1 && yR >= 2)
            {
                if (s * 2 >= d && c <= 6)
                {
                    app = " is applicable";
                }
            }
            return app;
        }
        static string showStats(ArrayList a, int employed, int yearsAtJob, int yearsAtResidence, double salary, double debt, int numOfChildren)
        {
            string em = "";
            string print = "-----------------------------------";
            string e;

            if (employed == 1)
            {
                e = "Yes";
            }
            else
            {
                e = "No";
            }

            for (int i = 0; i < a.ToArray().Length; i++)
            {
                em += print + "\n" + a[i] + "\nEmployed: " + e + "\nYears at job: " + yearsAtJob + "\nYears at residence: " + yearsAtResidence + "\nSalary: R" + salary + "\nNon-mortgage debt: R" + debt + "\nNumber of children: " + numOfChildren + "\n";
            }
            return em;
        }
        enum options
        {
            option1 = 1, option2, option3, option4
        }
    }
}
