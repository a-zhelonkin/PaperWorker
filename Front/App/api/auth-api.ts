import ApiBase from "./api-base";
import {HttpMethod} from "../constants/http-method";

export interface TokenData {
    readonly token: string
}

export default class AuthApi extends ApiBase {

    public static auth(email: string, password: string): Promise<TokenData> {
        return fetch(`${this.SERVER_HOST}/api/auth/token`, {
            method: HttpMethod.Post,
            headers: this.DEFAULT_HEADERS,
            body: JSON.stringify({
                email,
                password
            })
        })
            .then((response: Response) => {
                if (response.ok) {
                    return response.json();
                }
            });
    }

    public static restorePassword(email: string): Promise<boolean> {
        return fetch(`${this.SERVER_HOST}/api/auth/restore-password`, {
            method: HttpMethod.Post,
            headers: this.DEFAULT_HEADERS,
            body: JSON.stringify(email)
        })
            .then((response: Response) => response.ok);
    }

}