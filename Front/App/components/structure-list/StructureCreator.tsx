import React, {Component, ReactNode} from "react";
import Modal from "react-bootstrap/lib/Modal";
import Button from "react-bootstrap/lib/Button";
import FormGroup from "react-bootstrap/lib/FormGroup";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import FormControl from "react-bootstrap/lib/FormControl";
import Form from "react-bootstrap/lib/Form";
import StructuresApi, {StructureModel} from "../../api/structures-api";

interface StructureCreatorProps {
    readonly streetId: string;
    readonly addStructure: (structure: StructureModel) => void;
}

interface StructureCreatorState {
    readonly show: boolean;
}

export default class StructureCreator extends Component<StructureCreatorProps, StructureCreatorState> {

    private inputNumber: HTMLInputElement;

    public state: StructureCreatorState = {
        show: false
    };

    public render(): ReactNode {
        return (
            <>
                <Button className="btn-primary" onClick={this.handleShow}>
                    Добавить строение
                </Button>

                <Modal show={this.state.show} onHide={this.handleHide}>
                    <Modal.Header closeButton>
                        <Modal.Title>Добавление строения</Modal.Title>
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
        const structureNumber: number = parseInt(this.inputNumber.value);
        if (structureNumber) {
            StructuresApi.post({number: structureNumber, alone: false, streetId: this.props.streetId})
                .then(structure => {
                    if (structure) {
                        this.props.addStructure(structure);
                        this.setState({show: false});
                    }
                });
        }
    }

}