import {combineReducers} from "redux";
import {ActionType, getType} from "typesafe-actions";
import {authActions} from "./";

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
                return null;

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
    return !!getToken();
}

function getToken(): string {
    return localStorage.getItem("auth.token") || null;
}

function setToken(token: string): void {
    localStorage.setItem("auth.token", token);
}

function removeToken() {
    localStorage.removeItem("auth.token")
}