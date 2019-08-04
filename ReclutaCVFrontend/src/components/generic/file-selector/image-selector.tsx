import * as React from "react";
import { FileSelector } from "../../generic";
import { Row } from "reactstrap";

interface ImageSelectorProps  {
    value?: string;
    onLoad?: (content: string) => void;
    label: string;
}

export class ImageSelector extends React.Component<ImageSelectorProps, ImageSelectorState> { 
    readonly extensions = ["png","jpg"];

    constructor(props: any) {
        super(props);
        console.log(this.props.value);
        this.onChange = this.onChange.bind(this);
    }

    onChange(event) {
        let file = event.target.files[0];
        let reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = this.onLoad;
    }

    onLoad = (event) => {
        let content = event.target.result;

        this.props.onLoad(content);
    }


    render() {
        return (
            <div>
                <Row>
                    <FileSelector
                        required = {true}
                        label = {this.props.label}
                        extensions = {this.extensions}
                        onChange = {this.onChange}
                    />
                </Row>
                
            </div>
           
        );
    }


}