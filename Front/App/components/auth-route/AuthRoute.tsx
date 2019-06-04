import React, {Component, ReactNode} from "react";
import queryString from "querystring";
import {Loading} from "../";
import AuthApi from "../../api/auth-api";
import {updateEmail, updateRoles, updateToken} from "../../pages/auth/actions";
import {connect} from "react-redux";
import {Redirect, Route, RouteProps} from "react-router";
import {RootState} from "../../store";
import AuthData from "../../api/models/auth-data";
import {RoleName} from "../../constants/role-name";

export interface AuthRouteProps extends RouteProps {
    autoLogin: boolean;
    isLoggedIn?: boolean;
    updateToken?: (token: string) => void;
    updateEmail?: (email: string) => void;
    updateRoles?: (roles: RoleName[]) => void;
}

export interface AuthRouteState {
    tokenCheckingState: "pending" | "success" | "error";
}

class AuthRoute extends Component<AuthRouteProps, AuthRouteState> {

    public static defaultProps: AuthRouteProps = {
        autoLogin: false
    };

    public constructor(props: AuthRouteProps) {
        super(props);
        this.state = {
            tokenCheckingState: "pending"
        };
    }

    public componentWillMount() {
        if (this.props.autoLogin) {
            if (this.props.isLoggedIn) {
                this.setState({tokenCheckingState: "success"});
                return;
            }

            const params: any = queryString.parse(this.props.location.search.slice(1));
            const token: string = params.token;

            AuthApi.email(token)
                .then((data: AuthData): void => {
                    if (data) {
                        this.props.updateToken(token);
                        this.props.updateEmail(data.email);
                        this.props.updateRoles(data.roles);
                        this.setState({tokenCheckingState: "success"});
                    } else {
                        this.setState({tokenCheckingState: "error"});
                    }
                });
        }
    }

    public render(): ReactNode {
        if (this.props.autoLogin) {
            switch (this.state.tokenCheckingState) {
                case "success":
                    return this.route();
                case "error":
                    return AuthRoute.redirect();
                case "pending":
                default:
                    return <Loading/>;
            }
        } else {
            return this.props.isLoggedIn
                ? this.route()
                : AuthRoute.redirect();
        }
    }

    private route(): ReactNode {
        return <Route {...this.props} />;
    }

    private static redirect(): ReactNode {
        return <Redirect to={{pathname: "/login"}}/>;
    }

}

const mapStateToProps = (state: RootState) => ({
    isLoggedIn: state.auth.isLoggedIn
});

const mapDispatchToProps = {
    updateToken: updateToken,
    updateEmail: updateEmail,
    updateRoles: updateRoles
};

export default connect(mapStateToProps, mapDispatchToProps)(AuthRoute);