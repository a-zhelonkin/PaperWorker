import React, {Component, ReactNode} from "react";
import Form from "react-bootstrap/lib/Form";
import FormGroup from "react-bootstrap/lib/FormGroup";
import Col from "react-bootstrap/lib/Col";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import FormControl from "react-bootstrap/lib/FormControl";
import Button from "react-bootstrap/lib/Button";
import Label from "react-bootstrap/lib/Label";
import Jumbotron from "react-bootstrap/lib/Jumbotron";
import {validateEmail} from "../../utils/strings-utils";
import AuthApi from "../../api/auth-api";

export interface RestorePasswordState {
    email: string;
    valid: boolean;
    success: boolean;
}

export default class RestorePassword extends Component<any, RestorePasswordState> {

    public constructor(props: any, context?: any) {
        super(props, context);
        this.state = {
            email: "",
            valid: false,
            success: false
        };
    }

    public render(): ReactNode {
        return (
            <Jumbotron className="center input-form text-center">
                {this.state.success ? (
                    <Label className="text-primary">
                        Ссылка для восстановления пароля выслана на Ваш электронный адрес
                    </Label>
                ) : (
                    <Form horizontal className="container">
                        <FormGroup controlId="email" validationState={this.getEmailValidationState()}>
                            <Col smOffset={3} sm={6}>
                                <ControlLabel>Введите Ваш почтовый адрес</ControlLabel>
                                <FormControl
                                    type="email"
                                    value={this.state.email}
                                    placeholder="Почтовый адрес"
                                    onChange={this.onEmailChange}
                                />
                                <FormControl.Feedback/>
                            </Col>
                        </FormGroup>

                        <FormGroup>
                            <Button className="btn-primary" type="submit" onClick={this.submit}>
                                Восстановить пароль
                            </Button>
                        </FormGroup>
                    </Form>
                )}
            </Jumbotron>
        );
    }

    private onEmailChange = (e: any) => {
        const email: string = e.target.value;

        return this.setState({
            email,
            valid: validateEmail(email)
        });
    }

    private getEmailValidationState = (): "success" | "error" | null => {
        return this.state.email
            ? this.state.valid
                ? "success"
                : "error"
            : undefined;
    }

    private submit = (e: any): void => {
        e.preventDefault();

        if (this.state.valid) {
            AuthApi.restorePassword(this.state.email)
                .then((success: boolean) => {
                    if (success) {
                        this.setState({success: true});
                    }
                });
        }
    }

}