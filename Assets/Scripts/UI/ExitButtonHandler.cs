using Photon.Pun;
using UnityEngine;

public class ExitButtonHandler : MonoBehaviourPunCallbacks
{
    [SerializeField] private string lobbySceneName = "Lobby";

    public void ReturnToLobby()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(lobbySceneName);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("EXIT");
    }
}
