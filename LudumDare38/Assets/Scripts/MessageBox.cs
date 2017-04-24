using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageBox : MonoBehaviour
{
    private Text _messageBox;
    private RawImage _imageBox;
    private const float _defaultDismissTime = 3.0f;
    private Coroutine _showMessage;

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
        if (_showMessage != null)
        {
            StopCoroutine(_showMessage);
            _showMessage = null;
        }

        _messageBox.text = message;

        if (player == EPlayer.Player2)
        {
            _imageBox.uvRect = new Rect(1, 0, -1, 1);
        }
        else
        {
            _imageBox.uvRect = new Rect(0, 0, 1, 1);
        }

        _showMessage = StartCoroutine(ShowMessage(dismiss));
    }

    private IEnumerator ShowMessage(bool dismiss = true)
    {
        _imageBox.gameObject.SetActive(true);

        if (dismiss)
        {
            yield return new WaitForSeconds(_defaultDismissTime);

            _imageBox.gameObject.SetActive(false);
        }

        _showMessage = null;
    }
}
