import React, {Component, ReactNode} from "react";
import {LocalityModel} from "../../api/localities-api";
import StreetList from "../street-list/StreetList";

interface LocalityItemProps {
    readonly locality: LocalityModel;
}

export default class LocalityItem extends Component<LocalityItemProps> {

    public render(): ReactNode {
        return (
            <>
                <StreetList localityId={this.props.locality.id}/>
            </>
        );
    }

}