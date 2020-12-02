public class Record
{
    private static Record instance = new Record();
    private Record() {
        reset();
    }
    public void reset() {
        combo = 0;
        maxCombo = 0;
        score = 0;
        judgementedNoteCount = 0;
        HP = pullHP;
        isGameOver = false;
    }
    private readonly int pullHP = 10;

    private int combo;
    private int maxCombo;
    private int score;
    private int HP;

    public int judgementedNoteCount;
    public int noteCount;

    public bool isGameOver {get; private set;}

    public static Record Instance {
        get {
            if(instance == null)
                instance = new Record();
            return instance;
        }
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
    public void HPminusplus(int _HP) {
        if(HP+_HP < 10) {
            HP += _HP;
        }
        if(HP <= 0) {
            isGameOver = true;
            UIManager.Instance.setGameOverUI(true);
            BGAPlayer.BGA.Stop();
        }
        UIManager.Instance.HPBar.fillAmount = (float)HP/pullHP;
    }
    public int getCombo() {return combo;}
    public int getMaxCombo() {return maxCombo;}
    public int getScore() {return score;}
}
