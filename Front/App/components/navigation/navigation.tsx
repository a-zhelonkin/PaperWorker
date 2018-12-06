import React, {FunctionComponent} from "react";
import Nav from "react-bootstrap/lib/Nav";
import Navbar from "react-bootstrap/lib/Navbar";
import NavItem from "react-bootstrap/lib/NavItem";
import MenuItem from "react-bootstrap/lib/MenuItem";
import NavDropdown from "react-bootstrap/lib/NavDropdown";
import {NavLink} from "react-router-dom";
import {connect} from "react-redux";
import {login, logout} from "../../pages/auth/actions";

export interface NavigationProps {
    logout: () => void;
}

const Navigation: FunctionComponent<NavigationProps> = (props: NavigationProps) => {
    return (
        <header>
            <Navbar inverse collapseOnSelect>
                <Navbar.Header>
                    <Navbar.Brand>
                        <NavLink to="/">PaperWorker</NavLink>
                    </Navbar.Brand>
                    <Navbar.Toggle/>
                </Navbar.Header>
                <Navbar.Collapse>
                    <Nav>
                        <NavItem eventKey={1} href="/home">
                            Home
                        </NavItem>
                        <NavItem eventKey={2} href="/login">
                            Login
                        </NavItem>
                        <NavDropdown eventKey={3} title="Dropdown" id="basic-nav-dropdown">
                            <MenuItem eventKey={3.1}>Action</MenuItem>
                            <MenuItem eventKey={3.2}>Another action</MenuItem>
                            <MenuItem eventKey={3.3}>Something else here</MenuItem>
                            <MenuItem divider/>
                            <MenuItem eventKey={3.3}>Separated link</MenuItem>
                        </NavDropdown>
                    </Nav>
                    <Nav pullRight>
                        <NavItem eventKey={1} href="#">
                            Link Right
                        </NavItem>
                        <NavItem eventKey={2} href="/" onClick={props.logout}>
                            Выход
                        </NavItem>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        </header>
    );
};

export default connect(null, {
    logout: logout
})(Navigation);