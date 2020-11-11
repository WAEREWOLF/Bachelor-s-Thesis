using System.Collections.Generic;

namespace LogicModel
{
    public enum UserState { Active, Inactive, Banned }
    
    public class AuthenticatedUser
    {
        public PersonalData PersonalData { get; set; }
        public History History { get; set; }
        public Message Message { get; set; }
        public IReadOnlyCollection<Announcements> Announcements { get; }
        public IReadOnlyCollection<Announcements> RecomAnouncements { get; }
        public IReadOnlyCollection<Announcements> FavouriteAnouncements { get; }
        public decimal Credits { get; set; }
        public int NrOfAnnouncements { get; set; }
        public Location Location { get; set; }
        public string UserType { get; set; }
        public UserState GetState {get;set;}
    }
}
