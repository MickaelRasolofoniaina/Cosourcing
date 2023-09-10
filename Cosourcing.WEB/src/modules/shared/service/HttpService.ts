
export async function get<T> (url: string) {
  try {
    const response = await fetch(url);
    const data: T = await response.json();
    return data;
  }
  catch {
    throw new Error();
  }
}

export async function post<T, U>(url: string, jsonData: T) {
  try {
    const response = await fetch(url, {
      method: "POST",
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(jsonData)
    });
    const data: U = await response.json();
    return data;
  }
  catch {
    throw new Error();
  }
}