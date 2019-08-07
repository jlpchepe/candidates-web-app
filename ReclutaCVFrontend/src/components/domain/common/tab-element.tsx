import * as React from "react";
import { TabPane } from "reactstrap";

export const TabElemento: React.FC<{tab: number}> = (props) => (
    <TabPane tabId={props.tab}>
        {props.children}
    </TabPane>
);