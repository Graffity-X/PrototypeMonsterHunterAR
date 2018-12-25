using UnityEngine;
using System.Collections;

public class PhotonConnect : MonoBehaviour
{
    [SerializeField] GameObject Player, Monster;
    int RoomCount = 0;

    void Start()
    {
        // Photonに接続する(引数でゲームのバージョンを指定できる)
        PhotonNetwork.ConnectUsingSettings(null);

        //今回オートでロビーにJoinする
    }

    // ロビーに入ると呼ばれる
    void OnJoinedLobby()
    {
        Debug.Log("ロビーに入りました。");

        // ルームに入室する
        PhotonNetwork.JoinRandomRoom();


    }

    // ルームに入室すると呼ばれる
    void OnJoinedRoom()
    {
        Debug.Log("ルームへ入室しました。");

        GameManagerScript.Instance.MinePlayer = PhotonNetwork.Instantiate(Player.name, new Vector3(0, 0, 0), transform.rotation, 0);
        if (PhotonNetwork.isMasterClient)
            GameManagerScript.Instance.Monster = PhotonNetwork.Instantiate(Monster.name, new Vector3(0, 0.01f, 0), transform.rotation, 0);

    }

    // ルームの入室に失敗すると呼ばれる
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("ルームの入室に失敗しました。");

        // ルームがないと入室に失敗するため、その時は自分で作る
        // 引数でルーム名を指定できる
        PhotonNetwork.CreateRoom("ARKitShare" + RoomCount.ToString());
        RoomCount++;
    }
}