using System;

namespace Gradebook
{
    public abstract class Book : NamedObject,Ibook
    {
        public Book(string name) : base(name)
        {
            result = new Stats(this);
        }

        //Gradeadded is a delegate, not a method. It's like defining a new object.

        public abstract void Addgrade(float grade);
        private Stats result;
        protected bool check;
        public Stats Result 
        {
            get
            {
                if (check)
                {
                    return result;
                }
                else
                {
                    throw new Exception("Please enter at least one Grade");
                }
            }            
        }
    }
}