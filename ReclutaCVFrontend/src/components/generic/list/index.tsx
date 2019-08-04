import React from "react";

/**
 * Contenedor para una lista de elementos
 */
export const List: React.FC<{}> = props => (
    <ul>
        {React.Children.map(props.children, (child, childIndex) => (
            <li key={childIndex}>{child}</li>
        ))}
    </ul>
);
