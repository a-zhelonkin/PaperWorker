import {combineReducers} from "redux";
import {ActionType, getType} from "typesafe-actions";
import {authActions} from "./";

export type AuthAction = ActionType<typeof authActions>;

export type AuthState = Readonly<{
    token: string;
}>;

export default combineReducers<AuthState, AuthAction>({
    token: (token: string = null, action: any) => {
        switch (action.type) {
            case getType(authActions.login):
                return action.payload;

            case getType(authActions.logout):
                return null;

            default:
                return token;
        }
    }
});
