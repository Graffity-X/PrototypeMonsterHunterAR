using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class SetOrigin : MonoBehaviour {

    // Use this for initialization
    void Start() {
        UnityARSessionNativeInterface.GetARSessionNativeInterface().SetWorldOrigin(transform);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
