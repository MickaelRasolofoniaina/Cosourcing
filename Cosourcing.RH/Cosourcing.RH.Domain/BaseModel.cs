using System;

namespace Cosourcing.RH.Domain
{
	public class BaseModel
	{
		public Guid Id { get; set; }

		public BaseModel(Guid id)
		{
			Id = id;
		}
	}
}

