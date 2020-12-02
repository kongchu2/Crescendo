using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Judgement judge;
    public  Transform keyBeams;
    private GameObject[] keyBeamList;
    public  KeyCode[] KeyCodes = { KeyCode.D, KeyCode.F, KeyCode.J, KeyCode.K };
    private void Awake()
    {
        judge = new Judgement();
        keyBeamList = new GameObject[keyBeams.childCount];
        for (int i = 0; i < keyBeams.childCount; i++)
            keyBeamList[i] = keyBeams.GetChild(i).gameObject;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Record.Instance.isGameOver) {
            PauseMenu.Instance.isPause = !PauseMenu.Instance.isPause;
            PauseMenu.Instance.PauseAndResume(PauseMenu.Instance.isPause);
        }
        if(Input.anyKey && !PauseMenu.Instance.isPause && !Record.Instance.isGameOver)
        {
            for(int i=0;i<Setting.Instance.key;i++) {
                if(Input.GetKeyDown(KeyCodes[i]))
                    LaneKeyDown(i);
            }
            ChangeSpeedRate();
            BackDoor();
        }
        for(int i=0;i<Setting.Instance.key;i++)
        KeyBeam(i, Input.GetKey(KeyCodes[i]));
    }
    private void LaneKeyDown(int lane) {
        judge.JudgementNote(lane);
    }
    private void KeyBeam(int lane, bool input) {
        keyBeamList[lane].SetActive(input);
    }
    private void ChangeSpeedRate() {
        if (Input.GetKeyDown(KeyCode.PageUp))
            Setting.Instance.userSpeedRate++;
        else if (Input.GetKeyDown(KeyCode.PageDown))
            Setting.Instance.userSpeedRate--;
        UIManager.Instance.setNoteSpeedRateUI_Text(Setting.Instance.userSpeedRate.ToString());
    }
    private void BackDoor() {
        if(Input.GetKeyDown(KeyCode.F12))
            GameManager.ChangeScene("Result");
    }
}
