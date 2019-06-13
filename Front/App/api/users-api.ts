import ApiBase from "./api-base";
import {HttpMethod} from "../constants/http-method";
import {UserStatus} from "../constants/user-status";

export interface UserModel {
    readonly id: string;
    readonly email: string;
    readonly status: UserStatus;
    readonly firstName: string;
    readonly lastName: string;
    readonly patronymic: string;
    readonly phoneNumber: string;
}

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

}