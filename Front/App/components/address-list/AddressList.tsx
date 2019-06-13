import React, {Component, ReactNode} from "react";
import PanelGroup from "react-bootstrap/lib/PanelGroup";
import Panel from "react-bootstrap/lib/Panel";
import AddressesApi, {AddressModel} from "../../api/addresses-api";
import AddressCreator from "./AddressCreator";
import AddressItem from "./AddressItem";

interface AddressListProps {
    readonly structureId: string;
}

interface AddressListState {
    readonly activeAddressIndex: number;
    readonly addresses: AddressModel[];
}

export default class AddressList extends Component<AddressListProps, AddressListState> {

    public state: AddressListState = {
        activeAddressIndex: -1,
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

                <PanelGroup
                    id="accordion-controlled-example"
                    accordion
                    activeKey={this.state.activeAddressIndex}
                    onSelect={this.onSelect}
                >
                    {this.state.addresses.map((address, index) => {
                        return (
                            <Panel key={index} eventKey={index}>
                                <Panel.Heading>
                                    <Panel.Title toggle>Квартира: {address.number}</Panel.Title>
                                </Panel.Heading>
                                <Panel.Body collapsible>
                                    <AddressItem addressId={address.id}/>
                                </Panel.Body>
                            </Panel>
                        );
                    })}
                </PanelGroup>
            </>
        );
    }

    private onSelect = (index: number | any): void => this.setState({activeAddressIndex: index});

    private addAddress = (address: AddressModel): void => {
        this.setState({addresses: [...this.state.addresses, address]});
    }

}