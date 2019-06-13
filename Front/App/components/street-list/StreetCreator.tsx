import React, {Component, ReactNode} from "react";
import Modal from "react-bootstrap/lib/Modal";
import Button from "react-bootstrap/lib/Button";
import FormGroup from "react-bootstrap/lib/FormGroup";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import FormControl from "react-bootstrap/lib/FormControl";
import Form from "react-bootstrap/lib/Form";
import StreetsApi, {StreetModel} from "../../api/streets-api";

interface StreetCreatorProps {
    readonly localityId: string;
    readonly addStreet: (street: StreetModel) => void;
}

interface StreetCreatorState {
    readonly show: boolean;
}

export default class StreetCreator extends Component<StreetCreatorProps, StreetCreatorState> {

    private inputName: HTMLInputElement;

    public state: StreetCreatorState = {
        show: false
    };

    public render(): ReactNode {
        return (
            <>
                <Button className="btn-primary" onClick={this.handleShow}>
                    Добавить улицу
                </Button>

                <Modal show={this.state.show} onHide={this.handleHide}>
                    <Modal.Header closeButton>
                        <Modal.Title>Добавление улицы</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form horizontal>
                            <FormGroup>
                                <ControlLabel>Название</ControlLabel>
                                <FormControl
                                    type="email"
                                    inputRef={this.setInputName}
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

    private setInputName = (input: HTMLInputElement) => this.inputName = input;

    private handleShow = (e: any): void => this.setState({show: true});

    private handleHide = (e: any): void => this.setState({show: false});

    private handleAdd = (e: any): void => {
        const name: string = this.inputName.value;
        if (name) {
            StreetsApi.post({name, localityId: this.props.localityId})
                .then(street => {
                    if (street) {
                        this.props.addStreet(street);
                        this.setState({show: false});
                    }
                });
        }
    }

}