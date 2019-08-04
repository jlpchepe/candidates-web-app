import * as React from "react";
import { Label as BootstrapLabel } from "reactstrap";

interface LabelProps {
    className?: string;
}
/**
 * Una etiqueta
 */
export const Label: React.FC<LabelProps> = props => (
    <BootstrapLabel
        className={props.className}
        style={{
            fontWeight: "bolder",
            whiteSpace: "nowrap"
        }}
    >
        {props.children}
    </BootstrapLabel>
);
