using UnityEngine;

public class Player : Character
{
    public static Player Instance { private set; get; }

    private void Start()
    {
        Instance = this;

        MessageBox.Instance.SetMessage("The world is too small for both of us!", MessageBox.EPlayer.Player1);
    }

#if !UNITY_ANDROID
    private void Update()
    {
        if ((!IsDefeated) && (!Enemy.Instance.IsDefeated))
        {
            if (Input.GetKey(KeyCode.Z))
            {
                if (Input.GetKey(KeyCode.X))
                {
                    ActionShoot();
                }
                else
                {
                    ActionDraw();
                }
            }
            else
            {
                ActionIdle();
            }
        }
    }
#endif

    public void ActionDraw()
    {
        ChangeState(ECharaterState.Draw);
    }

    public void ActionShoot()
    {
        if (Enemy.Instance.CurrentState == ECharaterState.Draw)
        {
            ChangeState(ECharaterState.Shoot);
            Enemy.Instance.ChangeState(ECharaterState.Defeated);

            MessageBox.Instance.SetMessage("The world is mine! Muahaha", MessageBox.EPlayer.Player1, false);
        }
        else
        {
            ChangeState(ECharaterState.Defeated);
            Enemy.Instance.ChangeState(ECharaterState.Draw);

            MessageBox.Instance.SetMessage("That's not fair play, you can't shoot if I didn't draw! \nThe world is mine now!", MessageBox.EPlayer.Player2, false);
        }
    }

    public void ActionIdle()
    {
        ChangeState(ECharaterState.Idle);
    }
}
