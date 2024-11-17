namespace WebApp_ASP.Models
{
    public class Calculator
    {

        public enum Operators
        {
            Unknown, Add, Mul, Sub, Div
        }
        public Operators? Operator { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        public String Op
        {
            get
            {
                switch (Operator)
                {
                    case Operators.Add:
                        return "+";

                    case Operators.Div:
                        return "/";

                    case Operators.Mul:
                        return "*";

                    case Operators.Sub:
                        return "-";

                    default:
                        return "";
                }
            }
        }

        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }

        public double Calculate()
        {
            switch (Operator)
            {
                case Operators.Add:
                    return (double)(X + Y);

                case Operators.Mul:
                    return (double)(X * Y);

                case Operators.Sub:
                    return (double)(X - Y);

                case Operators.Div:
                    if (Y != 0)
                        return (double)(X / Y);
                    else
                        throw new DivideByZeroException();

                default: return double.NaN;
            }
        }
    }
}
