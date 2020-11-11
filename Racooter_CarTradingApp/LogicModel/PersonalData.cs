using static System.Net.Mime.MediaTypeNames;

namespace LogicModel
{
    public class PersonalData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public enum UserType { normalUser, moderator}
        public UserType GetUserType { get; set; }
    }
}