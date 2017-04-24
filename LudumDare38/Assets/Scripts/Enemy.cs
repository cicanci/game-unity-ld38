using UnityEngine;
using System.Collections;

public class Enemy : Character
{
    private Coroutine _enemyAction;
    private const float _minActionTime = 0.5f;
    private const float _maxActionTime = 1.0f;

    public static Enemy Instance { private set; get; }
    
    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if ((!IsDefeated) && (!Player.Instance.IsDefeated))
        {
             if (Player.Instance.CurrentState == ECharaterState.Draw)
            {
                if (_enemyAction == null)
                {
                    _enemyAction = StartCoroutine(QuickDraw());
                }
            }
        }
    }

    private IEnumerator QuickDraw()
    {
        yield return new WaitForSeconds(Random.Range(_minActionTime, _maxActionTime));

        ChangeState(ECharaterState.Draw);

        yield return new WaitForSeconds(Random.Range(_minActionTime, _maxActionTime));

        if ((!IsDefeated) && (!Player.Instance.IsDefeated))
        {
            if (Random.value <= 0.5f)
            {
                ChangeState(ECharaterState.Idle);
            }
            else
            {
                ActionShoot();
            }
        }

        _enemyAction = null;
    }

    private void ActionShoot()
    {
        if (Player.Instance.CurrentState == ECharaterState.Draw)
        {
            ChangeState(ECharaterState.Shoot);
            Player.Instance.ChangeState(ECharaterState.Defeated);

            MessageBox.Instance.SetMessage("The world is mine! Muahaha", MessageBox.EPlayer.Player2, false);
        }
        else
        {
            ChangeState(ECharaterState.Defeated);
            Player.Instance.ChangeState(ECharaterState.Draw);

            MessageBox.Instance.SetMessage("That's not fair play, you can't shoot if I didn't draw! \nThe world is mine now!", MessageBox.EPlayer.Player1, false);
        }
    }
}
