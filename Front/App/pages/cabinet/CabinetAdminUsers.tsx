import React, {Component, ReactNode} from "react";
import {connect} from "react-redux";
import {RootState} from "../../store";
import "react-bootstrap-table/css/react-bootstrap-table.css";
import {BootstrapTable, TableHeaderColumn} from "react-bootstrap-table";
import UsersApi, {UserModel} from "../../api/users-api";

export interface CabinetAdminUsersProps {
}

export interface CabinetAdminUsersState {
    users: UserModel[];
}

class CabinetAdminUsers extends Component<CabinetAdminUsersProps, CabinetAdminUsersState> {

    public constructor(props: CabinetAdminUsersProps) {
        super(props);
        this.state = {
            users: []
        };
    }

    public componentDidMount(): void {
        // todo Реализовать серверную пагинацию
        UsersApi.get(0, 10)
            .then(users => {
                this.setState({users});
            });
    }

    public render(): ReactNode {
        return (
            <BootstrapTable data={this.state.users} pagination>
                <TableHeaderColumn dataField="id" isKey>Id</TableHeaderColumn>
                <TableHeaderColumn dataField="email">Email</TableHeaderColumn>
                <TableHeaderColumn dataField="status">Status</TableHeaderColumn>
                <TableHeaderColumn dataField="firstName">Имя</TableHeaderColumn>
                <TableHeaderColumn dataField="lastName">Фамилия</TableHeaderColumn>
                <TableHeaderColumn dataField="patronymic">Отчество</TableHeaderColumn>
                <TableHeaderColumn dataField="phoneNumber">Номер телефона</TableHeaderColumn>
            </BootstrapTable>
        );
    }

}

const mapStateToProps = (state: RootState) => ({});

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(CabinetAdminUsers);