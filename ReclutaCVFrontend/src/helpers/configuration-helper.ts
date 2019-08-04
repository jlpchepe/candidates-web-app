import { ConfigurationServiceBoardConsultable } from "../communication/dtos/configuration";

export class ConfigurationHelper {
    public static getDeliveryMarginTime = (
        configurationServiceBoard: ConfigurationServiceBoardConsultable
    ): number => configurationServiceBoard != null ? configurationServiceBoard.deliveryMarginTime : 100;
}