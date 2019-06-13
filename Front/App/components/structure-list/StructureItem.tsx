import React, {Component, ReactNode} from "react";
import StructuresApi, {StructureModel} from "../../api/structures-api";
import AddressList from "../address-list/AddressList";

interface StructureItemProps {
    readonly structureId: string;
}

interface StructureItemState {
    readonly structure: StructureModel;
}

export default class StructureItem extends Component<StructureItemProps, StructureItemState> {

    public state: StructureItemState = {
        structure: undefined
    };

    public componentDidMount(): void {
        StructuresApi.getById(this.props.structureId).then(structure => {
            if (structure) {
                this.setState({structure});
            }
        });
    }

    public render(): ReactNode {
        const {structure} = this.state;

        if (!structure) {
            return false;
        }

        return (
            <>
                <AddressList structureId={structure.id}/>
            </>
        );
    }

}