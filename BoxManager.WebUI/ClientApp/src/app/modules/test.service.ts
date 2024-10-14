import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class TestService {
    private _rootUrl: string = 'api/home';
    headers: HttpHeaders;

    constructor(private _http: HttpClient, @Inject('BASE_URL') private vaseUrl: string) {
        this.headers = new HttpHeaders();
    }

    test() : Observable<string> {
        return this._http.get<string>(`${this._rootUrl}`)
    }
}