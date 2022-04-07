[Flags]

public enum Days

{
    None = 0b_0000_0000,
    Monday = 0b_0000_0001,
    Tuesday = 0b_0000_0010,
    Wednesday = 0b_0000_0100,
    Thursday = 0b_0000_1000,
    Friday = 0b_0001_0000,
    Saturday = 0b_0010_0000,
    Sunday = 0b_0100_0000,
    Weekend = Saturday | Sunday
}

public class FlagsEnumExample

{

    public static void Main()

    {

        Days meetingDays = Days.Monday | Days.Wednesday | Days.Friday;
        Console.WriteLine(meetingDays);

        Days workingFromHomeDays = Days.Thursday | Days.Friday;
        Console.WriteLine($"Join a meeting by phone on {meetingDays & workingFromHomeDays}");

        bool isMeetingOnTuesday = (meetingDays & Days.Tuesday) == Days.Tuesday;
        Console.WriteLine($"Is there a meeting on Tuesday: {isMeetingOnTuesday}");

        var a = (Days)25;
        Console.WriteLine(a);
    }

}