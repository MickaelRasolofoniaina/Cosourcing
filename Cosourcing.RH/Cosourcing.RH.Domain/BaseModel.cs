using System;

namespace Cosourcing.RH.Domain
{
	public class BaseModel
	{
		public Guid Id { get; set; }
		public bool Deleted { get; set; }

		public BaseModel(Guid id, bool deleted)
		{
			Id = id;
			Deleted = deleted;
		}
	}
}

