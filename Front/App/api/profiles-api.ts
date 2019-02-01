import ApiBase from "./api-base";
import {HttpMethod} from "../constants/http-method";

export interface Profile {
    email: string;
    userId: string;
    firstName: string;
    lastName: string;
    patronymic: string;
    birthDateTime: string;
    employmentDateTime: string;
}

export default class ProfilesApi extends ApiBase {

    public static get(): Promise<Profile> {
        return fetch(`${this.SERVER_HOST}/api/profiles`, {
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