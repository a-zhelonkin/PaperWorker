import ApiBase from "./api-base";
import {HttpMethod} from "../constants/http-method";
import EmailData from "./models/email-data";

export default class UsersApi extends ApiBase {

    public static changePassword(password: string): Promise<EmailData> {
        return fetch(`${this.SERVER_HOST}/api/users/change-password`, {
            method: HttpMethod.Put,
            headers: this.authorizedHeaders(),
            body: JSON.stringify(password)
        })
            .then((response: Response) => {
                if (response.ok) {
                    return response.json();
                }
            });
    }

}