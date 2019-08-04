import React from "react";
import { Route, Container } from "../generic";
import { RountingRelationRepository } from "./routing-relation-repository";
import { TopBar } from "./top-bar";

interface BodyProps {
    toggleModal: () => void;
}

/**
 * Contiene el cuerpo de la aplicación web
 * Aquí se rutearán las diferentes pantallas de las que consta el sistema
 */
export default class Body extends React.Component<BodyProps> {
    render() {
        const { toggleModal } = this.props;
        return (
            <>
                <TopBar />
                <Container fluid>
                    {RountingRelationRepository.map(
                        (routingRelation, routingRelationIndex) => (
                            <Route
                                key={routingRelationIndex}
                                path={routingRelation.path}
                                component={props => <routingRelation.component {...props} toggleModal={toggleModal} />}

                            />
                        )
                    )}
                </Container>
            </>
        );
    }
}
