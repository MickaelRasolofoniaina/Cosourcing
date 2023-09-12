import { Link, useNavigate, useParams } from "react-router-dom";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Button from "@mui/material/Button";
import Divider from "@mui/material/Divider";
import Typography from "@mui/material/Typography";
import { Societe } from "../../../models/entite/Societe";
import { useHttp } from "../../shared/hooks/UseHttp";
import { getDetailSociete } from "../services/SocieteService";
import { BaseEcran } from "../../shared/components/BaseEcran";
import { EtablissementRoute } from "../../etablissement/EtablissementRouter";
import { SocieteRoute } from "../SocieteRouter";
import HomeWorkIcon from "@mui/icons-material/HomeWork";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import { formatDate } from "../../../utils/DateUtils";
import { afficherInformation } from "../../../utils/StringUtils";

export const DetailSociete: React.FC = () => {
  const params = useParams();
  const navigate = useNavigate();

  const id = parseInt(params.id ?? "0");

  const { isLoading, error, data } = useHttp<Societe>(() =>
    getDetailSociete(id)
  );

  const handleListeEtablissement = () => {
    navigate(EtablissementRoute.Root);
  };

  if (!data) {
    return null;
  }

  return (
    <BaseEcran isLoading={isLoading} error={error} titre="Détail société">
      <Grid container spacing={2} marginBottom={4}>
        <Grid item xs={6}>
          <Link to={SocieteRoute.Root}>Retour</Link>
        </Grid>
        <Grid item xs={6}>
          <Box
            display={"flex"}
            justifyContent={"flex-end"}
            alignItems={"center"}
          >
            <Button
              variant="contained"
              color="primary"
              endIcon={<HomeWorkIcon />}
              onClick={handleListeEtablissement}
            >
              Liste des établissements
            </Button>
          </Box>
        </Grid>
      </Grid>
      <Grid container spacing={2}>
        <Grid item xs={6}>
          <Divider>Information générale</Divider>
          <List>
            <ListItem>
              <Typography>
                <b>Raison sociale:</b> {data.raisonSociale}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Nom commercial:</b> {data.nomCommercial}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Adresse:</b> {data.adresse}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Date de creation:</b> {formatDate(data.dateDeCreation)}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Forme Juridique:</b> {data.formeJuridique}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Numéro statistique:</b> {data.numeroStatistique}
              </Typography>
            </ListItem>
            <ListItem>
              <Typography>
                <b>Numéro d'identification fiscale:</b> {data.nif}
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
                <b>Nombre établissement:</b> {data.nombreEtablissement}
              </Typography>
            </ListItem>
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
