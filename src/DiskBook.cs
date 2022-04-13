using System.IO;
using System;

namespace Gradebook
{
    public class DiskBook : Book
    {
        public DiskBook(string name):base(name)
        {
            check = false;
            if (File.Exists($"../Grades/{Name}.txt"))
            { AskUser();}
            else
            {
                System.Console.WriteLine("Creating file "+Name);
                Program.InputGrades(this);
            }
        }

        public override void Addgrade(float grade)
        {
            check = true;
            Result.Update(grade);            
            /*The Streamwriter class derives from Textwriter,which has an IDisposable interface.
            This is used when the method starts using some resource it knows may have to be reused
            and therefore shut down.(Here it is the open file)
            I can do that by using 
            writer.close() or writer.dispose() after whatever needs to be done is done.*/
            using(StreamWriter writer =  File.AppendText($"../../Grades/{Name}.txt"))
            {writer.WriteLine(grade);}
            //The above is the common approach: It effectively creates a try catch thing
            //and ensures that the resourcce being used due to the object created in()
            //is freed by the end.
        }
        private void AskUser()
        {
            System.Console.WriteLine($"File for {Name} already exists:");
            System.Console.WriteLine("Type R to rewrite grades");
            System.Console.WriteLine("Type U to update it");
            System.Console.WriteLine("Type D to delete it");
            System.Console.WriteLine("Type E to choose another student");
            System.Console.WriteLine("Type S to view the grades");
            var t = Console.ReadLine();
            switch (t)
            {
                case "R":
                    File.Delete($"../../Grades/{Name}.txt");
                    System.Console.WriteLine("The file was cleaned");
                    System.Console.WriteLine();
                    Program.InputGrades(this);
                    break;
                
                case "U":
                    check = true;
                    System.Console.WriteLine("The present grades are:");
                    using (var reader = File.OpenText($"../../Grades/{Name}.txt"))
                    {
                        var Line = reader.ReadLine();
                        while (Line != null)
                        {
                            System.Console.WriteLine(Line);
                            Result.Update(float.Parse(Line));
                            Line = reader.ReadLine();
                        }
                    }
                    System.Console.WriteLine();
                    System.Console.WriteLine("File loaded");
                    System.Console.WriteLine();
                    Program.InputGrades(this);
                    break;
                
                case "D":           
                    File.Delete($"../../Grades/{Name}.txt");
                    break;

                case "E":
                    break;

                case "S":
                    System.Console.WriteLine("The present grades are:");
                    using (var reader = File.OpenText($"../../Grades/{Name}.txt"))
                    {
                        var Line = reader.ReadLine();
                        while (Line != null)
                        {
                            System.Console.WriteLine(Line);
                            Line = reader.ReadLine();
                        }
                    }
                    System.Console.WriteLine();
                    AskUser();
                    break;
                
                default:
                    System.Console.WriteLine("Whut?"); AskUser(); 
                    break;
            }
        }   
    }
}