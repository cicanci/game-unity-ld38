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
        else if (Player.Instance.CurrentState == ECharaterState.Defeated)
        {
            ChangeState(ECharaterState.Shoot);
        }
        else
        {
            ChangeState(ECharaterState.Idle);
        }
    }
}
