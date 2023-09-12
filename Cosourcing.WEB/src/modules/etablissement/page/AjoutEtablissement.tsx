import { Link, useNavigate, useSearchParams } from "react-router-dom";
import { BaseEcran } from "../../shared/components/BaseEcran";
import { EtablissementRoute } from "../EtablissementRouter";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { object, number, string, ObjectSchema, boolean } from "yup";
import { CodeBanqueRegex, IbanRegex, NomRegex } from "../../../constants/Regex";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import TextField from "@mui/material/TextField";
import Cancel from "@mui/icons-material/Cancel";
import Save from "@mui/icons-material/Save";
import Divider from "@mui/material/Divider";
import Alert from "@mui/material/Alert";
import Snackbar from "@mui/material/Snackbar";
import { useState } from "react";
import { ajouterEtablissement } from "../services/EtablissementService";
import { Etablissement } from "../../../models/entite/Etablissement";

const Etablissementchema: ObjectSchema<Etablissement> = object({
  nomResponsable: string()
    .required("Veuillez indiquer le nom du responsable")
    .matches(NomRegex, "Le nom du responsable n'est pas valide"),
  prenomResponsable: string()
    .optional()
    .default("")
    .matches(NomRegex, "Le prénom du responsable n'est pas valide"),
  qualiteResponsable: string().required(
    "Veuillez indiquer la qualité du responsable"
  ),
  codeBanque1: string()
    .optional()
    .nullable()
    .transform((value) => (value === "" ? null : value))
    .matches(
      CodeBanqueRegex,
      "Code banque invalide, veuillez insérer un code à 2 chiffres uniquement"
    ),
  nomBanque1: string().optional(),
  adresseBanque1: string().optional(),
  iban1: string()
    .optional()
    .nullable()
    .transform((value) => (value === "" ? null : value))
    .matches(
      IbanRegex,
      "Iban invalide, veuillez insérer un code à 23 chiffres uniquement"
    ),
  codeBanque2: string()
    .optional()
    .nullable()
    .transform((value) => (value === "" ? null : value))
    .matches(
      CodeBanqueRegex,
      "Code banque invalide, veuillez insérer un code à 2 chiffres uniquement"
    ),
  nomBanque2: string().optional(),
  adresseBanque2: string().optional(),
  iban2: string()
    .optional()
    .nullable()
    .transform((value) => (value === "" ? null : value))
    .matches(
      IbanRegex,
      "Iban invalide, veuillez insérer un code à 23 chiffres uniquement"
    ),
  nomOrganismeSociale: string().required(
    "Veuillez insérer le nom de l'organisme social"
  ),
  numeroOrganismeSociale: string().required(
    "Veuillez insérer le numéro d'affiliation de l'organisme social"
  ),
  nomServiceImpots: string().required(
    "Veuillez insérer le nom du service impôt"
  ),
  numeroAffiliationImpots: string().required(
    "Veuillez insérer le numéro d'affiliation du service impôt"
  ),
  commentaire: string().optional(),
  adresse: string().required("Veuillez indiquer l'adresse"),
  nom: string().required("Veuillez indiquer le nom"),
  activite: string().required("Veuillez indiquer l'activité de la société"),
  id: number().optional(),
  deleted: boolean().optional().default(false),
  idSociete: number().required(),
}).required();

