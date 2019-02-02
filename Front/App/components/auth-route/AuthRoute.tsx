import React, {FunctionComponent} from "react";
import {connect} from "react-redux";
import {Redirect, Route, RouteProps} from "react-router";
import {RootState} from "../../store";

export interface AuthRouteProps extends RouteProps {
    isLoggedIn: boolean;
}

const AuthRoute: FunctionComponent<AuthRouteProps> = (props: AuthRouteProps) =>
    props.isLoggedIn
        ? <Route {...props} />
        : <Redirect to={{pathname: "/login", state: {from: props.location}}}/>;

const mapStateToProps = (state: RootState) => ({
    isLoggedIn: state.auth.isLoggedIn
});

export default connect(mapStateToProps, undefined)(AuthRoute);