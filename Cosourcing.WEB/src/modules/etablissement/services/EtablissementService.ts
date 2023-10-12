
import { ETABLISSEMENT_ROOT_URL } from "../../../configs/EtablissementURL";
import { Etablissement } from "../../../models/entite/Etablissement";
import { get, post, put } from "../../shared/service/HttpService";


export const getAllEtablissement = async () => {
  return get<Etablissement[]>(ETABLISSEMENT_ROOT_URL);
}

export const getSocieteEtablissement = async (idSociete: number) => {
  return get<Etablissement[]>(`${ETABLISSEMENT_ROOT_URL}?idSociete=${idSociete}`);
}

export const ajouterEtablissement = async(etablissement: Etablissement) => {
  return post<Etablissement, number>(ETABLISSEMENT_ROOT_URL, etablissement);
}

export const getDetailEtablissement = async(id: number) => {
  return get<Etablissement>(`${ETABLISSEMENT_ROOT_URL}/${id}`);
}

export const modifEtablissement = async(etablissement:Etablissement) => {
  return put<Etablissement, number>(`${ETABLISSEMENT_ROOT_URL}`, etablissement);   
}