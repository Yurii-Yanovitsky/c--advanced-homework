namespace Task2
{
    public class Temperature
    {
        public decimal Fahrenheit(decimal temperature)
        {
            return temperature * 9 / 5 + 32;
        }

        public decimal Kelvin(decimal temperature)
        {
            return temperature + 273.15m;
        }
    }
}
