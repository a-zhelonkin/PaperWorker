import "react-bootstrap-table/css/react-bootstrap-table.css";
import React, {Component, ReactNode} from "react";
import {connect} from "react-redux";
import {RootState} from "../../store";
import FormGroup from "react-bootstrap/lib/FormGroup";
import FormControl from "react-bootstrap/lib/FormControl";
import Col from "react-bootstrap/lib/Col";
import Button from "react-bootstrap/lib/Button";
import Form from "react-bootstrap/lib/Form";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import Select from "react-select";
import {roleNameDetails} from "../../constants/role-name";
import InvitesApi from "../../api/invites-api";

interface SelectOption {
    readonly value: string;
    readonly label: string;
}

export interface CabinetAdminInviteProps {
}

export interface CabinetAdminInviteState {
    options: SelectOption[];
}

const rolesOptions: SelectOption[] = Object.keys(roleNameDetails).map(role => ({
    value: role,
    label: roleNameDetails[role].name
}));

class CabinetAdminInvite extends Component<CabinetAdminInviteProps, CabinetAdminInviteState> {

    private inputEmail: HTMLInputElement;

    public constructor(props: CabinetAdminInviteProps) {
        super(props);
        this.state = {
            options: []
        };
    }

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
                    <ControlLabel>Роли</ControlLabel>

                    <Select
                        isMulti
                        name="roles"
                        options={rolesOptions}
                        onChange={this.onSelectRoles}
                        defaultValue={this.state.options}
                    />
                </FormGroup>

                <FormGroup>
                    <Col smOffset={2} sm={8}>
                        <Button block className="btn-primary" onClick={this.invite}>
                            Пригласить
                        </Button>
                    </Col>
                </FormGroup>
            </Form>
        );
    }

    private setInputEmail = (input: HTMLInputElement) => this.inputEmail = input;

    private onSelectRoles = (options: SelectOption[] | any) => this.setState({options});

    private invite = (e: any): void => {
        e.preventDefault();

        const email: string = this.inputEmail.value;
        const roles: string[] = this.state.options.map(option => option.value);

        InvitesApi.invite(email, roles)
            .then(isSuccess => {
                // todo Реализовать реакцию на успех приглашения
            });
    }

}

const mapStateToProps = (state: RootState) => ({});

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(CabinetAdminInvite);