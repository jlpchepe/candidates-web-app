export class BooleanHelper {

    public static parseFromValue(value: string | number) {
        if (value == 0 || value == 1 || value == "true" || value == "false") {
            return Boolean(value);
        }

        return undefined;
    }
}