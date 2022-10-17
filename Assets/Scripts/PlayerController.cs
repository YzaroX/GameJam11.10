using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Move Controller
    public CharacterController controller;
    public float speed = 12f;

    //Rotate camera
    public float mouseSensibility = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    Vector3 holdAreaPositionWithoutObject;
    Vector3 holdAreaPositionWithObject;

    //Pickup & Drop
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    [SerializeField] Transform holdAreaWithObj;
    private GameObject heldObj;
    private Rigidbody heldObjRB;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Rotate camera
        holdAreaPositionWithoutObject = holdArea.localPosition;
        holdAreaPositionWithObject = holdAreaWithObj.localPosition;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Move Controller
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Rotate camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        //Pickup & Drop
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    //Pickup Object
                    PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                //Drop Object
                DropObject();
            }
        }
        if (heldObj != null)
        {
            //Move Object
            MoveObject();
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && holdArea.transform.localPosition.z <= 2.99f)
        {
            holdArea.localPosition += Vector3.forward * 0.5f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && holdArea.transform.localPosition.z >= 1.01f)
        {
            holdArea.localPosition += Vector3.back * 0.5f;
        }
    }

    void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            holdArea.localPosition = holdAreaPositionWithObject;
            //heldObj.transform.localRotation
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        holdArea.localPosition = holdAreaPositionWithoutObject;
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;
        heldObjRB.transform.parent = null;
        heldObj = null;
    }
}
