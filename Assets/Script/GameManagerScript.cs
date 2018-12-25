using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : SingletonMonoBehaviour<GameManagerScript>
{

    [SerializeField] private GameObject mainCamera;

    [SerializeField] private GameObject mineplayer;
    [SerializeField] private GameObject monster;

    public List<GameObject> players = new List<GameObject>();

    private Vector3 position = new Vector3(0, 0, 0);

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

    public GameObject MinePlayer
    {
        get
        {
            return mineplayer;
        }

        set
        {
            mineplayer = value;
        }
    }

    public Vector3 Position
    {
        get
        {
            return position;
        }

        set
        {
            position = value;
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
