import "./../addressing.scss";
import React, {Component, ReactNode} from "react";
import {LocalityModel} from "../../api/localities-api";
import LocalityCreator from "./LocalityCreator";
import {RouteComponentProps, withRouter} from "react-router";

interface LocalityListProps extends RouteComponentProps {
    readonly territoryId: string;
    readonly localities: LocalityModel[];
}

interface LocalityListState {
    readonly localities: LocalityModel[];
}

class LocalityList extends Component<LocalityListProps, LocalityListState> {

    public static getDerivedStateFromProps(props: LocalityListProps): LocalityListState {
        return {
            localities: props.localities
        };
    }

    public state: LocalityListState = {
        localities: this.props.localities
    };

    public render(): ReactNode {
        return (
            <>
                <LocalityCreator territoryId={this.props.territoryId} addLocality={this.addLocality}/>

                {this.state.localities.map((locality, index) => {
                    const onClick = (): void => this.props.history.push(`/cabinet?localityId=${locality.id}`);

                    return (
                        <div className="addressing-item" key={index} onClick={onClick}>
                            {locality.name}
                        </div>
                    );
                })}
            </>
        );
    }

    private addLocality = (locality: LocalityModel): void => {
        this.setState({localities: [...this.state.localities, locality]});
    }

}

export default withRouter(LocalityList);