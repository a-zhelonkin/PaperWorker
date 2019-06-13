import React, {Component, ReactNode} from "react";
import PanelGroup from "react-bootstrap/lib/PanelGroup";
import Panel from "react-bootstrap/lib/Panel";
import StructureItem from "./StructureItem";
import StructuresApi, {StructureModel} from "../../api/structures-api";
import StructureCreator from "./StructureCreator";

interface StructureListProps {
    readonly streetId: string;
}

interface StructureListState {
    readonly activeStructureIndex: number;
    readonly structures: StructureModel[];
}

export default class StructureList extends Component<StructureListProps, StructureListState> {

    public state: StructureListState = {
        activeStructureIndex: -1,
        structures: []
    };

    public componentDidMount(): void {
        StructuresApi.get(this.props.streetId).then(structures => {
            if (structures) {
                this.setState({structures});
            }
        });
    }

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
                                    <StructureItem structure={structure}/>
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