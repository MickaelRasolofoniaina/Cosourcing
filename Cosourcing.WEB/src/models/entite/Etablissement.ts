import { BaseEntite } from "./BaseEntite";

export interface Etablissement extends BaseEntite {
  nom: string;
  activite: string;
  idSociete: string;
}