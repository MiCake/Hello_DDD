export class TimeHelper {

    public static addDays(current: Date, days: number): Date {
        return new Date(current.getTime() + 24 * 60 * 60 * 1000 * 30 * days);
    }

    public static isBefore(current: Date, compare: Date) {
        return current < compare;
    }
}