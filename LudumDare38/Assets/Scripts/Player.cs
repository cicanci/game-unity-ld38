using UnityEngine;

public class Player : Character
{
    public static Player Instance { private set; get; }

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
#if !UNITY_ANDROID && !UNITY_IOS
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
#endif
    }
}
