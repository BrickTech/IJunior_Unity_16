using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private static int Walk = Animator.StringToHash(nameof(Walk));
    private float _forwardRotationValue = -90.0f;
    private float _backRotationValue = 90.0f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, _forwardRotationValue, transform.rotation.x);
            _animator.SetBool(Walk, true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, _backRotationValue, transform.rotation.x);
            _animator.SetBool(Walk, true);
        }
        else
        {
            _animator.SetBool(Walk, false);
        }
    }
}
