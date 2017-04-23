using UnityEngine;

public class Player : Character
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
        if(Input.GetKey(KeyCode.Z))
        {
            _playerAnimatior.Play(_animationShoot);
        }
        else if(Input.GetKey(KeyCode.X))
        {
            _playerAnimatior.Play(_animationDefeated);
        }
        else
        {
            _playerAnimatior.Play(_animationIdle);
        }
    }
}
