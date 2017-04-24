using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageBox : MonoBehaviour
{
    private Text _messageBox;
    private RawImage _imageBox;
    private float _defaultDismissTime = 3.0f;

    public enum EPlayer
    {
        Player1,
        Player2
    }

    public static MessageBox Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
        _messageBox = GetComponentInChildren<Text>();
        _imageBox = GetComponentInChildren<RawImage>();
        _imageBox.gameObject.SetActive(false);
    }

    public void SetMessage(string message, EPlayer player, bool dismiss = true)
    {
        _messageBox.text = message;

        if (player == EPlayer.Player2)
        {
            _imageBox.uvRect = new Rect(1, 0, -1, 1);
        }
        else
        {
            _imageBox.uvRect = new Rect(0, 0, 1, 1);
        }

        StartCoroutine(ShowMessage(dismiss));
    }

    private IEnumerator ShowMessage(bool dismiss = true)
    {
        _imageBox.gameObject.SetActive(true);

        if (dismiss)
        {
            yield return new WaitForSeconds(_defaultDismissTime);

            _imageBox.gameObject.SetActive(false);
        }
    }
}
