
namespace Cosourcing.RH.Domain.User
{
	public class UserModel : BaseModel
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public DateTime Birthday { get; set; }
        public string Email { get; set; }
	    public string MotDePasseHash { get; set; }

		public string Password { get; set; }

        public bool IsActive { get; set; }

        public UserModel(
			int id,
			string lastName,
			string firstName,
			DateTime birthday,
			string email,
			string motDePasseHash,
			string password,
			bool isActive
		) : base(id)
		{
			LastName = lastName;
			FirstName = firstName;
			Birthday = birthday;
			Email = email;
			MotDePasseHash = motDePasseHash;
			Password = password;
			IsActive = isActive;
		}
	}
}

