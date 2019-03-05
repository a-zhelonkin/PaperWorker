import React, {Component, ReactNode} from "react";
import history from "../../store/history";
import {connect} from "react-redux";
import Col from "react-bootstrap/lib/Col";
import Form from "react-bootstrap/lib/Form";
import Button from "react-bootstrap/lib/Button";
import FormGroup from "react-bootstrap/lib/FormGroup";
import FormControl from "react-bootstrap/lib/FormControl";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import {updateEmail, updateToken} from "./actions";
import AuthApi from "../../api/auth-api";
import {Link} from "react-router-dom";
import TokenData from "../../api/models/token-data";

export interface AuthViaPasswordProps {
    updateToken: (token: string) => void;
    updateEmail: (email: string) => void;
}

class AuthViaPassword extends Component<AuthViaPasswordProps> {

    private inputEmail: HTMLInputElement;

    private inputPassword: HTMLInputElement;

    public render(): ReactNode {
        return (
            <Form horizontal>
                <FormGroup>
                    <ControlLabel>Электронная почта</ControlLabel>
                    <FormControl
                        type="email"
                        inputRef={this.setInputEmail}
                    />
                </FormGroup>

                <FormGroup>
                    <ControlLabel>Пароль</ControlLabel>

                    <Link className="pull-right" to="/restore-password">
                        Забыли пароль?
                    </Link>

                    <FormControl
                        type="password"
                        inputRef={this.setInputPassword}
                    />
                </FormGroup>

                <FormGroup>
                    <Col smOffset={2} sm={8}>
                        <Button block className="btn-primary" onClick={this.submit}>
                            Войти
                        </Button>
                    </Col>
                </FormGroup>

                <FormGroup>
                    <Button className="btn-link pull-right" onClick={this.submit}>
                        Зарегистрироваться
                    </Button>
                </FormGroup>
            </Form>
        );
    }

    private setInputEmail = (input: HTMLInputElement) => this.inputEmail = input;

    private setInputPassword = (input: HTMLInputElement) => this.inputPassword = input;

    private submit = (e: any): void => {
        e.preventDefault();

        const email: string = this.inputEmail.value;
        const password: string = this.inputPassword.value;

        AuthApi.token(email, password)
            .then((data: TokenData): void => {
                if (data) {
                    this.props.updateToken(data.token);
                    this.props.updateEmail(email);
                    history.push("/cabinet");
                }
            });
    }

}

const mapDispatchToProps = {
    updateToken: updateToken,
    updateEmail: updateEmail
};

export default connect(undefined, mapDispatchToProps)(AuthViaPassword);
// todo проверить восстановление пароля