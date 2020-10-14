public class JudgementInfo
{
    public string name;
    public float time;
    public int score;
    public bool comboBreak;
    public JudgementInfo(string _name, float _time, int _score, bool _comboBreak) {
        name = _name;
        time = _time;
        score = _score;
        comboBreak = _comboBreak;
    }
}