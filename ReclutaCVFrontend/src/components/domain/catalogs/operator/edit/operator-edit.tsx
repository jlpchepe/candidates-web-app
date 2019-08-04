import * as React from "react";

import { LabeledTextInput, LabeledNumberInput, LabeledStatusInput } from "../../../../generic";
import { Row } from "../../../common/row";
import {
    OperatorInsertable,
    OperatorUpdatable,
    OperatorConsultable
} from "../../../../../communication/dtos/operator";
import { Operator } from "../../../../../communication/services";
import { EditCatalog } from "../../../base/edit-catalog";
import {
    WithModelManagementProps,
    withModelLoading
} from "../../../../hoc/with-model-loader";
import { EmployeeTypeCombo } from "../../employee-types/combo/employee-type-combo";
import { MechanicLevelCombo } from "../../employee-types/combo/mechanic-level-combo";
import { WorkstationCombo } from "../../workstation/combo/workstation-combo";
import { ConstHelper } from "../../../../../helpers/const-helper";
import { MechanicLevel } from "../../../../../communication/enums/mechanic-level";
import { EmployeeType } from "../../../../../communication/enums/employee-type";

const service = Operator;

type TModelEditable =
    OperatorInsertable &
    OperatorUpdatable &
    OperatorConsultable;

interface OperatorEditState {
    model: TModelEditable;
}

class OperatorEditSimple extends React.Component<WithModelManagementProps<TModelEditable>, OperatorEditState> {
    constructor(props) {
        super(props);

        this.state = {
            model: this.props.model
        };
    }

    private setName = (name: string) =>
        this.refreshModelInState({ ...this.state.model, name });

    private setEmployeeType = (employeeType: number) => {
        this.refreshModelInState({ ...this.state.model, employeeType });
    }
    private setMechanicLevel = (mechanicLevel: MechanicLevel) => {
        this.refreshModelInState({ ...this.state.model, mechanicLevel });
    }
    private setWorkstation = (workstationId: number) => {
        this.refreshModelInState({ ...this.state.model, workstationId });
    }
    private setCode = (code: number) =>
        this.refreshModelInState({ ...this.state.model, code });
    private setActive = (active: boolean) =>
        this.refreshModelInState({ ...this.state.model, active });
    private refreshModelInState = (model: TModelEditable) => {
        this.setState({ model: model });
    }
    private handleOnSave = () => this.props.onSaveModel(this.state.model);

    render() {
        return (
            <EditCatalog
                title="Operador"
                readonly={this.props.readonly}
                onSave={this.handleOnSave}
            >
                <Row>
                    <LabeledNumberInput
                        label="Código"
                        value={this.state.model.code}
                        onChange={this.setCode}
                        readonly={!this.props.isNewModel}
                        required
                        integer
                    />
                    <LabeledTextInput
                        label="Nombre"
                        value={this.state.model.name}
                        onChange={this.setName}
                        readonly={this.props.readonly}
                        required
                        maxlength={ConstHelper.nameMaxLength}
                    />
                    <LabeledStatusInput
                        value={this.state.model.active}
                        onChange={this.setActive}
                        readonly={this.props.readonly}
                        required={true}
                    />
                </Row>
                <Row>
                    <EmployeeTypeCombo
                        value={this.state.model.employeeType}
                        onValueChange={this.setEmployeeType}
                        readonly={this.props.readonly}
                        required
                    />
                    {
                        this.state.model.employeeType == EmployeeType.Mechanic ?
                            <MechanicLevelCombo
                                value={this.state.model.mechanicLevel}
                                onValueChange={this.setMechanicLevel}
                                readonly={this.props.readonly}
                                required
                            /> :
                            null
                    }

                    <WorkstationCombo
                        includedId={this.state.model.workstationId}
                        idSelected={this.state.model.workstationId}
                        onIdSelectedChange={this.setWorkstation}
                        label="Estaciones de trabajo"
                        readonly={this.props.readonly}
                        required
                    />
                </Row>
            </EditCatalog>
        );
    }
}

const getNewOperator: () => TModelEditable = () => ({
    id: undefined,
    name: undefined,
    code: undefined,
    employeeType: undefined,
    mechanicLevel: undefined,
    workstationId: undefined,
    workstationName: undefined,
    active: true
});

export const OperatorEdit = withModelLoading(
    OperatorEditSimple,
    getNewOperator,
    service.getById,
    service.insert,
    service.update
);
