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
    NonConnue="Non connue"

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

export enum Categorie{
    categorie1="Categorie1",
    categorie2 = "Categorie2"
}

export enum Groupe{
    groupe1 = "Groupe1",
    groupe2 = "Groupe2"
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
    dateEmbauche:Date;
    dateSortie:Date;
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