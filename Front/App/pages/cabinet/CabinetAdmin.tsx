import React, {Component, ReactNode} from "react";
import {connect} from "react-redux";
import {RootState} from "../../store";
import Tabs from "react-bootstrap/lib/Tabs";
import Tab from "react-bootstrap/lib/Tab";
import CabinetAdminUsers from "./CabinetAdminUsers";
import CabinetAdminInvite from "./CabinetAdminInvite";

export interface CabinetAdminProps {
}

class CabinetAdmin extends Component<CabinetAdminProps> {

    public render(): ReactNode {
        return (
            <div>
                <Tabs defaultActiveKey="users" id="admin-tabs">
                    <Tab eventKey="users" title="Пользователи">
                        <CabinetAdminUsers/>
                    </Tab>
                    <Tab eventKey="invite" title="Приглашение">
                        <CabinetAdminInvite/>
                    </Tab>
                </Tabs>
            </div>
        );
    }

}

const mapStateToProps = (state: RootState) => ({});

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(CabinetAdmin);