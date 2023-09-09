import { BaseEntite } from "./BaseEntite";

export interface Societe extends BaseEntite {
  raisonSociale: string;
  nomCommercial: string;
  adresse: string;
  dateDeCreation: Date;
  formeJuridique: string;
  numeroStatistique: string;
  nif: string;
  activite: string;
  nombreEtablissement: number;
  
}
