import React, {FunctionComponent} from "react";
import {Logo} from "../";

export interface LogoHeaderProps {
    header: string;
    className?: string;
}

const LogoHeader: FunctionComponent<LogoHeaderProps> = (props: LogoHeaderProps) => (
    <div className={`container text-center ${props.className}`}>
        <Logo/>
        <div>
            {props.header}
        </div>
    </div>
);

export default LogoHeader;