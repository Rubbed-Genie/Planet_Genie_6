using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSys : MonoBehaviour
{

    public Vector3 Speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Speed * Time.deltaTime);
    }
}
