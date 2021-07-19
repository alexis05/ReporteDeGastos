import React, { Component } from 'react';
import { Col, Row } from 'react-bootstrap';
import DateCal from './DateCal';
import Header from './Header';
import List from './List';

class Report extends Component {
    render() {
        return (
            <div className="container">
                <Header />

                <Row>
                   <div className="input-group mb-3">
                    <Col md={6}>
                        <div>
                            CONCEPTO:
                            <input type="text" className="form-control" name="concepto" placeholder="Concepto" aria-label="Concepto" aria-describedby="basic-addon1"></input>
                        </div>
                    </Col>
                    <Col md={6}>
                        <Row>
                            <Col md={6}>
                                Desde: <DateCal />
                            </Col>
                            <Col md={6}>
                                Hasta: <DateCal />
                            </Col>
                        </Row>
                    </Col>
                    </div>
                </Row>
                <Row>
                    <Col>Información del empleador:</Col>
                </Row>
                <Row>
                   <div className="input-group mb-3">
                    <Col md={6}>
                        Nombre: 
                        <input type="text" className="form-control" name="nombre" placeholder="Nombre" aria-label="Nombre" aria-describedby="basic-addon1"></input>
                    </Col>
                    <Col md={6}>
                        Posición:
                        <input type="text" className="form-control" name="posicion" placeholder="Posición" aria-label="Posición" aria-describedby="basic-addon1"></input>
                    </Col>
                    </div>

                </Row>
                <Row>
                   <div className="input-group mb-3">
                    <Col md={6}>
                        Departamento: 
                        <input type="text" className="form-control" name="departamento" placeholder="Departamento" aria-label="Departamento" aria-describedby="basic-addon1"></input>

                    </Col>
                    <Col md={6}>
                        Supervisor:
                        <input type="text" className="form-control" name="supervisor" placeholder="Supervisor" aria-label="Supervisor" aria-describedby="basic-addon1"></input>
                    </Col>
                    </div>
                </Row>
                <Row>
                    <List />
                </Row>

            </div>
        );
    }
}

export default Report;