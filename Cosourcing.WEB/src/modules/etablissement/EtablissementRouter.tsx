import { AjoutEtablissement } from "./page/AjoutEtablissement";
import { DetailEtablissement } from "./page/DetailEtablissement";
import { ListeEtablissement } from "./page/ListeEtablissement";
import { ModifierEtablissement } from "./page/ModifierEtablissement";
import {
  Route,
} from "react-router-dom";

export const EtablissementRoute = {
  Root: "/etablissement",
  Ajout: "/etablissement/ajout/:idEtablissement/:idSociete",
  Detail: "/etablissement/:id",
  Modifier: "/etablissement/modifier/:idEtablissement/:idSociete"
}


export const EtablissementRouter = (
  <Route path={EtablissementRoute.Root}>
    <Route index element={<ListeEtablissement />} />
    <Route path={EtablissementRoute.Detail} element={<DetailEtablissement />} />
    <Route path={EtablissementRoute.Ajout} element={<AjoutEtablissement />} />
    <Route path ={EtablissementRoute.Modifier} element={<ModifierEtablissement />} />
  </Route>
);
