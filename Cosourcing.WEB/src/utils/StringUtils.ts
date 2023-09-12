export const afficherInformation = (info: string | null | undefined) => {
  if(info && info.trim() !== "") return info;
  else return "Néant";
}