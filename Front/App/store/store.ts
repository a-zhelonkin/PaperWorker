import {createStore} from "redux";
import rootReducer from "./reducer";

const _window: any = window;

const email: string = _window._INITIAL_STATE_.email;
const store = createStore(rootReducer, {
    auth: {
        email: email
    }
});

_window.store = store;

export default store;
