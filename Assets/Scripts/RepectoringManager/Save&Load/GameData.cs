using System.Collections.Generic;

[System.Serializable]
public class StageStarData
{
    public int stageIndex;
    public int stars;
}

[System.Serializable]
public class GameData
{
    public int stageIndex;
    public List<StageStarData> stageStars = new List<StageStarData>();
}
