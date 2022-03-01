namespace cogip.Models
{
    public class CompanyPostDto
    {
        public string name { get; set; }
        public string vat { get; set; }
        public string status { get; set; }
        public DateTime added { get; set; }
        public string country { get; set; }
        public string town { get; set; }
        public string street { get; set; }
        public int zip { get; set; }
        public string streetnumber { get; set; }
        public int[] contacts { get; set; }
    }
}
