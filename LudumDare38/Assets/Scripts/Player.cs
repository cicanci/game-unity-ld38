using UnityEngine;

public class Player : Character
{
    public static Player Instance { private set; get; }

    private void Start()
    {
        Instance = this;
        MessageBox.Instance.SetMessage("You are a pain in the ass", false);
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
