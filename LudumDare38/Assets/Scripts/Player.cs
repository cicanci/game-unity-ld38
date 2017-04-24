using UnityEngine;

public class Player : Character
{
    public static Player Instance { private set; get; }

    private void Start()
    {
        Instance = this;

        MessageBox.Instance.SetMessage("The world is too small for both of us!", 
            MessageBox.EPlayer.Player1);
    }

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

    public void ActionDraw()
    {
        ChangeState(ECharaterState.Draw);
    }

    public void ActionShoot()
    {
        ChangeState(ECharaterState.Shoot);
    }

    public void ActionIdle()
    {
        ChangeState(ECharaterState.Idle);
    }
}
