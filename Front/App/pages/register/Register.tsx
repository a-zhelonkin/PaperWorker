import "./register.scss";
import React, {Component, ReactNode} from "react";
import {LogoHeader} from "../../components";
import Form from "react-bootstrap/lib/Form";
import FormGroup from "react-bootstrap/lib/FormGroup";
import FormControl from "react-bootstrap/lib/FormControl";
import Col from "react-bootstrap/lib/Col";
import Button from "react-bootstrap/lib/Button";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import AuthApi from "../../api/auth-api";

export default class Register extends Component {

    private inputEmail: HTMLInputElement;

    public render(): ReactNode {
        return (
            <div className="register container">
                <LogoHeader className="logo-header" header="Подача заявки на регистрацию"/>

                <Form className="input-form" horizontal>
                    <FormGroup>
                        <ControlLabel>Электронная почта</ControlLabel>
                        <FormControl
                            type="email"
                            inputRef={this.setInputEmail}
                        />
                    </FormGroup>

                    <FormGroup>
                        <Col smOffset={2} sm={8}>
                            <Button block className="btn-primary" onClick={this.submit}>
                                Отправить заявку
                            </Button>
                        </Col>
                    </FormGroup>
                </Form>
            </div>
        );
    }

    private setInputEmail = (input: HTMLInputElement) => this.inputEmail = input;

    private submit = (e: any): void => {
        e.preventDefault();

        const email: string = this.inputEmail.value;

        AuthApi.register(email)
            .then((isSuccessful: boolean): void => {
                if (isSuccessful) {
                    // todo реакция на успешность оставки заявки
                }
            });
    }

}