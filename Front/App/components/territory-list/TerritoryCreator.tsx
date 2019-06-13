import React, {Component, ReactNode} from "react";
import Modal from "react-bootstrap/lib/Modal";
import Button from "react-bootstrap/lib/Button";
import FormGroup from "react-bootstrap/lib/FormGroup";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import FormControl from "react-bootstrap/lib/FormControl";
import Form from "react-bootstrap/lib/Form";
import TerritoriesApi, {TerritoryModel} from "../../api/territories-api";

interface TerritoryCreatorProps {
    readonly parentId?: string;
    readonly addTerritory: (territory: TerritoryModel) => void;
}

interface TerritoryCreatorState {
    readonly show: boolean;
}

export default class TerritoryCreator extends Component<TerritoryCreatorProps, TerritoryCreatorState> {

    private inputName: HTMLInputElement;

    public state: TerritoryCreatorState = {
        show: false
    };

    public render(): ReactNode {
        return (
            <>
                <Button className="btn-primary" onClick={this.handleShow}>
                    Добавить территорию
                </Button>

                <Modal show={this.state.show} onHide={this.handleHide}>
                    <Modal.Header closeButton>
                        <Modal.Title>Добавление территории</Modal.Title>
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
            TerritoriesApi.post({name, parentId: this.props.parentId})
                .then(territory => {
                    if (territory) {
                        this.props.addTerritory(territory);
                        this.setState({show: false});
                    }
                });
        }
    }

}