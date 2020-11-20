using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Judgement judge;
    private GameObject[] keyBeamList;

    public Transform keyBeams;

    private readonly KeyCode[] KeyCodes = { KeyCode.D, KeyCode.F, KeyCode.J, KeyCode.K };
    private bool[] inputs;//입력데이터
    private bool[] canPress;//노트를 부실 수 있는가

    private void Awake()
    {
        keyBeamList = new GameObject[keyBeams.childCount];
        for (int i = 0; i < keyBeams.childCount; i++)
            keyBeamList[i] = keyBeams.GetChild(i).gameObject;
        inputs = new bool[Setting.Instance.key];
        canPress = new bool[Setting.Instance.key];
        for(int i=0;i<canPress.Length;i++)
            canPress[i] = true;
        judge = new Judgement();
        UIManager.Instance.setNoteSpeedRateUI_Text(Setting.Instance.userSpeedRate.ToString());
    }
    private void Update()
    {
        GetInput();//입력
        for (int i = 0; i < canPress.Length; i++) {
            if (Input.GetKeyDown(KeyCodes[i]))
                SoundManager.Instance.HitSoundPlay();
            canPress[i] = Input.GetKeyUp(KeyCodes[i]) || canPress[i];
        }
        judge.JudgementNote(inputs, canPress);
        KeyBeam();
        ChangeSpeedRate();
        BackDoor();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.isPause = !PauseMenu.isPause;
            PauseMenu.PauseAndResume(PauseMenu.isPause);
        }
    }
    private void GetInput()
    {
        for (int i = 0; i < inputs.Length; i++)
            inputs[i] = Input.GetKey(KeyCodes[i]);
    }
    private void KeyBeam()
    {
        for (int i = 0; i < keyBeamList.Length; i++)
            keyBeamList[i].SetActive(inputs[i]);
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
