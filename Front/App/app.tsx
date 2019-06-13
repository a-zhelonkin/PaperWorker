import "./app.scss";
import React, {FunctionComponent} from "react";
import {Route, Router, Switch} from "react-router-dom";
import history from "./store/history";
import {AuthRoute, NavigationBar} from "./components";
import {Auth, Cabinet, ChangePassword, Error404, Home, Invite, Register, RestorePassword} from "./pages";

export const App: FunctionComponent = () => (
    <Router history={history}>
        <>
            <header>
                <NavigationBar/>
            </header>
            <main>
                <Switch>
                    <AuthRoute component={Home} exact path="/"/>
                    <Route component={Auth} path="/login"/>
                    <Route component={Register} path="/register"/>
                    <Route component={RestorePassword} path="/restore-password"/>
                    <Route component={ChangePassword} path="/change-password"/>
                    <AuthRoute component={Cabinet} path="/cabinet" autoLogin/>
                    <AuthRoute component={Invite} path="/invite"/>
                    <AuthRoute component={Error404}/>
                </Switch>
            </main>
        </>
    </Router>
);