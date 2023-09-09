import { useEffect, useState } from "react";
import { Erreur } from "../../../models/BaseModel";

export function useHttp<T>(fn: () => Promise<T>) {
  const [data, setData] = useState<T>();
  const [isLoading, setLoading] = useState(false);
  const [error, setError] = useState<Erreur>();

  useEffect(() => {
    setLoading(true);

    fn()
      .then((data) => {
        setData(data);
      })
      .catch((error: Erreur) => {
        console.log(error, "erreur");
        setError(error);
      })
      .finally(() => {
        setLoading(false);
      })
  }, []);

  return { isLoading, data, error }
}