import {
  createBrowserRouter,
  RouterProvider,
  createRoutesFromElements,
  Route,
} from "react-router-dom";

import { BaseLayout } from "./modules/shared/layout/BaseLayout";
import { SocieteRouter } from "./modules/societe/SocieteRouter";
import { EtablissementRouter } from "./modules/etablissement/EtablissementRouter";
import { EmployeRouter } from "./modules/employe/EmployeRouter";
import { Erreur } from "./modules/erreur/page/Erreur";
import { DashboardRouter } from "./modules/dashboard/DashboardRouter";

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<BaseLayout />} errorElement={<Erreur />}>
      {DashboardRouter}
      {SocieteRouter}
      {EtablissementRouter}
      {EmployeRouter}
    </Route>
  )
);

function App() {
  return <RouterProvider router={router} />;
}

export default App;
