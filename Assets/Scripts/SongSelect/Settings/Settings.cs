using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject setting;
    public void Click()
    {

       if(setting.activeSelf == false)
        {
            setting.SetActive(true);
        }
        else
        {
            setting.SetActive(false);
        }

    }
}
