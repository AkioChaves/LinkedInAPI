namespace LinkedInAPI.Models
{
    public class Company
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Company() { }

        public Company(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
