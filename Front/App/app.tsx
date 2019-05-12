import "./app.scss";
import React, {FunctionComponent} from "react";
import {Router, Route, Switch} from "react-router-dom";
import history from "./store/history";
import NavigationBar from "./components/navigation-bar/NavigationBar";
import Home from "./pages/home/home";
import Error404 from "./pages/error404/error404";
import {Auth} from "./pages/auth";
import {Cabinet} from "./pages/cabinet";
import {Invite} from "./pages/invite";
import AuthRoute from "./components/auth-route/AuthRoute";
import {ChangePassword} from "./pages/change-password";
import {RestorePassword} from "./pages/restore-password";

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