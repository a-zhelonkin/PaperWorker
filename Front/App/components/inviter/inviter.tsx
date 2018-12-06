import React, {FunctionComponent} from "react";
import FormGroup from "react-bootstrap/lib/FormGroup";
import InputGroup from "react-bootstrap/lib/InputGroup";
import FormControl from "react-bootstrap/lib/FormControl";
import Button from "react-bootstrap/lib/Button";
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";

export const Inviter: FunctionComponent = () => {

    const handleInvite = (): void => {
        alert(123);
    };

    return (
        <FormGroup>
            <InputGroup>
                <FormControl type="text"/>
                <InputGroup.Button>
                    <Button onClick={handleInvite}>
                        <FontAwesomeIcon icon="envelope"/>
                    </Button>
                </InputGroup.Button>
            </InputGroup>
        </FormGroup>
    );
};