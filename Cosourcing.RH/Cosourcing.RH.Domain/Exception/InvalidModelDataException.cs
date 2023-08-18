using System;

namespace Cosourcing.RH.Domain.Exception
{
	public class InvalidModelDataException : System.Exception
	{
		public InvalidModelDataException(string message) : base(message)
		{
		}
	}
}

