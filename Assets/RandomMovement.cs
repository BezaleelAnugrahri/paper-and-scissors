using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 1.0f;
    private Transform target;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTo();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other.name);
        if (other.name == "Rock" && this.gameObject.name != other.name)
        {
            Mesh mf = other.GetComponent<MeshFilter>().mesh;
            this.gameObject.GetComponent<MeshFilter>().mesh = mf;
        }
        if (other.name == "Paper" && this.gameObject.name != other.name)
        {
            Mesh mf = other.GetComponent<MeshFilter>().mesh;
            this.gameObject.GetComponent<MeshFilter>().mesh = mf;
        }
        if (other.name == "Scisor" && this.gameObject.name != other.name)
        {
            Mesh mf = other.GetComponent<MeshFilter>().mesh;
            this.gameObject.GetComponent<MeshFilter>().mesh = mf;
        }
    }

    void MoveTo()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 randTarget = new Vector3(Random.Range(1, 10), 0, Random.Range(1, 10));
        var step = speed * Time.deltaTime;
        if (rb.position != randTarget)
        {
            rb.position = Vector3.MoveTowards(rb.position, randTarget, step);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

}
