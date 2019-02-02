import "./app.css";
import React, {FunctionComponent} from "react";
import {BrowserRouter, Route, Switch} from "react-router-dom";
import Home from "./pages/home/home";
import Error404 from "./pages/error404/error404";
import {Auth} from "./pages/auth";
import {Cabinet} from "./pages/cabinet";
import {Invite} from "./pages/invite";
import AuthRoute from "./components/auth-route/AuthRoute";
import {ChangePassword} from "./pages/change-password";
import NavigationBar from "./components/navigation-bar/NavigationBar";
import {RestorePassword} from "./pages/restore-password";

export const App: FunctionComponent = () => (
    <BrowserRouter>
        <>
            <header>
                <NavigationBar/>
            </header>
            <main>
                <Switch>
                    <AuthRoute component={Home} exact path="/"/>
                    <Route component={Auth} path="/login"/>
                    <AuthRoute component={Cabinet} path="/cabinet"/>
                    <AuthRoute component={Invite} path="/invite"/>
                    <AuthRoute component={ChangePassword} path="/change-password"/>
                    <AuthRoute component={RestorePassword} path="/restore-password"/>
                    <AuthRoute component={Error404}/>
                </Switch>
            </main>
        </>
    </BrowserRouter>
);