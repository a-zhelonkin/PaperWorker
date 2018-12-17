import {createStore} from "redux";
import rootReducer from "./reducer";

const store = createStore(rootReducer);

(window as any).store = store;

export default store;
