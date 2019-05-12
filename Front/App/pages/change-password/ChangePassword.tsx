import React, {Component, ReactNode} from "react";
import {connect} from "react-redux";
import {updateEmail, updateRoles, updateToken} from "../auth/actions";
import Form from "react-bootstrap/lib/Form";
import FormGroup from "react-bootstrap/lib/FormGroup";
import Col from "react-bootstrap/lib/Col";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import FormControl from "react-bootstrap/lib/FormControl";
import Button from "react-bootstrap/lib/Button";
import UsersApi from "../../api/users-api";
import queryString from "querystring";
import history from "../../store/history";
import {RoleName} from "../../constants/role-name";
import AuthData from "../../api/models/auth-data";

export interface ChangePasswordProps {
    location: Location;
    updateToken: (token: string) => void;
    updateEmail: (email: string) => void;
    updateRoles: (roles: RoleName[]) => void;
}

export interface ChangePasswordState {
    password: string;
    confirmPassword: string;
    passwordsIdentical: boolean;
}

class ChangePassword extends Component<ChangePasswordProps, ChangePasswordState> {

    private token?: string;

    public constructor(props: ChangePasswordProps) {
        super(props);
        this.state = {
            password: "",
            confirmPassword: "",
            passwordsIdentical: true
        };
    }

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
            UsersApi.changePassword(this.state.password, this.token)
                .then((data: AuthData) => {
                    if (data) {
                        this.props.updateToken(this.token);
                        this.props.updateEmail(data.email);
                        this.props.updateRoles(data.roles);
                        history.push("/cabinet");
                    } else {
                        alert("Не удалось сменить пароль");
                    }
                });
        }
    }

}

const mapDispatchToProps = {
    updateToken: updateToken,
    updateEmail: updateEmail,
    updateRoles: updateRoles
};

export default connect(undefined, mapDispatchToProps)(ChangePassword);
