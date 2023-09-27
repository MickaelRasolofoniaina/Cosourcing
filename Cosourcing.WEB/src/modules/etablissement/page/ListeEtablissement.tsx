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
import { getAllEtablissement, getSocieteEtablissement } from "../services/EtablissementService";
import { BaseEcran } from "../../shared/components/BaseEcran";
import { Etablissement } from "../../../models/entite/Etablissement";
import { Link, useNavigate, useSearchParams } from "react-router-dom";
import Grid from "@mui/material/Grid";
import { SocieteRoute } from "../../societe/SocieteRouter";
import { EtablissementRoute } from "../EtablissementRouter";
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import { useState, useEffect } from "react";
import { modifEtablissement } from "../services/EtablissementService";

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
  const [liste, setListe] = useState<Etablissement[]>([]);
  useEffect(() => {
    if(data){
      setListe(data)
    }
  }, [data])

  const handleAjouterEtablissement = () => {
    navigate(`${EtablissementRoute.Root}/ajout/0/${idSociete}`);
  }
  //modal
  const [open, setOpen] = useState(false);
  const [supr, setSupr] = useState<Etablissement | undefined> (undefined);
  const handleOpen = () => {
    setOpen(true);
  }

  const handleClose = () => {
    setOpen(false);
  }
  const handleSupprimerEtablissement = (etablissement: Etablissement) =>{
    setSupr(etablissement)
    handleOpen()
  }

  const supression = (etablissement: Etablissement) => {
      if(etablissement && etablissement.id !== undefined){
      etablissement.deleted = true;
      modifEtablissement(etablissement.id, etablissement)
      .then(response => {
        if(!response.ok){
          throw new Error('Echec de la suppression de cet Etablissement ');
        }
        setListe((ancienneListe) => ancienneListe.filter((e) => e.id !== etablissement.id));
             
        return response.json();
      })
      .then(data => {
        console.log('mise à jour réussi', data);
      })
      .catch(error => {
        console.error("Erreur lors de la mise à jour", error);
      })
    }else{
      console.log("erreur de suppression")
    }
  }
  

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
            {idSociete > 0 ? (
            <Button
              variant="contained"
              color="success"
              endIcon={<AddCircleIcon />}
              onClick={handleAjouterEtablissement}
            >
              Ajouter un établissement
            </Button>
            ) : ""}

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
              <TableCell align="right" colSpan={2}>
                <b>Gestion</b>
              </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {liste.map((etablissement) => (
              <TableRow
                key={etablissement.id}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell>
                  <Link to={`/etablissement/${etablissement.id}?idSociete=${idSociete}`}>
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
                  <IconButton>                    
                  <Link to={`/etablissement/modifier/${etablissement.id}/${etablissement.idSociete}`}>
                    <EditIcon />
                  </Link>
                  </IconButton>
                </TableCell>
                <TableCell align="right">
                  <IconButton  onClick={()=>{
                    handleSupprimerEtablissement(etablissement)
                  }}>
                    <DeleteIcon />
                  </IconButton>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
            <Dialog open={open} onClose={handleClose}>
        <DialogTitle>Alert</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Voulez vous vraiment Supprimer {supr !== undefined ? supr.nom : " "} ? 
          </DialogContentText>
        </DialogContent>
        <DialogActions>
        <Button onClick={()=>{
          if(supr !== undefined){
            supression(supr)
          }
          handleClose()
        }}>
          Valider

        </Button>
          <Button onClick={handleClose} color="primary">
            Fermer
          </Button>
        </DialogActions>
      </Dialog>
    </BaseEcran>
  );
};
