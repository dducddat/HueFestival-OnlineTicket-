namespace HueFestival_OnlineTicket.ViewModel
{
    public class UserVM_Input
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Role { get; set; }
    }

    public class UserVM_Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
