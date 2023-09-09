
import { SOCIETE_ROOT_URL } from "../../../../configs/SocieteURL";
import { Societe } from "../../../../models/entite/Societe";
import { get } from "../HttpService";

export const getAllSociete = async () => {
  return get<Societe[]>(SOCIETE_ROOT_URL);
}