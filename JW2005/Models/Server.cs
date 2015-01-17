using System.ComponentModel.DataAnnotations;

namespace JW2005.Models
{
    public enum ServerStatus
    {
        Online,
        Down
    }

    public class Server
    {
        public int Id { get; set; }

        [Required]
        public string Hostname { get; set; }

        public ServerStatus Status { get; set; }
    }
}