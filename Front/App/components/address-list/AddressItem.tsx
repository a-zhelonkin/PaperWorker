import React, {Component, ReactNode} from "react";
import AddressesApi, {AddressModel} from "../../api/addresses-api";

interface AddressItemProps {
    readonly addressId: string;
}

interface AddressItemState {
    readonly address: AddressModel;
}

export default class AddressItem extends Component<AddressItemProps, AddressItemState> {

    public state: AddressItemState = {
        address: undefined
    };

    public componentDidMount(): void {
        AddressesApi.getById(this.props.addressId).then(address => {
            if (address) {
                this.setState({address});
            }
        });
    }

    public render(): ReactNode {
        const {address} = this.state;

        if (!address) {
            return false;
        }

        return (
            <>
                {address.number}
            </>
        );
    }

}