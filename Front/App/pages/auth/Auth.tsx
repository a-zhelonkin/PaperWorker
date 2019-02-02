import React, {Component, ReactNode} from "react";
import {History} from "history";
import {connect} from "react-redux";
import Col from "react-bootstrap/lib/Col";
import Form from "react-bootstrap/lib/Form";
import Button from "react-bootstrap/lib/Button";
import FormGroup from "react-bootstrap/lib/FormGroup";
import FormControl from "react-bootstrap/lib/FormControl";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import {updateEmail, updateToken} from "./actions";
import AuthApi, {TokenData} from "../../api/auth-api";

export interface AuthProps {
    history: History;
    updateToken: (token: string) => void;
    updateEmail: (email: string) => void;
}

class Auth extends Component<AuthProps> {

    private inputEmail: HTMLInputElement;

    private inputPassword: HTMLInputElement;

    public render(): ReactNode {
        return (
            <Form horizontal className="container center input-form">
                <FormGroup>
                    <Col sm={4} componentClass={ControlLabel}>
                        Почтовый адрес
                    </Col>
                    <Col sm={8}>
                        <FormControl
                            type="email"
                            placeholder="Почтовый адрес"
                            inputRef={this.setInputEmail}
                        />
                    </Col>
                </FormGroup>

                <FormGroup>
                    <Col sm={4} componentClass={ControlLabel}>
                        Пароль
                    </Col>
                    <Col sm={8}>
                        <FormControl
                            type="password"
                            placeholder="Пароль"
                            inputRef={this.setInputPassword}
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

    private setInputEmail = (input: HTMLInputElement) => this.inputEmail = input;

    private setInputPassword = (input: HTMLInputElement) => this.inputPassword = input;

    private submit = (e: any): void => {
        e.preventDefault();

        const email: string = this.inputEmail.value;
        const password: string = this.inputPassword.value;

        AuthApi.auth(email, password)
            .then((data: TokenData): void => {
                if (data) {
                    this.props.updateToken(data.token);
                    this.props.updateEmail(email);
                    this.props.history.push("/cabinet");
                }
            });
    }

}

const mapDispatchToProps = {
    updateToken: updateToken,
    updateEmail: updateEmail
};

export default connect(undefined, mapDispatchToProps)(Auth);