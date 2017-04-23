using UnityEngine;

public class Player : Character
{
    private void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            ChangeState(ECharaterState.Shoot);
        }
        else if(Input.GetKey(KeyCode.X))
        {
            ChangeState(ECharaterState.Defeated);
        }
        else
        {
            ChangeState(ECharaterState.Idle);
        }
    }
}
