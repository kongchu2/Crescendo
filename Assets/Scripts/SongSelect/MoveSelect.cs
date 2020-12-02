using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelect : MonoBehaviour
{
    Vector3 target = new Vector3(1290f,540f,0f);

    private void OnEnable()
    {
        transform.position =new Vector3(3290f, 540f, 0f);
    }
    void Update()
    {
        Vector3 velo = Vector3.zero;
        //transform.position = Vector3.SmoothDamp(transform.position, target,ref velo, 0.3f);
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 10f);
    }
}
