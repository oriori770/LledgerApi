using LledgerApi.Models;

namespace LledgerApi.ViewModels
{
    public class UserVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User ToUser (UserVM userVM)
        {
            return new User { FirstName = FirstName, LastName = LastName };
        }
        }
}
