using UnityEngine;

public class Enemy : Character
{
    private void Awake()
    {
        _playerAnimatior = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerAnimatior.Play(_animationIdle);
    }

    private void Update()
    {

    }
}
