import { EMPLOYE_ROOT_URL } from "../../../configs/EmployeURL"
import { Employe } from "../../../models/entite/Employe";
import { get, post, put } from "../../shared/service/HttpService";

export const getAllEmploye = async () =>{
    return get<Employe[]>(EMPLOYE_ROOT_URL);
}

export const getEtablissementEmploye = async(idEtablissement: number) => {
    return get<Employe[]>(`${EMPLOYE_ROOT_URL}?idEtablisement=${idEtablissement}`);
}

export const ajouterEmploye = async(employe:Employe) => {
    return post<Employe,number>(EMPLOYE_ROOT_URL,employe);
}

export const getDetailEmploye = async(id:number) => {
    return get<Employe>(`${EMPLOYE_ROOT_URL}/${id}`);
}

export const modifierEmployer = async(id:number,employe : Employe) => {
    return put<Employe, number>(`${EMPLOYE_ROOT_URL}/${id}`, employe);   
}