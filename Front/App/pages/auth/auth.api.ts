import ApiBase from "../../api/api-base";

export interface TokenData {
    readonly token: string
}

export default class LoginApi extends ApiBase {

    public static auth(email: string, password: string): Promise<TokenData> {
        return fetch(`${this.SERVER_HOST}/api/auth/token`, {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
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

}