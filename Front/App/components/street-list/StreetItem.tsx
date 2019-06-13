import React, {Component, ReactNode} from "react";
import {StreetModel} from "../../api/streets-api";
import StructureList from "../structure-list/StructureList";

interface StreetItemProps {
    readonly street: StreetModel;
}

export default class StreetItem extends Component<StreetItemProps> {

    public render(): ReactNode {
        return (
            <>
                <StructureList streetId={this.props.street.id}/>
            </>
        );
    }

}