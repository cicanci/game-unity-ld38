using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject ButtonDraw;
    public GameObject ButtonShoot;
    public GameObject ButtonPlayAgain;

    private void Start()
    {
        ButtonDraw.SetActive(true);
        ButtonShoot.SetActive(false);
        ButtonPlayAgain.SetActive(false);
    }

    private void Update()
    {
        if ((Player.Instance.IsDefeated) || (Enemy.Instance.IsDefeated))
        {
            ButtonDraw.SetActive(false);
            ButtonShoot.SetActive(false);
            ButtonPlayAgain.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
