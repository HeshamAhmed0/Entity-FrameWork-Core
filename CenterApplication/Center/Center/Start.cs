using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Center.RemoveStatement;
using Center.SelectStatement;
using Center.Transaction;

namespace Center
{
    internal class Start
    {
        int Input;
        public void Decition()
        {
            Console.WriteLine("Please Choose What Do You Want ");
            Console.WriteLine("1 :: Insert");
            Console.WriteLine("2 :: Select");
            Console.WriteLine("3 :: Remove");
            Console.Write("You Choosen : ");
            Input = int.Parse(Console.ReadLine());
            if (Input == 1)
            {
               InsertStatemnet insertStatemnet = new InsertStatemnet();
                insertStatemnet.InsertSection();
            }
            else if (Input == 2)
            {
                Console.Clear();
                SelectFromDatabase selectFromDatabase = new SelectFromDatabase();
                selectFromDatabase.Select();

            }
            else if (Input == 3)
            { 
                Console.Clear();
            RemoveFromDataBase removeFromDataBase = new RemoveFromDataBase();
                removeFromDataBase.Decition();
                
            }
            AnotherDescition();

        }
      
        public void AnotherDescition()
        {
          
            Console.WriteLine("Do You Want Another Desction " +
                              "1 :: Yes " +
                              "2 :: No");
            Console.Write("You Choosen Is : ");
            Input = int.Parse(Console.ReadLine());
            Console.Clear() ;
            if (Input == 1)
            {
                Decition();
            }
            else if (Input == 2) 
            {
                Console.Clear();
                Console.WriteLine("*************** See You Soon ***************");
            }
            else
            {
                Console.WriteLine("You Choosen is not Correct ");
                AnotherDescition();
            }
        }
    }
}
