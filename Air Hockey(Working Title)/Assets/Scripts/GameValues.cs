using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameValues
{
    public enum Difficulties { Easy, Medium, Hard};
    public enum SelectedMap { Basic, Earth, Ice, Wind, Fire};
    public enum LevelSelection { Level1, Level2, Level3, Level4, Level5};

    public static bool IsMultiplayer;
    public static Difficulties Difficulty = Difficulties.Easy;
    public static SelectedMap PresentMap = SelectedMap.Basic;
    public static LevelSelection CurrentLevel = LevelSelection.Level1;
}
