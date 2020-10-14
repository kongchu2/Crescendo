using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Judgement judge;
    public AudioSource Hitsound;
    public Transform keyBeams;
    private GameObject[] keyBeamList;
    private readonly KeyCode[] KeyCodes = { KeyCode.D, KeyCode.F, KeyCode.J, KeyCode.K };
    private bool[] inputs;//입력데이터
    private bool[] canPress;//노트를 부실 수 있는가
    
    private void Awake()
    {
        //keyBeamList 초기화
        keyBeamList = new GameObject[keyBeams.childCount];
        for (int i = 0; i < keyBeams.childCount; i++)
            keyBeamList[i] = keyBeams.GetChild(i).gameObject;
        inputs = new bool[GameManager.KEY];
        //canPress true로 초기화
        canPress = new bool[GameManager.KEY];
        for(int i=0;i<canPress.Length;i++)
            canPress[i] = true;
        judge = new Judgement();//Judgement 객체 생성
    }
    private void Update()
    {
        GetInput();//입력
        for (int i = 0; i < canPress.Length; i++) {
            if (Input.GetKeyDown(KeyCodes[i]))
                Hitsound.Play();
            canPress[i] = Input.GetKeyUp(KeyCodes[i]) || canPress[i];
        }
        judge.JudgementNote(inputs, canPress);
        KeyBeam();
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
}
