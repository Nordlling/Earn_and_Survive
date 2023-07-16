using Photon.Pun;
using TMPro;
using UnityEngine;

public class Lobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField  createInput;
    [SerializeField] private TMP_InputField  joinInput;

    public void CreateRoom()
    {
        // RoomOptions roomOptions = new RoomOptions();
        // roomOptions.MaxPlayers = 4;
        // PhotonNetwork.CreateRoom(createInput.text, roomOptions);
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
