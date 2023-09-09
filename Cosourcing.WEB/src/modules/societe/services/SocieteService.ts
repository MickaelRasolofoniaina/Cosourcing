
import { Societe } from "../../../models/entite/Societe";

export const getAllSociete = async () => {
  const response = await fetch("https://localhost:40406/api/rh/societe", {
    method: "GET",
    headers: {
      "Access-control-allow-origin": "*",
      "Content-type": "application/json; charset=UTF-8",
    },
  });
 
  const data: Societe[] = await response.json();
  
  return data;
}