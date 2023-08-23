using System;

namespace Cosourcing.RH.Domain.Etablissement
{
	public class EtablissementModel : BaseModel
	{
		
		public float Montant { get; set; }
		public DateTime Date { get; set; }
        public string Description { get; set; }

        public EtablissementModel(
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

