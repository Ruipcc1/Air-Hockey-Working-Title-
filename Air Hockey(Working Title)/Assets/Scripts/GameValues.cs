using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameValues
{
    public enum Difficulties { Easy, Medium, Hard};
    public enum SelectedMap { Basic, Earth, Ice, Wind, Fire};

    public static bool IsMultiplayer;
    public static Difficulties Difficulty = Difficulties.Easy;
    public static SelectedMap PresentMap = SelectedMap.Basic;
}
