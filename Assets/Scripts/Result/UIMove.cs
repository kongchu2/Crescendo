using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 target = new Vector3(960f, 540f, 0f);
    private void OnEnable()
    {
        transform.position = new Vector3(960, -740f, 0f);
    }
    void Update()
    {
        Vector3 velo = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 0.05f);
        
    }
}
