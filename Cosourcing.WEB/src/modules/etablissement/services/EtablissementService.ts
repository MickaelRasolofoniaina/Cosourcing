
import { ETABLISSEMENT_ROOT_URL } from "../../../configs/EtablissementURL";
import { Etablissement } from "../../../models/entite/Etablissement";

export const getAllEtablissement = async () => {
  const response = await fetch(ETABLISSEMENT_ROOT_URL);
 
  const data: Etablissement[] = await response.json();
  
  return data;
}