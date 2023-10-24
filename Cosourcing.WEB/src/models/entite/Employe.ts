import internal from "stream";
import { string } from "yup";
import { BaseModele } from "../BaseModel";
import { Pays } from "./Pays";

export enum Situation {
    CELIBATAIRE = "CELIBATAIRE",
    MARIE = "MARIE",
    DIVORCE = "DIVORCE",
    NONCONNUE = "NONCONNUE"
}

export enum MotifSortie {
    DEMISSION = "DEMISSION",
    LICENCIEMENT = "LICENCIEMENT",
    FIN_ESSAI_EMPLOYEUR = "FIN_ESSAI_EMPLOYEUR",
    FIN_ESSAI_SALARIE = "FIN_ESSAI_SALARIE",
    FIN_CDD_EMPLOYEUR = "FIN_CDD_EMPLOYEUR",
    FIN_CDD_SALARIE = "FIN_CDD_SALARIE"
}

export enum TypeContrat {
    CDD = "CDD",
    CDI = "CDI"
}

export enum ModeReglement {
    VIREMENT = "VIREMENT",
    CHEQUE = "CHEQUE"
}

export enum Genre {
    HOMME = "HOMME",
    FEMME = "FEMME",
    AUTRE = "AUTRE"
}

export enum Poste {
    DEVELOPPEUR = "DEVELOPPEUR",
    DIRECTEUR = "DIRECTEUR",
    AGENT = "AGENT"
}

export enum Categorie {
    CATEGORIE1 = "CATEGORIE1",
    CATEGORIE2 = "CATEGORIE2"
}

export enum Groupe {
    GROUPE1 = "GROUPE1",
    GROUPE2 = "GROUPE2"
}


export interface Employe extends BaseModele {
    nom:string;
    prenom:string;
    matricule:number;
    genre:Genre;
    dateNaissance:Date;
    lieuNaissance:string;
    paysNaissance:Pays;
    paysNationalite:Pays;
    situation:Situation;
    adresse:string;
    poste:Poste;
    categorie:Categorie;
    groupe:Groupe;
    dateEmbauche:Date;
    salaire:number;
    iban:string;
    cin:string;
    numCnaps:string;
    heureContractuelle:number;
    typeContrat:TypeContrat;
    modeReglement:ModeReglement;
    lieuTravail:string;
    affectation:string;
    commentaire:string;
    idEtablissement:number;
    motifSortie:MotifSortie;
}
