namespace HueFestival_OnlineTicket.Model
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Type_Inoff { get; set; } // 1: khong ban ve, 2: ban ve
        public int Type_Program { get; set; } // 1: Tieu diem, 3: Cong dong
        public double Price { get; set; }

    }
}
