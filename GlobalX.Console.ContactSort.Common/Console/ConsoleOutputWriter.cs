namespace GlobalX.Console.ContactSort.Common.Console
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void WriteLine(string s)
        {
            System.Console.WriteLine(s);
        }
    }
}
