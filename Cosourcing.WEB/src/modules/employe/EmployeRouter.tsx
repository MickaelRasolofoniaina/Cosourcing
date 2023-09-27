import { AjoutEmploye } from "./page/AjoutEmploye";
import { DetailEmploye } from "./page/DetailEmploye";
import { ListeEmploye } from "./page/ListeEmploye";
import {
  Route,
} from "react-router-dom";
import { ModifierEmploye } from "./page/ModifierEmploye";
export const EmployeRoute ={
  Root:"/employe",
  Ajout:"/employe/ajout",
  Detail:"/employe/:id",
  Modifier: "/employe/modifier"
}

export const EmployeRouter = (
  <Route path={EmployeRoute.Root}>
    <Route index element={<ListeEmploye />} />
    <Route path={EmployeRoute.Detail} element={<DetailEmploye />} />
    <Route path={EmployeRoute.Ajout} element={<AjoutEmploye />} />
    <Route path={EmployeRoute.Modifier} element={<ModifierEmploye /> }/>
  </Route>
);
