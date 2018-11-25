import "./bootstrap.minty.css";
import React from "react";
import {render} from "react-dom";
import {BrowserRouter} from "react-router-dom";
import routes from "./routes";

const element =
    <BrowserRouter>
        {routes}
    </BrowserRouter>;

render(element, document.getElementById("app"));