import React from "react";
import { goToPath } from "../../../../helpers/navigation-helper";
import { History } from "history";

interface TopBarBrandProps {
    history: History;
    logoBase64: string;
}

export const TopBarBrand: React.FC<TopBarBrandProps> = props => (
    <div className="top-bar__brand">
        <img src={props.logoBase64} onClick={() => goToPath(props.history, "candidato")} />
    </div>
);
