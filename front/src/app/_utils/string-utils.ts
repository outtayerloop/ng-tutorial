export class StringUtils {

    public static isNullOrEmpty(input: string | null): boolean {
        return input === null
            || input === '';
    }

    public static isNullOrWhiteSpace(input: string | null): boolean {
        return input === null
            || input.trim() === '';
    }
}