using System;

namespace Cosourcing.RH.Domain.User
{
	public class UserModel : BaseModel
	{
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public DateTime Birthday { get; set; }

		public UserModel(
			Guid id,
			string lastName,
			string firstName,
			DateTime birthday
		) : base(id)
		{
			LastName = lastName;
			FirstName = firstName;
			Birthday = birthday;
		}
	}
}

