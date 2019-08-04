import * as React from "react";

import { LabeledTextAreaInput, LabeledCombo } from "../../../../generic";
import { Row } from "../../../common/row";
import { AbsentInsertable, AbsentUpdatable, AbsentConsultable } from "../../../../../communication/dtos/absent";
import { EditCatalog } from "../../../base/edit-catalog";
import { WithModelManagementProps, withModelLoading } from "../../../../hoc/with-model-loader";
import { OperatorCombo } from "../../operator/combo/operator-combo";
import { Absent } from "../../../../../communication/services";
import { LabeledDateInput, LabeledNumberInput } from "../../../../generic/input";
import { Column } from "../../../common/column";
import { addDays } from "date-fns/esm";

const service = Absent;

type TModelEditable = AbsentInsertable & AbsentUpdatable & AbsentConsultable;

interface AbsentEditState {
    model: TModelEditable;
    absentType: number;
}

class AbsentEditSimple extends React.Component<WithModelManagementProps<TModelEditable>, AbsentEditState> {
    constructor(props) {
        super(props);

        this.state = {
            model: {
                ...this.props.model,
                // El ID del operador podría venir desde el state del router como redirección desde la capacidad del taller,
                // en caso de que no venga de ahí se establece desde el props.model
                operatorId:
                    this.props.location.state != null
                        ? this.props.location.state.operatorId
                        : this.props.model.operatorId
            },
            absentType: null
        };
    }

    componentDidMount() {
        const absentType = this.props.model.hoursOfAbsent ? 1 : this.props.model.dueDate ? 2 : null;
        this.setState({ absentType });
    }

    private setReason = (reason: string) => this.refreshModelInState({ ...this.state.model, reason });

    private setStartDate = (startDate: Date) => this.refreshModelInState({ ...this.state.model, startDate });

    private setOperatorId = (operatorId: number) => this.refreshModelInState({ ...this.state.model, operatorId });

    private setDueDate = (dueDate: Date) => this.refreshModelInState({ ...this.state.model, dueDate, hoursOfAbsent: null });

    private refreshModelInState = (model: TModelEditable) => this.setState({ model });

    private handleOnSave = () => this.props.onSaveModel(this.state.model);

    private onChangeAbsentType = (absentType: number) => this.setState({ absentType });

    private onChangeHours = (hoursOfAbsent: number) => this.refreshModelInState({ ...this.state.model, hoursOfAbsent, dueDate: null });

    render() {
        return (
            <EditCatalog title="Ausencia" readonly={this.props.readonly} onSave={this.handleOnSave}>
                <Row>
                    <Column >
                        <OperatorCombo
                            label="Operador"
                            idSelected={this.state.model.operatorId}
                            onIdSelectedChange={this.setOperatorId}
                            readonly={this.props.readonly || !this.props.isNewModel}
                            required
                        />
                    </Column>
                    <Column >
                        <LabeledCombo
                            items={[{ value: 1, description: "Mismo día" }, { value: 2, description: "Rango de fechas" }]}
                            label="Tipo de ausencia"
                            readonly={this.props.readonly || !this.props.isNewModel}
                            required
                            valueSelector={item => item.value}
                            descriptionSelector={item => item.description}
                            valueSelected={this.state.absentType}
                            onValueAsNumberChange={this.onChangeAbsentType}
                        /> 
                        
                    </Column>
                </Row>
                {this.state.absentType === 1 && <>
                    <Row>
                        <LabeledDateInput
                            label="Fecha inicio"
                            value={this.state.model.startDate}
                            onChange={this.setStartDate}
                            readonly={this.props.readonly}
                            maxDate={this.state.model.dueDate}
                            required
                            useUtcZero
                        />
                        <LabeledNumberInput
                            label="Horas de ausencia"
                            value={this.state.model.hoursOfAbsent}
                            onChange={this.onChangeHours}
                            readonly={this.props.readonly}
                            required />
                    </Row>
                    <Row>
                        <LabeledTextAreaInput
                            label="Motivo"
                            value={this.state.model.reason}
                            onChange={this.setReason}
                            readonly={this.props.readonly}
                            required
                        />
                    </Row>
                </>
                }
                {
                    this.state.absentType === 2 && <>
                        <Row>
                            <LabeledDateInput
                                label="Fecha inicio"
                                value={this.state.model.startDate}
                                onChange={this.setStartDate}
                                readonly={this.props.readonly}
                                maxDate={this.state.model.dueDate}
                                required
                                useUtcZero
                            />
                            <LabeledDateInput
                                label="Fecha fin"
                                value={this.state.model.dueDate}
                                onChange={this.setDueDate}
                                readonly={this.props.readonly}
                                minDate={this.state.model.startDate}
                                useUtcZero
                                required
                            />
                        </Row>
                        <Row>
                            <LabeledTextAreaInput
                                label="Motivo"
                                value={this.state.model.reason}
                                onChange={this.setReason}
                                readonly={this.props.readonly}
                                required
                            />
                        </Row>
                    </>
                }
            </EditCatalog>
        );
    }
}

const getNewAbsent: () => TModelEditable = () => ({
    dueDate: undefined,
    id: undefined,
    operatorId: undefined,
    reason: undefined,
    startDate: undefined,
    hoursOfAbsent: undefined
});

export const AbsentEdit = withModelLoading(
    AbsentEditSimple,
    getNewAbsent,
    service.getById,
    service.insert,
    service.update
);
