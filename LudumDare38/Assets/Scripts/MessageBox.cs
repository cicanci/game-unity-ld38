using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageBox : MonoBehaviour
{
    private Text _messageBox;
    private RawImage _imageBox;

    public static MessageBox Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
        _messageBox = GetComponentInChildren<Text>();
        _imageBox = GetComponentInChildren<RawImage>();
        _imageBox.gameObject.SetActive(false);
    }

    public void SetMessage(string message, bool flip)
    {
        _messageBox.text = message;

        if (flip)
        {
            _imageBox.uvRect = new Rect(1, 0, -1, 1);
        }
        else
        {
            _imageBox.uvRect = new Rect(0, 0, 1, 1);
        }

        StartCoroutine(ShowMessage());
    }

    private IEnumerator ShowMessage()
    {
        _imageBox.gameObject.SetActive(true);

        yield return new WaitForSeconds(3);

        _imageBox.gameObject.SetActive(false);
    }
}
