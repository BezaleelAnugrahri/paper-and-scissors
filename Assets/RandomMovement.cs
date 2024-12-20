using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 3f; 
    public Vector3 targetPosition; 
    private Bounds areaBounds; 

    private void Start()
    {
        
        GameObject playArea = GameObject.Find("PlayArea"); 
        areaBounds = playArea.GetComponent<Collider>().bounds;

        SetRandomTargetPosition();
    }

    private void Update()
    {
        Movement();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other.name);

        if (other.name.Contains("Wall"))
        {
            SetRandomTargetPosition();
        }

        if (this.gameObject.name.Contains("Scissor"))//if this gameobject is scissor
        {
            if (other.name.Contains("Rock"))
            {
                Mesh mf = other.GetComponent<MeshFilter>().mesh;
                this.gameObject.GetComponent<MeshFilter>().mesh = mf;
                this.gameObject.name = other.name;
            }
            if (other.name.Contains("Paper"))
            {
                Mesh mf = this.GetComponent<MeshFilter>().mesh;
                other.gameObject.GetComponent<MeshFilter>().mesh = mf;
                other.gameObject.name = this.gameObject.name;
            }
        }
        else if (this.gameObject.name.Contains("Rock"))//if this gameobject is rock
        {
            if (other.name.Contains("Paper"))
            {
                Mesh mf = other.GetComponent<MeshFilter>().mesh;
                this.gameObject.GetComponent<MeshFilter>().mesh = mf;
                this.gameObject.name = other.name;
            }
            if (other.name.Contains("Scissor"))
            {
                Mesh mf = this.GetComponent<MeshFilter>().mesh;
                other.gameObject.GetComponent<MeshFilter>().mesh = mf;
                other.gameObject.name = this.gameObject.name;
            }
        }
        else //if this gameobject is paper
        {
            if (other.name.Contains("Scissor"))
            {
                Mesh mf = other.GetComponent<MeshFilter>().mesh;
                this.gameObject.GetComponent<MeshFilter>().mesh = mf;
                this.gameObject.name = other.name;
            }
            if (other.name.Contains("Rock"))
            {
                Mesh mf = this.GetComponent<MeshFilter>().mesh;
                other.gameObject.GetComponent<MeshFilter>().mesh = mf;
                other.gameObject.name = this.gameObject.name;
            }
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Wall"))
        {
            SetRandomTargetPosition();
        }
    }

    void Movement()
    {

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }

    private void SetRandomTargetPosition()
    {
        targetPosition = new Vector3(
            Random.Range(areaBounds.min.x, areaBounds.max.x),
            transform.position.y,
            Random.Range(areaBounds.min.z, areaBounds.max.z)
        );
    }

}
