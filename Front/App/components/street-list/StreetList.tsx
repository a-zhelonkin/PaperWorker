import "./../addressing.scss";
import React, {Component, ReactNode} from "react";
import {StreetModel} from "../../api/streets-api";
import StreetCreator from "./StreetCreator";
import {RouteComponentProps, withRouter} from "react-router";

interface StreetListProps extends RouteComponentProps {
    readonly localityId: string;
    readonly streets: StreetModel[];
}

interface StreetListState {
    readonly streets: StreetModel[];
}

class StreetList extends Component<StreetListProps, StreetListState> {

    public static getDerivedStateFromProps(props: StreetListProps): StreetListState {
        return {
            streets: props.streets
        };
    }

    public state: StreetListState = {
        streets: this.props.streets
    };

    public render(): ReactNode {
        return (
            <>
                <StreetCreator localityId={this.props.localityId} addStreet={this.addStreet}/>

                {this.state.streets.map((street, index) => {
                    const onClick = (): void => this.props.history.push(`/cabinet?streetId=${street.id}`);

                    return (
                        <div className="addressing-item" key={index} onClick={onClick}>
                            {street.name}
                        </div>
                    );
                })}
            </>
        );
    }

    private addStreet = (street: StreetModel): void => {
        this.setState({streets: [...this.state.streets, street]});
    }

}

export default withRouter(StreetList);