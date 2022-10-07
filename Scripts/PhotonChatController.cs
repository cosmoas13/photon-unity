using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Photon.Chat;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class PhotonChatController : MonoBehaviour, IChatClientListener
{
    public TextMeshProUGUI connectionState;
    public TMP_InputField msgInput;
    public TextMeshProUGUI msgArea;

    private string worldchat;

    [SerializeField] private string nickName;
    private ChatClient chatClient;

    private void Awake()
    {
        nickName = PhotonNetwork.LocalPlayer.NickName;
    }

    private void Start()
    {
        chatClient = new ChatClient(this);
        ConnectoToPhotonChat();

        worldchat = "world";
    }

    private void Update()
    {
        if (chatClient != null)
        {
            chatClient.Service();
        }
    }

    public void ConnectoToPhotonChat()
    {
        Debug.Log("Connecting");
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion,
            new Photon.Chat.AuthenticationValues(nickName));
        Debug.Log(nickName);
    }

    public void SendMsg()
    {
        chatClient.PublishMessage(worldchat, msgInput.text);
        msgInput.text = "";
    }

    public void DebugReturn(DebugLevel level, string message)
    {

    }

    public void OnDisconnected()
    {
        chatClient.Unsubscribe(new string[] { worldchat });
        chatClient.SetOnlineStatus(ChatUserStatus.Offline);
    }

    public void OnConnected()
    {
        chatClient.Subscribe(new string[] { worldchat });
        chatClient.SetOnlineStatus(ChatUserStatus.Online);
    }

    public void OnChatStateChange(ChatState state)
    {

    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < senders.Length; i++)
        {
            msgArea.text += senders[i] + ": " + messages[i] + "\n";
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {

    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        foreach (var channel in channels)
        {
            this.chatClient.PublishMessage(channel, "joined");
        }

        connectionState.text = "Connected";
    }

    public void OnUnsubscribed(string[] channels)
    {
        msgArea.text = "";
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {

    }

    public void OnUserSubscribed(string channel, string user)
    {

    }

    public void OnUserUnsubscribed(string channel, string user)
    {

    }
}