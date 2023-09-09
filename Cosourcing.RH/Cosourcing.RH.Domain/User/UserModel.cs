﻿
namespace Cosourcing.RH.Domain.User
{
	public class UserModel : BaseModel
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public DateTime Birthday { get; set; }
        public string Email { get; set; }

        public UserModel(
			int id,
			string lastName,
			string firstName,
			DateTime birthday,
			string email
		) : base(id)
		{
			LastName = lastName;
			FirstName = firstName;
			Birthday = birthday;
			Email = email;
		}
	}
}

