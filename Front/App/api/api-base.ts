import store from "../store";
import {HttpMethod} from "../constants/http-method";

export const LS_KEY_TOKEN: string = "auth.token";

export default abstract class ApiBase {

    public static readonly SERVER_HOST: string = window.location.origin;

    public static readonly DEFAULT_HEADERS: Headers = ApiBase.defaultHeaders();

    public static defaultHeaders(): Headers {
        const headers: Headers = new Headers();
        headers.append("Content-Type", "application/json");
        return headers;
    }

    public static authorizedHeaders(token: string = store.getState().auth.token): Headers {
        const headers: Headers = ApiBase.defaultHeaders();
        headers.append("Authorization", `Bearer ${token}`);
        return headers;
    }

    protected static getAuthorizedApi<T>(route: string): Promise<T> {
        return fetch(`${this.SERVER_HOST}/api/${route}`, {
            method: HttpMethod.Get,
            headers: this.authorizedHeaders()
        }).then((response: Response) => {
            if (response.ok) {
                return response.json();
            }
        });
    }

    protected static postAuthorizedApi<T>(route: string, body: T): Promise<T> {
        return fetch(`${this.SERVER_HOST}/api/${route}`, {
            method: HttpMethod.Post,
            headers: this.authorizedHeaders(),
            body: JSON.stringify(body)
        }).then((response: Response) => {
            if (response.ok) {
                return response.json();
            }
        });
    }

}