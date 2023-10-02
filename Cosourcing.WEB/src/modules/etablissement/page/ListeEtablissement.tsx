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
import { useHttp } from "../../shared/hooks/UseHttp";
import {
  getAllEtablissement,
  getSocieteEtablissement,
} from "../services/EtablissementService";
import { BaseEcran } from "../../shared/components/BaseEcran";
import { Etablissement } from "../../../models/entite/Etablissement";
import { Link, useNavigate, useSearchParams } from "react-router-dom";
import Grid from "@mui/material/Grid";
import { SocieteRoute } from "../../societe/SocieteRouter";
import { EtablissementRoute } from "../EtablissementRouter";

export const ListeEtablissement: React.FC = () => {
  const [params] = useSearchParams();
  const navigate = useNavigate();

  const idSociete = parseInt(params.get("idSociete") ?? "-1");

  const { data, isLoading, error } = useHttp<Etablissement[]>(() => {
    if (idSociete === -1) {
      return getAllEtablissement();
    } else {
      return getSocieteEtablissement(idSociete);
    }
  });

  const handleAjouterEtablissement = () => {
    navigate(`${EtablissementRoute.Ajout}?idSociete=${idSociete}`);
  };

  if (!data) {
    return null;
  }

  return (
    <BaseEcran
      isLoading={isLoading}
      error={error}
      titre="Liste des établissements"
    >
      <Grid container spacing={2} marginBottom={4}>
        <Grid item xs={6}>
          <Box display={"flex"} alignItems={"center"}>
            <Link to={`${SocieteRoute.Root}/${idSociete}`}>Retour</Link>
          </Box>
        </Grid>
        <Grid item xs={6}>
          <Box display="flex" justifyContent="flex-end">
            <Button
              variant="contained"
              color="success"
              endIcon={<AddCircleIcon />}
              onClick={handleAjouterEtablissement}
            >
              Ajouter un établissement
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
                <b>Nom</b>
              </TableCell>
              <TableCell>
                <b>Adresse</b>
              </TableCell>
              <TableCell>
                <b>Responsable</b>{" "}
              </TableCell>
              <TableCell>
                <b>Activité</b>{" "}
              </TableCell>
              <TableCell align="center" colSpan={2}>
                <b>Gestion</b>
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {data.map((etablissement) => (
              <TableRow
                key={etablissement.id}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell>
                  <Link
                    to={`/etablissement/${etablissement.id}?idSociete=${idSociete}`}
                  >
                    {etablissement.id}
                  </Link>
                </TableCell>
                <TableCell>{etablissement.nom}</TableCell>
                <TableCell>{etablissement.adresse}</TableCell>
                <TableCell>
                  {etablissement.nomResponsable}{" "}
                  {etablissement.prenomResponsable}
                </TableCell>
                <TableCell>{etablissement.activite}</TableCell>
                <TableCell align="right">
                  <Button
                    variant="contained"
                    color="warning"
                    endIcon={<EditIcon />}
                    onClick={() => {}}
                  >
                    Modifier
                  </Button>
                </TableCell>
                <TableCell align="right">
                  <Button
                    variant="contained"
                    color="error"
                    endIcon={<DeleteIcon />}
                    onClick={() => {}}
                  >
                    Supprimer
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </BaseEcran>
  );
};
