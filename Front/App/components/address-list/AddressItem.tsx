import React, {Component, ReactNode} from "react";
import {AddressModel} from "../../api/addresses-api";

interface AddressItemProps {
    readonly address: AddressModel;
}

export default class AddressItem extends Component<AddressItemProps> {

    public render(): ReactNode {
        return (
            <>
                {this.props.address.number}
            </>
        );
    }

}