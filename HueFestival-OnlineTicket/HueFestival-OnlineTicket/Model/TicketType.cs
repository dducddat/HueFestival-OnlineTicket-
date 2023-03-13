namespace HueFestival_OnlineTicket.Model
{
    public class TicketType
    {
        public Guid Id { get; set; }
        public int ShowId { get; set; }
        public Show Show { get; set; }
        public string Type { get; set; }
        public Double Price { get; set; }
        public int Quantity { get; set; }
    }
}
