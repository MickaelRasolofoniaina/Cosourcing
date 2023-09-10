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
import { getAllEtablissement } from "../services/EtablissementService";
import { BaseEcran } from "../../shared/components/BaseEcran";
import { Etablissement } from "../../../models/entite/Etablissement";
import { Link } from "react-router-dom";

export const ListeEtablissement: React.FC = () => {
  const { data, isLoading, error } = useHttp<Etablissement[]>(() =>
    getAllEtablissement()
  );

  return (
    <BaseEcran isLoading={isLoading} error={error} titre="Liste des établissements">
      <Box marginBottom={4} display="flex" justifyContent="flex-end">
        <Button variant="contained" color="success" endIcon={<AddCircleIcon />}>
          Ajouter un établissement
        </Button>
      </Box>
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
              <TableCell align="right" colSpan={2}>
                <b>Gestion</b>
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {data?.map((etablissement) => (
              <TableRow
                key={etablissement.id}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell>
                  <Link to={`/etablissement/${etablissement.id}`}>{etablissement.id}</Link>
                </TableCell>
                <TableCell>{etablissement.nom}</TableCell>
                <TableCell>{etablissement.adresse}</TableCell>
                <TableCell>
                  {etablissement.nomResponsable} {etablissement.prenomResponsable}
                </TableCell>
                <TableCell>{etablissement.activite}</TableCell>
                <TableCell align="right">
                  <IconButton>
                    <EditIcon />
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
};
