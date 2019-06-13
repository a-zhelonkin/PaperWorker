import React, {Component, ReactNode} from "react";
import PanelGroup from "react-bootstrap/lib/PanelGroup";
import Panel from "react-bootstrap/lib/Panel";
import TerritoryList from "../../components/territory-list/TerritoryList";
import queryString from "querystring";
import {RouteComponentProps, withRouter} from "react-router";
import TerritoryItem from "../../components/territory-list/TerritoryItem";
import TerritoriesApi, {TerritoryModel} from "../../api/territories-api";
import LocalityItem from "../../components/locality-list/LocalityItem";
import StreetItem from "../../components/street-list/StreetItem";
import StructureItem from "../../components/structure-list/StructureItem";
import AddressItem from "../../components/address-list/AddressItem";

export interface CabinetLocksmithProps extends RouteComponentProps {
}

export interface CabinetLocksmithState {
    readonly activeTab: number;
    readonly territories: TerritoryModel[];
}

const tabNone: number = -1;
const tabAddresses: number = 0;
const tabConsumers: number = 1;

class CabinetLocksmith extends Component<CabinetLocksmithProps, CabinetLocksmithState> {

    public state: CabinetLocksmithState = {
        activeTab: tabNone,
        territories: []
    };

    public componentDidMount(): void {
        TerritoriesApi.getByParentId().then(territories => {
            if (territories) {
                this.setState({territories});
            }
        });
    }

    public render(): ReactNode {
        const params: any = queryString.parse(this.props.location.search.slice(1));

        const addressId: string = params.addressId;
        if (addressId) {
            return (<AddressItem addressId={addressId}/>);
        }

        const structureId: string = params.structureId;
        if (structureId) {
            return (<StructureItem structureId={structureId}/>);
        }

        const streetId: string = params.streetId;
        if (streetId) {
            return (<StreetItem streetId={streetId}/>);
        }

        const localityId: string = params.localityId;
        if (localityId) {
            return (<LocalityItem localityId={localityId}/>);
        }

        const territoryId: string = params.territoryId;
        if (territoryId) {
            return (<TerritoryItem territoryId={territoryId}/>);
        }

        return (
            <PanelGroup
                id="accordion-controlled-example"
                accordion
                activeKey={this.state.activeTab}
                onSelect={this.onSelect}
            >
                <Panel eventKey={tabAddresses}>
                    <Panel.Heading>
                        <Panel.Title toggle>Территории</Panel.Title>
                    </Panel.Heading>
                    <Panel.Body collapsible>
                        <TerritoryList territories={this.state.territories}/>
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

export default withRouter(CabinetLocksmith);