import {combineReducers} from "redux";
import {routerReducer} from "react-router-redux";
import {StateType} from "typesafe-actions";
import {authReducer} from "../pages/auth";

const rootReducer = combineReducers({
    router: routerReducer,
    auth: authReducer,
});

export type RootState = StateType<typeof rootReducer>;

export default rootReducer;
