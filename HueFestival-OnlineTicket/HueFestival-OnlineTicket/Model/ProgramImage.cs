using System.ComponentModel.DataAnnotations.Schema;

namespace HueFestival_OnlineTicket.Model
{
    public class ProgramImage
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public string Image { get; set; }

        [ForeignKey("ProgramId")]
        public Program Program { get; set; }
    }
}

