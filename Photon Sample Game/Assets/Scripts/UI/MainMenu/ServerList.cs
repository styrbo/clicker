using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerList : MonoBehaviourPunCallbacks
{
    private ScrollRect _scrollView;
    private List<Server> _servers;

    public Text sss;

    private void Awake()
    {
        _scrollView = GetComponent<ScrollRect>();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        sss.text = "";
        foreach (var item in roomList)
        {
            sss.text += $"{item.Name} \n";
        }
    }
}