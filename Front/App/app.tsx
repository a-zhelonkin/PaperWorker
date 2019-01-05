import "./app.css";
import React, {FunctionComponent} from "react";
import {BrowserRouter, Route, Switch} from "react-router-dom";
import Home from "./pages/home/home";
import Error404 from "./pages/error404/error404";
import {Auth} from "./pages/auth";
import {Cabinet} from "./pages/cabinet";
import Invite from "./pages/invite/invite";

export const App: FunctionComponent = () =>
    <BrowserRouter>
        <main>
            <Switch>
                <Route component={Home} path="/" exact/>
                <Route component={Auth} path="/login"/>
                <Route component={Cabinet} path="/cabinet"/>
                <Route component={Invite} path="/invite"/>
                <Route component={Error404}/>
            </Switch>
        </main>
    </BrowserRouter>;