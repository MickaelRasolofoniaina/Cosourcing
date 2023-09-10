import IconButton from '@mui/material/IconButton';
import Box from "@mui/material/Box";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import Button from '@mui/material/Button';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import { Societe } from "../../../models/entite/Societe";
import { useHttp } from "../../shared/hooks/UseHttp";
import { getAllSociete } from "../services/SocieteService";
import { BaseEcran } from '../../shared/components/BaseEcran';
import { Link } from 'react-router-dom';

export const ListeSociete: React.FC = () => {
  const  { data, isLoading, error } = useHttp<Societe[]>(() => getAllSociete());

  return (
    <BaseEcran isLoading={isLoading} error={error} titre='Liste des sociétés'>
      <Box marginBottom={4} display="flex" justifyContent="flex-end">
        <Button variant="contained" color='success' endIcon={<AddCircleIcon/>}>Ajouter une société</Button>
      </Box>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell><b>Id</b></TableCell>
              <TableCell><b>Nom</b></TableCell>
              <TableCell><b>Adresse</b></TableCell>
              <TableCell><b>Responsable</b> </TableCell>
              <TableCell><b>Activité</b> </TableCell>
              <TableCell align="right"><b>Numéro statistique</b></TableCell>
              <TableCell align="right"><b>Nif</b></TableCell>
              <TableCell align="right" colSpan={2}><b>Gestion</b></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
          {data?.map((societe) => (
            <TableRow
              key={societe.id}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell>
                <Link to={`/societe/${societe.id}`}>{societe.id}</Link>
              </TableCell>
              <TableCell>
                {societe.nomCommercial}
              </TableCell>
              <TableCell>{societe.adresse}</TableCell>
              <TableCell>{societe.nomResponsable} {societe.prenomResponsable}</TableCell>
              <TableCell>{societe.activite}</TableCell>
              <TableCell align="right">{societe.numeroStatistique}</TableCell>
              <TableCell align="right">{societe.nif}</TableCell>
              <TableCell align="right"><IconButton><EditIcon/></IconButton></TableCell>
              <TableCell align="right"><IconButton><DeleteIcon/></IconButton></TableCell>
            </TableRow>
          ))}
        </TableBody>
        </Table>
      </TableContainer>
    </BaseEcran>
  );
};
