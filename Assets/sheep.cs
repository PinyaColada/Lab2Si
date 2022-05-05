using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheep : MonoBehaviour
{

    public float runSpeed; // 1
    public float gotHayDestroyDelay; // 2
    private bool hitByHay; // 3

    public float dropDestroyDelay; // 1
    private Collider myCollider; // 2
    private Rigidbody myRigidbody; // 3
    private bool shrink = false;

    private Vector3 scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);

    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1 * Vector3.up * runSpeed * Time.deltaTime);

        if (shrink) {
            transform.localScale += scaleChange;
        }
    }

    private void HitByHay()
    {
        hitByHay = true; // 1
        runSpeed = 0; // 2

        Destroy(gameObject, gotHayDestroyDelay); // 3
        shrink = true;
    }

    private void Drop()
    {
        myRigidbody.isKinematic = false; // 1
        myCollider.isTrigger = false; // 2
        Destroy(gameObject, dropDestroyDelay); // 3
    }

    private void OnTriggerEnter(Collider other) // 1
    {
        if (other.CompareTag("Hay") && !hitByHay) // 2
        {
            Destroy(other.gameObject); // 3
            HitByHay(); // 4
        } 
        else if (other.CompareTag("DropSheep"))
        {
            Drop();
        }
    }
}
