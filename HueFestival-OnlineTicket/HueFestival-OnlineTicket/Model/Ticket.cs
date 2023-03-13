namespace HueFestival_OnlineTicket.Model
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }
    }
}
