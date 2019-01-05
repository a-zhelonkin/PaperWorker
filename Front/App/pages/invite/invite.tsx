import React, {Component, ReactNode} from "react";
import Navigation from "../../components/navigation/navigation";
import queryString from "querystring";
import {connect} from "react-redux";

export interface InviteProps {
    location: Location;
}

class Invite extends Component<InviteProps> {

    componentDidMount() {
        const params: any = queryString.parse(this.props.location.search.slice(1));

        const token: string = params.token;
        
        console.log(params);
    }

    public render(): ReactNode {
        return (
            <>
                <Navigation/>

                invite
            </>
        );
    }

}

export default connect(null, {})(Invite);