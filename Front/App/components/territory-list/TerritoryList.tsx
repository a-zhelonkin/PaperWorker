import "./../addressing.scss";
import React, {Component, ReactNode} from "react";
import {TerritoryModel} from "../../api/territories-api";
import TerritoryCreator from "./TerritoryCreator";
import {RouteComponentProps, withRouter} from "react-router";

interface TerritoryListProps extends RouteComponentProps {
    readonly parentId?: string;
    readonly territories: TerritoryModel[];
}

interface TerritoryListState {
    readonly territories: TerritoryModel[];
}

class TerritoryList extends Component<TerritoryListProps, TerritoryListState> {

    public static getDerivedStateFromProps(props: TerritoryListProps): TerritoryListState {
        return {
            territories: props.territories
        };
    }

    public state: TerritoryListState = {
        territories: this.props.territories
    };

    public render(): ReactNode {
        return (
            <>
                <TerritoryCreator parentId={this.props.parentId} addTerritory={this.addTerritory}/>

                {this.state.territories
                    .filter(territory => territory.parentId == this.props.parentId)
                    .map((territory, index) => {
                        const onClick = (): void => this.props.history.push(`/cabinet?territoryId=${territory.id}`);

                        return (
                            <div className="addressing-item" key={index} onClick={onClick}>
                                {territory.name}
                            </div>
                        );
                    })}
            </>
        );
    }

    private addTerritory = (territory: TerritoryModel): void => {
        this.setState({territories: [...this.state.territories, territory]});
    }

}

export default withRouter(TerritoryList);