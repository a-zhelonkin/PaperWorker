import React from "react";
import {render} from "react-dom";
import {Home} from "./pages/home/home";

const app = () => (
    <Home/>
);

render(<app/>, document.getElementById("app"));