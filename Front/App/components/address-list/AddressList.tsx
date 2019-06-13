import "./../addressing.scss";
import React, {Component, ReactNode} from "react";
import AddressesApi, {AddressModel} from "../../api/addresses-api";
import AddressCreator from "./AddressCreator";
import {RouteComponentProps, withRouter} from "react-router";

interface AddressListProps extends RouteComponentProps {
    readonly structureId: string;
}

interface AddressListState {
    readonly addresses: AddressModel[];
}

class AddressList extends Component<AddressListProps, AddressListState> {

    public state: AddressListState = {
        addresses: []
    };

    public componentDidMount(): void {
        AddressesApi.getByStructureId(this.props.structureId).then(addresses => {
            if (addresses) {
                this.setState({addresses});
            }
        });
    }

    public render(): ReactNode {
        return (
            <>
                <AddressCreator structureId={this.props.structureId} addAddress={this.addAddress}/>

                {this.state.addresses.map((address, index) => {
                    const onClick = (): void => this.props.history.push(`/cabinet?addressId=${address.id}`);

                    return (
                        <div className="addressing-item" key={index} onClick={onClick}>
                            {address.number}
                        </div>
                    );
                })}
            </>
        );
    }

    private addAddress = (address: AddressModel): void => {
        this.setState({addresses: [...this.state.addresses, address]});
    }

}

export default withRouter(AddressList);