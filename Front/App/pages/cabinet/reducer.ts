import {combineReducers} from "redux";
import {ActionType, getType} from "typesafe-actions";
import {cabinetActions} from "./";
import {Profile} from "../../api/profiles-api";

export type CabinetAction = ActionType<typeof cabinetActions>;

export type CabinetState = Readonly<{
    profile: Profile;
}>;

export default combineReducers<CabinetState, CabinetAction>({
    profile: (profile: Profile = undefined, action: any) => {
        switch (action.type) {
            case getType(cabinetActions.loadProfile):
                return action.payload;

            default:
                return profile;
        }
    }
});