namespace WebApp.Models
{
    public class Birthday
    {
        public DateTime? Date { get; set; }
        public string? Name { get; set; }

        public bool IsValid()
        {
            return Name != null && Date != null;
        }

        public int Birth()
        {
            if (Date == null)
            {
                throw new InvalidOperationException("Date cannot be null");
            }

            DateTime today = DateTime.Now;
            int age = today.Year - Date.Value.Year; 
            return age;
        }
    }
}