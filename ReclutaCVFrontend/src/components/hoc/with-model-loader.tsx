import * as React from "react";
import { RouteComponentProps, withRouter } from "react-router";
import { readNumberPathParam, readBooleanRouteParam, goBack } from "../../helpers/navigation-helper";
import { TObservableLike, toObservable } from "../../helpers/observable-helper";
import { ServiceErrorsHandler } from "../../communication/errors/service-errors-handler";
import { Diff } from "../../helpers/type-helper";
import { WithItemsComboLoaderProps } from "./with-items-combo-loader";

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
    onSaveModel: (model: TModel) => TObservableLike<void>;
}

/**
 * 
 * @param Component Componente al cual se hará la inyección
 * @param getNewModel Método para obtener un nuevo modelo
 * @param findModelById Método para obtener un modelo a partir de su ID
 */
function withModelManagementSimple<TModel, ComponentProps extends WithModelManagementProps<TModel>>(
    Component: React.ComponentType<ComponentProps>,
    getNewModel: () => TObservableLike<TModel>,
    findModelById: (id: number) => TObservableLike<TModel>,
    onInsertModel: (model: TModel) => TObservableLike<void>,
    onUpdateModel: (model: TModel) => TObservableLike<void>
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

            return toObservable(findModelWithIdOrNew)
                .subscribe(modelWithIdOrNew => {
                    this.setState({
                        model: modelWithIdOrNew,
                        isNewModel: isNewModel,
                        readonly: readonly
                    });
                });
        }

        private handleSaveModel = (model: TModel) => {
            const savePromise: TObservableLike<number | void> =
                this.state.isNewModel ?
                    onInsertModel(model) :
                    onUpdateModel(model);

            toObservable(savePromise)
                .subscribe(() => goBack(this.props.history));
        }

        render() {
            return (
                this.state.model != null ?
                    <Component
                        {...this.props as ComponentProps}
                        model={this.state.model}
                        isNewModel={this.state.isNewModel}
                        readonly={this.state.readonly}
                        onSaveModel={this.handleSaveModel}
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
    getNewModel: () => TObservableLike<TModel>,
    findModelById: (id: number) => TObservableLike<TModel>,
    onInsertModel: (model: TModel) => TObservableLike<void>,
    onUpdateModel: (model: TModel) => TObservableLike<void>
) { return withRouter(withModelManagementSimple(component, getNewModel, findModelById, onInsertModel, onUpdateModel)); }