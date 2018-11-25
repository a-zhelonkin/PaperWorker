import "./app.css";
import React, {Component, ReactNode} from "react";
import {Link} from "react-router-dom";
import * as PropTypes from "prop-types";
import Grid from "react-bootstrap/lib/Grid";
import Nav from "react-bootstrap/lib/Nav";
import Navbar from "react-bootstrap/lib/Navbar";
import NavItem from "react-bootstrap/lib/NavItem";

export default class App extends Component {

    public static readonly propTypes = {
        children: PropTypes.node
    };

    public render(): ReactNode {
        return (
            <>

                <Link to="/">root</Link>
                <Link to="/login">login</Link>
                
                <Navbar>
                    <Navbar.Header>
                        <Navbar.Brand>
                            <span>Hello World</span>
                        </Navbar.Brand>
                        <Navbar.Toggle/>
                    </Navbar.Header>
                    <Navbar.Collapse>
                        <Nav navbar={true}>
                            <NavItem>Время</NavItem>
                            <NavItem>Счетчики</NavItem>
                        </Nav>
                    </Navbar.Collapse>
                </Navbar>
                <Grid>
                    {this.props.children}
                </Grid>
            </>
        );
    }
}