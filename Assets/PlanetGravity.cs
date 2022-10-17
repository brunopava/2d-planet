using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    public Transform planet;

    public float G;
    public float planetMass;

    public float playerSpeed = 10f;
    public float jumpForce = 100f;

    private Rigidbody2D _rigidbody;
    private float _distance;
    private float _playerMass;

    private float _forceValue;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerMass = _rigidbody.mass;

        _distance = Vector3.Distance(planet.position, transform.position);
        _forceValue = G * _playerMass * planetMass / (_distance * _distance);
    }

    private void Update()
    {
        Vector3 direction = (planet.position - transform.position).normalized;
        _rigidbody.AddForce(_forceValue * direction);

        if(Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(playerSpeed * Vector3.right);
        }

        if(Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(playerSpeed * Vector3.left);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(jumpForce*Vector3.up);
        }
    }
}