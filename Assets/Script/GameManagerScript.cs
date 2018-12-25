using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : SingletonMonoBehaviour<GameManagerScript>
{

    [SerializeField] private GameObject mainCamera;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject monster;

    public GameObject MainCamera
    {
        get
        {
            return mainCamera;
        }
    }

    public GameObject Monster
    {
        get
        {
            return monster;
        }

        set
        {
            monster = value;
        }
    }

    public GameObject Player
    {
        get
        {
            return player;
        }

        set
        {
            player = value;
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
