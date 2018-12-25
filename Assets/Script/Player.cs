using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Player : MonoBehaviour
{
    [SerializeField] Monster monster;


    // Use this for initialization
    void Start()
    {


        this.UpdateAsObservable()
            .First(l => GameManagerScript.Instance.Monster != null)
            .Subscribe(l => monster = GameManagerScript.Instance.Monster.GetComponent<Monster>());
        // Monsterが生成されてたら入れる


        GameManagerScript.Instance.players.Add(this.gameObject);


    }

    // Update is called once per frame
    void Update()
    {

    }

    [PunRPC]
    public void DamageToMonster(int damage)
    {
        monster.Damage(damage);
    }
}
