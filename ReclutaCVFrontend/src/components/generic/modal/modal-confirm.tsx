import React, { ReactElement } from "react";
import { Modal as BModal, ModalHeader as BModalHeader, ModalBody as BModalBody, ModalFooter as BModalFooter } from "reactstrap";
import { Button } from "..";

export interface ModalProps {
    message: string;
    body: ReactElement;
    isOpen: boolean;
    title: string;
    toggle?: () => void;
    footerJustifyContent?: "start" | "around" | "between" | "end";
    onConfirm: () => void;
    onCancel: () => void;
}

export const ConfirmationModal: React.FC<ModalProps> = props => {
    const fixedToggle = props.toggle || (() => {});

    return (
        <div role="dialog">   
            <BModal isOpen={props.isOpen} scrollable size="md">
                <BModalHeader>{props.message}</BModalHeader>
                <BModalBody>{props.body}</BModalBody>
                <BModalFooter className={props.footerJustifyContent && `justify-content-${props.footerJustifyContent}`}>
                    <Button
                        color="primary"
                        label="Confirmar"
                        onClick={props.onConfirm}
                    >
                    </Button>
                    <Button
                        color="secondary"
                        label="Cancelar"
                        onClick={props.onCancel}
                    >
                    </Button>
                </BModalFooter>
            </BModal>
        </div>
    );
};