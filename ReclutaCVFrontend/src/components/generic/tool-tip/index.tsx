import React from "react";
import { Tooltip } from "reactstrap";

interface ToolTipProps {
    text: string | React.ReactNode;
    target: string;
    placement?: "bottom" | "right" | "left" | "top";
}

interface ToolTipState {
    isOpen: boolean;
}

/**
 * Tooltip para mostrar información breve
 */
export class ToolTip extends React.Component<ToolTipProps, ToolTipState> {
    state: ToolTipState = {
        isOpen: false
    };

    /**
     * Determina si el componente puede seguir llamando a setState para hacer toggle
     */
    canToggle: boolean = true;

    componentWillUnmount() {
        this.canToggle = false;
    }

    private toggle = () => {
        if (this.canToggle) {
            this.setState({
                isOpen: !this.state.isOpen
            });
        }
    };

    render() {
        const isOpen = this.state.isOpen && document.getElementById(this.props.target) != null;

        return (
            <Tooltip
                placement={this.props.placement || "top"}
                target={this.props.target}
                isOpen={isOpen}
                toggle={this.toggle}
            >
                {this.props.text}
            </Tooltip>
        );
    }
}
