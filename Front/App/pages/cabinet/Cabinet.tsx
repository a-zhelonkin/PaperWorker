import React, {Component, ReactNode} from "react";
import {connect} from "react-redux";
import {RootState} from "../../store";
import {RoleName, roleNameDetails} from "../../constants/role-name";
import Tabs from "react-bootstrap/lib/Tabs";
import Tab from "react-bootstrap/lib/Tab";
import CabinetAdmin from "./CabinetAdmin";
import CabinetConsumer from "./CabinetConsumer";
import CabinetLocksmith from "./CabinetLocksmith";

export interface CabinetProps {
    roles: RoleName[];
}

class Cabinet extends Component<CabinetProps> {

    public render(): ReactNode {
        return (
            <div className="container">
                Кабинет
                <Tabs defaultActiveKey={this.props.roles[0]} id="uncontrolled-tab-example">
                    {this.props.roles.includes(RoleName.Admin) && (
                        <Tab eventKey={RoleName.Admin} title={roleNameDetails[RoleName.Admin].name}>
                            <CabinetAdmin/>
                        </Tab>
                    )}
                    {this.props.roles.includes(RoleName.Consumer) && (
                        <Tab eventKey={RoleName.Consumer} title={roleNameDetails[RoleName.Consumer].name}>
                            <CabinetConsumer/>
                        </Tab>
                    )}
                    {this.props.roles.includes(RoleName.Locksmith) && (
                        <Tab eventKey={RoleName.Locksmith} title={roleNameDetails[RoleName.Locksmith].name}>
                            <CabinetLocksmith/>
                        </Tab>
                    )}
                </Tabs>
            </div>
        );
    }

}

const mapStateToProps = (state: RootState) => ({
    roles: state.auth.roles
});

export default connect(mapStateToProps)(Cabinet);