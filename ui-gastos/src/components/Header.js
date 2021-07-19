import React from 'react';
import { Row, Col } from 'react-bootstrap';

const Header = () => {
    return (
        <React.Fragment>
            <Row className="d-flex text-center justify-content-center">
                <Col md={12}>
                    <h2>
                        Reporte de Gastos
                    </h2>
                </Col>
            </Row>
        </React.Fragment>
    );
};

export default Header;