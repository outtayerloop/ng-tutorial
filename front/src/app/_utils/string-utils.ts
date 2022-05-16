export class StringUtils {

    public static isNullOrEmpty(input: string): boolean {
        return input === null
            || input === '';
    }

    public static isNullOrWhiteSpace(input: string): boolean {
        return input === null
            || input.trim() === '';
    }
}