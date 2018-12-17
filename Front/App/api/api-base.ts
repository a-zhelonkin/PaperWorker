import store from "../store"

export default abstract class ApiBase {

    public static readonly SERVER_HOST: string = window.location.origin;

    public static readonly METHOD_GET: string = "GET";

    public static readonly METHOD_POST: string = "POST";

    public static readonly LS_KEY_TOKEN: string = "token";

    public static readonly DEFAULT_HEADERS: Headers = ApiBase.defaultHeaders();

    public static defaultHeaders(): Headers {
        const headers: Headers = new Headers();
        headers.append("Content-Type", "application/json");
        return headers;
    }

    public static authorizedHeaders(): Headers {
        const headers: Headers = ApiBase.defaultHeaders();
        headers.append("Authorization", `Bearer ${store.getState().auth.token}`);
        return headers;
    }

}