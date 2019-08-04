import React from "react";
import classnames from "classnames";

interface CheckboxProps {
    className?: string;
    checked: boolean;
    id: string;
    label: string;
    onChange: () => void;
    readonly?: boolean;
}

export const Checkbox: React.FC<CheckboxProps> = props => (
    <div className={classnames("checkbox", props.className)}>
        <input
            checked={props.checked}
            id={props.id}
            onChange={props.onChange}
            type="checkbox"
            readOnly={props.readonly}
            disabled={props.readonly}
        />
        <label htmlFor={props.id}>{props.label}</label>
        <span />
    </div>
);
