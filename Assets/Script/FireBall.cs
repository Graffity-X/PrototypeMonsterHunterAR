using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;


public class FireBall : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float power;
    // Use this for initialization
    void Start()
    {
        transform.LookAt(GameManagerScript.Instance.Position);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * power);

        Observable.Timer(System.TimeSpan.FromSeconds(3f)).Subscribe(_ =>
        {
            Destroy(gameObject);
        }
            ).AddTo(this);
                   
    }

    // Update is called once per frame
    void Update()
    {

    }
}
