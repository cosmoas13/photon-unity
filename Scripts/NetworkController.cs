using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;
using Photon.Voice.PUN;

public class NetworkController : MonoBehaviourPunCallbacks
{
    #region Private Serializeable Fields
    #endregion

    #region Private Fields
    #endregion

    #region Public Fields
    public static NetworkController Instace;
    #endregion

    #region MonoBehaviourPunCallbacks Callbacks
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Connection successfull");
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"Failed to create room:\n{returnCode}:{message}");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"Failed to join room:\n{returnCode}:{message}");
    }
    #endregion

    #region MonoBehaviour CallBacks
    private void Awake()
    {
        if(Instace != null)
        {

        }
    }

    private void Start()
    {
        ConnectServer();
    }
    #endregion

    #region Private Methods
    public void ConnectServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        // PhotonNetwork.ConnectToMaster("147.139.164.238", 5055, null);

        PhotonNetwork.GameVersion = "1.0.0";
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    #endregion
}
