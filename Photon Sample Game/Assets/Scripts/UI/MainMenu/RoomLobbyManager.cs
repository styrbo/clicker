using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;

public class RoomLobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _content;

    private Room _room;

    private new void OnEnable()
    {
        _room = PhotonNetwork.CurrentRoom;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }

    public override void OnLeftRoom()
    {
        Quit();
    }

    public void JoinToGame()
    {
        SceneLoader.LoadScene(1);
    }

    public void Quit()
    {
        PhotonNetwork.LeaveRoom();
        gameObject.SetActive(false);
    }
}
