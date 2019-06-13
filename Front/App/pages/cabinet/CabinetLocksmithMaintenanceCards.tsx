import React, {Component, ReactNode} from "react";
import {connect} from "react-redux";
import {RootState} from "../../store";

export interface CabinetLocksmithMaintenanceCardsProps {
}

class CabinetLocksmithMaintenanceCards extends Component<CabinetLocksmithMaintenanceCardsProps> {

    public render(): ReactNode {
        return (
            <div>
                Слесярь
            </div>
        );
    }

}

const mapStateToProps = (state: RootState) => ({});

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(CabinetLocksmithMaintenanceCards);