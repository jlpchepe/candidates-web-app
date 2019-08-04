import React from "react";
import classnames from "classnames";
import {
    ApplicationAvailableIcon,
    ApplicationAvailableColor,
    colorToButtonCssClassColor
} from "../look-and-feel/resources";
import { Icon } from "..";
import { ToolTip } from "../tool-tip";

interface CircularButtonTooltip {
    /**
     * ID con el cual se va a rastrear el tooltip del botón
     */
    id: string;
    /**
     * Mensaje que se mostrará en el tooltip
     */
    message: string;
}

interface CircularButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
    className?: string;
    color?: ApplicationAvailableColor;
    disabled?: boolean;
    icon: ApplicationAvailableIcon;
    isOutlined?: boolean;
    onClick: () => void;
    style?: React.CSSProperties;
    tag?: "button" | "a" | "input";
    /**
     * Tooltip a mostrarse en el botón
     */
    tooltip?: CircularButtonTooltip;
}

const fixedColor = (color, isOutlined) => {
    color = colorToButtonCssClassColor(color);
    return "btn-" + (isOutlined ? `outline-${color}` : color);
};

/**
 * Un botón circular
 */
export const CircularButton: React.FC<CircularButtonProps> = props => {
    const Tag = props.tag || "button";
    return (
        <>
            <Tag
                className={classnames(
                    "circular-button",
                    props.className,
                    "btn",
                    fixedColor(props.color, props.isOutlined)
                )}
                id={props.tooltip != null ? props.tooltip.id : undefined}
                color={props.color}
                disabled={props.disabled}
                onClick={props.onClick}
                style={props.style}
            >
                <Icon icon={props.icon} />
            </Tag>
            {props.tooltip && <ToolTip text={props.tooltip.message} target={props.tooltip.id} />}
        </>
    );
};
