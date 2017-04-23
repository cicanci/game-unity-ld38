using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    private Animator _playerAnimatior;
    private const string _animationIdle = "player_idle";
    private const string _animationShoot = "player_shoot";
    private const string _animationDefeated = "player_defeated";

    public enum ECharaterState
    {
        Idle,
        Shoot,
        Defeated
    }

    public ECharaterState CurrentState { private set; get; }

    private void Awake()
    {
        CurrentState = ECharaterState.Idle;
        _playerAnimatior = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerAnimatior.Play(_animationIdle);
    }

    public void ChangeState(ECharaterState state)
    {
        CurrentState = state;

        switch (state)
        {
            case ECharaterState.Idle:
                _playerAnimatior.Play(_animationIdle);
                break;
            case ECharaterState.Shoot:
                _playerAnimatior.Play(_animationShoot);
                break;
            case ECharaterState.Defeated:
                _playerAnimatior.Play(_animationDefeated);
                break;
            default:
                break;
        }
    }
}
