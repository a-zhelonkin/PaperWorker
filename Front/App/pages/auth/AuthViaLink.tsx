import React, {Component, ReactNode} from "react";
import {connect} from "react-redux";
import Col from "react-bootstrap/lib/Col";
import Form from "react-bootstrap/lib/Form";
import Button from "react-bootstrap/lib/Button";
import FormGroup from "react-bootstrap/lib/FormGroup";
import FormControl from "react-bootstrap/lib/FormControl";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import AuthApi from "../../api/auth-api";
import {Link} from "react-router-dom";

class AuthViaLink extends Component {

    private inputEmail: HTMLInputElement;

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
                    <Col smOffset={2} sm={8}>
                        <Button block className="btn-primary" onClick={this.submit}>
                            Получить ссылку для входа
                        </Button>
                    </Col>
                </FormGroup>

                <FormGroup>
                    <Link className="pull-right" to="/register">
                        Оставить заявку на регистрацию
                    </Link>
                </FormGroup>
            </Form>
        );
    }

    private setInputEmail = (input: HTMLInputElement) => this.inputEmail = input;

    private submit = (e: any): void => {
        e.preventDefault();

        const email: string = this.inputEmail.value;

        AuthApi.sendAuthLink(email)
            .then((isSuccessful: boolean): void => {
                if (isSuccessful) {
                    // todo реакция на успешность отправки ссылки
                }
            });
    }

}

export default connect(undefined, undefined)(AuthViaLink);