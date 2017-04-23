using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private void Awake()
    {
#if !UNITY_ANDROID && !UNITY_IOS
        gameObject.SetActive(false);
#endif
    }

    public void PlayerActionDraw()
    {
        Player.Instance.ChangeState(Character.ECharaterState.Shoot);
    }

    public void PlayerActionShoot()
    {
        Player.Instance.ChangeState(Character.ECharaterState.Defeated);
    }

    public void PlayerActionIdle()
    {
        Player.Instance.ChangeState(Character.ECharaterState.Idle);
    }
}
