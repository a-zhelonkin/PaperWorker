import React, {Component, ReactNode} from "react";
import PanelGroup from "react-bootstrap/lib/PanelGroup";
import Panel from "react-bootstrap/lib/Panel";
import StructureItem from "./StructureItem";
import {StructureModel} from "../../api/structures-api";
import StructureCreator from "./StructureCreator";

interface StructureListProps {
    readonly streetId: string;
    readonly structures: StructureModel[];
}

interface StructureListState {
    readonly activeStructureIndex: number;
    readonly structures: StructureModel[];
}

export default class StructureList extends Component<StructureListProps, StructureListState> {

    public state: StructureListState = {
        activeStructureIndex: -1,
        structures: this.props.structures
    };

    public render(): ReactNode {
        return (
            <>
                <StructureCreator streetId={this.props.streetId} addStructure={this.addStructure}/>

                <PanelGroup
                    id="accordion-controlled-example"
                    accordion
                    activeKey={this.state.activeStructureIndex}
                    onSelect={this.onSelect}
                >
                    {this.state.structures.map((structure, index) => {
                        return (
                            <Panel key={index} eventKey={index}>
                                <Panel.Heading>
                                    <Panel.Title toggle>Строение: {structure.number}</Panel.Title>
                                </Panel.Heading>
                                <Panel.Body collapsible>
                                    <StructureItem structureId={structure.id}/>
                                </Panel.Body>
                            </Panel>
                        );
                    })}
                </PanelGroup>
            </>
        );
    }

    private onSelect = (index: number | any): void => this.setState({activeStructureIndex: index});

    private addStructure = (structure: StructureModel): void => {
        this.setState({structures: [...this.state.structures, structure]});
    }

}