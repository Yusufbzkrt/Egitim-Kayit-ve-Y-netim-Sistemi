namespace MvcProject.Models
{
    public static class Repository
    {
        private static List<Aday> applications = new();

        public static IEnumerable<Aday> Applications => applications;

        public static void Add(Aday aday)
        {
            applications.Add(aday);
        }
        public static bool IsEmailExists(string email) 
        {
            return applications.Any(a => a.Email == email);// E-posta adresinin var olup olmadığını kontrol eder
        }
    }
}
