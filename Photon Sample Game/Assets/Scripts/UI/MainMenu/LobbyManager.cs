﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _playerNickNameField;

    private void Awake()
    {
        _playerNickNameField.onValueChanged.AddListener(OnPlayernameChanged);
    }

    public void Connect()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    private void OnPlayernameChanged(string value)
    {
        PhotonNetwork.NickName = value;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void JoinToRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

}
