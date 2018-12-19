using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransformSync : MonoBehaviour {
    Transform m_camera;
    PhotonView m_photonView;
	// Use this for initialization
	void Start () {
        m_camera = GameObject.FindWithTag("MainCamera").transform;
        m_photonView = GetComponent<PhotonView>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        if (m_photonView.isMine)
            gameObject.transform.SetPositionAndRotation(m_camera.position, m_camera.rotation);
    }
}
