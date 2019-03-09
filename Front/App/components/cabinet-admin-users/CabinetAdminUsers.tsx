import React, {Component, ReactNode} from "react";
import {connect} from "react-redux";
import {RootState} from "../../store";
import {BootstrapTable, TableHeaderColumn} from "react-bootstrap-table";
import UserModel from "../../api/models/user-model";
import UsersApi from "../../api/users-api";

export interface CabinetAdminUsersProps {
}

export interface CabinetAdminUsersState {
    users: UserModel[];
}

class CabinetAdminUsers extends Component<CabinetAdminUsersProps, CabinetAdminUsersState> {

    constructor(props: CabinetAdminUsersProps, context: any) {
        super(props, context);
        this.state = {
            users: []
        };
    }

    public componentDidMount(): void {
        UsersApi.get(0, 10)
            .then(users => {
                this.setState({users});
            });
    }

    public render(): ReactNode {
        return (
            <div>
                <BootstrapTable data={this.state.users}>
                    <TableHeaderColumn dataField="id" isKey>Id</TableHeaderColumn>
                    <TableHeaderColumn dataField="email">Email</TableHeaderColumn>
                    <TableHeaderColumn dataField="status">Status</TableHeaderColumn>
                    <TableHeaderColumn dataField="firstName">Имя</TableHeaderColumn>
                    <TableHeaderColumn dataField="lastName">Фамилия</TableHeaderColumn>
                    <TableHeaderColumn dataField="patronymic">Отчество</TableHeaderColumn>
                    <TableHeaderColumn dataField="birthDateTime">Дата рождения</TableHeaderColumn>
                    <TableHeaderColumn dataField="employmentDateTime">Дата трудоустройства</TableHeaderColumn>
                </BootstrapTable>
            </div>
        );
    }

}

const mapStateToProps = (state: RootState) => ({});

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(CabinetAdminUsers);