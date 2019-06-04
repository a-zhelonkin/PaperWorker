import React, {Component, ReactNode} from "react";
import {connect} from "react-redux";
import {RootState} from "../../store";

export interface CabinetConsumerProps {
}

class CabinetConsumer extends Component<CabinetConsumerProps> {

    public render(): ReactNode {
        return (
            <div>
                Патрибитель
            </div>
        );
    }

}

const mapStateToProps = (state: RootState) => ({});

const mapDispatchToProps = {};

export default connect(mapStateToProps, mapDispatchToProps)(CabinetConsumer);