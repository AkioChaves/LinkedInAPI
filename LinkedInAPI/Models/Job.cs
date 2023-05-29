using LinkedInAPI.Models.Enums;

namespace LinkedInAPI.Models
{
    public class Job
    {
        public int ID { get; set; }
        public Company Company { get; set; }
        public string Function { get; set; }
        public DateTime PostedDate { get; set; }
        public double Salary { get; set; }
        public string Benefits { get; set; }
        public ApplicationStatus Status { get; set; }
        public string Requirements { get; set; }
        public string Local { get; set; }
        public string Shipping { get; set; }

        public Job() { }

        public Job(int id, Company company, string function, DateTime postedDate, double salary, string benefits,
        ApplicationStatus status, string requirements, string local, string shipping)
        {
            ID = id;
            Company = company;
            Function = function;
            PostedDate = postedDate;
            Salary = salary;
            Benefits = benefits;
            Status = status;
            Requirements = requirements;
            Local = local;
            Shipping = shipping;
        }
    }
}
