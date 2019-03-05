import ApiBase from "./api-base";
import {HttpMethod} from "../constants/http-method";

export default class UsersApi extends ApiBase {

    public static changePassword(password: string): Promise<boolean> {
        return fetch(`${this.SERVER_HOST}/api/users/change-password`, {
            method: HttpMethod.Put,
            headers: this.authorizedHeaders(),
            body: JSON.stringify(password)
        })
            .then((response: Response) => response.ok);
    }

}