namespace cogip.Models
{
    public class ContactGetDto
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public string email { get; set; }
        public string phonenumber { get; set; }
        public DateTime added { get; set; }

        public int[] companies { get; set; }
    }
}
