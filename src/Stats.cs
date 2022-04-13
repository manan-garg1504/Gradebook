using System;

namespace Gradebook
{
    public class Stats
    {
        public Stats(Book CBook)
        {
            low = 101.0f;
            //needed otherwise treated as a double for some reason
        }

        public float high
        {get;   private set;}

        public float low
        {get;   private set;}

        public double avg
        {get{return Sum/Count;}   private set{}}

        public char LGrade
        {
            get
            {
                char A;
                switch(avg)
                {
                    case var x when x >=90 :
                        A = 'A';
                        break;
                    
                    case var x when x >=80 :
                        A = 'B';
                        break;

                    case var x when x>=70:
                        A = 'C';
                        break;
                    
                    case var x when x>=60:
                        A = 'D';
                        break;
                    
                    case var x when x>=50:
                        A = 'E';
                        break;

                    default:
                        A = 'F';
                        break;

                }
                return A;
            }
            private set{}
        }
        private double Sum = 0.0;   
        private int Count = 0;     

        public void Update(float grade)
        {
            high = Math.Max(grade,high);
            low= Math.Min(grade,low);
            Sum +=grade;
            Count ++;
        }

        public void StatsPrint()
        {
            System.Console.WriteLine($"The lowest score is {low:N2}");
            System.Console.WriteLine($"The highest score is {high:N2}");
            System.Console.WriteLine($"The average score is {avg:N2}");
            System.Console.WriteLine($"The final grade is {LGrade}");
        }
    }
}