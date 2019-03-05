import React, {Component, ReactNode} from "react";
import queryString from "querystring";
import Loading from "../loading/Loading";
import AuthApi from "../../api/auth-api";
import {updateEmail, updateToken} from "../../pages/auth/actions";
import {connect} from "react-redux";
import EmailData from "../../api/models/email-data";
import {Redirect, Route, RouteProps} from "react-router";
import {RootState} from "../../store";

export interface AuthRouteProps extends RouteProps {
    isLoggedIn?: boolean;
    updateToken?: (token: string) => void;
    updateEmail?: (email: string) => void;
}

export interface AuthRouteState {
    tokenCheckingState: "pending" | "success" | "error";
}

class AuthRoute extends Component<AuthRouteProps, AuthRouteState> {

    constructor(props: AuthRouteProps, context?: any) {
        super(props, context);
        this.state = {
            tokenCheckingState: "pending"
        };
    }

    public componentWillMount() {
        if (this.props.isLoggedIn) {
            this.setState({tokenCheckingState: "success"});
            return;
        }

        const params: any = queryString.parse(this.props.location.search.slice(1));
        const token: string = params.token;

        AuthApi.email(token)
            .then((data: EmailData): void => {
                if (data) {
                    this.props.updateToken(token);
                    this.props.updateEmail(data.email);
                    this.setState({tokenCheckingState: "success"});
                } else {
                    this.setState({tokenCheckingState: "error"});
                }
            });
    }

    public render(): ReactNode {
        switch (this.state.tokenCheckingState) {
            case "error":
                return <Redirect to={{pathname: "/login"}}/>;
            case "success":
                return <Route {...this.props} />;
            case "pending":
            default:
                return <Loading/>;
        }
    }

}

const mapStateToProps = (state: RootState) => ({
    isLoggedIn: state.auth.isLoggedIn
});

const mapDispatchToProps = {
    updateToken: updateToken,
    updateEmail: updateEmail
};

export default connect(mapStateToProps, mapDispatchToProps)(AuthRoute);