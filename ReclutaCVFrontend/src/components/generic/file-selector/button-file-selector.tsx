import * as React from "react";
import { CSSProperties } from "react";
import { NotificationHelper } from "../../../helpers/notification-helper";

interface ButtonFileSelectorProps {
    label: string;
    extensions: string[];
    value?: string;
    onLoad?: (content: string) => void;
    placeholder?: string | null;
    readonly?: boolean;
    required?: boolean;
    readMode: FileReadMode;
}

export enum FileReadMode {
    AsData,
    AsText
}

export class ButtonFileSelector extends React.Component<ButtonFileSelectorProps> {
    onChange = (e) => {
        let file = e.target.files[0];
        if( this.props.extensions.includes("xls") && file.type != "application/vnd.ms-excel" ) {
            NotificationHelper.notifyError("Error", "Formato Invalido");
            return;
        }

        let reader = new FileReader();
        if(this.props.readMode == FileReadMode.AsData){
            reader.readAsDataURL(file);
        }
        
        if(this.props.readMode == FileReadMode.AsText){
            reader.readAsText(file, "ISO-8859-1");
        }
        reader.onload = this.onLoad;
        e.target.value = null;
    }

    onLoad = (event) => {
        let content = event.target.result;

        this.props.onLoad(content);
    }

    styles: CSSProperties = {
        position: "absolute",
        top: 0,
        right: 0,
        minWidth: 100,
        minHeight: 100,
        fontSize: 100,
        textAlign: "right",
        filter: "alpha(opacity=0)",
        opacity: 0,
        outline: "none",
        background: "white",
        cursor: "inherit",
        display: "block"
    };

    render() {
        const fixedPlaceholder = this.props.placeholder || this.props.label;

        const acceptExtensions = this.props.extensions.map(extension => "." + extension).join(",");

        return (

            <span
                style={{ position: "relative", overflow: "hidden" }}
                className="btn btn-primary"
            >
                {fixedPlaceholder}
                <input
                    type="file"
                    style={this.styles}
                    accept={acceptExtensions}
                    readOnly={this.props.readonly}
                    onChange={this.onChange}
                />
            </span>
        );
    };
}