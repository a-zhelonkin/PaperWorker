import "./auth.scss";
import React, {Component, ReactNode} from "react";
import Tabs from "react-bootstrap/lib/Tabs";
import Tab from "react-bootstrap/lib/Tab";
import AuthViaPassword from "./AuthViaPassword";
import AuthViaLink from "./AuthViaLink";
import {LogoHeader} from "../../components";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";

export default class Auth extends Component {

    public render(): ReactNode {
        return (
            <div className="auth container">
                <LogoHeader className="logo-header" header="Вход в сервис"/>

                <Tabs id="auth-tabs" className="input-form">
                    <Tab eventKey="password" title={<FontAwesomeIcon icon="key" title="По паролю"/>}>
                        <AuthViaPassword/>
                    </Tab>
                    <Tab eventKey="link" title={<FontAwesomeIcon icon="link" title="По ссылке"/>}>
                        <AuthViaLink/>
                    </Tab>
                </Tabs>
            </div>
        );
    }

}