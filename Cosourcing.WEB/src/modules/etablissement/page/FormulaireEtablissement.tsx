import { Link, useNavigate, useSearchParams } from "react-router-dom";
import { BaseEcran } from "../../shared/components/BaseEcran";
import { EtablissementRoute } from "../EtablissementRouter";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { object, number, string, ObjectSchema, boolean } from "yup";
import { CodeBanqueRegex, IbanRegex, NomRegex } from "../../../constants/Regex";
import { FormLabel} from '@mui/material';
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import TextField from "@mui/material/TextField";
import Cancel from "@mui/icons-material/Cancel";
import Save from "@mui/icons-material/Save";
import Divider from "@mui/material/Divider";
import { useState } from "react";
import { modifEtablissement } from "../services/EtablissementService";
import { Etablissement } from "../../../models/entite/Etablissement";
import { useHttp } from "../../shared/hooks/UseHttp";
import { getDetailEtablissement} from "../services/EtablissementService";
import React, {useEffect} from 'react';

interface myProps {
  executable: (etablissement : Etablissement) => void;
  idEtablissement : number;
  idSociete : number;
}


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
  id: number().optional().default(0),
  deleted: boolean().optional().default(false),
  idSociete: number().required(),
}).required();

export const FormulaireEtablissement: React.FC<myProps> = (props) => {
  const {
    register,
    handleSubmit,
    setValue,
    formState: { errors },
  } = useForm<Etablissement>({
    resolver: yupResolver(Etablissementchema),
  });


  const idEtablissement= props.idEtablissement;
  const idSociete= props.idSociete;


  const [erreur, setErreur] = useState(false);


  const onSubmit = handleSubmit((etablissement) => {
      console.log("execution du fonction props")
      console.log(etablissement)
      props.executable(etablissement);
  });

const { isLoading, error, data } = useHttp<Etablissement>(() =>
  getDetailEtablissement(idEtablissement)
);


useEffect(() => {
  setValue('id', idEtablissement);
  setValue('idSociete', idSociete);
if(idEtablissement > 0){
if(data){
  setValue('nom', data.nom);
  setValue('adresse', data.adresse);
  setValue('activite', data.activite);
  setValue('nomResponsable', data.nomResponsable);
  setValue('prenomResponsable', data.prenomResponsable);
  setValue('qualiteResponsable', data.qualiteResponsable);
  setValue('codeBanque1', data.codeBanque1);
  setValue('nomBanque1', data.nomBanque1);
  setValue('adresseBanque1', data.adresseBanque1);
  setValue('iban1', data.iban1);
  setValue('codeBanque2', data.codeBanque2);
  setValue('nomBanque2', data.nomBanque2);
  setValue('adresseBanque2', data.adresseBanque2);
  setValue('iban2', data.iban2);
  setValue('nomOrganismeSociale', data.nomOrganismeSociale);
  setValue('numeroOrganismeSociale', data.numeroOrganismeSociale);
  setValue('nomServiceImpots', data.nomServiceImpots);
  setValue('numeroAffiliationImpots', data.numeroAffiliationImpots);
  setValue('commentaire', data.commentaire);
  setValue('idSociete', data.idSociete);
  setValue('id', data.id);
}}
}, [data, setValue]);
  

  return (
    <BaseEcran titre="Etablissement">
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
            <FormLabel>Nom *</FormLabel>
            <TextField
              {...register("nom")}
              fullWidth
              error={errors.nom !== undefined}
              helperText={errors.nom?.message}

            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>Adresse *</FormLabel>
            <TextField
              {...register("adresse")}
              fullWidth
              error={errors.adresse !== undefined}
              helperText={errors.adresse?.message}

            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>Activité*</FormLabel>
            <TextField
              {...register("activite")}
              fullWidth
              error={errors.activite !== undefined}
              helperText={errors.activite?.message}

            />
          </Grid>
        </Grid>
        <Box marginTop={2} marginBottom={2}>
          <Divider>Information responsable</Divider>
        </Box>
        <Grid container spacing={2}>
          <Grid item xs={4}>
          <FormLabel>Nom responsable*</FormLabel>
            <TextField
              {...register("nomResponsable")}
              fullWidth
              error={errors.nomResponsable !== undefined}
              helperText={errors.nomResponsable?.message}

            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>Prénoms responsable</FormLabel>
            <TextField
              {...register("prenomResponsable")}
              fullWidth
              error={errors.prenomResponsable !== undefined}
              helperText={errors.prenomResponsable?.message}

            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>Qualité responsable</FormLabel>
            <TextField
              {...register("qualiteResponsable")}
              fullWidth
              error={errors.qualiteResponsable !== undefined}
              helperText={errors.qualiteResponsable?.message}

            />
          </Grid>
        </Grid>
        <Box marginTop={2} marginBottom={2}>
          <Divider>Information bancaire</Divider>
        </Box>
        <Grid container spacing={2}>
          <Grid item xs={4}>
          <FormLabel>codeBanque1</FormLabel>
            <TextField
              {...register("codeBanque1")}
              fullWidth
              error={errors.codeBanque1 !== undefined}
              helperText={errors.codeBanque1?.message}

            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>Nom banque 1</FormLabel>
            <TextField
              {...register("nomBanque1")}
              fullWidth
              error={errors.nomBanque1 !== undefined}
              helperText={errors.nomBanque1?.message}

            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>Adresse banque 1</FormLabel>
            <TextField
              {...register("adresseBanque1")}
              fullWidth
              error={errors.adresseBanque1 !== undefined}
              helperText={errors.adresseBanque1?.message}
              label="Adresse banque 1"
            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>IBAN 1</FormLabel>
            <TextField
              {...register("iban1")}
              fullWidth
              error={errors.iban1 !== undefined}
              helperText={errors.iban1?.message}

            />
          </Grid>
          <Grid item xs={8} />
          <Grid item xs={4}>
          <FormLabel>Code banque 2</FormLabel>
            <TextField
              {...register("codeBanque2")}
              fullWidth
              error={errors.codeBanque2 !== undefined}
              helperText={errors.codeBanque2?.message}

            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>Nom banque 2</FormLabel>
            <TextField
              {...register("nomBanque2")}
              fullWidth
              error={errors.nomBanque2 !== undefined}
              helperText={errors.nomBanque2?.message}

            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>Adresse banque 2</FormLabel>
            <TextField
              {...register("adresseBanque2")}
              fullWidth
              error={errors.adresseBanque2 !== undefined}
              helperText={errors.adresseBanque2?.message}

            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>IBAN 2</FormLabel>
            <TextField
              {...register("iban2")}
              fullWidth
              error={errors.iban2 !== undefined}
              helperText={errors.iban2?.message}

            />
          </Grid>
        </Grid>
        <Box marginTop={2} marginBottom={2}>
          <Divider>Autre information</Divider>
        </Box>
        <Grid container spacing={2}>
          <Grid item xs={4}>
          <FormLabel>Nom Organisme social rattaché à la Société</FormLabel>
            <TextField
              {...register("nomOrganismeSociale")}
              fullWidth
              error={errors.nomOrganismeSociale !== undefined}
              helperText={errors.nomOrganismeSociale?.message}

            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>Numéro d’affiliation à l’Organisme social rattaché à la Société</FormLabel>
            <TextField
              {...register("numeroOrganismeSociale")}
              fullWidth
              error={errors.numeroOrganismeSociale !== undefined}
              helperText={errors.numeroOrganismeSociale?.message}

            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>Nom Service des impôts rattaché à la Société</FormLabel>
            <TextField
              {...register("nomServiceImpots")}
              fullWidth
              error={errors.nomServiceImpots !== undefined}
              helperText={errors.nomServiceImpots?.message}

            />
          </Grid>
          <Grid item xs={4}>
          <FormLabel>Numéro d’affiliation au Service des impôts rattaché à la Société</FormLabel>
            <TextField
              {...register("numeroAffiliationImpots")}
              fullWidth
              error={errors.numeroAffiliationImpots !== undefined}
              helperText={errors.numeroAffiliationImpots?.message}

            />
          </Grid>
          <Grid item xs={8} />
          <Grid item xs={8}>
          <FormLabel>Commentaire</FormLabel>
            <TextField
              {...register("commentaire")}
              fullWidth
              error={errors.commentaire !== undefined}
              helperText={errors.commentaire?.message}

              multiline
              rows={5}
            />
          </Grid>
          <input type="hidden" {...register("idSociete")} />
          
          <input type="hidden" {... register ("id")} />
         

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
             
            >
              Annuler
            </Button>
            <Button
              variant="contained"
              color="success"
              type="submit"
              endIcon={<Save />}
              
            >
              Enregistrer
            </Button>

          </Grid>
        </Grid>
      </form>

    </BaseEcran>
  );
};
