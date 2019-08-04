import * as React from "react";
import { RouteComponentProps, withRouter } from "react-router";
import { readNumberPathParam, readBooleanRouteParam, goBack } from "../../helpers/navigation-helper";
import { ServiceErrorsHandler } from "../../communication/errors/service-errors-handler";
import { Diff } from "../../helpers/type-helper";
import { WithItemsComboLoaderProps } from "./with-items-combo-loader";
import { toPromise, TPromiseLike } from "../../helpers/promise-helper";

interface WithModelManagementState<TModel> {
    model?: TModel;
    isNewModel?: boolean;
    noEditable?: boolean;
    readonly?: boolean;
}

export interface WithModelManagementProps<TModel> extends RouteComponentProps {
    model: TModel;
    isNewModel: boolean;
    readonly: boolean;
    onSaveModel: () => TPromiseLike<void>;
    setModel: (model: Partial<TModel>) => void;
}

/**
 * 
 * @param Component Componente al cual se hará la inyección
 * @param getNewModel Método para obtener un nuevo modelo
 * @param findModelById Método para obtener un modelo a partir de su ID
 */
function withModelManagementSimple<TModel, ComponentProps extends WithModelManagementProps<TModel>>(
    Component: React.ComponentType<ComponentProps>,
    getNewModel: () => TPromiseLike<TModel>,
    findModelById: (id: number) => TPromiseLike<TModel>,
    onInsertModel: (model: TModel) => TPromiseLike<void>,
    onUpdateModel: (model: TModel) => TPromiseLike<void>
) {
    return class WithModelManagement extends React.Component<
    Diff<ComponentProps, WithItemsComboLoaderProps<TModel>> & RouteComponentProps, 
    WithModelManagementState<TModel>
    > {
        state: WithModelManagementState<TModel> = {}

        componentDidMount() {
            const id = readNumberPathParam(this.props.match, "id") || null;
            const readonly = readBooleanRouteParam(this.props.match, "readonly") || false;

            const isNewModel = id == null;

            const findModelWithIdOrNew = isNewModel ? getNewModel() : findModelById(id);

            return toPromise(findModelWithIdOrNew)
                .then(modelWithIdOrNew => {
                    this.setState({
                        model: modelWithIdOrNew,
                        isNewModel: isNewModel,
                        readonly: readonly
                    });
                });
        }

        private handleSaveModel = () => {
            const savePromise: TPromiseLike<number | void> =
                this.state.isNewModel ?
                    onInsertModel(this.state.model) :
                    onUpdateModel(this.state.model);

            toPromise(savePromise)
                .then(() => goBack(this.props.history));
        }

        private handleSetModel = (model: Partial<TModel>) =>
            this.setState(prevState => ({ 
                model: { ...prevState.model, ...model }
            }));

        render() {
            return (
                this.state.model != null ?
                    <Component
                        {...this.props as ComponentProps}
                        model={this.state.model}
                        isNewModel={this.state.isNewModel}
                        readonly={this.state.readonly}
                        onSaveModel={this.handleSaveModel}
                        setModel={this.handleSetModel}
                    /> :
                    null
            );
        }
    };
}

/**
 * 
 * @param component 
 * @param getNewModel Método para obtener un nuevo modelo
 * @param findModelById Método para obtener un modelo a partir de su ID
 * @param onSaveModel Determina lo que ocurre ante al momento en el que usuario da en guardar
 */
export function withModelLoading<TModel, ComponentProps extends WithModelManagementProps<TModel>>(
    component: React.ComponentType<ComponentProps>,
    getNewModel: () => TPromiseLike<TModel>,
    findModelById: (id: number) => TPromiseLike<TModel>,
    onInsertModel: (model: TModel) => TPromiseLike<void>,
    onUpdateModel: (model: TModel) => TPromiseLike<void>
) { return withRouter(withModelManagementSimple(component, getNewModel, findModelById, onInsertModel, onUpdateModel)); }