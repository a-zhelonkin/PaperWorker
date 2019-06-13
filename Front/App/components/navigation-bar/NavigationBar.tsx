import React, {FunctionComponent} from "react";
import Nav from "react-bootstrap/lib/Nav";
import Navbar from "react-bootstrap/lib/Navbar";
import NavItem from "react-bootstrap/lib/NavItem";
import NavDropdown from "react-bootstrap/lib/NavDropdown";
import MenuItem from "react-bootstrap/lib/MenuItem";
import LinkContainer from "react-router-bootstrap/lib/LinkContainer";
import {NavLink, RouteComponentProps, withRouter} from "react-router-dom";
import {connect} from "react-redux";
import {logout} from "../../pages/auth/actions";
import {RootState} from "../../store";

export interface NavigationBarProps extends RouteComponentProps {
    email: string;
    isLoggedIn: boolean;
    logout: () => void;
}

const NavigationBar: FunctionComponent<NavigationBarProps> = (props: NavigationBarProps) => (
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
                        <NavDropdown id="nav-dropdown" title={props.email}>
                            <LinkContainer to="/cabinet">
                                <MenuItem>
                                    Профиль
                                </MenuItem>
                            </LinkContainer>
                            <MenuItem divider/>
                            <LinkContainer to="/login">
                                <MenuItem onClick={props.logout}>
                                    Выйти
                                </MenuItem>
                            </LinkContainer>
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
);

const mapStateToProps = (state: RootState) => ({
    email: state.auth.email,
    isLoggedIn: state.auth.isLoggedIn
});

const mapDispatchToProps = {
    logout: logout
};

export default connect(mapStateToProps, mapDispatchToProps)(withRouter(NavigationBar));