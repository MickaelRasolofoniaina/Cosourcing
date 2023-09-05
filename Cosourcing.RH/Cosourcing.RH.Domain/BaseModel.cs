namespace Cosourcing.RH.Domain
{
	public class BaseModel
	{
		public Guid Id { get; set; }
		public bool Deleted { get; set; } = false;

		public BaseModel(Guid id)
		{
			Id = id;
		}
	}
}

