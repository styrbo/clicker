using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomCreator : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _createPanel;
    [SerializeField] private GameObject _roomLobby;
    [SerializeField] private Text _maxPlayerText;

    private const char InfinityChar = '∞';

    private string _roomName;
    private RoomOptions _options;


    public void CreateNewRoom()
    {
        _options = new RoomOptions();
        _options.IsOpen = true;
        Debug.Log(_options);

        _createPanel.SetActive(true);
    }

    public void OnMaxPlayerSliderChanged(Slider slider)
    {
        _options.MaxPlayers = (byte)slider.value;
        _maxPlayerText.text = _options.MaxPlayers == 0 ? InfinityChar.ToString() : _options.MaxPlayers.ToString();
    }

    public void OnRoomNameChanged(InputField field)
    {
        _roomName = field.text;
    }

    public override void OnCreatedRoom()
    {
        _roomLobby.SetActive(true);
    }

    public void Create()
    {
        PhotonNetwork.CreateRoom(_roomName,_options);
    }

    public void Close()
    {
        _options = null;
        _createPanel.SetActive(false);
    }

}
