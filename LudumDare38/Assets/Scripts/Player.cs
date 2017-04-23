using UnityEngine;

public class Player : Character
{
    public static Player Instance { private set; get; }

    private void Start()
    {
        Instance = this;
        MessageBox.Instance.SetMessage("The world is too small for both of us!", false);
    }

    private void Update()
    {
#if !UNITY_ANDROID && !UNITY_IOS
        if(Input.GetKey(KeyCode.Z))
        {
            if (Input.GetKey(KeyCode.X))
            {
                ChangeState(ECharaterState.Shoot);
            }
            else
            {
                ChangeState(ECharaterState.Draw);
            }
        }
        else
        {
            ChangeState(ECharaterState.Idle);
        }
#endif
    }
}
