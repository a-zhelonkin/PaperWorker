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

export interface ChangePasswordProps {
    updateToken: (token: string) => void;
}

export interface ChangePasswordState {
    password: string;
    confirmPassword: string;
    passwordsIdentical: boolean;
}

class ChangePassword extends Component<ChangePasswordProps, ChangePasswordState> {

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
        this.setState({password: e.target.value});

        if (this.state.confirmPassword) {
            this.checkPasswordsIdentical();
        }
    }

    private onConfirmPasswordChange = (e: any) => {
        this.setState({confirmPassword: e.target.value});
        this.checkPasswordsIdentical();
    }

    private checkPasswordsIdentical = () => {
        this.setState({passwordsIdentical: true});
    }

    private submit = (e: any): void => {
        e.preventDefault();

        if (this.state.confirmPassword) {
            UsersApi.changePassword(this.state.password)
                .then(console.log);
        }
    }

}

export default connect(undefined, {
    updateToken: updateToken,
    updateEmail: updateEmail
})(ChangePassword);