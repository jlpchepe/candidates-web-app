import React from "react";
import { Modal as BModal, ModalHeader as BModalHeader, ModalBody as BModalBody, ModalFooter as BModalFooter } from "reactstrap";

export interface ModalProps {
    children: React.ReactNode;
    isOpen: boolean;
    title: string;
    toggle: () => void;
    modalFooter?: React.ReactNode;
    footerJustifyContent?: "start" | "around" | "between" | "end";
}

export const Modal: React.FC<ModalProps> = props => (
    <BModal isOpen={props.isOpen} scrollable size="md">
        <BModalHeader toggle={props.toggle}>{props.title}</BModalHeader>
        <BModalBody>{props.children}</BModalBody>
        {props.modalFooter && <BModalFooter className={props.footerJustifyContent && `justify-content-${props.footerJustifyContent}`}>{props.modalFooter}</BModalFooter>}
    </BModal>
);
