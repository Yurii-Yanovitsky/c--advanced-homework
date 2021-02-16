namespace ObjectValidator
{
    public class User
    {
        [Required(Error = "ID isn't specified")]
        public string ID { get; set; }

        [Length(3, 12, Error = "Invalid name length")]
        [Required(Error = "User name isn't specified")]
        public string Name { get; set; }

        [PhoneNumber(@"^[+3(0-9)\s]{2,}[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$", Error = "Phone number is in invalid format")]
        [Required(Error = "Phone isn't specified")]
        public string Phone { get; set; }

        [Email(@"^[0-9A-Za-z_.-]+@[0-9a-zA-Z-]+\.[a-zA-Z]{2,4}$", "Email is in invalid format")]
        [Required(Error = "Email isn't specified")]
        public string Email { get; set; }

        [Required(Error = "Age isn't specified")]
        public int Age { get; set; }

    }
}