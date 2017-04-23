using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private Animator _playerAnimatior;
    private const string _animationIdle = "player_idle";
    private const string _animationShoot = "player_shoot";
    private const string _animationDefeated = "player_defeated";

    private void Awake()
    {
        _playerAnimatior = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerAnimatior.Play("player_idle");
	}

    private void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            _playerAnimatior.Play("player_shoot");
        }
        else if(Input.GetKey(KeyCode.X))
        {
            _playerAnimatior.Play("player_defeated");
        }
        else
        {
            _playerAnimatior.Play("player_idle");
        }
    }
}
