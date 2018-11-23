import "./app.css";
import React, {Component, PropTypes} from "react";
import Grid from 'react-bootstrap/lib/Grid';
import Nav from 'react-bootstrap/lib/Nav';
import Navbar from 'react-bootstrap/lib/Navbar';
import NavItem from 'react-bootstrap/lib/NavItem';

export default class App extends Component {

    static propTypes = {
        children: PropTypes.node
    };

    render() {
        return (
            <>
                <Navbar>
                    <Navbar.Header>
                        <Navbar.Brand>
                            <span>Hello World</span>
                        </Navbar.Brand>
                        <Navbar.Toggle/>
                    </Navbar.Header>
                    <Navbar.Collapse>
                        <Nav navbar>
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