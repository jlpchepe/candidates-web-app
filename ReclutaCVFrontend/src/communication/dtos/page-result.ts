/**
 * Un resultado de una consulta con paginación
 */
export interface PageResult<TListable> {
    /**
     * Elementos que se encontraron en la página que se solicitó
     */
    items: TListable[],
    /**
     * Número total de páginas
     */
    totalPages: number
}