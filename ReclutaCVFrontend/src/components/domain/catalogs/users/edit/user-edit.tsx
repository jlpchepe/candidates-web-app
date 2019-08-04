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
import { ConstHelper } from "../../../../../helpers/const-helper";


const service = Usuario;

type TModelEditable = UsuarioInsertable & UsuarioUpdatable & UsuarioConsultable;

class UsuarioEditSimple extends React.Component<
WithModelManagementProps<TModelEditable>
> {     
    private setName = (nombre: string) =>
        this.props.setModel({ nombre });
    private setPassword = (contraseña: string) =>
        this.props.setModel({ contraseña });
    private setActive = (activo: boolean) =>
        this.props.setModel({ activo });

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
                        this.props.isNewModel ?  
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
