import { useCallback, useEffect, useState } from "react";
import { Erreur } from "../../../models/BaseModel";

export function useHttp<T>(fn: () => Promise<T>) {
  const [data, setData] = useState<T>();
  const [isLoading, setLoading] = useState(false);
  const [error, setError] = useState<Erreur>();

  const fnc = useCallback(fn, [fn]);

  useEffect(() => {
    setLoading(true);

    fnc()
      .then((data) => {
        setData(data);
      })
      .catch((error: Erreur) => {
        setError(error);
      })
      .finally(() => {
        setLoading(false);
      })
  }, [fnc]);

  return { isLoading, data, error }
}