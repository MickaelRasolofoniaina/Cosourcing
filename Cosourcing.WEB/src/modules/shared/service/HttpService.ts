
export async function get<T> (url: string) {
  const response = await fetch(url);
  const data: T = await response.json();
  return data;
}