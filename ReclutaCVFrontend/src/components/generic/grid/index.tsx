import * as React from "react";
import { Table } from "reactstrap";
import classnames from "classnames";

/**
 * Información que contendrá una columna del Grid
 */
interface GridColumn<TListable> {
    /**
     * Cabecera de la columna
     */
    header: string | React.ReactNode;
    /**
     * Selector del contenido que tendrá la columna en función del elemento que se dibuje sobre ella
     */
    contentSelector: (item: TListable, itemIndex: number) => string | number | JSX.Element;
    /**
     * Alineación del contenido
     */
    contentAlign?: "center" | "left";
}

interface GridProps<TListable> {
    readonly?: boolean;
    /**
     * Elementos que se dibujarán en el Grid
     */
    items: TListable[];
    /**
     * Columnas en función a las cuales se dibujará el Grid
     */
    columns: GridColumn<TListable>[];
    draggable?: boolean;
    onDragStart?: (e:React.DragEvent, item:TListable) => void;
    onDrop?: (e:React.DragEvent, item:TListable) => void;
    /**
     * Indica si se debe de retirar el margen del grid
     */
    removeMargin?: boolean;
    className?: string;
    overflow?: boolean;
    /**
     * Acción a ejecutar cuando se de doble clic
     */
    onItemDoubleClick?: (item: TListable) => void;
}

/**
 * Un Grid, representa lainformación definida en sus props en forma de cuadrícula
 */
export class Grid<TListable> extends React.Component<GridProps<TListable>> {

    onDragOver(e) {
        e.preventDefault();
    }

    /**
     * Renderiza una cuadrícula
     */
    render() {
        const table = (
            <Table 
                striped 
                className={classnames(this.props.className, { "m-0" : this.props.removeMargin})}
                size={"sm"}
            >
                <thead>
                    <tr>
                        {this.props.columns.map((column, columnIndex) => (
                            <th key={columnIndex} style={{ textAlign: "center" }}>
                                {
                                    column.header
                                }
                            </th>
                        ))}
                    </tr>
                </thead>
                <tbody>
                    {this.props.items.map((item, itemIndex) => (
                        <tr 
                            key={itemIndex} 
                            draggable={this.props.draggable && !this.props.readonly} 
                            onDragStart={(e)=>this.props.onDragStart(e, item)} 
                            onDragOver={(e)=>this.onDragOver(e)}
                            onDrop={(e)=>this.props.onDrop(e, item)} 
                            className={this.props.draggable && !this.props.readonly ? "draggable droppable" : null}
                            onDoubleClick={() => this.props.onItemDoubleClick(item)}
                        >
                            {this.props.columns.map((column, columnIndex) => (
                                <td
                                    style={{ verticalAlign: "middle", textAlign: column.contentAlign || "center" }}
                                    key={itemIndex + "-" + columnIndex}
                                >
                                    {column.contentSelector(item, itemIndex)}
                                </td>
                            ))}
                        </tr>
                    ))}
                </tbody>
            </Table>
        );

        return (
            this.props.overflow ? 
                <div style={{ overflowX: "auto" }}>
                    {table}
                </div> :
                table            
        );
    }
}
