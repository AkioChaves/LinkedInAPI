using System.ComponentModel.DataAnnotations;

namespace LinkedInAPI.Models
{
    public class Company
    {
        public int ID { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Localização")]
        public string Location { get; set; }
        public ICollection<Job> Jobs { get; set; } = new List<Job>();

        public Company() { }

        public Company(int id, string name, string location)
        {
            Name = name;
            ID = id;
            Location = location;
        }
    }
}