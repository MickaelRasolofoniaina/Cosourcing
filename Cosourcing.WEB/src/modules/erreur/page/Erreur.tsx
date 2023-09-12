
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import { Link } from "react-router-dom";

export const Erreur: React.FC = () => {
  return (
    <Box display={"flex"} alignItems={"center"} justifyContent={"center"} padding={20} flexDirection={"column"}>
      <Typography variant="h4" textAlign={"center"} component={"p"}>
        Oops! La page que vous demandez n'existe pas!
      </Typography>
      <Link to="/">Retourner vers la page d'accueil</Link>
    </Box>
  );
}