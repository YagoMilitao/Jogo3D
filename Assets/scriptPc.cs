using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPc : MonoBehaviour {

    private Rigidbody rbd;
    public float velocidade = 80;
    public float rotVel = 20;
    private float rotY = 0;
    private float rotX = 0;
    Quaternion rotOriginal;
    public LayerMask mascara;

    // Use this for initialization
    void Start()
    {
        rotOriginal = transform.localRotation;
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float frente = Input.GetAxis("Vertical");
        float lado = Input.GetAxis("Horizontal");

        rbd.velocity = transform.TransformDirection(new Vector3(lado * velocidade, rbd.velocity.y, frente * velocidade));

        rotY += Input.GetAxis("Mouse X");
        rotX += Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, -45, 45);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.up);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.left);
        transform.localRotation = rotOriginal * yQuaternion;
        Camera.main.transform.localRotation = rotOriginal * xQuaternion;

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("tiro");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, 500, mascara))
            {
                Debug.Log("acertou");
                hit.rigidbody.AddForce(Camera.main.transform.TransformDirection(new Vector3(0, 0, 2000)));
            }
        }

    }
}
