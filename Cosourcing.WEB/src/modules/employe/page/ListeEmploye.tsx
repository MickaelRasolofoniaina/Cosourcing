import IconButton from "@mui/material/IconButton";
import Box from "@mui/material/Box";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import Button from "@mui/material/Button";
import AddCircleIcon from "@mui/icons-material/AddCircle";
import { BaseEcran } from "../../shared/components/BaseEcran";
import { getAllEmploye, getEtablissementEmploye } from "../service/employeService";
import { useHttp } from "../../shared/hooks/UseHttp";
import { Employe } from "../../../models/entite/Employe";
import { Link, useNavigate, useSearchParams } from "react-router-dom";
import Grid from "@mui/material/Grid";
import { SocieteRoute } from "../../societe/SocieteRouter";
import { EmployeRoute } from "../EmployeRouter";

export const ListeEmploye: React.FC = () => {
    const [params] = useSearchParams();
    const navigate = useNavigate();

    const idEtablissement = parseInt(params.get("idEtablissement") ?? "-1");

    const { data, isLoading,error} = useHttp<Employe[]>(() => {
        if(idEtablissement === -1)
        {
            return getAllEmploye();
        }
        else {
            return getEtablissementEmploye(idEtablissement);
        }
    });

    const handleAjouterEmploye = () => {
        navigate(`${EmployeRoute.Ajout}?idEtablissement=${idEtablissement}`);
    }

    if (!data){
        return null;
    }

    return (
        <BaseEcran 
        isLoading={isLoading}
        error={error}
        titre="Liste des employés"
        >
            <Grid container spacing={2} marginBottom={4}>
                <Grid item xs={6}>
                    <Box display={"flex"} alignItems={"center"}>
                        <Link to={`${SocieteRoute.Root}/${idEtablissement}`}></Link>
                    </Box>
                </Grid>
                <Grid item xs={6}>
                <Box display="flex" justifyContent="flex-end">
                    <Button
                    variant="contained"
                    color="success"
                    endIcon={<AddCircleIcon />}
                    onClick={handleAjouterEmploye}
                    >
                    Ajouter un employé
                    </Button>
                </Box>
                </Grid>
            </Grid>
            <TableContainer component={Paper}>
                <Table>
                    <TableHead>
                        <TableRow>
                        <TableCell>
                                <b>Id</b>
                            </TableCell>
                            <TableCell>
                                <b>Matricule</b>
                            </TableCell>
                            <TableCell>
                                <b>Nom</b>
                            </TableCell>
                            <TableCell>
                                <b>Prénoms</b>
                            </TableCell>
                            <TableCell>
                                <b>Poste</b>
                            </TableCell>
                            <TableCell>
                                <b>Catégorie</b>
                            </TableCell>
                            <TableCell>
                                <b>Lieu de travail</b>
                            </TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {data.map((employe)=>(
                            <TableRow
                            key={employe.id}
                            sx={{"&:last-child td, &:last-child th":{ border: 0}}}
                            >
                                <TableCell>
                                    <Link to={`/employe/${employe.id}?idEtablissement=${idEtablissement}`}>
                                        {employe.id}
                                    </Link>
                                </TableCell>
                                <TableCell>
                                    <Link to={`/employe/${employe.matricule}?idEtablissement=${idEtablissement}`}>
                                        {employe.matricule}
                                    </Link>
                                </TableCell>
                                <TableCell>{employe.nom}</TableCell>
                                <TableCell>{employe.prenom}</TableCell>
                                <TableCell>{employe.poste}</TableCell>
                                <TableCell>{employe.lieuTravail}</TableCell>
                                <TableCell align="right">
                                <IconButton>                                    
                                    <Link to={`/employe/modifier?idEtablissement=${idEtablissement}&idEmployer=${employe.id}`}>
                                    <EditIcon />
                                    </Link>
                                </IconButton>
                                </TableCell>
                                <TableCell align="right">
                                <IconButton>
                                    <DeleteIcon />
                                </IconButton>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            
        </BaseEcran>
    );
}