import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";

import { BaseLayout } from "./modules/shared/Layout/BaseLayout";
import { SocieteRouter } from "./modules/societe/societeRouter";

const router = createBrowserRouter([
  {
    path: "/",
    element: <BaseLayout />,
    children: [SocieteRouter]
  },
]);

function App() {
  return (<RouterProvider router={router} />)
}

export default App;
