import React, {Component, ReactNode} from "react";
import LocalitiesApi, {LocalityModel} from "../../api/localities-api";
import StreetList from "../street-list/StreetList";

interface LocalityItemProps {
    readonly localityId: string;
}

interface LocalityItemState {
    readonly locality: LocalityModel;
}

export default class LocalityItem extends Component<LocalityItemProps, LocalityItemState> {

    public state: LocalityItemState = {
        locality: undefined
    };

    public componentDidMount(): void {
        LocalitiesApi.getById(this.props.localityId).then(locality => {
            if (locality) {
                this.setState({locality});
            }
        });
    }

    public render(): ReactNode {
        const {locality} = this.state;

        if (!locality) {
            return false;
        }

        return (
            <>
                <StreetList localityId={locality.id} streets={locality.streets}/>
            </>
        );
    }

}