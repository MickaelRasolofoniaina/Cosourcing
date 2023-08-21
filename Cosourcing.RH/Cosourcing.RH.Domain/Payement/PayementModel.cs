using System;

namespace Cosourcing.RH.Domain.Payement
{
	public class PayementModel : BaseModel
	{
		
		public float Montant { get; set; }
		public DateTime Date { get; set; }
        public string Description { get; set; }

        public PayementModel(
			Guid id,
			bool deleted,
			float montant,
			DateTime date,
			string description
		) : base(id, deleted)
		{
			Montant = montant;
			Date = date;
			Description = description;
		}
	}
}

