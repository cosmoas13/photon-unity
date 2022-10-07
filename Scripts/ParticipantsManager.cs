using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[CreateAssetMenu(fileName = "ParticipantsManager", menuName = "Managers/ParticipantsManager")]
public class ParticipantsManager : ScriptableObject
{
    #region Serializeable Fields
    [SerializeField] private string nickName;
    #endregion

    #region Private Fields
    private int charIndex { get; set; } = 0;
    private ExitGames.Client.Photon.Hashtable playersCustomProp = new();
    #endregion

    #region Public Methods
    public void CreateOrJoinRoom(TMPro.TextMeshProUGUI roomName)
    {
        RoomOptions roomOptions = new() { MaxPlayers = 20 };
        PhotonNetwork.JoinOrCreateRoom(roomName.text, roomOptions, null);
    }

    public void SetPlayerName(TMPro.TextMeshProUGUI name)
    {
        nickName = PlayerPrefs.GetString("USERNAME");
        PhotonNetwork.NickName = nickName;
        Debug.Log($"Player name: {nickName}");
    }

    public void SetPlayerDisplayeName(TMPro.TextMeshProUGUI name)
    {
        name.text = PhotonNetwork.NickName;
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void SelectCharacter()
    {
        charIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        playersCustomProp["Character"] = charIndex;
        PhotonNetwork.LocalPlayer.CustomProperties = playersCustomProp;
    }
    #endregion
}
