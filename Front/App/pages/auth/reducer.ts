import {combineReducers} from "redux";
import {ActionType, getType} from "typesafe-actions";
import {authActions} from "./";
import {LS_KEY_TOKEN} from "../../api/api-base";
import Cookies from "universal-cookie";

const cookies = new Cookies();

export type AuthAction = ActionType<typeof authActions>;

export type AuthState = Readonly<{
    token: string;
    email: string;
    isLoggedIn: boolean;
}>;

export default combineReducers<AuthState, AuthAction>({
    token: (token: string = getToken(), action: any) => {
        switch (action.type) {
            case getType(authActions.updateToken):
                setToken(action.payload);
                return action.payload;

            case getType(authActions.logout):
                removeToken();
                return undefined;

            default:
                return token;
        }
    },
    isLoggedIn: (isLoggedIn: boolean = isTokenExists(), action: any) => {
        switch (action.type) {
            case getType(authActions.updateToken):
                return true;

            case getType(authActions.logout):
                return false;

            default:
                return isLoggedIn;
        }
    },
    email: (email: string = "guest", action: any) => {
        switch (action.type) {
            case getType(authActions.updateEmail):
                return action.payload;

            case getType(authActions.logout):
                return "guest";

            default:
                return email;
        }
    }
});

function isTokenExists(): boolean {
    return getToken() !== undefined;
}

function getToken(): string {
    return cookies.get(LS_KEY_TOKEN) || undefined;
}

function setToken(token: string): void {
    cookies.set(LS_KEY_TOKEN, token, {path: "/"});
}

function removeToken() {
    cookies.remove(LS_KEY_TOKEN);
}