export const AjoutEtablissement: React.FC = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<Etablissement>({
    resolver: yupResolver(Etablissementchema),
  });

  const [params] = useSearchParams();

  const idSociete = parseInt(params.get("idSociete") ?? "-1");

  const [erreur, setErreur] = useState(false);
  const [sending, setSending] = useState(false);
  const navigate = useNavigate();

  const onSubmit = handleSubmit((etablissement) => {
    setErreur(false);
    setSending(true);
    ajouterEtablissement(etablissement)
      .then((response) => {
        if (response > 0) {
          navigate(`${EtablissementRoute.Root}?idSociete=${idSociete}`);
        }
      })
      .catch(() => {
        setErreur(true);
      })
      .finally(() => {
        setSending(false);
      });
  });

  return (
    <BaseEcran titre="Ajouter un établissement">
      <Box marginBottom={4}>
        <Link to={`${EtablissementRoute.Root}?idSociete=${idSociete}`}>
          Retour
        </Link>
      </Box>
      <form onSubmit={onSubmit}>
        <Box marginBottom={2}>
          <Divider>Information générale</Divider>
        </Box>
        <Grid container spacing={2}>
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
              {...register("adresse")}
              fullWidth
              error={errors.adresse !== undefined}
              helperText={errors.adresse?.message}
              label="Adresse*"
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("activite")}
              fullWidth
              error={errors.activite !== undefined}
              helperText={errors.activite?.message}
              label="Activité*"
            />
          </Grid>
        </Grid>
        <Box marginTop={2} marginBottom={2}>
          <Divider>Information responsable</Divider>
        </Box>
        <Grid container spacing={2}>
          <Grid item xs={4}>
            <TextField
              {...register("nomResponsable")}
              fullWidth
              error={errors.nomResponsable !== undefined}
              helperText={errors.nomResponsable?.message}
              label="Nom responsable*"
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("prenomResponsable")}
              fullWidth
              error={errors.prenomResponsable !== undefined}
              helperText={errors.prenomResponsable?.message}
              label="Prénom responsable"
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("qualiteResponsable")}
              fullWidth
              error={errors.qualiteResponsable !== undefined}
              helperText={errors.qualiteResponsable?.message}
              label="Qualité responsable*"
            />
          </Grid>
        </Grid>
        <Box marginTop={2} marginBottom={2}>
          <Divider>Information bancaire</Divider>
        </Box>
        <Grid container spacing={2}>
          <Grid item xs={4}>
            <TextField
              {...register("codeBanque1")}
              fullWidth
              error={errors.codeBanque1 !== undefined}
              helperText={errors.codeBanque1?.message}
              label="Code banque 1"
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("nomBanque1")}
              fullWidth
              error={errors.nomBanque1 !== undefined}
              helperText={errors.nomBanque1?.message}
              label="Nom banque 1"
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("adresseBanque1")}
              fullWidth
              error={errors.adresseBanque1 !== undefined}
              helperText={errors.adresseBanque1?.message}
              label="Adresse banque 1"
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("iban1")}
              fullWidth
              error={errors.iban1 !== undefined}
              helperText={errors.iban1?.message}
              label="IBAN Banque 1"
            />
          </Grid>
          <Grid item xs={8} />
          <Grid item xs={4}>
            <TextField
              {...register("codeBanque2")}
              fullWidth
              error={errors.codeBanque2 !== undefined}
              helperText={errors.codeBanque2?.message}
              label="Code banque 2"
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("nomBanque2")}
              fullWidth
              error={errors.nomBanque2 !== undefined}
              helperText={errors.nomBanque2?.message}
              label="Nom banque 2"
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("adresseBanque2")}
              fullWidth
              error={errors.adresseBanque2 !== undefined}
              helperText={errors.adresseBanque2?.message}
              label="Adresse banque 2"
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("iban2")}
              fullWidth
              error={errors.iban2 !== undefined}
              helperText={errors.iban2?.message}
              label="IBAN Banque 2"
            />
          </Grid>
        </Grid>
        <Box marginTop={2} marginBottom={2}>
          <Divider>Autre information</Divider>
        </Box>
        <Grid container spacing={2}>
          <Grid item xs={4}>
            <TextField
              {...register("nomOrganismeSociale")}
              fullWidth
              error={errors.nomOrganismeSociale !== undefined}
              helperText={errors.nomOrganismeSociale?.message}
              label="Nom Organisme social rattaché à la Société"
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("numeroOrganismeSociale")}
              fullWidth
              error={errors.numeroOrganismeSociale !== undefined}
              helperText={errors.numeroOrganismeSociale?.message}
              label="Numéro d’affiliation à l’Organisme social rattaché à la Société"
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("nomServiceImpots")}
              fullWidth
              error={errors.nomServiceImpots !== undefined}
              helperText={errors.nomServiceImpots?.message}
              label="Nom Service des impôts rattaché à la Société"
            />
          </Grid>
          <Grid item xs={4}>
            <TextField
              {...register("numeroAffiliationImpots")}
              fullWidth
              error={errors.numeroAffiliationImpots !== undefined}
              helperText={errors.numeroAffiliationImpots?.message}
              label="Numéro d’affiliation au Service des impôts rattaché à la Société"
            />
          </Grid>
          <Grid item xs={8} />
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
          <input {...register("idSociete")} type="hidden" value={idSociete} />
        </Grid>
        <Box marginTop={2} marginBottom={2}>
          <Divider />
        </Box>
        <Grid container spacing={2}>
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
        </Grid>
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
