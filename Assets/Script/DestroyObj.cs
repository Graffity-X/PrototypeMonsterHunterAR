using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour {
    [SerializeField] float time;
	// Use this for initialization
	IEnumerator Start () {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
