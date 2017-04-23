using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    protected Animator _playerAnimatior;
    protected const string _animationIdle = "player_idle";
    protected const string _animationShoot = "player_shoot";
    protected const string _animationDefeated = "player_defeated";
}
