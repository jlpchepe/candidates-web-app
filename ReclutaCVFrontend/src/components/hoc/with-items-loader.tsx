import * as React from "react";
import { RouteComponentProps, withRouter, RouterProps } from "react-router";
import { readNumberQueryParam } from "../../helpers/navigation-helper";
import { PageResult } from "../../communication/dtos/page-result";
import { Diff } from "../../helpers/type-helper";
import { WithItemsComboLoaderProps } from "./with-items-combo-loader";
import { TPromiseLike, toPromise } from "../../helpers/promise-helper";

type TDefaultFilters = {};

interface WithItemsLoaderState<TListable, TFilters> {
    items?: TListable[];
    pageNumber?: number;
    pageSize?: number;
    totalPages?: number;
    filters: Partial<TFilters>
}

export interface WithItemsLoaderProps<TListable, TFilters = TDefaultFilters> extends RouterProps {
    items: TListable[];
    /**
     * Los elementos también podrían cambiar en memoria, no solo asincronamente
     * Para estos cambios, esta prop le permitirá a los componentes hijos notificar cuando hagan cambios al listado de elementos
     */
    onItemsChange: (items: TListable[]) => void,
    pageNumber: number;
    pageSize: number;
    totalPages: number;
    /**
     * Evento que ocurrirá cuando se cambie la página
     */
    onPageChange: (pageNumber: number) => void;
    onDeleteItem?: (item: TListable) => void;
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

const defaultPageNumber = 0;
const defaultPageSize = 15;

/**
 * 
 * @param Component Componente al cual se hará la inyección
 * @param getNewModel Método para obtener los nuevos elementos
 */
function withItemsLoadingSimple<TListable, TFilters, ComponentProps extends WithItemsLoaderProps<TListable, TFilters>>(
    Component: React.ComponentType<ComponentProps>,
    getItems: (pageNumberZeroBased: number, pageSize: number, filters?: Partial<TFilters>) => TPromiseLike<PageResult<TListable>>,
    deleteItem?: (item: TListable) => TPromiseLike<void>
) {
    return class WithItemsLoading extends React.Component<
    Diff<ComponentProps, WithItemsComboLoaderProps<TListable, TFilters>> & RouteComponentProps,
    WithItemsLoaderState<TListable, TFilters>
    > {
        state: WithItemsLoaderState<TListable, TFilters> = {
            filters: {}
        }

        componentDidMount() {
            const pageNumberZeroBased = readNumberQueryParam(this.props.location, "pageNumber") || defaultPageNumber;

            this.refreshItemsWithCurrentFilters(pageNumberZeroBased);
        }

        componentIsMounted = true;

        componentWillUnmount() {
            this.componentIsMounted = false;
        }

        private refreshItemsWithCurrentState: () => TPromiseLike<void> = () =>
            this.refreshItems(this.state.pageNumber, this.state.filters);

        private refreshItemsWithCurrentFilters = (pageNumber: number) =>
            this.setState(
                { pageNumber },
                () => this.refreshItemsWithCurrentState()
            );

        private refreshItemsWithCurrentPageNumber = (filters: TFilters) =>
            this.setState(
                { filters },
                () => this.refreshItemsWithCurrentState()
            );

        /**
         * Refresca los elementos del listado
         * @param pageNumberZeroBased 
         * @param pageSize 
         */
        private refreshItems = (
            pageNumberZeroBased: number,
            filters: Partial<TFilters>
        ) : TPromiseLike<void> => {
            const pageSize = readNumberQueryParam(this.props.location, "pageSize") || defaultPageSize;

            return toPromise(
                getItems(
                    pageNumberZeroBased,
                    pageSize,
                    filters
                )
            ).then(page => {
                if (this.componentIsMounted) {
                    this.setState({
                        items: page.items,
                        pageNumber: pageNumberZeroBased,
                        pageSize: pageSize,
                        totalPages: page.totalPages
                    });
                }
            });
        }

        /**
         * Maneja el cambio de items en memoria
         */
        private handleItemsChange = (items: TListable[]) =>
            this.setState({ items: items });
        /**
         * Maneja el borrado de items 
         */
        private handleDeleteItem = deleteItem != null ?
            (item : TListable) => toPromise(
                    deleteItem(item)
                ).then(() => {
                    this.refreshItemsWithCurrentFilters(this.state.pageNumber);
                }) :
            null;

        render() {
            return (
                this.state.items != null ?
                    <>
                        <Component
                            {...this.props as any}
                            items={this.state.items}
                            pageNumber={this.state.pageNumber}
                            pageSize={this.state.pageSize}
                            totalPages={this.state.totalPages}
                            onPageChange={this.refreshItemsWithCurrentFilters}
                            onItemsChange={this.handleItemsChange}
                            onDeleteItem={this.handleDeleteItem}
                            refreshItems={this.refreshItemsWithCurrentState}
                            setFilters={this.refreshItemsWithCurrentPageNumber}
                            filters={this.state.filters}
                        />
                    </>
                    :
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
export function withItemsLoading<TListable, TFilters = TDefaultFilters, ComponentProps extends WithItemsLoaderProps<TListable, TFilters> = WithItemsLoaderProps<TListable, TFilters>>(
    component: React.ComponentType<ComponentProps>,
    getItems: (pageNumberZeroBased: number, pageSize: number, filters?: Partial<TFilters>) => TPromiseLike<PageResult<TListable>>,
    deleteItem?: (item: TListable) => TPromiseLike<void>
) { return withRouter(withItemsLoadingSimple(component, getItems, deleteItem)); }