import Alert from "@mui/material/Alert";
import Box from "@mui/material/Box";
import CircularProgress from "@mui/material/CircularProgress";
import { Erreur } from "../../../models/BaseModel";
import { Link } from "react-router-dom";
import Typography from "@mui/material/Typography";

export interface BaseEcranProps {
  isLoading?: boolean;
  error?: Erreur | undefined;
  children: React.ReactElement[] | React.ReactElement;
  titre: string;
}

export const BaseEcran: React.FC<BaseEcranProps> = ({
  isLoading,
  error,
  children,
  titre
}) => {
  if (isLoading) {
    return (
      <Box
        display={"flex"}
        alignItems={"center"}
        justifyContent={"center"}
        flexDirection={"column"}
      >
        <CircularProgress />
      </Box>
    );
  }

  if (error) {
    return (
      <Box
        display={"flex"}
        alignItems={"center"}
        justifyContent={"center"}
        flexDirection={"column"}
      >
        <img
          src="https://www.kodella.com/wp-content/uploads/2020/10/shutterstock_1827272009-Converted-1024x545.jpg"
          alt="Illustration erreur"
        />
        <Alert severity="error">
          Une erreur s'est produite, cliquer <Link to={"/"}>ici</Link> pour
          revenir à la page d'accueil
        </Alert>
      </Box>
    );
  }

  return (<>
   <Typography variant="h5" component="h1" marginBottom={2}>
        {titre}
      </Typography>
  {children}
  </>);
};
