import { Link, useNavigate, useSearchParams } from "react-router-dom";
import { BaseEcran } from "../../shared/components/BaseEcran";
import { EmployeRoute } from "../EmployeRouter";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import {
    object,
    number,
    string,
    ObjectSchema,
    date,
    boolean,
    mixed,
  } from "yup";
import {  IbanRegex, NomRegex } from "../../../constants/Regex";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import TextField from "@mui/material/TextField";
import Cancel from "@mui/icons-material/Cancel";
import MenuItem from "@mui/material/MenuItem";
import Save from "@mui/icons-material/Save";
import Divider from "@mui/material/Divider";
import Alert from "@mui/material/Alert";
import Snackbar from "@mui/material/Snackbar";
import { useState } from "react";
import { ajouterEmploye } from "../service/employeService";
import { Employe , Genre , Situation , TypeContrat , ModeReglement} from "../../../models/entite/Employe";

const EmployeSchema:ObjectSchema<Employe>=object({
    nom:string().required("Veuillez indiquer le nom de l'employé"),
    prenom:string().required(),
    matricule:number().required("Veuillez indiquer le numéro matricule de l'employé"),
    genre: mixed<Genre>()
        .required("Veuillez indiquer le genre de l'employé: Monsieur ou Madamae"),
    dateNaissance:date()
        .required("Veuillez indiquer la date de nnaissande de l'employé")
        .max(new Date(),"La date de naissance doit être dans le passé")
        .typeError("La date de naissance doit être dans le passé"),
    lieuNaissance:string().required("Veuillez indiquer le lieu de naissance de l'employé"),
    paysNaissance:string()
        .required("Veuillez indiquer le pays de naissance de l'employé"), 
    paysNationalite:string().required("Veuillez indiquez la nationnalité de l'employé"),
    situation:mixed<Situation>().required("Veuillez indiquez la situation de l'employé"),
    adresse:string().required("Vueillez indiquer l'adresse de l'employé"),
    poste:string().required("Vueillez indiquer le poste qu'occupe l'employé"),
    categorie:string().required("Veuillez indiquer la catégorie de l'employé"),
    groupe:string().required("Veuillez indiquer le groupe de l'employé"),
    dEmbauche:date().required("Veuillez indiquer la date d'embauche de l'employé"),
    salaire:number()
        .required("Vueillez indiquer le salaire de base mensuel de l'employé")
        .min(0),
    iban: string()
        .optional()
        .transform((value) => (value === "" ? null : value))
        .default("")
        .matches(
        IbanRegex,
      "Iban invalide, veuillez insérer un code à 23 chiffres uniquement"),
    cin:string()
        .required("Veuillez indiquer le numéro cin de l'employé")
        .matches(/^\d{12}$/,"Le numéro CIN doit être composé de 12 caractéres"),
    numCnaps:string().required("Veuillez indiquer le numéro CNAPS de l'employé"),
    heureContractuelle:number().required("Veuillez indiquer l'heure contractuelle de l'employé"),
    typeContrat:mixed<TypeContrat>()
        .required("Veuillez indiquer le type de contrat de l'employé")
        .default(TypeContrat.CDD),
        modeReglement:mixed<ModeReglement>().required("Veuillez indiquez le mode règlement de l'employé"),
    lieuTravail:string().required("Veuillez indiquer le lieu où traille l'employé"),
    affectation:string().required("Veuillez indiquer l'affectation de l'employé"),
    commentaire:string().optional().default(""),
    id: number().optional(),
    deleted: boolean().optional().default(false),
    idEtablissement:number().required(),
    motifSortie:string().optional().default(""),
}).required();

