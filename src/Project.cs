using System;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            /* now, look at the line below.The left side of the comment says Fbook is a Book.So the 
            methods available are the ones available to a Book.Their exact implementation is defined
            by the right side, which actually makes a new object. */
            while (true)
            {
                System.Console.WriteLine("Enter name of a student or press Q to Quit");
                var input = Console.ReadLine();
                if (input =="Q"){break;}
                else
                {
                    Book Fbook = new DiskBook($"{input}'s Grades");
                }
            }
        }

        public static void InputGrades(Book Fbook)
        {
            string input;
            while (true)
            {
                System.Console.WriteLine("Enter a grade(0 to 100) or type C to calculate result");
                input = Console.ReadLine();

                if (input == "C")
                {
                    try
                    {
                        Fbook.Result.StatsPrint();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        var NEW = float.Parse(input);

                        if (NEW <= 100 && NEW >= 0)
                        {
                            Fbook.Addgrade(NEW);
                        }
                        else
                        {
                            System.Console.WriteLine("This is not an acceptable grade");
                        }
                    }
                    catch (FormatException ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                    //more catches are possible      
                    /*
                    public static double GetDouble(object input, double defaultVal)
                    {
                        double parsed;
                        return double.TryParse(input.ToString(), out parsed)) ? parsed : defaultVal;
                    }*/        
                }
            }
        }
       
        //to use a delegate, you can define more methods here, but they must have the static keyword.
        //Then you can add the method to Fbook.Gradeadded and have it executed when you call AddGGrade
    }

    
}
