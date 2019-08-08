import * as React from "react";
import { Grid, CircularButton, Button, Icon, Container } from "../../generic";
import { ApplicationAvailableIcon, ApplicationAvailableColor } from "../../generic/look-and-feel/resources";
import { PageHeader } from "../common/page-header";
import { Pager } from "../../generic/pager";
import { ArrayHelper } from "../../../helpers/array-helper";
import { Column } from "../common/column";

interface ListCatalogColumn<TListable> {
    header: string | React.ReactNode;
    contentSelector: (item: TListable, itemIndex: number) => string | number | JSX.Element;
    contentAlign?: "center" | "left";
}

/**
 * Propiedades que requiere la funcionalidad de cambio de estatus en el listado
 */
interface ChangeStatusProps<TListable> {
    /**
     * Función a ejecutar cuando se cambie el estatus
     * Debe regresar el nuevo estatus
     */
    changeStatus: (item: TListable) => Promise<boolean>;
    /**
     * Propiedad de los elementos que se listan que indica el estatus
     * Debe ser de tipo boolean
     */
    statusProp: keyof TListable;
    /**
     * Función que se llamará cuando se termine el cambio de estatus de algun elemento
     */
    onItemsChange: (items: TListable[]) => void;
}

interface ListCatalogButton<TListable> {
    icon: ApplicationAvailableIcon;
    color: ApplicationAvailableColor;
    onClick: (item: TListable) => void;
    isDisabled?: (item: TListable) => boolean;
    /**
     * Mensaje que se mostrará en el tooltip
     */
    tooltip: string;
}

interface ListCatalogProps<TListable> {
    title: string;
    /**
	 * Número de página basado en cero
	 */
    pageNumber: number;
    /**
	 * Número de elementos que se mostrarán por cada página
	 */
    pageSize: number;
    /**
	 * Elementos que se listarán
	 */
    items: TListable[];
    /**
	 * Páginas totales
	 */
    totalPages: number;
    /**
     * Functión que se ejecutará cuando se ha seleccionado una página nueva
     */
    onPageChange: (pageNumber: number) => void;
    /**
	 * Función a ejecutar cuando el usuario dé clic en nuevo elemento
	 */
    onNewItem?: () => void;
    /**
	 * Columnas que se mostrarán en la tabla
	 */
    columns: ListCatalogColumn<TListable>[];
    /**
     * Botones adicionales que se dibujaran en el candidato
     */
    itemsExtraButtons: ListCatalogButton<TListable>[];
    /**
	 * Función que se ejecutará cada vez que los elementos se terminen de cargar
	 */
    onItemsLoaded?: (loadedItems: TListable[]) => void;
    /**
	 * Función a ejecutar cuando se de clic sobre un elemento
	 */
    onItemClick?: (item: TListable) => void;
    /**
	 * Función a ejecutar cuando se de clic en editar un elemento
	 */
    onItemEdit?: (item: TListable) => void;
    /**
	 * Función a ejecutar cuando se dé clic en consultar un elemento
	 */
    onItemSeeDetails?: (item: TListable) => void;
    /**
	 * Función a ejecutar cuando se dé clic en eliminar un elemento
	 */
    onItemDelete?: (item: TListable) => void;
    /**
     * Función a ejecutar cuando se desee cambiar de estatus un elemento
     */
    onItemChangeStatus?: ChangeStatusProps<TListable>;
    /**
     * Filtros a colocar para el listado
     */
    filters?: JSX.Element;
    /**
     * Botones adicionales que se mostrarán en el listado
     */
    extraButtons?: JSX.Element;

    overflow? : boolean;

    containerFluid?: boolean;
}

/**
 * Componente para mostrar un catálogo
 */
class ListCatalogSimple<TListable> extends React.Component<ListCatalogProps<TListable>> {

