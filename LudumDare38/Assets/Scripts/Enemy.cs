using UnityEngine;
using System.Collections;

public class Enemy : Character
{
    private Coroutine _enemyAction;
    private float _minActionTime = 1.0f;
    private float _maxActionTime = 2.0f;

    public static Enemy Instance { private set; get; }
    
    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!IsDefeated)
        {
            if ((Player.Instance.CurrentState == ECharaterState.Shoot) &&
                (CurrentState == ECharaterState.Draw))
            {
                ChangeState(ECharaterState.Defeated);

                MessageBox.Instance.SetMessage("The world is mine! Muahaha",
                    MessageBox.EPlayer.Player1, false);
            }
            else if (Player.Instance.CurrentState == ECharaterState.Draw)
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

        ChangeState(ECharaterState.Idle);

        _enemyAction = null;
    }
}
