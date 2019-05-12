import ApiBase from "./api-base";
import {HttpMethod} from "../constants/http-method";

export interface InviteStatus {
    status: string;
}

export default class InvitesApi extends ApiBase {

    public static getStatus(token: string): Promise<InviteStatus> {
        return fetch(`${this.SERVER_HOST}/api/invites/get-status`, {
            method: HttpMethod.Get,
            headers: this.authorizedHeaders(token)
        })
            .then((response: Response) => {
                if (response.ok) {
                    return response.json();
                }
            });
    }

    public static invite(email: string, roles: string[]): Promise<boolean> {
        return fetch(`${this.SERVER_HOST}/api/invites/invite`, {
            method: HttpMethod.Post,
            headers: this.authorizedHeaders(),
            body: JSON.stringify({
                email,
                roles
            })
        })
            .then((response: Response) => response.ok);
    }

}