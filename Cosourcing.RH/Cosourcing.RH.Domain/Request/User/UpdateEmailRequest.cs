using System;
namespace Cosourcing.RH.Domain.Request.User
{
	public class UpdateEmailRequest
	{
		public string Email { get; set; }

		public UpdateEmailRequest(string email)
		{
			Email = email;
		}
	}
}

