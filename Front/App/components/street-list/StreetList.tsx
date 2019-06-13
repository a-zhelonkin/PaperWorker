import React, {Component, ReactNode} from "react";
import PanelGroup from "react-bootstrap/lib/PanelGroup";
import Panel from "react-bootstrap/lib/Panel";
import StreetsApi, {StreetModel} from "../../api/streets-api";
import StreetCreator from "./StreetCreator";
import StreetItem from "./StreetItem";

interface StreetListProps {
    readonly localityId: string;
}

interface StreetListState {
    readonly activeStreetIndex: number;
    readonly streets: StreetModel[];
}

export default class StreetList extends Component<StreetListProps, StreetListState> {

    public state: StreetListState = {
        activeStreetIndex: -1,
        streets: []
    };

    public componentDidMount(): void {
        StreetsApi.get(this.props.localityId).then(streets => {
            if (streets) {
                this.setState({streets});
            }
        });
    }

    public render(): ReactNode {
        return (
            <>
                <StreetCreator localityId={this.props.localityId} addStreet={this.addStreet}/>

                <PanelGroup
                    id="accordion-controlled-example"
                    accordion
                    activeKey={this.state.activeStreetIndex}
                    onSelect={this.onSelect}
                >
                    {this.state.streets.map((street, index) => {
                        return (
                            <Panel key={index} eventKey={index}>
                                <Panel.Heading>
                                    <Panel.Title toggle>Населенный пункт: {street.name}</Panel.Title>
                                </Panel.Heading>
                                <Panel.Body collapsible>
                                    <StreetItem street={street}/>
                                </Panel.Body>
                            </Panel>
                        );
                    })}
                </PanelGroup>
            </>
        );
    }

    private onSelect = (index: number | any): void => this.setState({activeStreetIndex: index});

    private addStreet = (street: StreetModel): void => {
        this.setState({streets: [...this.state.streets, street]});
    }

}