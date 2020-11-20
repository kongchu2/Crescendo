using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamequit : MonoBehaviour
{
    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("나가짐");
    }
}
