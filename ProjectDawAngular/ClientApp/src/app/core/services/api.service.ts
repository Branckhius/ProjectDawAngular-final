import { Inject, Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private readonly apiUrl: string;

  constructor(private readonly httpClient: HttpClient, @Inject('BASE_URL') apiUrl: string) {
    this.apiUrl = apiUrl;
  }
  deleteData(type: string, id: number): Observable<any[]> {
    const url = `${this.apiUrl}api/${type}/${id}`;
    console.log('DELETE request to:', url);  // Adăugați această linie pentru depanare
    return this.httpClient.delete<any[]>(url);
  }
  getData(type: string): Observable<any[]> {
    const url = `${this.apiUrl}api/${type}`;
    console.log('GET request to:', url);  // Adăugați această linie pentru depanare
    return this.httpClient.get<any[]>(url);
  }

  addData(type: string, newData: any): Observable<any[]> {
    const url = `${this.apiUrl}api/${type}`;
    console.log('POST request to:', url, 'with data:', newData);  // Adăugați această linie pentru depanare
    return this.httpClient.post<any[]>(url, newData);
  }

  get<T>(path: string, params = {}): Observable<any> {
    return this.httpClient.get<T>(`${this.apiUrl}${path}`, { params });
  }

  put<T>(path: string, body = {}): Observable<any> {
    return this.httpClient.put<T>(`${this.apiUrl}${path}`, body);
  }

  post<T>(path: string, body = {}): Observable<any> {
    return this.httpClient.post<T>(`${this.apiUrl}${path}`, body);
  }

  delete<T>(path: string): Observable<any> {
    return this.httpClient.delete<T>(`${this.apiUrl}${path}`);
  }
}
