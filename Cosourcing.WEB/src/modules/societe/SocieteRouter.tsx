import { AjoutSociete } from "./page/AjoutSociete";
import { DetailSociete } from "./page/DetailSociete";
import { ListeSociete } from "./page/ListeSociete";
import {
  Route,
} from "react-router-dom";

export const SocieteRoute = {
  Root: "/societe",
  Ajout: "/societe/ajout",
  Detail: "/societe/:id",
}

export const SocieteRouter = (
  <Route path={SocieteRoute.Root}>
    <Route index element={<ListeSociete />} />
    <Route path={SocieteRoute.Detail} element={<DetailSociete />} />
    <Route path={SocieteRoute.Ajout} element={<AjoutSociete />} />
  </Route>
);
