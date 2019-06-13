import React, {Component, ReactNode} from "react";
import Modal from "react-bootstrap/lib/Modal";
import Button from "react-bootstrap/lib/Button";
import FormGroup from "react-bootstrap/lib/FormGroup";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import FormControl from "react-bootstrap/lib/FormControl";
import Form from "react-bootstrap/lib/Form";
import AddressesApi, {AddressModel} from "../../api/addresses-api";

interface AddressCreatorProps {
    readonly structureId: string;
    readonly addAddress: (address: AddressModel) => void;
}

interface AddressCreatorState {
    readonly show: boolean;
}

export default class AddressCreator extends Component<AddressCreatorProps, AddressCreatorState> {

    private inputNumber: HTMLInputElement;

    public state: AddressCreatorState = {
        show: false
    };

    public render(): ReactNode {
        return (
            <>
                <Button className="btn-primary" onClick={this.handleShow}>
                    Добавить квартиру
                </Button>

                <Modal show={this.state.show} onHide={this.handleHide}>
                    <Modal.Header closeButton>
                        <Modal.Title>Добавление квартиры</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form horizontal>
                            <FormGroup>
                                <ControlLabel>Номер</ControlLabel>
                                <FormControl
                                    type="email"
                                    inputRef={this.setInputNumber}
                                />
                            </FormGroup>
                        </Form>
                    </Modal.Body>
                    <Modal.Footer>
                        <Button className="btn-secondary" onClick={this.handleHide}>
                            Закрыть
                        </Button>
                        <Button className="btn-primary" onClick={this.handleAdd}>
                            Добавить
                        </Button>
                    </Modal.Footer>
                </Modal>
            </>
        );
    }

    private setInputNumber = (input: HTMLInputElement) => this.inputNumber = input;

    private handleShow = (e: any): void => this.setState({show: true});

    private handleHide = (e: any): void => this.setState({show: false});

    private handleAdd = (e: any): void => {
        const addressNumber: number = parseInt(this.inputNumber.value);
        if (addressNumber) {
            AddressesApi.post({number: addressNumber, structureId: this.props.structureId})
                .then(address => {
                    if (address) {
                        this.props.addAddress(address);
                        this.setState({show: false});
                    }
                });
        }
    }

}