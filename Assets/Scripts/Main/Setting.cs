public class Setting {
    private static Setting instance;
    public int key = 4;
    public float userSpeedRate = 16f;
    
    //public int gearPosMode = 1;
    public static Setting Instance {
        get {
            if(instance == null)
                instance = new Setting();
            return instance;
        }
    }
    private Setting() {}
}