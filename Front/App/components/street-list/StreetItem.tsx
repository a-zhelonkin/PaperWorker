import React, {Component, ReactNode} from "react";
import StreetsApi, {StreetModel} from "../../api/streets-api";
import StructureList from "../structure-list/StructureList";

interface StreetItemProps {
    readonly streetId: string;
}

interface StreetItemState {
    readonly street: StreetModel;
}

export default class StreetItem extends Component<StreetItemProps, StreetItemState> {

    public state: StreetItemState = {
        street: undefined
    };

    public componentDidMount(): void {
        StreetsApi.getById(this.props.streetId).then(street => {
            if (street) {
                this.setState({street});
            }
        });
    }

    public render(): ReactNode {
        const {street} = this.state;

        if (!street) {
            return false;
        }

        return (
            <>
                <StructureList streetId={street.id} structures={street.structures}/>
            </>
        );
    }

}