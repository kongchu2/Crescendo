using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    public void Start()
    {
        Invoke("BGA", 1f);
    }

    public void BGA()
    {
           
    }

}
