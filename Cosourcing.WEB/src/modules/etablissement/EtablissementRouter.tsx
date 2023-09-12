import { AjoutEtablissement } from "./page/AjoutEtablissement";
import { ListeEtablissement } from "./page/ListeEtablissement";
import {
  Route,
} from "react-router-dom";

export const EtablissementRoute = {
  Root: "/etablissement",
  Ajout: "/etablissement/ajout"
}


export const EtablissementRouter = (
  <Route path={EtablissementRoute.Root}>
    <Route index element={<ListeEtablissement />} />
    <Route path={EtablissementRoute.Ajout} element={<AjoutEtablissement />} />
  </Route>
);
