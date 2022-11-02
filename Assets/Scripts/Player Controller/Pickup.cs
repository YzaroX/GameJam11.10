using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    [SerializeField] Transform objectPicked;
    [SerializeField] Transform noObjectCatched;

    Vector3 objectPickedPosition;
    Vector3 noObjectCatchedPosition;

    private GameObject heldObj;
    private Rigidbody heldObjRB;
    [SerializeField] private float pickupRange = 2.0f;
    [SerializeField] private float pickupForce = 150.0f;

    private void Start()
    {
        noObjectCatchedPosition = noObjectCatched.localPosition;
        objectPickedPosition = objectPicked.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }
        if (heldObj != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, objectPicked.position) > 0.1f)
        {
            Vector3 moveDirection = (objectPicked.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            objectPicked.localPosition = objectPickedPosition;

            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = objectPicked;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        objectPicked.localPosition = noObjectCatchedPosition;
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObj = null;
    }
}
