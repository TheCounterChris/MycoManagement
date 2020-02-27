public enum MushroomStage {spore, budding, medium, full, dying, dead};
public class MushroomState
{
    public float startTime;

    public string Name;
    
    public float growthRate = 100f;

    public MushroomStage stage = MushroomStage.spore;

}
