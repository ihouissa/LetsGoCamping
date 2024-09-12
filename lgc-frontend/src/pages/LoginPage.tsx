// LoginPage.tsx
import React, { useState } from 'react';
import { Container, Form, Button, Alert } from 'react-bootstrap';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootswatch/dist/lux/bootstrap.min.css';
import { useNavigate } from 'react-router-dom';

const LoginPage: React.FC = () => {
    const [usernameOrEmail, setUsernameOrEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [success, setSuccess] = useState('');
    const navigate = useNavigate();

    const handleLogin = async (event: React.FormEvent) => {
        event.preventDefault();
        try {
            const response = await axios.post('/api/user/login', {
                usernameOrEmail,
                password,
            });
            setSuccess('Login successful!');
            navigate('/'); // Redirect to the home page or any other page upon success
        } catch (err) {
            setError('Login failed. Please check your credentials.');
        }
    };

    return (
        <Container className="d-flex justify-content-center align-items-center" style={{ height: '100vh' }}>
            <Form onSubmit={handleLogin} style={{ width: '100%', maxWidth: '500px' }}>
                <h1 className="mb-4 text-center">Login</h1>
                {error && <Alert variant="danger">{error}</Alert>}
                {success && <Alert variant="success">{success}</Alert>}
                <Form.Group className="mb-3" controlId="formBasicUsernameOrEmail">
                    <Form.Label>Username or Email</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="Enter username or email"
                        value={usernameOrEmail}
                        onChange={(e) => setUsernameOrEmail(e.target.value)}
                        required
                    />
                </Form.Group>
                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control
                        type="password"
                        placeholder="Enter password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </Form.Group>
                <Button variant="primary" type="submit">
                    Login
                </Button>
                <Button
                    variant="link"
                    onClick={() => navigate('/register')}
                    style={{ display: 'block', marginTop: '1rem' }}
                >
                    Don't have an account? Register here
                </Button>
            </Form>
        </Container>
    );
};

export default LoginPage;
