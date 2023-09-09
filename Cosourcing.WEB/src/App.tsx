import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";

import { BaseLayout } from "./modules/shared/layout/BaseLayout";
import { SocieteRouter } from "./modules/societe/SocieteRouter";
import { Erreur } from "./modules/erreur/Erreur";

const router = createBrowserRouter([
  {
    path: "/",
    element: <BaseLayout />,
    children: [SocieteRouter],
    errorElement: <Erreur />
  },
]);

function App() {
  return (<RouterProvider router={router} />)
}

export default App;
