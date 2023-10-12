import { Link, useNavigate, useParams } from "react-router-dom";
import Box from "@mui/material/Box";
import Grid from "@mui/material/Grid";
import Button from "@mui/material/Button";
import Divider from "@mui/material/Divider";
import Typography from "@mui/material/Typography";
import { Societe } from "../../../models/entite/Societe";
import { useHttp } from "../../shared/hooks/UseHttp";
import { getDetailEmploye } from "../service/employeService";
import { BaseEcran } from "../../shared/components/BaseEcran";
import { EmployeRoute } from "../../employe/EmployeRouter";
import HomeWorkIcon from "@mui/icons-material/HomeWork";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import { formatDate } from "../../../utils/DateUtils";
import { afficherInformation } from "../../../utils/StringUtils";
import { Employe } from "../../../models/entite/Employe";


export const DetailEmploye: React.FC = () => {
    const params = useParams();
    const navigate = useNavigate();

    const id = parseInt(params.id ?? "0");

    const { isLoading, error, data } = useHttp<Employe>(() =>
    getDetailEmploye(id)
    );
    
    const handleListeEmploye = () => {
        navigate(`${EmployeRoute.Root}?idEmploye=${id}`);
      };
    
    if(!data){
        return null;
    } 
    
    return (
        <BaseEcran isLoading={isLoading} error={error} titre="Détail société">
            <Grid container spacing={2} marginBottom={4}>
                <Grid item xs={6}>
                    <Box display={"flex"} alignItems={"center"}><Link to={EmployeRoute.Root}>Retour</Link></Box>
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
                        onClick={handleListeEmploye}
                        >
                        Liste des employés
                        </Button>
                    </Box>
                </Grid>
            </Grid>

            <Grid container spacing={2}>
            <Grid item xs={6}>
                <Divider>Information personnel</Divider>
                <List>
                    <ListItem>
                        <Typography>
                            <b>Genre:</b>{data.genre}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Nom:</b>{data.nom}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Prénoms:</b>{data.prenom}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Date de naissance:</b> {formatDate(data.dateNaissance)}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Lieu de naissance:</b>{data.lieuNaissance}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Pays de naissance:</b>{data.paysNaissance}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Nationalité:</b>{data.paysNationalite}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>CIN:</b>{data.cin}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Situation familliale:</b>{data.situation}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Adresse:</b>{data.adresse}
                        </Typography>
                    </ListItem>
                </List>

            </Grid>
            <Grid item xs={6}>
                <Divider>Information proffesionnel</Divider>
                <List>
                    <ListItem>
                        <Typography>
                            <b>Matricule:</b>{data.matricule}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Poste:</b>{data.poste}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Catégorie:</b>{data.categorie}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Groupe:</b>{data.groupe}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Date d'embauche:</b>{formatDate(data.dateEmbauche)}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Numéro CNAPS:</b>{data.numCnaps}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Heure contractuelle:</b>{data.heureContractuelle}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Type de contrat:</b>{data.typeContrat}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Lieu de travail:</b>{data.lieuTravail}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>Affectation:</b>{data.affectation}
                        </Typography>
                    </ListItem>
                </List>
            </Grid>
            <Grid item xs={6}>
                <Divider>Information financière</Divider>
                <List>
                    <ListItem>
                        <Typography>
                            <b>Salaire de base:</b>{data.salaire}
                        </Typography>
                    </ListItem>
                    <ListItem>
                        <Typography>
                            <b>N°iban:</b>{data.iban}
                        </Typography>
                    </ListItem>
                </List>
            </Grid>
            </Grid>
            <Typography>
                <b>Commentaire:</b>{afficherInformation(data.commentaire)}
            </Typography>

        </BaseEcran>
    );
};