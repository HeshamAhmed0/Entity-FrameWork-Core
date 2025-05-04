using Center.ApplicationDbContexts;
using Center.SelectStatement;
using Center.Transaction;

namespace Center
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start start = new Start();
            start.Decition();
        }
    }
}
