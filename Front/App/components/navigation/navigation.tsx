import React, {FunctionComponent} from "react";
import Nav from "react-bootstrap/lib/Nav";
import Navbar from "react-bootstrap/lib/Navbar";
import NavItem from "react-bootstrap/lib/NavItem";
import NavDropdown from "react-bootstrap/lib/NavDropdown";
import MenuItem from "react-bootstrap/lib/MenuItem";
import LinkContainer from "react-router-bootstrap/lib/LinkContainer";
import {NavLink} from "react-router-dom";
import {connect} from "react-redux";
import {logout} from "../../pages/auth/actions";
import {RootState} from "../../store";

export interface NavigationProps {
    email: string;
    isLoggedIn: boolean;
    logout: () => void;
}

const Navigation: FunctionComponent<NavigationProps> = (props: NavigationProps) =>
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
                    <LinkContainer to="/home">
                        <NavItem>
                            Home
                        </NavItem>
                    </LinkContainer>
                </Nav>
                <Nav pullRight>
                    {
                        props.isLoggedIn ? (
                            <NavDropdown title={props.email} id="nav-dropdown">
                                <LinkContainer to="/cabinet">
                                    <MenuItem>
                                        Профиль
                                    </MenuItem>
                                </LinkContainer>
                                <MenuItem divider/>
                                <MenuItem onClick={props.logout}>
                                    Выйти
                                </MenuItem>
                            </NavDropdown>
                        ) : (
                            <LinkContainer to="/login">
                                <NavItem>
                                    Войти
                                </NavItem>
                            </LinkContainer>
                        )
                    }
                </Nav>
            </Navbar.Collapse>
        </Navbar>
    </header>;

const mapStateToProps = (state: RootState) => ({
    email: state.auth.email,
    isLoggedIn: state.auth.isLoggedIn
});

const mapDispatchToProps = {
    logout: logout
};

export default connect(mapStateToProps, mapDispatchToProps)(Navigation);