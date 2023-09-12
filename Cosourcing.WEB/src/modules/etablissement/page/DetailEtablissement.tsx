import { Link, useParams, useSearchParams } from "react-router-dom";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Divider from "@mui/material/Divider";
import Typography from "@mui/material/Typography";
import { useHttp } from "../../shared/hooks/UseHttp";
import { getDetailEtablissement} from "../services/EtablissementService";
import { BaseEcran } from "../../shared/components/BaseEcran";
import { EtablissementRoute } from "../EtablissementRouter";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import { afficherInformation } from "../../../utils/StringUtils";
import { Etablissement } from "../../../models/entite/Etablissement";

export const DetailEtablissement: React.FC = () => {
  const params = useParams();
  const [searchParams] = useSearchParams();

  const id = parseInt(params.id ?? "0");
  const idSociete = parseInt(searchParams.get("idSociete") ?? "-1");

  const { isLoading, error, data } = useHttp<Etablissement>(() =>
    getDetailEtablissement(id)
  );

  if (!data) {
    return null;
  }

  return (
    <BaseEcran isLoading={isLoading} error={error} titre="Détail établissement">
      <Grid container spacing={2} marginBottom={4}>
        <Grid item xs={6}>
          <Box display={"flex"} alignItems={"center"}><Link to={`${EtablissementRoute.Root}?idSociete=${idSociete}`}>Retour</Link></Box>
        </Grid>
      </Grid>
      <Grid container spacing={2}>
        <Grid item xs={6}>
          <Divider>Information générale</Divider>
          <List>
            <ListItem>
              <Typography>
                <b>Nom commercial:</b> {data.nom}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Adresse:</b> {data.adresse}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Activité:</b> {data.activite}
              </Typography>
            </ListItem>
          </List>
        </Grid>
        <Grid item xs={6}>
          <Divider>Information responsable</Divider>
          <List>
            <ListItem>
              <Typography>
                <b>Nom responsable:</b> {data.nomResponsable}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Prénom responsable:</b> {afficherInformation(data.prenomResponsable)}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Qualité responsable:</b> {data.qualiteResponsable}
              </Typography>
            </ListItem>
          </List>
        </Grid>
        <Grid item xs={6}>
          <Divider>Information bancaire</Divider>
          <List>
            <ListItem>
              <Typography>
                <b>Code banque 1:</b> {afficherInformation(data.codeBanque1)}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Nom banque 1:</b> {afficherInformation(data.nomBanque1)}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Adresse banque 1:</b> {afficherInformation(data.adresseBanque1)}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>IBAN Banque 1:</b> {afficherInformation(data.iban1)}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Code banque 2:</b> {afficherInformation(data.codeBanque2)}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Nom banque 2:</b> {afficherInformation(data.nomBanque2)}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Adresse banque 2:</b> {afficherInformation(data.adresseBanque2)}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>IBAN Banque 2:</b> {afficherInformation(data.iban2)}
              </Typography>
            </ListItem>
          </List>
        </Grid>
        <Grid item xs={6}>
          <Divider>Autres information</Divider>
          <List>
            <ListItem>
              <Typography>
                <b>Nom Organisme social rattaché à la Société:</b> {data.nomOrganismeSociale}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Numéro d’affiliation à l’Organisme social rattaché à la Société:</b> {data.numeroOrganismeSociale}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Nom Service des impôts rattaché à la Société:</b> {data.nomServiceImpots}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Numéro d’affiliation au Service des impôts rattaché à la Société:</b> {data.numeroAffiliationImpots}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Commentaire:</b> {afficherInformation(data.commentaire)}
              </Typography>
            </ListItem>
          </List>
        </Grid>
      </Grid>
    </BaseEcran>
  );
};
