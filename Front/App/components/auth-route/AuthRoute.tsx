import React, {Component, ReactNode} from "react";
import queryString from "querystring";
import {Loading} from "../";
import AuthApi, {AuthData} from "../../api/auth-api";
import {updateEmail, updateRoles, updateToken} from "../../pages/auth/actions";
import {connect} from "react-redux";
import {Redirect, Route, RouteProps} from "react-router";
import {RootState} from "../../store";
import {RoleName} from "../../constants/role-name";
import {LoadStatus} from "../../constants/load-status";

export interface AuthRouteProps extends RouteProps {
    autoLogin: boolean;
    isLoggedIn?: boolean;
    updateToken?: (token: string) => void;
    updateEmail?: (email: string) => void;
    updateRoles?: (roles: RoleName[]) => void;
}

export interface AuthRouteState {
    tokenCheckingState: LoadStatus;
}

class AuthRoute extends Component<AuthRouteProps, AuthRouteState> {

    public static defaultProps: AuthRouteProps = {
        autoLogin: false
    };

    public state = {
        tokenCheckingState: LoadStatus.Pending
    };

    public componentDidMount(): void {
        if (this.props.autoLogin) {
            if (this.props.isLoggedIn) {
                this.setState({tokenCheckingState: LoadStatus.Success});
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
                        this.setState({tokenCheckingState: LoadStatus.Success});
                    } else {
                        this.setState({tokenCheckingState: LoadStatus.Error});
                    }
                });
        }
    }

    public render(): ReactNode {
        if (this.props.autoLogin) {
            switch (this.state.tokenCheckingState) {
                case LoadStatus.Success:
                    return this.route();
                case LoadStatus.Error:
                    return AuthRoute.redirect();
                case LoadStatus.Pending:
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