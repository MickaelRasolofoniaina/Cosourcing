import { DetailSociete } from "./page/DetailSociete";
import { ListeSociete } from "./page/ListeSociete";
import {
  Route,
} from "react-router-dom";

export const SocieteRouter = (
  <Route path="/societe">
    <Route index element={<ListeSociete />} />
    <Route path="/societe/:id" element={<DetailSociete />} />
  </Route>
);
