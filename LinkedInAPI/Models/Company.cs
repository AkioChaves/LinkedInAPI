namespace LinkedInAPI.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Job> Jobs { get; set; } = new List<Job>();

        public Company() { }

        public Company(int id, string name)
        {
            Name = name;
            ID = id;
        }
    }
}
