using Photon.Pun;
using TMPro;
using UnityEngine;

public class Lobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField  createInput;
    [SerializeField] private TMP_InputField  joinInput;
    [SerializeField] private TMP_InputField  nicknameInput;
    [SerializeField] private GameObject feedbackText;

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(nicknameInput.text) || string.IsNullOrEmpty(createInput.text))
        {
            feedbackText.SetActive(true);
            Invoke(nameof(DisableFeedback), 4f);
            return;
        }
        PhotonNetwork.NickName = nicknameInput.text;
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        if (string.IsNullOrEmpty(nicknameInput.text) || string.IsNullOrEmpty(joinInput.text))
        {
            feedbackText.SetActive(true);
            Invoke(nameof(DisableFeedback), 2f);
            return;
        }
        PhotonNetwork.NickName = nicknameInput.text;
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    private void DisableFeedback()
    {
        feedbackText.SetActive(false);
    }
}
