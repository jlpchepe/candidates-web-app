import * as React from "react";

export const Seccion: React.FC<{title: string}> = (props) => (
    <>
        <h4>{props.title}</h4>
        {props.children}
    </>    
);