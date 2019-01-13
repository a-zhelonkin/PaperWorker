import store from "../store"

export const LS_KEY_TOKEN: string = "auth.token";

export default abstract class ApiBase {

    public static readonly SERVER_HOST: string = window.location.origin;

    public static readonly DEFAULT_HEADERS: Headers = ApiBase.defaultHeaders();

    public static defaultHeaders(): Headers {
        const headers: Headers = new Headers();
        headers.append("Content-Type", "application/json");
        return headers;
    }

    public static authorizedHeaders(token: string = store.getState().auth.token): Headers {
        const headers: Headers = ApiBase.defaultHeaders();
        headers.append("Authorization", `Bearer ${token}`);
        return headers;
    }

}