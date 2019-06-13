import React, {Component, ReactNode} from "react";
import TerritoriesApi, {TerritoryModel} from "../../api/territories-api";
import TerritoryItem from "./TerritoryItem";
import PanelGroup from "react-bootstrap/lib/PanelGroup";
import Panel from "react-bootstrap/lib/Panel";
import TerritoryCreator from "./TerritoryCreator";

interface TerritoryListProps {
    readonly parentId?: string;
}

interface TerritoryListState {
    readonly activeTerritoryIndex: number;
    readonly territories: TerritoryModel[];
}

export default class TerritoryList extends Component<TerritoryListProps, TerritoryListState> {

    public state: TerritoryListState = {
        activeTerritoryIndex: -1,
        territories: []
    };

    public componentDidMount(): void {
        TerritoriesApi.get(this.props.parentId).then(territories => {
            if (territories) {
                this.setState({territories});
            }
        });
    }

    public render(): ReactNode {
        return (
            <>
                <TerritoryCreator parentId={this.props.parentId} addTerritory={this.addTerritory}/>

                <PanelGroup
                    id="accordion-controlled-example"
                    accordion
                    activeKey={this.state.activeTerritoryIndex}
                    onSelect={this.onSelect}
                >
                    {this.state.territories
                        .filter(territory => territory.parentId == this.props.parentId)
                        .map((territory, index) => {
                            return (
                                <Panel key={index} eventKey={index}>
                                    <Panel.Heading>
                                        <Panel.Title toggle>Территория: {territory.name}</Panel.Title>
                                    </Panel.Heading>
                                    <Panel.Body collapsible>
                                        <TerritoryItem territory={territory}/>
                                    </Panel.Body>
                                </Panel>
                            );
                        })}
                </PanelGroup>
            </>
        );
    }

    private onSelect = (index: number | any): void => this.setState({activeTerritoryIndex: index});

    private addTerritory = (territory: TerritoryModel): void => {
        this.setState({territories: [...this.state.territories, territory]});
    }

}