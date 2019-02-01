import React, {Component, ReactNode} from "react";
import {connect} from "react-redux";
import queryString from "querystring";
import {History} from "history";
import Jumbotron from "react-bootstrap/lib/Jumbotron";
import Label from "react-bootstrap/lib/Label";
import InvitesApi, {InviteStatus} from "../../api/invites-api";
import {Link} from "react-router-dom";
import {UserStatus} from "../../constants/user-status";

export interface InviteProps {
    history: History;
    location: Location;
}

export interface InviteState {
    status: string;
}

class Invite extends Component<InviteProps, InviteState> {

    componentDidMount() {
        const params: any = queryString.parse(this.props.location.search.slice(1));
        const token: string = params.token;

        InvitesApi.getStatus(token)
            .then((status: InviteStatus) => {
                if (status.status === UserStatus.Pending) {
                    this.props.history.push("/change-password");
                    return;
                }

                this.setState({status: status.status});
            });
    }

    render(): ReactNode {
        return (
            <Jumbotron>
                {this.state.status === UserStatus.Expired && (
                    <Label bsStyle="danger">
                        Срок приглашения истек. Вы можете оставить заявку на регистрацию Вашего почтового адреса, на
                        который было отправлено это приглашение.
                    </Label>
                )}
                {this.state.status === UserStatus.Confirmed && (
                    <Label bsStyle="info">
                        Пришлашение уже было использовано. <Link to="/login">Авторизуйтесь</Link> или
                        <Link to="/restore-password">восстановите пароль</Link>
                    </Label>
                )}
            </Jumbotron>
        );
    }

}

export default connect(null, null)(Invite);