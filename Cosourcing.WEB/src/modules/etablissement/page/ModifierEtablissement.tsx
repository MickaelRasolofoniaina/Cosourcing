import { useNavigate, useParams } from "react-router-dom";
import { BaseEcran } from "../../shared/components/BaseEcran";
import { Etablissement } from "../../../models/entite/Etablissement";
import { modifEtablissement } from "../services/EtablissementService";
import { EtablissementRoute } from "../EtablissementRouter";
import { FormulaireEtablissement } from "./FormulaireEtablissement";

export const ModifierEtablissement : React.FC = () =>{	
	
	const params = useParams();
	const idEtablissement = parseInt(params.idEtablissement ?? "0");
	const idSociete = parseInt(params.idSociete ?? "0")
	
	const navigate = useNavigate();

	const executer = (etablissement : Etablissement) => {
		etablissement.id = idEtablissement;
		modifEtablissement(etablissement.id, etablissement)
			.then(response => {
				if(!response.ok){
					throw new Error('Echec de la mise à jour de cet Etablissement ');
				}
				navigate(`${EtablissementRoute.Root}?idSociete=${etablissement.idSociete}`);
				return response.json();
			})
			.then(data => {
				console.log('mise à jour réussi', data);
			})
			.catch(error => {
				console.error("Erreur lors de la mise à jour", error);
			})
	}
	return(
		<BaseEcran titre="Modifier Etablissement">
			<FormulaireEtablissement executable={executer} idEtablissement={idEtablissement} idSociete={idSociete} />
		</BaseEcran>
	)
}