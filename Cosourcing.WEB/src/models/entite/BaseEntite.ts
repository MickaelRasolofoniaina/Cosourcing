import { BaseModele } from "../BaseModel";

export interface BaseEntite extends BaseModele {
  nomResponsable: string;
  prenomResponsable?: string;
  qualiteResponsable: string;
  codeBanque1?: string | null;
  nomBanque1?: string;
  adresseBanque1?: string;
  iban1?: string | null;
  codeBanque2?: string | null;
  nomBanque2?: string;
  adresseBanque2?: string;
  iban2?: string | null;
  nomOrganismeSociale: string;
  numeroOrganismeSociale: string;
  nomServiceImpots: string;
  numeroAffiliationImpots: string;
  commentaire?: string;
  adresse: string;
}