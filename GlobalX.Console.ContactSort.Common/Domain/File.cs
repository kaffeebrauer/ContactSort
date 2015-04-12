namespace GlobalX.Console.ContactSort.Common.Domain
{
    public class File
    {
        public File ()
        {

        }

        public string FileName { get; set; }

        public int FileSize { get; set; }
        
        public string ContentType { get; set; }

        public string Content { get; set; }
    }
}
