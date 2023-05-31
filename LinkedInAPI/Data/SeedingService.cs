using LinkedInAPI.Models;

namespace LinkedInAPI.Data
{
    public class SeedingService
    {
        private LinkedInAPIContext _context;

        public SeedingService(LinkedInAPIContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Company.Any() | _context.Job.Any())
            {
                return;
            }

            Company c1 = new Company(1, "Kaju Energia");
            Company c2 = new Company(2, "Sonae Sierra Brasil");
            Company c3 = new Company(3, "Nikkey Sushi");
            Company c4 = new Company(4, "Atos");
            Company c5 = new Company(5, "TCS");
            Company c6 = new Company(6, "Twitch");

            Job j1 = new Job(1, c1, "Instalador", DateTime.Now, 1860.00, "VR + VT + Plano de saúde", 0, "Ensino médio Completo", "Presencial", "kajuenergia@gmail.com");
            Job j2 = new Job(2, c2, "Auditor", DateTime.Now, 2860.00, "VR + VT + Plano de saúde", 0, "Ensino Superior Completo", "Presencial", "sonaesierra@gmail.com");
            Job j3 = new Job(3, c2, "Supervisor", DateTime.Now, 3860.00, "VR + VT + Plano de saúde", 0, "Ensino médio Completo", "Presencial", "sonaesierra@gmail.com");
            Job j4 = new Job(4, c3, "Auxiliar de Cozinha", DateTime.Now, 1660.00, "VR + VT + Plano de saúde", 0, "Ensino médio Incompleto", "Presencial", "nikkeysushi@gmail.com");
            Job j5 = new Job(5, c4, "Programador", DateTime.Now, 3860.00, "VR + VT + Plano de saúde", 0, "Ensino médio Completo", "Presencial", "atos@gmail.com");
            Job j6 = new Job(6, c5, "Programador Senior", DateTime.Now, 11860.00, "VR + VT + Plano de saúde", 0, "Ensino médio Completo", "Presencial", "tcs@gmail.com");

            _context.Company.AddRange(c1, c2, c3, c4, c5, c6);

            _context.Job.AddRange(j1, j2, j3, j4, j5, j6);

            _context.SaveChanges();
        }
    }
}
