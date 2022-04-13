namespace Gradebook
{
    public class NamedObject : object//all of these are objects by default, no need to write this.
    {
        public NamedObject(string name)
        {
            Name = name;
        }
        public string Name
        {
            get;
        }
    }
    
    public interface Ibook
    {
        void Addgrade(float grade);
        // fields can't be defined by interfaces:
        //string Name;
        //is not legal(fortunately, Name is a property, inherited from NamedObject)
        string Name {get;}
    }
}