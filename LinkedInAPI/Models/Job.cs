using LinkedInAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LinkedInAPI.Models
{
    public class Job
    {
        public int ID { get; set; }

        [Display(Name = "Companhia")]
        public Company? Company { get; set; }

        [Display(Name = "Vaga")]
        public string? Title { get; set; }

        [Display(Name = "Data Postada")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PostedDate { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Salário")]
        public double Salary { get; set; }

        [Display(Name = "Benefícios")]
        public string? Benefits { get; set; }
        public ApplicationStatus Status { get; set; }

        [Display(Name = "Qualificações")]
        public string? Qualifications { get; set; }

        [Display(Name = "Modalidade")]
        public ModalityType Modality { get; set; }

        [Display(Name = "Envio")]
        public string? Shipping { get; set; }

        public Job() { }

        public Job(int id, Company company, string title, DateTime postedDate, double salary, string benefits,
        ApplicationStatus status, string qualifications, ModalityType modality, string shipping)
        {
            ID = id;
            Company = company;
            Title = title;
            PostedDate = postedDate;
            Salary = salary;
            Benefits = benefits;
            Status = status;
            Qualifications = qualifications;
            Modality = modality;
            Shipping = shipping;
        }
    }
}
