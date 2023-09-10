import { useParams } from "react-router-dom";
import { Societe } from "../../../models/entite/Societe"
import { useHttp } from "../../shared/hooks/UseHttp"
import { getDetailSociete } from "../services/SocieteService";
import { BaseEcran } from "../../shared/components/BaseEcran";

export const DetailSociete: React.FC = () => {
  const params = useParams();
  const id = parseInt(params.id ?? "0");
  const { isLoading, error } = useHttp<Societe>(() => getDetailSociete(id));

  return (
    <BaseEcran isLoading={isLoading} error={error} titre="Détail société">
      <div>{id}</div>
    </BaseEcran>
  )
}