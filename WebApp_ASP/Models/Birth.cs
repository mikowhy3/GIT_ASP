namespace WebApp_ASP.Models
{
    public class Birth
    {

        public string? X { get; set; }
        public DateTime? Y { get; set; }




        public bool IsValid()
        {
            return X != null && Y != null && Y <= DateTime.Today;
        }


        public int BirthCalculate()
        {


            // Obliczanie wieku na podstawie daty urodzenia
            var today = DateTime.Today;
            var age = today.Year - Y.Value.Year;

            // Jeśli data urodzin jeszcze nie miała miejsca w bieżącym roku, odejmij 1 rok
            //if (Y.Value.Date > today.AddYears(-age)) age--;

            return age;

        }
    }
}
