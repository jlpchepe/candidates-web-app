// Dependencias Globales
import React from "react";
import { Row, Col } from "reactstrap";
import { withRouter, RouteComponentProps } from "react-router";

// Helpers
import { goToPath } from "../../../../helpers/navigation-helper";

// Servicios
import { WorkshopCapacity } from "../../../../communication/dtos/workshop";

// Genéricos
import { Grid, Modal, CircularButton, Label, LabeledDateInput } from "../../../generic";

interface WorkshopCapacityModalProps extends RouteComponentProps {
    activeWindow: string;
    onClickActionButton: () => void;
    workshopCapacity: WorkshopCapacity;
    workshopCapacityDate: Date;
    onChangeDate: (date: Date) => void;
}

const WorkshopCapacityModal: React.FC<WorkshopCapacityModalProps> = props => (
    <Modal
        isOpen={props.activeWindow == "workshopCapacityModal"}
        title="Capacidad de taller"
        footerJustifyContent="start"
        toggle={props.onClickActionButton}
        modalFooter={
            <Row className="align-items-center">
                <Col>
                    <Label className="text-uppercase m-0">Capacidad de taller</Label>
                </Col>
                <Col>
                    <Label className="h4 text-primary m-0">{`${
                        props.workshopCapacity.workShopCapacityFactor
                    } horas`}</Label>
                </Col>
            </Row>
        }
    >
        <div style={{ minHeight: 400 }}>
            <LabeledDateInput
                label="Fecha"
                value={props.workshopCapacityDate}
                onChange={props.onChangeDate}
                useUtcZero
            />
            <Grid
                items={props.workshopCapacity.operators}
                columns={[
                    {
                        header: "Código",
                        contentSelector: item => <span style={{ cursor: "pointer" }}>{item.code}</span>
                    },
                    {
                        header: "Nombre",
                        contentSelector: item => <span style={{ cursor: "pointer" }}>{item.name}</span>
                    },
                    {
                        header: "Horas",
                        contentSelector: item => item.availableHours
                    },
                    {
                        header: "",
                        contentSelector: item => (
                            <CircularButton
                                color="info"
                                isOutlined
                                icon="user-clock"
                                onClick={() => {
                                    props.onClickActionButton();
                                    goToPath(props.history, "absent/new", { operatorId: item.id });
                                }}
                            />
                        )
                    }
                ]}
            />
        </div>
    </Modal>
);

export default withRouter(WorkshopCapacityModal);
