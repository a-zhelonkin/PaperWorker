import ApiBase from "../../api/api-base";

export interface Profile {
}

export default class CabinetApi extends ApiBase {

    public static auth(email: string, password: string): Promise<Profile> {
        return fetch(`${this.SERVER_HOST}/api/profile`, {
            method: this.METHOD_GET,
            headers: this.authorizedHeaders()
        })
            .then((response: Response) => {
                if (response.ok) {
                    return response.json();
                }
            });
    }

}