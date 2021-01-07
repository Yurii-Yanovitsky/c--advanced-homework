using System;

namespace ObjectValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                ID = "314123312",
                Name = "Barry",
                Phone = "+380995478295",
                Email = "barry@gmail.com",
                Age = 22
            };

            Validator validator = new Validator();
            var (isValid, errors) = validator.Validate(user);

            Console.WriteLine(isValid ? "user is valid" : string.Join('\n', errors));

            Console.ReadLine();
        }
    }
}