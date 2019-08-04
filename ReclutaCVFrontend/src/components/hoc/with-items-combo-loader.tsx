import * as React from "react";
import { RouteComponentProps, withRouter, RouterProps } from "react-router";
import { readNumberQueryParam } from "../../helpers/navigation-helper";
import { TPromiseLike, toPromise } from "../../helpers/observable-helper";
import { PageResult } from "../../communication/dtos/page-result";
import { Diff } from "../../helpers/type-helper";
import { string } from "prop-types";

type TDefaultFilters = {};

interface WithItemsComboLoaderState<TListable, TFilters> {
    items?: TListable[];
    filters: Partial<TFilters>;
}

export interface WithItemsComboLoaderProps<TListable, TFilters = TDefaultFilters> extends RouterProps {
    items: TListable[];
    /**
     * Los elementos también podrían cambiar en memoria, no solo asincronamente
     * Para estos cambios, esta prop le permitirá a los componentes hijos notificar cuando hagan cambios al listado de elementos
     */
    onItemsChange: (items: TListable[]) => void;
    /**
     * Refresca los elementos del listado
     */
    refreshItems: () => TPromiseLike<void>;
    /**
     * Función que establece los filtros de la consulta
     */
    setFilters: (newFilters: TFilters) => TPromiseLike<void>;
    /**
     * Filtros actuales del listado
     */
    filters: Partial<TFilters>;
}

/**
 * 
 * @param Component Componente al cual se hará la inyección
 * @param getNewModel Método para obtener los nuevos elementos
 */
function withItemsComboLoadingSimple<TListable, TFilters, ComponentProps extends WithItemsComboLoaderProps<TListable, TFilters>>(
    Component: React.ComponentType<ComponentProps>,
    getItems: (filters?: Partial<TFilters>) => TPromiseLike<TListable[]>
) {

    return class WithItemsComboLoading extends React.Component<
    Diff<ComponentProps, WithItemsComboLoaderProps<TListable, TFilters>>, 
    WithItemsComboLoaderState<TListable, TFilters>
    > {
        state: WithItemsComboLoaderState<TListable, TFilters> = {
            filters: {}
        }

        componentIsMounted: boolean;

        componentDidMount() {
            this.componentIsMounted = true;
            this.refreshItemsWithCurrentState();
        }

        componentWillUnmount() {
            this.componentIsMounted = false;
        }

        private refreshItemsWithCurrentState = () => 
            this.refreshItems(this.state.filters);
        
        private refreshItemsWithNewFilters = (filters: Partial<TFilters>) => 
            this.setState(prevState => ({
                filters: { ...prevState.filters, ...filters }
            }), 
            () => this.refreshItemsWithCurrentState()
            );

        /**
         * Refresca los elementos del listado
         * @param pageNumberZeroBased 
         * @param pageSize 
         */
        private refreshItems = (
            filters: Partial<TFilters>
        ) => {
            toPromise(
                getItems(filters)
            ).subscribe(items => {
                if(this.componentIsMounted){
                    this.setState({ items: items });
                }
            });
        }

        /**
         * Maneja el cambio de items en memoria
         */
        private handleItemsChange = (items: TListable[]) => 
            this.setState({ items: items });
        
        render() {
            return (
                this.state.items != null ?
                    <Component 
                        {...this.props as ComponentProps} 
                        items={ this.state.items }
                        onItemsChange={ this.handleItemsChange }
                        refreshItems={ this.refreshItemsWithCurrentState }
                        setFilters={this.refreshItemsWithNewFilters}
                        filters={this.state.filters}
                    /> :
                    null
            );
        }
    };
}

/**
 * 
 * @param component 
 * @param getItems Función que obtiene una página de elementos
 * @param deleteItem Función que se encarga de borrar el elemento indicado
 */
export function withItemsComboLoading<TListable, ComponentProps extends WithItemsComboLoaderProps<TListable, TFilters>, TFilters = TDefaultFilters>(
    component: React.ComponentType<ComponentProps>,
    getItems: (filters?: Partial<TFilters>) => TPromiseLike<TListable[]>
) { return withItemsComboLoadingSimple(component, getItems); }