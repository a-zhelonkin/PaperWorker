import "./../addressing.scss";
import React, {Component, ReactNode} from "react";
import {StructureModel} from "../../api/structures-api";
import StructureCreator from "./StructureCreator";
import {RouteComponentProps, withRouter} from "react-router";

interface StructureListProps extends RouteComponentProps {
    readonly streetId: string;
    readonly structures: StructureModel[];
}

interface StructureListState {
    readonly structures: StructureModel[];
}

class StructureList extends Component<StructureListProps, StructureListState> {

    public static getDerivedStateFromProps(props: StructureListProps): StructureListState {
        return {
            structures: props.structures
        };
    }

    public state: StructureListState = {
        structures: this.props.structures
    };

    public render(): ReactNode {
        return (
            <>
                <StructureCreator streetId={this.props.streetId} addStructure={this.addStructure}/>

                {this.state.structures.map((structure, index) => {
                    const onClick = (): void => this.props.history.push(`/cabinet?structureId=${structure.id}`);

                    return (
                        <div className="addressing-item" key={index} onClick={onClick}>
                            {structure.number}
                        </div>
                    );
                })}
            </>
        );
    }

    private addStructure = (structure: StructureModel): void => {
        this.setState({structures: [...this.state.structures, structure]});
    }

}

export default withRouter(StructureList);