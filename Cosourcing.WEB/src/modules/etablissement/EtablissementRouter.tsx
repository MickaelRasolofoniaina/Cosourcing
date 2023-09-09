import { ListeEtablissement } from "./page/ListeEtablissement";
import {
  Route,
} from "react-router-dom";

export const EtablissementRouter = (
  <Route path="/etablissement">
    <Route index element={<ListeEtablissement />} />
  </Route>
);
