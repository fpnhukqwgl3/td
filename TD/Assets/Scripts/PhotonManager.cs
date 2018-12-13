using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
public class PhotonManager : MonoBehaviourPunCallbacks
{

    [SerializeField] private Text LabelState;
	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings();
    }
	
	// Update is called once per frame
	void Update () {
        LabelState.text = PhotonNetwork.NetworkClientState.ToString();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conected Server Success.");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby Success.");
        PhotonNetwork.JoinOrCreateRoom("1314", new RoomOptions { MaxPlayers = 250 },TypedLobby.Default);
    }


    public override void OnCreatedRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.Name);

    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo room in roomList)
        {
            Debug.Log(room.Name);
            Debug.Log(room.MaxPlayers);
        }
    }
}
