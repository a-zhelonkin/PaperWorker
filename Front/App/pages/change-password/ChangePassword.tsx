import React, {Component, ReactNode} from "react";
import {connect} from "react-redux";
import {updateEmail, updateToken} from "../auth/actions";
import Form from "react-bootstrap/lib/Form";
import FormGroup from "react-bootstrap/lib/FormGroup";
import Col from "react-bootstrap/lib/Col";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import FormControl from "react-bootstrap/lib/FormControl";
import Button from "react-bootstrap/lib/Button";
import UsersApi from "../../api/users-api";
import queryString from "querystring";
import EmailData from "../../api/models/email-data";
import history from "../../store/history";

export interface ChangePasswordProps {
    location: Location;
    updateToken: (token: string) => void;
    updateEmail: (email: string) => void;
}

export interface ChangePasswordState {
    password: string;
    confirmPassword: string;
    passwordsIdentical: boolean;
}

class ChangePassword extends Component<ChangePasswordProps, ChangePasswordState> {

    private token?: string;

    public componentDidMount() {
        const params: any = queryString.parse(this.props.location.search.slice(1));

        this.token = params.token;
    }

    public render(): ReactNode {
        return (
            <Form horizontal className="container center input-form">
                <FormGroup>
                    <Col sm={4} componentClass={ControlLabel}>
                        Новый пароль
                    </Col>
                    <Col sm={8}>
                        <FormControl
                            type="password"
                            placeholder="Новый пароль"
                            onChange={this.onPasswordChange}
                        />
                    </Col>
                </FormGroup>

                <FormGroup>
                    <Col sm={4} componentClass={ControlLabel}>
                        Подтверждение пароля
                    </Col>
                    <Col sm={8}>
                        <FormControl
                            type="password"
                            placeholder="Подтверждение пароля"
                            onChange={this.onConfirmPasswordChange}
                        />
                    </Col>
                </FormGroup>

                <FormGroup>
                    <Col smOffset={4} sm={8}>
                        <Button type="submit" onClick={this.submit}>
                            Войти
                        </Button>
                    </Col>
                </FormGroup>
            </Form>
        );
    }

    private onPasswordChange = (e: any) => {
        const password: string = e.target.value;
        const confirmPassword: string = this.state.confirmPassword;

        this.setState({password});

        if (confirmPassword) {
            this.checkPasswordsIdentical(password, confirmPassword);
        }
    }

    private onConfirmPasswordChange = (e: any) => {
        const password: string = this.state.password;
        const confirmPassword: string = e.target.value;

        this.setState({confirmPassword});

        if (password) {
            this.checkPasswordsIdentical(password, confirmPassword);
        }
    }

    private checkPasswordsIdentical = (password: string, confirmPassword: string) =>
        this.setState({passwordsIdentical: password === confirmPassword})

    private submit = (e: any): void => {
        e.preventDefault();

        if (this.state.passwordsIdentical) {
            UsersApi.changePassword(this.state.password)
                .then((data: EmailData) => {
                    if (data) {
                        this.props.updateToken(this.token);
                        this.props.updateEmail(data.email);
                        history.push("/cabinet");
                    } else {
                        // todo реакция на ошибку
                    }
                });
        }
    }

}

const mapDispatchToProps = {
    updateToken: updateToken,
    updateEmail: updateEmail
};

export default connect(undefined, mapDispatchToProps)(ChangePassword);
