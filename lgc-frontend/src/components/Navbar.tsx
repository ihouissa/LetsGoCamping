// Navbar.tsx
import React, { useContext } from 'react';
import { Navbar, Nav, Container, NavDropdown, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { AuthContext } from '../context/AuthContext';

const AppNavbar: React.FC = () => {
  const auth = useContext(AuthContext);

  // If auth is undefined, throw an error to enforce proper use of context
  if (!auth) {
    throw new Error('AppNavbar must be used within an AuthProvider');
  }

  const { user, logout } = auth;

  return (
    <Navbar bg="dark" variant="dark" expand="lg">
      <Container>
        <Navbar.Brand as={Link as any} to="/">
          Let's Go Camping
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            {user ? (
              <>
                <Nav.Link as={Link as any} to="/home">
                  Home
                </Nav.Link>
                <Nav.Link as={Link as any} to="/my-trips">
                  My Trips
                </Nav.Link>
                <Nav.Link as={Link as any} to="/create-trip">
                  Create Camping Trip
                </Nav.Link>
              </>
            ) : (
              <>
                <Nav.Link as={Link as any} to="/login">
                  Login
                </Nav.Link>
                <Nav.Link as={Link as any} to="/register">
                  Register
                </Nav.Link>
              </>
            )}
          </Nav>
          <Nav>
            {user ? (
              <NavDropdown title={user.username} id="basic-nav-dropdown">
                <NavDropdown.Item onClick={logout}>Logout</NavDropdown.Item>
              </NavDropdown>
            ) : (
              <Button as={Link as any} to="/login" variant="outline-light">
                Login
              </Button>
            )}
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default AppNavbar;
