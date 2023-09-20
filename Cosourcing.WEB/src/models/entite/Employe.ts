import internal from "stream";
import { string } from "yup";
import { BaseModele } from "../BaseModel";

export enum Genre{
    Monsieur='Monsieur',
    Madame='Madame'
}

export enum Situation{
    Celibataire="Célibataire",  
    Marie="Marié",  
    Divorce="Divorcé",  
    Non_connue="Non connue"
}

export enum MotifSotie{
    Demision="Démission",
    Licenciement="Licenciement",
    FinEssaiEmployeur="Fin de période d’essai à l’initiative de l’Employeur",
    FinEssaiSalarie="Fin de période d’essai à l’initiative du salarié",
    FinCDDEmployeur="Fin de CDD par l’Employeur",
    FinCDDSalarie=" Fin de CDD par le salarié"
}
 export enum TypeContrat{
    CDD="CDD",
    CDI="CDI"
 }

export enum ModeReglement{
    virement="Virement",
    cheque="Chèque"
}

export interface Employe extends BaseModele {
    nom:string;
    prenom:string;
    matricule:number;
    genre:Genre;
    dateNaissance:Date;
    lieuNaissance:string;
    paysNaissance:string;
    paysNationalite:string;
    situation:Situation;
    adresse:string;
    poste:string;
    categorie:string;
    groupe:string;
    dEmbauche:Date;
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
    motifSortie:string;
}

export interface EmployeModif extends BaseModele {
    nom:string;
    prenom:string;
    matricule:number;
    genre:Genre;
    dateNaissance:Date;
    lieuNaissance:string;
    paysNaissance:string;
    paysNationalite:string;
    situation:Situation;
    adresse:string;
    poste:string;
    categorie:string;
    groupe:string;
    dEmbauche:Date;
    dSortie:Date;
    motifSortie:MotifSotie;
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
}