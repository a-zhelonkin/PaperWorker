import {createStore} from "redux";
import rootReducer from "./reducer";

const state: any = (window as any)._INITIAL_STATE_;
const store = createStore(rootReducer, {
    auth: {
        email: state.email,
        roles: state.roles
    }
});

export default store;
