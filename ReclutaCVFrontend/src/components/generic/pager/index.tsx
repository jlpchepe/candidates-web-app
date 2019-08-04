import React from "react";
import { Pagination, PaginationItem, PaginationLink } from "reactstrap";

interface PagerProps {
    /**
     * Número de página basado en cero
     */
    pageNumberZeroBased: number;
    totalPages: number;
    /**
     * Número de páginas mostradas
     */
    totalDisplayed: number;
    /**
     * Evento que se dispara cuando se cambia la página
     * El número es basado en cero
     */
    onPageChange?: (pageNumber: number) => void;
    rightAlign?: boolean;
}

/**
 * Paginador de elementos en un listado
 */
export const Pager: React.FC<PagerProps> = props => {
    const calculateTheNumbers = (
        currentPage: number,
        totalPages: number,
        paginationLength: number
    ) => {
        const calculatedPagesLength =
            totalPages > paginationLength
                ? paginationLength
                : totalPages;

        const pagesBeforeAfterCurrentPage = Math.floor(calculatedPagesLength / 2);

        let pageToStart = 1;

        // La página actual está cerca del inicio
        if (currentPage - pagesBeforeAfterCurrentPage < 1) {
            pageToStart = 1;
        }
        // La página actual está cerca del final
        else if (currentPage + pagesBeforeAfterCurrentPage > totalPages) {
            pageToStart = totalPages - calculatedPagesLength + 1;
        }
        // La página actual está en algún lugar de en medio
        else {
            pageToStart = currentPage - pagesBeforeAfterCurrentPage;
        }

        return Array.from({ length: calculatedPagesLength }, () => pageToStart++);
    };

    const pagesItems = calculateTheNumbers(props.pageNumberZeroBased + 1, props.totalPages, props.totalDisplayed);
    return (
        <Pagination style={
            {
                float: props.rightAlign ? "right" : undefined,
                margin: "5px 0"
            }
        }>
            <PaginationItem disabled={props.pageNumberZeroBased === 0}>
                <PaginationLink
                    onClick={_ => props.onPageChange(0)}
                    first
                />
            </PaginationItem>
            <PaginationItem disabled={props.pageNumberZeroBased <= 0}>
                <PaginationLink
                    onClick={_ => props.onPageChange(props.pageNumberZeroBased - 1)}
                    previous
                />
            </PaginationItem>
            {pagesItems.map((page) =>
                <PaginationItem active={page - 1 === props.pageNumberZeroBased} key={page}>
                    <PaginationLink onClick={_ => props.onPageChange(page - 1)}>
                        {page}
                    </PaginationLink>
                </PaginationItem>
            )}
            <PaginationItem disabled={props.pageNumberZeroBased >= props.totalPages - 1}>
                <PaginationLink
                    onClick={_ => props.onPageChange(props.pageNumberZeroBased + 1)}
                    next
                />
            </PaginationItem>
            <PaginationItem disabled={props.pageNumberZeroBased >= props.totalPages - 1}>
                <PaginationLink
                    onClick={_ => props.onPageChange(props.totalPages - 1)}
                    last
                />
            </PaginationItem>
        </Pagination>
    );
};