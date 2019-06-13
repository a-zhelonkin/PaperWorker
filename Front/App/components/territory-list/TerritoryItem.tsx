import React, {Component, ReactNode} from "react";
import {TerritoryModel} from "../../api/territories-api";
import TerritoryList from "./TerritoryList";
import LocalityList from "../locality-list/LocalityList";

interface TerritoryItemProps {
    readonly territory: TerritoryModel;
}

export default class TerritoryItem extends Component<TerritoryItemProps> {

    public render(): ReactNode {
        return (
            <>
                <TerritoryList parentId={this.props.territory.id}/>
                <LocalityList territoryId={this.props.territory.id}/>
            </>
        );
    }

}