import React, {Component, ReactNode} from "react";
import PanelGroup from "react-bootstrap/lib/PanelGroup";
import Panel from "react-bootstrap/lib/Panel";
import {LocalityModel} from "../../api/localities-api";
import LocalityCreator from "./LocalityCreator";
import LocalityItem from "./LocalityItem";

interface LocalityListProps {
    readonly territoryId: string;
    readonly localities: LocalityModel[];
}

interface LocalityListState {
    readonly activeLocalityIndex: number;
    readonly localities: LocalityModel[];
}

export default class LocalityList extends Component<LocalityListProps, LocalityListState> {

    public state: LocalityListState = {
        activeLocalityIndex: -1,
        localities: this.props.localities
    };

    public render(): ReactNode {
        return (
            <>
                <LocalityCreator territoryId={this.props.territoryId} addLocality={this.addLocality}/>

                <PanelGroup
                    id="accordion-controlled-example"
                    accordion
                    activeKey={this.state.activeLocalityIndex}
                    onSelect={this.onSelect}
                >
                    {this.state.localities.map((locality, index) => {
                        return (
                            <Panel key={index} eventKey={index}>
                                <Panel.Heading>
                                    <Panel.Title toggle>Населенный пункт: {locality.name}</Panel.Title>
                                </Panel.Heading>
                                <Panel.Body collapsible>
                                    <LocalityItem localityId={locality.id}/>
                                </Panel.Body>
                            </Panel>
                        );
                    })}
                </PanelGroup>
            </>
        );
    }

    private onSelect = (index: number | any): void => this.setState({activeLocalityIndex: index});

    private addLocality = (locality: LocalityModel): void => {
        this.setState({localities: [...this.state.localities, locality]});
    }

}