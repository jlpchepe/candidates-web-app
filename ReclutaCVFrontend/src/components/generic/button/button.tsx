import React from "react";
import classnames from "classnames";
import {
    ApplicationAvailableButtonSize,
    ApplicationAvailableColor,
    ApplicationAvailableIcon,
    colorToButtonCssClassColor
} from "../look-and-feel/resources";
import { Icon } from "../";

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
    className?: string;
    color?: ApplicationAvailableColor;
    disabled?: boolean;
    icon?: ApplicationAvailableIcon;
    isBlock?: boolean;
    isOutlined?: boolean;
    label?: string;
    onClick?: () => void;
    size?: ApplicationAvailableButtonSize;
    style?: React.CSSProperties;
    tag?: "button" | "a" | "input";
}

const fixedColor = (color, isOutlined) => {
    color = colorToButtonCssClassColor(color);
    return "btn-" + (isOutlined ? `btn-outline-${color}` : color);
};
/**
 * Un botón
 */
export const Button: React.FC<ButtonProps> = props => {
    const Tag = props.tag || "button";
    return (
        <Tag
            className={classnames("button", props.className, "btn", fixedColor(props.color, props.isOutlined), {
                "btn-block": props.isBlock,
                [`btn-${props.size}`]: props.size
            })}
            disabled={props.disabled}
            id={props.id}
            onClick={props.onClick}
            style={props.style}
        >
            {props.icon && <Icon icon={props.icon} />}
            <span className="btn__label">{props.label}</span>
        </Tag>
    );
};
