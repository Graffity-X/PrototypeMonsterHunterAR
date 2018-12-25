using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
public class Monster : MonoBehaviour
{
    [SerializeField] private int MaxHP = 100;
    [SerializeField] private int HP;

    [SerializeField] float AtackTime = 1f;

    [SerializeField] Slider slider;
    Animator anim;

    [SerializeField] GameObject FireBall;

    PhotonView PhotonView;

    int lookatnum = 0;

    // Use this for initialization
    void Start()
    {
        if (!PhotonNetwork.isMasterClient)
            GameManagerScript.Instance.Monster = this.gameObject;
        HP = MaxHP;
        slider.maxValue = MaxHP;
        slider.value = HP;
        anim = GetComponent<Animator>();
        PhotonView = gameObject.GetPhotonView();

        if (PhotonNetwork.isMasterClient)
            Observable.Interval(System.TimeSpan.FromSeconds(5f)).Subscribe(l =>
            {
            // 5秒ごとに発火
            AtackPlayer();
            }).AddTo(this);

    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.LookAt(GameManagerScript.Instance.MinePlayer.transform);
        if (HP <= 0)
        {
            anim.Play("Die");

            Observable.Timer(System.TimeSpan.FromSeconds(3f)).Subscribe(_ =>
            {
                Destroy(gameObject);
            }
            ).AddTo(this);


            // Die アニメーションして３秒後死
        }
    }

    public void AtackPlayer()
    {
        var positon = GameManagerScript.Instance.players[lookatnum].transform.position;
        transform.LookAt(positon);

        lookatnum++;
        lookatnum = lookatnum % GameManagerScript.Instance.players.Count;

        PhotonView.RPC("RunAtack", PhotonTargets.All,positon);
        Observable.Timer(System.TimeSpan.FromSeconds(1f)).Subscribe(l =>
        {
            PhotonNetwork.Instantiate(FireBall.name, transform.position + new Vector3(0,0.3f,0.3f), transform.rotation, 0);
        }).AddTo(this);

    }

    [PunRPC]
    void RunAtack(Vector3 posioton)
    {
        anim.Play("Atack");
        GameManagerScript.Instance.Position = posioton;
    }

    public void Damage(int damage)
    {
        anim.Play("Damage");
        HP -= damage;
        Debug.Log("Damage " + damage.ToString());
        slider.value = HP;
    }

}
