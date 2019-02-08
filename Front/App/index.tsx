import "bootstrap/dist/css/bootstrap.min.css";
import React from "react";
import store from "./store";
import {render} from "react-dom";
import {library} from "@fortawesome/fontawesome-svg-core";
import {faKey, faLink} from "@fortawesome/free-solid-svg-icons";
import {Provider} from "react-redux";
import {App} from "./App";

library.add(faKey);
library.add(faLink);

render((
    <Provider store={store}>
        <App/>
    </Provider>
), document.getElementById("app"));