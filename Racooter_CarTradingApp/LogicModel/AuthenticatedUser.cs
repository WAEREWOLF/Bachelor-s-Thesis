using System;
using System.Collections.Generic;

namespace LogicModel
{
    public enum UserState { Active, Inactive, Banned }
    
    public class AuthenticatedUser : BaseIdentifier
    {
        public virtual PersonalData PersonalData { get; set; }
        public virtual History History { get; set; }        
        public virtual ICollection<Message> Message { get; set; }
        public virtual IReadOnlyCollection<Announcement> Announcements { get; }
        public virtual IReadOnlyCollection<Announcement> RecomAnouncements { get; }
        public virtual IReadOnlyCollection<Announcement> FavouriteAnouncements { get; }
        public virtual Location Location { get; set; }
        public decimal Credits { get; set; }
        public int NrOfAnnouncements { get; set; }
        public string UserType { get; set; }
        public UserState GetState {get;set;}
    }
}
