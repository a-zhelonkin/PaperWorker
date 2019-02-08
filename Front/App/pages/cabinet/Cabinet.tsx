import React, {Component, ReactNode} from "react";
import {connect} from "react-redux";
import {loadProfile} from "./actions";
import {Profile} from "../../api/profiles-api";

export interface CabinetProps {
    loadProfile: (profile: Profile) => void;
}

class Cabinet extends Component<CabinetProps> {

    public render(): ReactNode {
        return (
            <>
                Кабинет
            </>
        );
    }

}

const mapDispatchToProps = {
    loadProfile: loadProfile
};

export default connect(undefined, mapDispatchToProps)(Cabinet);