import ApiBase from "./api-base";
import {HttpMethod} from "../constants/http-method";

export interface Profile {
}

export default class ProfilesApi extends ApiBase {

    public static get(): Promise<Profile> {
        return fetch(`${this.SERVER_HOST}/api/profile`, {
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