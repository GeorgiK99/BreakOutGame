using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float _speed = 20f;
    Rigidbody _rigidbody;
    Vector3 _velocity;
    Renderer _rendered;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rendered = GetComponent<Renderer>();
        Invoke("Launch", 0.5f);
    }
    void Launch()
    {
        _rigidbody.velocity = Vector3.up * _speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * _speed;
        _velocity = _rigidbody.velocity;
        if(!_rendered.isVisible)
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }
    private void  OnCollisionEnter (Collision collision)
    {
        _rigidbody.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);
    }
}
