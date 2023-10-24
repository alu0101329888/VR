using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Range(0f, 10f)]
    public float speed;
    public int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Animation>().Play("Walk");
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            movement = Quaternion.AngleAxis(-45, Vector3.up) * movement;
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().transform.position + movement.normalized * speed);
            GetComponent<Rigidbody>().transform.LookAt(GetComponent<Rigidbody>().transform.position + movement.normalized * speed);
        } else
        {
            GetComponent<Animation>().Play("Idle");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Spider")
        {
            print(contador);
            contador += 10;
        }
    }
}
