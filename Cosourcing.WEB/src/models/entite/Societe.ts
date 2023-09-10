import { BaseEntite } from "./BaseEntite";

export enum FormeJuridique {
  EI = "EI",
  EURL = "EURL",
  SA = "SA",
  SARL = "SARL",
  SAS = "SAS",
  SNC = "SNC",
  SCOP = "SCOP",
  SCA = "SCA"
}

export interface Societe extends BaseEntite {
  raisonSociale: string;
  nomCommercial: string;
  dateDeCreation: Date;
  formeJuridique: FormeJuridique;
  numeroStatistique: string;
  nif: string;
  activite: string;
  nombreEtablissement: number;
}
