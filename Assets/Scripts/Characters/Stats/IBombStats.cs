public enum StatLevel
{
    Level1, Level2, Level3, Level4, Level5
}

public interface IBombStats
{
    float BombCountdown { get; }
    uint MaxBombCount { get; }
    uint BombFireRange { get; }
}

