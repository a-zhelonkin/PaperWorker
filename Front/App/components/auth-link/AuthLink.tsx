import React, {Component, ReactNode} from "react";
import queryString from "querystring";
import Loading from "../loading/Loading";
import AuthApi, {EmailData} from "../../api/auth-api";
import history from "../../store/history";
import {updateEmail, updateToken} from "../../pages/auth/actions";
import {connect} from "react-redux";

export interface AuthLinkProps {
    location: Location;
    updateToken: (token: string) => void;
    updateEmail: (email: string) => void;
}

class AuthLink extends Component<AuthLinkProps> {

    public componentDidMount() {
        const params: any = queryString.parse(this.props.location.search.slice(1));
        const token: string = params.token;

        AuthApi.email(token)
            .then((data: EmailData): void => {
                if (data) {
                    this.props.updateToken(token);
                    this.props.updateEmail(data.email);
                    history.push("/cabinet");
                }
            });
    }

    public render(): ReactNode {
        return <Loading/>;
    }

}

const mapDispatchToProps = {
    updateToken: updateToken,
    updateEmail: updateEmail
};

export default connect(undefined, mapDispatchToProps)(AuthLink);