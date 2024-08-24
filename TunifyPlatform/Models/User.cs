using Microsoft.AspNetCore.Identity;

namespace TunifyPlatform.Models
{
    public class User : IdentityUser
    {
      
        public DateTime JoinDate { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
