using UnityEngine;

public enum MushroomStage { spore, budding, medium, full, dying, dead };
public class MushroomState
{

    public string Name;

    public float startTime;

    public float mushGrowth;

    public float potency = 1;

    // public float humidity = 90;

    public bool inIncubator;

    public MushroomStage stage = MushroomStage.spore;

    // public MushroomStage nextStage = MushroomStage.budding;

    public GameObject sporeModel, buddingModel, mediumModel, fullModel, dyingModel, deadModel;


}


