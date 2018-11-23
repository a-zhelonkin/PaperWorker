import React from "react";
import {Route} from "react-router";
import App from "./app";
import Home from "./pages/home/home";
import Login from "./pages/login/login";

export default (
    <Route component={App} path="/">
        <Route component={Home}/>
        <Route component={Login} path="login"/>
    </Route>
);