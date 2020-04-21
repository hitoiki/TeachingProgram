using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallObject : MonoBehaviour
{
    public GameObject Object;
    public Vector3 Relativeposition;
    public bool OnOff;

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    {
        if (OnOff) Instantiate(Object, this.transform.position + Relativeposition, Quaternion.identity);
    }



}
