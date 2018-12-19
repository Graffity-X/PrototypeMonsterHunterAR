using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour {
    [SerializeField] GameObject[] CreateObj;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < CreateObj.Length; i++)
        {
            Instantiate(CreateObj[i], transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
