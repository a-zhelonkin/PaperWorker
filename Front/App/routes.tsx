import React from "react";
import {Route, Switch} from "react-router";
import App from "./app";
import Home from "./pages/home/home";
import Login from "./pages/login/login";
import Error404 from "./pages/error404/error404";

export default (
    <main>
        <Switch>
            <Route component={App} path="/" exact/>
            <Route component={Home} path="/home"/>
            <Route component={Login} path="/login"/>
            <Route component={Error404}/>
        </Switch>
    </main>
);