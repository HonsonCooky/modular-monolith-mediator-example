namespace MMME.Common;

public enum MmmeUserType
{
    Curious,
    Enthusiast,
    Regular,
    Premium,
    Enterprise
}

public record MmmeUser(Guid Id, string Name, MmmeUserType Type);