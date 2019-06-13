import React, {Component, ReactNode} from "react";
import PanelGroup from "react-bootstrap/lib/PanelGroup";
import Panel from "react-bootstrap/lib/Panel";
import TerritoryList from "../../components/territory-list/TerritoryList";

export interface CabinetLocksmithProps {
}

export interface CabinetLocksmithState {
    activeTab: number;
}

const tabNone: number = -1;
const tabAddresses: number = 0;
const tabConsumers: number = 1;

export default class CabinetLocksmith extends Component<CabinetLocksmithProps, CabinetLocksmithState> {

    public state = {
        activeTab: tabNone
    };

    public render(): ReactNode {
        return (
            <PanelGroup
                id="accordion-controlled-example"
                accordion
                activeKey={this.state.activeTab}
                onSelect={this.onSelect}
            >
                <Panel eventKey={tabAddresses}>
                    <Panel.Heading>
                        <Panel.Title toggle>Адреса</Panel.Title>
                    </Panel.Heading>
                    <Panel.Body collapsible>
                        <TerritoryList/>
                    </Panel.Body>
                </Panel>
                <Panel eventKey={tabConsumers}>
                    <Panel.Heading>
                        <Panel.Title toggle>Потребители</Panel.Title>
                    </Panel.Heading>
                    <Panel.Body collapsible>
                        Panel content 2
                    </Panel.Body>
                </Panel>
            </PanelGroup>
        );
    }

    private onSelect = (index: number | any): void => this.setState({activeTab: index});

}