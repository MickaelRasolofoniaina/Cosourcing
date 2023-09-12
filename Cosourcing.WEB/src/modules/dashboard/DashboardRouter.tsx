import { Dashboard } from "./page/Dashboard";
import {
  Route,
} from "react-router-dom";

export const DashboardRoute = {
  Root: "/",
}

export const DashboardRouter = (
  <Route path="/">
    <Route index element={<Dashboard />} />
  </Route>
);
