import React, {Component, ReactNode} from "react";
import Modal from "react-bootstrap/lib/Modal";
import Button from "react-bootstrap/lib/Button";
import FormGroup from "react-bootstrap/lib/FormGroup";
import ControlLabel from "react-bootstrap/lib/ControlLabel";
import FormControl from "react-bootstrap/lib/FormControl";
import Form from "react-bootstrap/lib/Form";
import LocalitiesApi, {LocalityModel} from "../../api/localities-api";

interface LocalityCreatorProps {
    readonly territoryId: string;
    readonly addLocality: (locality: LocalityModel) => void;
}

interface LocalityCreatorState {
    readonly show: boolean;
}

export default class LocalityCreator extends Component<LocalityCreatorProps, LocalityCreatorState> {

    private inputName: HTMLInputElement;

    public state: LocalityCreatorState = {
        show: false
    };

    public render(): ReactNode {
        return (
            <>
                <Button className="btn-primary" onClick={this.handleShow}>
                    Добавить населенный пункт
                </Button>

                <Modal show={this.state.show} onHide={this.handleHide}>
                    <Modal.Header closeButton>
                        <Modal.Title>Добавление населенного пункта</Modal.Title>
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
            LocalitiesApi.post({name, territoryId: this.props.territoryId})
                .then(locality => {
                    if (locality) {
                        this.props.addLocality(locality);
                        this.setState({show: false});
                    }
                });
        }
    }

}