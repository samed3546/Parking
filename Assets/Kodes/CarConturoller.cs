using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarConturoller : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 50f;
    private float currentRotation = 0f;

    [SerializeField]
    private float MoveSpeed = 5f;
    GameManager Manager;
    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // rotate
        float rotateDirection = Input.GetAxis("Horizontal");
        this.transform.localEulerAngles += Vector3.up * rotateDirection * rotateSpeed * Time.deltaTime;
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);

        currentRotation += rotateDirection * rotateSpeed * Time.deltaTime;
        if (currentRotation > 360)
        {
            currentRotation -= 360;
        }

        // foward
        float moveDirection = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.forward * moveDirection * Time.deltaTime * MoveSpeed, Space.Self);

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Zone")
        {
            Debug.Log("Complet");
            Manager.Missons();
            transform.position = new Vector3(0, 0, 0);
            // bu kısımda başarılı için menü veya efetk eklenebilir.
        }
        else if (other.tag == "Death")
        {
            // başarısız belirtisi eklenebilir.
            Debug.Log("Faild");
            SceneManager.LoadScene(0);
        }
            
        
    }
}
