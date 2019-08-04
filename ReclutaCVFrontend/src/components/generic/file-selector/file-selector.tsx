import * as React from "react";
import { Labeled } from "../label/labeled";
import { Input as BootstrapInput, FormFeedback } from "reactstrap";

interface FileSelectorProps  {
    label: string;
    extensions: string[];
    value?: string;
    /**
     * Si no se especifica, se usará el valor @param label 
     */
    onChange?: (event: React.ChangeEvent<HTMLInputElement>) => void;
    placeholder?: string | null;
    readonly?: boolean;
    required?: boolean;
}

export class FileSelector extends React.Component<FileSelectorProps> {

    render() {
        const fixedPlaceholder = this.props.placeholder || this.props.label;

        const acceptExtensions = this.props.extensions.map(extension => "." + extension).join(",");

        return (
            <Labeled label={this.props.label}>
                <BootstrapInput 
                    type="file"
                    label={this.props.label}
                    accept={acceptExtensions}
                    value={this.props.value}
                    placeholder={fixedPlaceholder}
                    onChange={this.props.onChange}
                    required={this.props.required}
                    readOnly={this.props.readonly}
                ></BootstrapInput>
                <FormFeedback>Dato requerido</FormFeedback>
            </Labeled>
        );
    };
}