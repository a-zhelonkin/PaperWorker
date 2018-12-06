import "./app.css";
import React, {FunctionComponent} from "react";
import {BrowserRouter, Route, Switch} from "react-router-dom";
import Home from "./pages/home/home";
import {Auth} from "./pages/auth";
import Error404 from "./pages/error404/error404";

export const App: FunctionComponent = () => {
    return (
        <BrowserRouter>
            <main>
                <Switch>
                    <Route component={Home} path="/" exact/>
                    <Route component={Auth} path="/login"/>
                    <Route component={Error404}/>
                </Switch>
            </main>
        </BrowserRouter>
    );
};