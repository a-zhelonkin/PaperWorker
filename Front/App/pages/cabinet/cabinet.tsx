import "./cabinet.css"
import React, {Component, ReactNode} from "react";
import {History} from "history";
import {connect} from "react-redux";
import {loadProfile} from './actions';
import {Profile} from "./cabinet.api";
import Navigation from "../../components/navigation/navigation";

export interface CabinetProps {
    history: History;
    loadProfile: (profile: Profile) => void;
}

class Cabinet extends Component<CabinetProps> {

    public render(): ReactNode {
        return (
            <>
                <Navigation/>
            </>
        );
    }

}

export default connect(null, {
    loadProfile: loadProfile
})(Cabinet);