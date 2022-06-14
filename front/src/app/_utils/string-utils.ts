export class StringUtils {

    public static isNullOrEmpty(input: string | null): boolean {
        return input === null
            || input === ''
            || typeof(input) === typeof(undefined);
    }

    public static isNullOrWhiteSpace(input: string | null): boolean {
        return input === null
            || input.trim() === ''
            || typeof(input) === typeof(undefined);
    }
}