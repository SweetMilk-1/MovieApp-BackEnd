using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Database.Entities
{
    public class UserSession
    {
        [Key]
        public Guid UserId { get; set; }
        public Guid SessionId { get; set; }
    }
}
