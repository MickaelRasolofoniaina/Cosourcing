import { BaseModele } from "../BaseModel";

export interface BaseEntite extends BaseModele {
  nomResponsable: string;
  prenomResponsable: string;
  qualiteResponsable: string;
  codeBanque1: string;
  nomBanque1: string;
  iban1: string;
  codeBanque2: string;
  nomBanque2: string;
  iban2: string;
  nomOrganismeSociale: string;
  numeroOrganismeSociale: string;
  nomServiceImpots: string;
  numeroAffiliationImpots: string;
  commentaire: string;
  adresse: string;
}