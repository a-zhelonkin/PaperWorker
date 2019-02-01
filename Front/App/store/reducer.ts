import {combineReducers} from "redux";
import {StateType} from "typesafe-actions";
import {routerReducer} from "react-router-redux";
import {authReducer} from "../pages/auth";
import {cabinetReducer} from "../pages/cabinet";

const rootReducer = combineReducers({
    router: routerReducer,
    auth: authReducer,
    cabinet: cabinetReducer
});

export type RootState = StateType<typeof rootReducer>;

export default rootReducer;
