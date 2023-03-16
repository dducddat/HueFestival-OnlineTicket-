namespace HueFestival_OnlineTicket.ViewModel
{
    public class EmployeeVM_Create
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class EmployeeVM_Update
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class EmployeeVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public bool Activate { get; set; }
    }

    public class EmployeeVM_Login
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class EmployeeVM_Activate
    {
        public string PhoneNumber { get; set; }
        public int OTP { get; set; }
    }
}
