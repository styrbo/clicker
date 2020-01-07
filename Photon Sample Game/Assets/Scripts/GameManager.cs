using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        PhotonNetwork.Instantiate("Player", Vector3.up * 1.73f, Quaternion.identity);
    }
}
