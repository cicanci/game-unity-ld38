using UnityEngine;

public class Enemy : Character
{
    public static Enemy Instance { private set; get; }

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Player.Instance.CurrentState == ECharaterState.Shoot)
        {
            ChangeState(ECharaterState.Defeated);
        }
        else if (Player.Instance.CurrentState == ECharaterState.Draw)
        {
            ChangeState(ECharaterState.Draw);
        }
        else
        {
            ChangeState(ECharaterState.Idle);
        }
    }
}
