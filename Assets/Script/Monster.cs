using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;
public class Monster : MonoBehaviour
{
    [SerializeField] private int MaxHP = 100;
    [SerializeField] private int HP;

    [SerializeField] Slider slider;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        if (!PhotonNetwork.isMasterClient)
            GameManagerScript.Instance.Monster = this.gameObject;
        HP = MaxHP;
        slider.maxValue = MaxHP;
        slider.value = HP;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.LookAt(GameManagerScript.Instance.Player.transform);
        if (HP <= 0)
        {
            anim.Play("Die");
            Observable.Timer(TimeSpan.FromSeconds(3f)).Subscribe(_ =>
            {
                Destroy(gameObject);
            }
            ).AddTo(this);

            // Die アニメーションして３秒後死死
        }
    }

    public void Damage(int damage)
    {
        anim.Play("Damage");
        HP -= damage;
        Debug.Log("Damage " + damage.ToString());
        slider.value = HP;
    }
}
