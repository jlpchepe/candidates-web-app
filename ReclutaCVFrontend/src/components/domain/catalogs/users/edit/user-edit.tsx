import * as React from "react";

import { LabeledTextInput, PasswordInput, LabeledStatusInput, Checkbox } from "../../../../generic";
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
import { ConstHelper } from "../../../../../helpers/const-helper";


const service = Usuario;

type TModelEditable = UsuarioInsertable & UsuarioUpdatable & UsuarioConsultable;

interface UserEditState {
    modifyPassword: boolean;
}

class UsuarioEditSimple extends React.Component<
WithModelManagementProps<TModelEditable>,
UserEditState
> {
    state: UserEditState = {
        modifyPassword: false
    }

    private setName = (nombre: string) =>
        this.props.setModel({ nombre });
    private setPassword = (contraseña: string) =>
        this.props.setModel({ contraseña });
    private setActive = (activo: boolean) =>
        this.props.setModel({ activo });

    private handleModifyPasswordChanged = (modifyPassword: boolean) => {
        this.setState({ modifyPassword });

        if(!modifyPassword){
            this.setPassword(null);
        }
    }


    render() {
        return (
            <EditCatalog
                title="Usuario"
                readonly={this.props.readonly}
                onSave={this.props.onSaveModel}
            >
                <Row>
                    <LabeledTextInput
                        label="Nombre"
                        readonly={this.props.readonly}
                        required
                        value={this.props.model.nombre}
                        onChange={this.setName}
                        maxlength={ConstHelper.nameMaxLength}
                    />
                    <LabeledStatusInput
                        value={this.props.model.activo}
                        onChange={this.setActive}
                        readonly={this.props.readonly}
                        required={true}
                    >
                    </LabeledStatusInput>
                </Row>
                <Row>
                    {
                        !this.props.isNewModel ?
                            <Checkbox
                                id="modify"
                                label="Modificar contraseña"
                                checked={this.state.modifyPassword}
                                onChange={this.handleModifyPasswordChanged}
                            >
                            </Checkbox> : 
                            null
                    }
                    {
                        this.props.isNewModel || this.state.modifyPassword ?  
                            //usuario nuevo
                            <PasswordInput
                                label="Contraseña"
                                readonly={this.props.readonly}
                                required
                                value={this.props.model.contraseña}
                                onChange={this.setPassword}
                            /> :
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
    activo: true
});

export const UsuarioEdit = withModelLoading<TModelEditable, WithModelManagementProps<TModelEditable>>(
    UsuarioEditSimple,
    getNewUsuario,
    service.getById,
    service.insert,
    service.update
);
