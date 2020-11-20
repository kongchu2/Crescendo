public class Record
{
    private static Record instance = new Record();

    private int combo;
    private int maxCombo;
    private int score;
    
    public int noteCount;

    public static Record Instance {
        get {
            if(instance == null)
                instance = new Record();
            return instance;
        }
    }
    public Record()
    {
        combo = 0;
        score = 0;
    }
    public void ComboBreak(bool soundPlay)
    {
        combo = 0;
        if(soundPlay) {
            SoundManager.Instance.ComboBreakSoundPlay();
        }
    }
    public void ComboPlus() {
        combo++;
        if(maxCombo < combo) {
            maxCombo = combo;
        }
    }
    public void ScorePlus(int _score) {
        score += _score;
    }
    public void Reset() {
        combo = 0;
        maxCombo = 0;
        score = 0;
    }
    public int getCombo() {return combo;}
    public int getMaxCombo() {return maxCombo;}
    public int getScore() {return score;}
}