export const AjoutEmploye: React.FC = () => {


    const {
        register,
        handleSubmit,
        formState: { errors },
      } = useForm<Employe>({
        resolver: yupResolver(EmployeSchema),
      });

    const [params] = useSearchParams();

    const idEtablissement = parseInt(params.get("idEtablissement") ?? "-1");

    const [erreur, setErreur] = useState(false);
    const [sending, setSending] = useState(false);
    const navigate = useNavigate();
  
    const onSubmit = handleSubmit((employe) => {
        console.log(employe);
        setErreur(false);
        setSending(true);
        ajouterEmploye(employe)
          .then((response) => {
            if (response > 0) {
              navigate(`${EmployeRoute.Root}?idEtablissement=${idEtablissement}`);
            }
          })
          .catch(() => {
            setErreur(true);
          })
          .finally(() => {
            setSending(false);
          });
      });

    return(
        <BaseEcran titre="Ajouter un employé">
            <Box marginBottom={4}>
                <Link to={`${EmployeRoute.Root}?idEtablissement=${idEtablissement}`}>
                Retour
                </Link>
            </Box>
            <form onSubmit={onSubmit}>

                 <Box marginBottom={2}>
                    <Divider>Information personnel</Divider>
                </Box>

                    <Grid container spacing={2} >
                        <Grid item xs={4}>
                            <TextField
                                {...register("genre")}
                                fullWidth
                                error={errors.genre !== undefined}
                                helperText={errors.genre?.message}
                                label="Genre*"
                                select
                                >
                                {Object.values(Genre).map((option) => (
                                <MenuItem key={option} value={option}>
                                {option}
                                </MenuItem>
                                 ))}
                            </TextField>
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("nom")}
                                fullWidth
                                error={errors.nom !== undefined}
                                helperText={errors.nom?.message}
                                label="Nom*"
                            />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("prenom")}
                                fullWidth
                                error={errors.nom !== undefined}
                                helperText={errors.nom?.message}
                                label="Prénoms"
                            />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("dateNaissance")}
                                fullWidth
                                error={errors.dateNaissance !== undefined}
                                helperText={errors.dateNaissance?.message}
                                label="Date de Naissance*"
                                type="date"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("lieuNaissance")}
                                fullWidth
                                error={errors.lieuNaissance !== undefined}
                                helperText={errors.lieuNaissance?.message}
                                label="Lieu de naissance"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("paysNaissance")}
                                fullWidth
                                error={errors.paysNaissance !== undefined}
                                helperText={errors.paysNaissance?.message}
                                label="Pays de naissance"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("paysNationalite")}
                                fullWidth
                                error={errors.paysNationalite !== undefined}
                                helperText={errors.paysNationalite?.message}
                                label="Nationalité"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("cin")}
                                fullWidth
                                error={errors.cin !== undefined}
                                helperText={errors.cin?.message}
                                label="Numéro de CIN"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("situation")}
                                fullWidth
                                error={errors.situation !== undefined}
                                helperText={errors.situation?.message}
                                label="Situation de famille"
                                select
                            >
                            {Object.values(Situation).map((option) => (
                            <MenuItem key={option} value={option}>
                            {option}
                            </MenuItem>
                            ))}
                            </TextField>
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("adresse")}
                                fullWidth
                                error={errors.adresse !== undefined}
                                helperText={errors.adresse?.message}
                                label="Adresse"
                                />
                        </Grid>
                    </Grid>

                <Box marginBottom={2}>
                    <Divider>Information proffesionnel</Divider>
                </Box>
                <Grid container spacing={2}>

                        <Grid item xs={4}>
                            <TextField
                                {...register("matricule")}
                                fullWidth
                                error={errors.matricule !== undefined}
                                helperText={errors.matricule?.message}
                                label="Matricule"
                                type="number"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("poste")}
                                fullWidth
                                error={errors.poste !== undefined}
                                helperText={errors.poste?.message}
                                label="Poste"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("categorie")}
                                fullWidth
                                error={errors.categorie !== undefined}
                                helperText={errors.categorie?.message}
                                label="Catégorie"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("groupe")}
                                fullWidth
                                error={errors.groupe !== undefined}
                                helperText={errors.groupe?.message}
                                label="Groupe"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("dEmbauche")}
                                fullWidth
                                error={errors.dEmbauche !== undefined}
                                helperText={errors.dEmbauche?.message}
                                label="Date d'embauche"
                                type="date"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("numCnaps")}
                                fullWidth
                                error={errors.numCnaps !== undefined}
                                helperText={errors.numCnaps?.message}
                                label="Numéro CNAPS"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("heureContractuelle")}
                                fullWidth
                                error={errors.heureContractuelle !== undefined}
                                helperText={errors.heureContractuelle?.message}
                                label="Heure contractuelle"
                                type="number"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("typeContrat")}
                                fullWidth
                                error={errors.typeContrat !== undefined}
                                helperText={errors.typeContrat?.message}
                                label="Type de contrat"
                                select
                                >
                                {Object.values(TypeContrat).map((option) => (
                                <MenuItem key={option} value={option}>
                                {option}
                                </MenuItem>
                                ))}
                        </TextField>
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("lieuTravail")}
                                fullWidth
                                error={errors.lieuTravail !== undefined}
                                helperText={errors.lieuTravail?.message}
                                label="Lieu de travaille"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("affectation")}
                                fullWidth
                                error={errors.affectation !== undefined}
                                helperText={errors.affectation?.message}
                                label="Affectation"
                                />
                        </Grid>
                    
                </Grid>
                <Box marginBottom={2}>
                    <Divider>Information financière</Divider>
                </Box>
                <Grid container spacing={2}>
                        <Grid item xs={4}>
                            <TextField
                                {...register("salaire")}
                                fullWidth
                                error={errors.salaire !== undefined}
                                helperText={errors.salaire?.message}
                                label="Salaire de base mensuelle"
                                type="number"
                                />
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("modeReglement")}
                                fullWidth
                                error={errors.modeReglement !== undefined}
                                helperText={errors.modeReglement?.message}
                                label="Mode de règlement"
                                select
                                >
                                {Object.values(ModeReglement).map((option) => (
                                <MenuItem key={option} value={option}>
                                {option}
                                </MenuItem>
                                ))}    
                            </TextField>
                        </Grid>
                        <Grid item xs={4}>
                            <TextField
                                {...register("iban")}
                                fullWidth
                                error={errors.iban !== undefined}
                                helperText={errors.iban?.message}
                                label="N°iban"
                                />
                        </Grid>
                </Grid>
            <Grid item xs={8}>
                <TextField
                {...register("commentaire")}
                fullWidth
                error={errors.commentaire !== undefined}
                helperText={errors.commentaire?.message}
                label="Commentaire"
                multiline
                rows={5}
                />
            </Grid>
            <Grid item xs={12}>
            <Button
              variant="contained"
              color="error"
              type="reset"
              endIcon={<Cancel />}
              style={{
                marginRight: 20,
              }}
              disabled={sending}
            >
              Annuler
            </Button>
            <Button
              variant="contained"
              color="success"
              type="submit"
              endIcon={<Save />}
              disabled={sending}
            >
              Enregistrer
            </Button>
            
            
          </Grid>
          <input {...register("idEtablissement")} type="hidden" value={idEtablissement} />
          <input {...register("motifSortie")} type="hidden" value={""} />
            </form>
            <Snackbar
        open={erreur}
        autoHideDuration={2000}
        onClose={() => setErreur(false)}
        anchorOrigin={{ vertical: "top", horizontal: "right" }}
      >
        <Alert variant="filled" severity="error">
          Une erreur s'est produite, veuillez réessayer s'il vous plaît
        </Alert>
      </Snackbar>
            
        </BaseEcran>
    );
};
