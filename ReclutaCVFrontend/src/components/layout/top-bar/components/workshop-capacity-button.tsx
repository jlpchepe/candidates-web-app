import React from "react";
import { Icon } from "../../../generic";

interface WorkShopCapacityButtonProps {
    onClickActionButton: () => void;
}

export const WorkshopCapacityButton: React.FC<WorkShopCapacityButtonProps> = props => (
    <div className="user-menu__icon" onClick={props.onClickActionButton}>
        <Icon icon="car" />
    </div>
);
