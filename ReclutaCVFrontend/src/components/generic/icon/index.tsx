import React from "react";
import {
    ApplicationAvailableIcon,
    iconToIconCssClassName,
    ApplicationAvailableIconSize,
    ApplicationAvailableColor,
    ApplicationAvailableFaStyle
} from "../look-and-feel/resources";
import { StringHelper } from "../../../helpers/string-helper";

interface IconProps {
    className?: string;
    color?: ApplicationAvailableColor;
    faStyle?: ApplicationAvailableFaStyle;
    icon: ApplicationAvailableIcon;
    onClick?: () => void;
    size?: ApplicationAvailableIconSize;
    spin?: boolean;
}

/**
 * Un ícono en la aplicación
 */
export const Icon: React.FC<IconProps> = props => (
    <span className={"icon " + StringHelper.valueOrEmpty(props.className)} onClick={props.onClick}>
        <i className={iconToIconCssClassName(props.icon, props.size, props.color, props.faStyle, props.spin)} />
    </span>
);