    /**
	 * Convierte la función selector indicada a un botón circular, si la función no está definida, regresa null
	 * @param selectorFunctionOrNull
	 * @param item
	 */
    private convertFunctionToCircularButton = (
        selectorFunctionOrNull: (item: TListable) => void,
        item: TListable,
        icon: ApplicationAvailableIcon,
        color: ApplicationAvailableColor,
        tooltipMessage: string,
        tooltipIdPrefix: string,
        itemIndex: number
    ): JSX.Element => {
        return selectorFunctionOrNull != null ? (
            <div className="mx-1"
                key={`${itemIndex}${tooltipIdPrefix}`}
            >
                <CircularButton
                    isOutlined
                    icon={icon}
                    color={color}
                    tooltip={{
                        id: tooltipIdPrefix + itemIndex,
                        message: tooltipMessage
                    }}
                    onClick={() => selectorFunctionOrNull(item)}
                />
            </div>
        ) : null;
    }

    /**
     * Genera el botón de cambio de estatus
     * Si entre las props no está especificado lo que se hará al cambiar el estatus, se regresa null
     */
    private generateChangeStatusButton = (item: TListable, itemIndex: number) => {
        if (this.props.onItemChangeStatus == null) {
            return null;
        }

        const itemIsActive = item[this.props.onItemChangeStatus.statusProp];

        //Una vez que se cambie el estatus, se cambia también en memoria
        const changeStatus = () =>
            this.props.onItemChangeStatus.changeStatus(item)
                .then(newStatus =>
                    this.props.onItemChangeStatus.onItemsChange(
                        // Se reemplaza el elemento por el que tiene el nuevo estatus
                        ArrayHelper.replace(
                            this.props.items,
                            item,
                            { ...item, [this.props.onItemChangeStatus.statusProp]: newStatus }
                        )
                    )
                );

        return this.convertFunctionToCircularButton(
            changeStatus,
            item,
            itemIsActive ? "toggle-on" : "toggle-off",
            "secondary",
            itemIsActive ? "Desactivar" : "Activar",
            "btn_changeStatus",
            itemIndex
        );
    }

    private generateCrudButtons = () => {
        const crudButtons: ListCatalogColumn<TListable> = {
            header: <Icon icon="bolt" />,
            contentSelector: (item, itemIndex) => (
                <Container flex>
                    {
                        this.props.itemsExtraButtons && 
                        this.props.itemsExtraButtons.map(button => 
                            this.convertFunctionToCircularButton(
                                button.isDisabled != null && button.isDisabled(item) ? null : button.onClick,
                                item,
                                button.icon,
                                button.color,
                                button.tooltip,
                                "btn_esp" + button.tooltip.replace(" ", ""),
                                itemIndex
                            )
                        )
                    }
                    {this.convertFunctionToCircularButton(
                        this.props.onItemEdit,
                        item,
                        "edit",
                        "info",
                        "Editar",
                        "btn_edit",
                        itemIndex
                    )}
                    {this.generateChangeStatusButton(item, itemIndex)}
                    {this.convertFunctionToCircularButton(
                        this.props.onItemDelete,
                        item,
                        "trash",
                        "danger",
                        "Eliminar",
                        "btn_delete",
                        itemIndex
                    )}
                </Container>
            )
        };

        return [crudButtons];
    }

    render() {
        const columnsToShow = this.generateCrudButtons().concat(this.props.columns);

        // Si el número de páginas es cero, se establece en uno
        const fixedTotalPages = this.props.totalPages > 0 ? this.props.totalPages : 1;

        return (
            <Container 
                fluid={this.props.containerFluid}
                container={!this.props.containerFluid}
            >
                <PageHeader
                    title={this.props.title}
                    extraButtons={
                        <>
                            {
                                this.props.onNewItem &&
                                <Column className="px-1">
                                    <Button color="info" label="Nuevo" onClick={this.props.onNewItem} />
                                </Column>
                            }
                            {
                                this.props.extraButtons
                            }
                        </>
                    }
                />
                {this.props.filters}
                <Grid 
                    items={this.props.items} 
                    overflow={this.props.overflow} 
                    columns={columnsToShow} 
                    onItemDoubleClick={this.props.onItemEdit}
                    removeMargin 
                />
                <Pager
                    totalDisplayed={5}
                    rightAlign
                    totalPages={fixedTotalPages}
                    pageNumberZeroBased={this.props.pageNumber}
                    onPageChange={this.props.onPageChange}
                />
            </Container>
        );
    }
}

export const ListCatalog = ListCatalogSimple;
