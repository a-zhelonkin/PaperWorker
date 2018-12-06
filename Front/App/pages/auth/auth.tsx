import "./auth.css"
import React, {Component, ReactNode} from "react";
import {History} from "history";
import {connect} from "react-redux";
import Col from "react-bootstrap/lib/Col";
import Form from "react-bootstrap/lib/Form";
import Button from "react-bootstrap/lib/Button";
import FormGroup from "react-bootstrap/lib/FormGroup";
import FormControl from "react-bootstrap/lib/FormControl";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import Navigation from "../../components/navigation/navigation";
import LoginApi, {TokenData} from "./auth.api";
import {login} from './actions';

export interface AuthProps {
    history: History;
    login: (token: string) => void;
}

class Auth extends Component<AuthProps> {

    private inputEmail: HTMLInputElement;

    private inputPassword: HTMLInputElement;

    public render(): ReactNode {
        return (
            <>
                <Navigation/>
                <Form horizontal className="container center login-form">
                    <FormGroup controlId="formHorizontalEmail">
                        <Col sm={4} componentClass={ControlLabel}>
                            Почтовый адрес
                        </Col>
                        <Col sm={8}>
                            <FormControl
                                type="email"
                                placeholder="Почтовый адрес"
                                inputRef={input => this.inputEmail = input}
                            />
                        </Col>
                    </FormGroup>

                    <FormGroup controlId="formHorizontalPassword">
                        <Col sm={4} componentClass={ControlLabel}>
                            Пароль
                        </Col>
                        <Col sm={8}>
                            <FormControl
                                type="password"
                                placeholder="Пароль"
                                inputRef={input => this.inputPassword = input}
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
            </>
        );
    }

    submit = (e: any) => {
        e.preventDefault();

        LoginApi.auth(this.inputEmail.value, this.inputPassword.value)
            .then((data: TokenData) => {
                if (data) {
                    this.props.login(data.token);
                    this.props.history.push("/");
                }
            });
    };

}

export default connect(null, {
    login: login
})(Auth);