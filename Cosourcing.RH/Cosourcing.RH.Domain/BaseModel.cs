namespace Cosourcing.RH.Domain
{
	public class BaseModel
	{
		public int Id { get; set; }
		public bool Deleted { get; set; } = false;

		public BaseModel(int id)
		{
			Id = id;
		}
	}
}

