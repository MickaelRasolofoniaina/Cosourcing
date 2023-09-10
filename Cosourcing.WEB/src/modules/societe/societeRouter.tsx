import { AjoutSociete } from "./page/AjoutSociete";
import { DetailSociete } from "./page/DetailSociete";
import { ListeSociete } from "./page/ListeSociete";
import {
  Route,
} from "react-router-dom";

export const SocieteRoute = {
  Root: "/societe",
  Ajout: "/societe/ajout"
}

export const SocieteRouter = (
  <Route path="/societe">
    <Route index element={<ListeSociete />} />
    <Route path="/societe/:id" element={<DetailSociete />} />
    <Route path="/societe/ajout" element={<AjoutSociete />} />
  </Route>
);
