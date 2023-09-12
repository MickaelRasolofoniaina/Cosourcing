export const formatDate = (d:Date) => {
  const date = new Date(d);
  const year = date.getFullYear();
  const day = date.getDate();
  const month = date.getMonth();

  return `${day < 10 ? "0" + day : day}-${month + 1 < 10 ? "0" + (month + 1) : month + 1}-${year}`;
}