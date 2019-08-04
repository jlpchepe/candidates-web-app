import * as React from "react";

import { LabeledTextInput, PasswordInput, LabeledStatusInput } from "../../../../generic";
import { Row } from "../../../common/row";
import {
    UsuarioInsertable,
    UsuarioUpdatable,
    UsuarioConsultable
} from "../../../../../communication/dtos/user";
import { Usuario } from "../../../../../communication/services";
import {
    WithModelManagementProps,
    withModelLoading
} from "../../../../hoc/with-model-loader";
import { EditCatalog } from "../../../base/edit-catalog";
import { RoleCombo } from "../combo/role-combo";
import { ConstHelper } from "../../../../../helpers/const-helper";
import { AdvisorCombo } from "../../advisors/combo/advisor-combo";
import { UsuarioRole } from "../../../../../communication/enums/user-roles";


const service = Usuario;

type TModelEditable = UsuarioInsertable & UsuarioUpdatable & UsuarioConsultable;
interface UsuarioEditState {
    model: TModelEditable;
}

class UsuarioEditSimple extends React.Component<
WithModelManagementProps<TModelEditable>,
UsuarioEditState
> {
    constructor(props) {
        super(props);
        this.state = {
            model: this.props.model
        };
    }

    private refreshModelInState = (model: Partial<TModelEditable>) => {
        this.setState(prevState => ({ 
            model: { ...prevState.model, ...model }
        }));
    }
        
    private setName = (name: string) =>
        this.refreshModelInState({ nombre });
    private setPassword = (password: string) =>
        this.refreshModelInState({ contraseña });
    private setRole = (role: number) =>
        this.refreshModelInState({ role });
    private setActive = (active: boolean) =>
        this.refreshModelInState({ activo });
    private setAdvisorId = (advisorId: number) =>
        this.refreshModelInState({ advisorId });

    private handleOnSave = () => this.props.onSaveModel(this.state.model);

    render() {
        return (
            <EditCatalog
                title="Usuario"
                readonly={this.props.readonly}
                onSave={this.handleOnSave}
            >
                <Row>
                    <LabeledTextInput
                        label="Nombre"
                        readonly={this.props.readonly}
                        required
                        value={this.state.model.nombre}
                        onChange={this.setName}
                        maxlength={ConstHelper.nameMaxLength}
                    />
                    <LabeledStatusInput
                        value={this.state.model.activo}
                        onChange={this.setActive}
                        readonly={this.props.readonly}
                        required={true}
                    >
                    </LabeledStatusInput>
                </Row>
                <Row>
                    {
                        this.props.isNewModel ?  
                            //usuario nuevo
                            <PasswordInput
                                label="Contraseña"
                                readonly={this.props.readonly}
                                required
                                value={this.state.model.contraseña}
                                onChange={this.setPassword}
                            /> :
                            null 
                    }
                    <RoleCombo
                        value={this.state.model.role}
                        required
                        readonly={this.props.readonly}
                        onValueChange={this.setRole}
                    />
                    {
                        this.state.model.role == UsuarioRole.Advisor ?
                            <AdvisorCombo
                                label="Asesor"
                                idSelected={this.state.model.advisorId}
                                onIdSelectedChange={this.setAdvisorId}
                                readonly={this.props.readonly}
                                required
                            >
                            </AdvisorCombo> : 
                            null
                    }
                </Row>
            </EditCatalog>
        );
    }
}

const getNewUsuario: () => TModelEditable = () => ({
    id: undefined,
    nombre: undefined,
    contraseña: undefined,
    role: undefined,
    activo: true,
    advisorId: undefined
});

export const UsuarioEdit = withModelLoading<TModelEditable, WithModelManagementProps<TModelEditable>>(
    UsuarioEditSimple,
    getNewUsuario,
    service.getById,
    service.insert,
    service.update
);
