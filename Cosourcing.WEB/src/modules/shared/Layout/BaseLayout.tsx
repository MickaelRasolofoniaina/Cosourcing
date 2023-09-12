import { Link, Outlet, useLocation } from "react-router-dom";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import CssBaseline from "@mui/material/CssBaseline";
import Divider from "@mui/material/Divider";
import Drawer from "@mui/material/Drawer";
import AddHomeIcon from "@mui/icons-material/AddHome";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import PeopleAltIcon from "@mui/icons-material/PeopleAlt";
import { SocieteRoute } from "../../societe/SocieteRouter";
import { EtablissementRoute } from "../../etablissement/EtablissementRouter";
import HomeWorkIcon from "@mui/icons-material/HomeWork";

const drawerWidth = 240;

export const BaseLayout: React.FC = () => {
  const { pathname } = useLocation();

  const drawer = (
    <div>
      <Toolbar>
        <img
          src="https://www.cosourcing.fr/wp-content/uploads/2020/12/logo-cosourcing-v4-220x49-1.jpg"
          alt="logo cosourcing"
        />
      </Toolbar>
      <Divider />
      <List>
        <ListItem disablePadding>
          <ListItemButton
            component={Link}
            to={SocieteRoute.Root}
            selected={pathname.includes(SocieteRoute.Root)}
          >
            <ListItemIcon>
              <AddHomeIcon />
            </ListItemIcon>
            <ListItemText primary={"Société"} />
          </ListItemButton>
        </ListItem>
        <ListItem disablePadding>
          <ListItemButton
            component={Link}
            to={EtablissementRoute.Root}
            selected={pathname.includes(EtablissementRoute.Root)}
          >
            <ListItemIcon>
              <HomeWorkIcon />
            </ListItemIcon>
            <ListItemText primary={"Etablissement"} />
          </ListItemButton>
        </ListItem>
        <ListItem disablePadding>
          <ListItemButton
            component={Link}
            to={EtablissementRoute.Root}
            selected={pathname.includes("employe")}
          >
            <ListItemIcon>
              <PeopleAltIcon />
            </ListItemIcon>
            <ListItemText primary={"Employé"} />
          </ListItemButton>
        </ListItem>
      </List>
    </div>
  );

  return (
    <Box sx={{ display: "flex" }}>
      <CssBaseline />
      <AppBar
        position="fixed"
        sx={{
          width: { sm: `calc(100% - ${drawerWidth}px)` },
          ml: { sm: `${drawerWidth}px` },
        }}
      >
        <Toolbar>
          <Typography variant="h6" noWrap component="div">
            Gestion ressource humaine
          </Typography>
        </Toolbar>
      </AppBar>
      <Box
        component="nav"
        sx={{ width: { sm: drawerWidth }, flexShrink: { sm: 0 } }}
      >
        <Drawer
          variant="permanent"
          sx={{
            display: { xs: "none", sm: "block" },
            "& .MuiDrawer-paper": {
              boxSizing: "border-box",
              width: drawerWidth,
            },
          }}
          open
        >
          {drawer}
        </Drawer>
      </Box>
      <Box
        component="main"
        sx={{
          flexGrow: 1,
          p: 3,
          width: { sm: `calc(100% - ${drawerWidth}px)` },
        }}
      >
        <Toolbar />
        <Outlet />
      </Box>
    </Box>
  );
};
