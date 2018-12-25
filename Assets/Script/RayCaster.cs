using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;
using UniRx.Triggers;

public class RayCaster : MonoBehaviour
{

    [SerializeField] float maxdistance = 1;
    PhotonView PlayerPhotonView;
    [SerializeField] int damage = 10;
    Player player;
    // Debug
    [SerializeField] GameObject DebugAtackPoint;

    Animator MonsterAnimator = null;
    // Use this for initialization
    void Start()
    {

        this.UpdateAsObservable()
            .First(l => GameManagerScript.Instance.MinePlayer != null)
            .Subscribe(l => MonsterInit());
        // Monsterが生成されたらPhotonViewをいれる



    }

    void MonsterInit()
    {
        PlayerPhotonView = GameManagerScript.Instance.MinePlayer.GetPhotonView();
        player = GameManagerScript.Instance.MinePlayer.GetComponent<Player>();
        Debug.Log("photon view add");

    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(GameManagerScript.Instance.MainCamera.transform.position, GameManagerScript.Instance.MainCamera.transform.forward);
        if (GodTouches.GodTouch.GetPhase() == GodTouches.GodPhase.Began)
        {
            Ray ray = new Ray(GameManagerScript.Instance.MainCamera.transform.position, GameManagerScript.Instance.MainCamera.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxdistance))
            {
                if (hit.collider.CompareTag("Monster"))
                {
                    Debug.Log("Player -> Monster Atack");
                    // Instantiate(DebugAtackPoint, hit.point, transform.rotation);
                    if (MonsterAnimator == null)
                        MonsterAnimator = hit.collider.gameObject.transform.parent.gameObject.GetComponent<Animator>();
                    if (PlayerPhotonView.isMine)
                    {
                        PlayerPhotonView.RPC("DamageToMonster", PhotonTargets.Others, damage);
                        player.DamageToMonster(damage);
                    }
                }
            }
        }
    }
}
