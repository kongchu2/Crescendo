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
    private bool[] inputs;
    private bool[] canPress;
    
    
    private void Awake()
    {

        keyBeamList = new GameObject[keyBeams.childCount];
        for (int i = 0; i < keyBeams.childCount; i++)
            keyBeamList[i] = keyBeams.GetChild(i).gameObject;
        inputs = new bool[GameManager.KEY];
        canPress = new bool[GameManager.KEY];
        for(int i=0;i<canPress.Length;i++)
            canPress[i] = true;
        judge = new Judgement();
    }
    private void Update()
    {
        GetInput();
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
