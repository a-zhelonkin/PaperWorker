import {applyMiddleware, compose, createStore} from "redux";
import {createEpicMiddleware} from "redux-observable";
import rootReducer from "./root-reducer";
import rootEpic from "./root-epic";

function configureStore(initialState?: {}) {
    const epicMiddleware = createEpicMiddleware();
    // configure middlewares
    epicMiddleware.run(rootEpic);
    // compose enhancers
    const enhancer = compose(applyMiddleware(epicMiddleware));
    // create store
    return createStore(rootReducer, initialState!, enhancer);
}

// pass an optional param to rehydrate state on app start
const store = configureStore();

(window as any).store = store;

// export store singleton instance
export default store;
