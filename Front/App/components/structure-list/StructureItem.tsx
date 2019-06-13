import React, {Component, ReactNode} from "react";
import {StructureModel} from "../../api/structures-api";
import AddressList from "../address-list/AddressList";

interface StructureItemProps {
    readonly structure: StructureModel;
}

export default class StructureItem extends Component<StructureItemProps> {

    public render(): ReactNode {
        return (
            <>
                <AddressList structureId={this.props.structure.id}/>
            </>
        );
    }

}