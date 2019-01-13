import ApiBase from "./api-base";
import {HttpMethod} from "../constants/http-method";

export interface InviteStatus {
    status: string;
}

export default class InvitesApi extends ApiBase {

    public static getStatus(token: string): Promise<InviteStatus> {
        return fetch(`${this.SERVER_HOST}/api/invites`, {
            method: HttpMethod.Get,
            headers: this.authorizedHeaders(token)
        })
            .then((response: Response) => {
                if (response.ok) {
                    return response.json();
                }
            });
    }

}