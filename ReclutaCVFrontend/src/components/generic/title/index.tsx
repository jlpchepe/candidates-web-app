import React from "react";
import classnames from "classnames";
interface TitleProps {
    className?: string;
    title: string;
}

/**
 * Una cabecera grande
 */
export const Title: React.FC<TitleProps> = props => (
    <h3 className={classnames("title", props.className)}>{props.title}</h3>
);
