import {createStore} from "redux";
import rootReducer from "./reducer";

const email: string = (window as any)._INITIAL_STATE_.email;
const store = createStore(rootReducer, {
    auth: {
        email: email
    }
});

export default store;
