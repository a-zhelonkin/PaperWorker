import React, {Component, ReactNode} from "react";
import TerritoriesApi, {TerritoryModel} from "../../api/territories-api";
import TerritoryList from "./TerritoryList";
import LocalityList from "../locality-list/LocalityList";

interface TerritoryItemProps {
    readonly territoryId: string;
}

interface TerritoryItemState {
    readonly territory: TerritoryModel;
}

export default class TerritoryItem extends Component<TerritoryItemProps, TerritoryItemState> {

    public state: TerritoryItemState = {
        territory: undefined
    };

    public componentDidMount(): void {
        TerritoriesApi.getById(this.props.territoryId).then(territory => {
            if (territory) {
                this.setState({territory});
            }
        });
    }

    public render(): ReactNode {
        const {territory} = this.state;

        if (!territory) {
            return false;
        }

        return (
            <>
                <TerritoryList parentId={territory.id} territories={territory.children}/>
                <LocalityList territoryId={territory.id} localities={territory.localities}/>
            </>
        );
    }

}