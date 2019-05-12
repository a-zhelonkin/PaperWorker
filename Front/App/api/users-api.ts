import ApiBase from "./api-base";
import {HttpMethod} from "../constants/http-method";
import UserModel from "./models/user-model";
import AuthData from "./models/auth-data";

export default class UsersApi extends ApiBase {

    public static get(start: number, size: number): Promise<UserModel[]> {
        return fetch(`${this.SERVER_HOST}/api/users?start=${start}&size=${size}`, {
            method: HttpMethod.Get,
            headers: this.authorizedHeaders()
        })
            .then((response: Response) => {
                if (response.ok) {
                    return response.json();
                }
            });
    }

    public static changePassword(password: string, token?: string): Promise<AuthData> {
        return fetch(`${this.SERVER_HOST}/api/users/change-password`, {
            method: HttpMethod.Put,
            headers: this.authorizedHeaders(token),
            body: JSON.stringify(password)
        })
            .then((response: Response) => {
                if (response.ok) {
                    return response.json();
                }
            });
    }

}