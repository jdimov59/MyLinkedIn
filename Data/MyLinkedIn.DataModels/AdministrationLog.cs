using System.ComponentModel.DataAnnotations;

namespace MyLinkedIn.DataModels
{
    public class AdministrationLog
    {
        [Key]
        public long Id { get; set; }

        public virtual User User { get; set; }

        public string IpAddress { get; set; }

        public string RequestType { get; set; }

        public string Url { get; set; }

        public string PostParams { get; set; }
    }
}
