import * as React from "react";

import { LabeledTextInput, PasswordInput, LabeledStatusInput } from "../../../../generic";
import { Row } from "../../../common/row";
import {
    UserInsertable,
    UserUpdatable,
    UserConsultable
} from "../../../../../communication/dtos/user";
import { User } from "../../../../../communication/services";
import {
    WithModelManagementProps,
    withModelLoading
} from "../../../../hoc/with-model-loader";
import { EditCatalog } from "../../../base/edit-catalog";
import { RoleCombo } from "../combo/role-combo";
import { ConstHelper } from "../../../../../helpers/const-helper";
import { AdvisorCombo } from "../../advisors/combo/advisor-combo";
import { UserRole } from "../../../../../communication/enums/user-roles";


const service = User;

type TModelEditable = UserInsertable & UserUpdatable & UserConsultable;
interface UserEditState {
    model: TModelEditable;
}

class UserEditSimple extends React.Component<
WithModelManagementProps<TModelEditable>,
UserEditState
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
        this.refreshModelInState({ name });
    private setPassword = (password: string) =>
        this.refreshModelInState({ password });
    private setRole = (role: number) =>
        this.refreshModelInState({ role });
    private setActive = (active: boolean) =>
        this.refreshModelInState({ active });
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
                        value={this.state.model.name}
                        onChange={this.setName}
                        maxlength={ConstHelper.nameMaxLength}
                    />
                    <LabeledStatusInput
                        value={this.state.model.active}
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
                                value={this.state.model.password}
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
                        this.state.model.role == UserRole.Advisor ?
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

const getNewUser: () => TModelEditable = () => ({
    id: undefined,
    name: undefined,
    password: undefined,
    role: undefined,
    active: true,
    advisorId: undefined
});

export const UserEdit = withModelLoading<TModelEditable, WithModelManagementProps<TModelEditable>>(
    UserEditSimple,
    getNewUser,
    service.getById,
    service.insert,
    service.update
);
