using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBreak : MonoBehaviour
{
    public void Click()
    {
        GetComponent<Button>().interactable = false;
    }
}
