public enum MushroomStage {spore, budding, medium, full, dying, dead};
public class MushroomState
{
    public float startTime;

    public string Name;
    
    public float mushgrowth;

    public MushroomStage stage = MushroomStage.spore;

}
