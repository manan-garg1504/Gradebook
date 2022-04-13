namespace Gradebook
{
    public class MemoryBook: Book
    {        
        public MemoryBook(string name) :base(name)
        {
            check = false;
            Program.InputGrades(this);
        }
        //override is there to write over the abstract method
        public override void Addgrade(float grade)
        {
            check = true;
            Result.Update(grade);
        }
    }
}