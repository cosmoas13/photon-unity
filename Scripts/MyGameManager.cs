using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class MyGameManager : MonoBehaviourPunCallbacks
{
    #region Serializeable Fields

    #endregion

    #region Private Fields
    private string CHARACTER = "Character";
    #endregion

    #region MonoBehaviour Callbacks
    private void Start()
    {
        RenderCharacter(PhotonNetwork.LocalPlayer.CustomProperties[CHARACTER]);
    }
    #endregion

    #region MonoBehaviourPun Callbacks

    #endregion

    #region Private Methods
    private void RenderCharacter(object charNumber)
    {
        if (charNumber == null)
        {
            PhotonNetwork.Instantiate("Player 1", Vector3.zero, Quaternion.identity, 0);
            return;
        }

        switch ((int)charNumber)
        {
            case 0:
                PhotonNetwork.Instantiate("Player 1", Vector3.zero, Quaternion.identity, 0);
                break;
            default:
                PhotonNetwork.Instantiate("Player 2", Vector3.zero, Quaternion.identity, 0);
                break;
        }
    }
    #endregion
}
