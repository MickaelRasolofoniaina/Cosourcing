import { useNavigate, useParams } from "react-router-dom";
import { BaseEcran } from "../../shared/components/BaseEcran";
import { Etablissement } from "../../../models/entite/Etablissement";
import { ajouterEtablissement } from "../services/EtablissementService";
import { EtablissementRoute } from "../EtablissementRouter";
import { FormulaireEtablissement } from "./FormulaireEtablissement";

export const AjoutEtablissement : React.FC = () =>{	
	
	const params = useParams();
	const idEtablissement = parseInt(params.idEtablissement ?? "0");
	const idSociete = parseInt(params.idSociete ?? "0")
	
	const navigate = useNavigate();

	const executer = (etablissement : Etablissement) => {
    console.log("fonction ajout etablissement")
		etablissement.idSociete = idSociete;
		etablissement.id = 0;  
    console.log("ajouter etablissement")
    ajouterEtablissement(etablissement)
      .then((response) => {
        if (response > 0) {
          navigate(`${EtablissementRoute.Root}?idSociete=${idSociete}`);
        }
      })
      .catch(() => {
        console.log("erreur pendant le create")
      })
      .finally(() => {
        console.log("ajout avec succes");
      });
	}
	return(
		<BaseEcran titre="Modifier Etablissement">
			<FormulaireEtablissement executable={executer} idEtablissement={idEtablissement} idSociete={idSociete} />
    </BaseEcran>
	)
}