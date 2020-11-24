using System;
using System.Collections.Generic;

namespace LogicModel
{
    public enum UserState { Active, Inactive, Banned }
    
    public class AuthenticatedUser : BaseIdentifier
    {
        public PersonalData PersonalData { get; set; }
        public History History { get; set; }        
        public ICollection<Message> Message { get; set; }
        public IReadOnlyCollection<Announcement> Announcements { get; }
        public IReadOnlyCollection<Announcement> RecomAnouncements { get; }
        public IReadOnlyCollection<Announcement> FavouriteAnouncements { get; }
        public decimal Credits { get; set; }
        public int NrOfAnnouncements { get; set; }
        public Location Location { get; set; }
        public string UserType { get; set; }
        public UserState GetState {get;set;}
    }
}
