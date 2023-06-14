using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] public Vector2 topLeft;
    [SerializeField] public Vector2 bottomRight;
    /*
    [SerializeField] public float followSpeedFactor;
    [SerializeField] public float leashDistance;
    [SerializeField] public float catchUpSpeed;*/
    [SerializeField] GameObject Target;
    private Camera managedCamera;
    //private bool centered = false;

    private void Awake()
    {
        managedCamera = gameObject.GetComponent<Camera>();
    }

    void LateUpdate()
    {
        var targetPosition = this.Target.transform.position;
        var cameraPosition = managedCamera.transform.position;
        
        cameraPosition = new Vector3(targetPosition.x - topLeft.x - bottomRight.x, targetPosition.y - topLeft.y - bottomRight.y, cameraPosition.z);

        managedCamera.transform.position = cameraPosition;
    }
    
    /*
    void LateUpdate()
    {
        var targetPosition = this.Target.transform.position;
        var cameraPosition = managedCamera.transform.position;

        if (this.centered == false)
        {
            cameraPosition = new Vector3(targetPosition.x - topLeft.x - bottomRight.x, targetPosition.y - topLeft.y - bottomRight.y, cameraPosition.z);
            managedCamera.transform.position = cameraPosition;
            this.centered = true;
        }

        else
        {
            Vector3 movementDirection = this.Target.GetComponent<PlayerController>().GetMovementDirection();
            Vector3 directionVec = new Vector3(targetPosition.x - cameraPosition.x, targetPosition.y - cameraPosition.y, targetPosition.z - cameraPosition.z).normalized;
            var movementDirectionMag = movementDirection.magnitude;
            var distance = new Vector2(targetPosition.x - cameraPosition.x, targetPosition.y - cameraPosition.y).magnitude;
            float currentSpeed = this.Target.GetComponent<PlayerController>().GetCurrentSpeed();

            if(movementDirectionMag == 0)
            {
                cameraPosition = new Vector3(cameraPosition.x + Time.deltaTime * (directionVec.x * catchUpSpeed), cameraPosition.y + Time.deltaTime * (directionVec.y * catchUpSpeed), cameraPosition.z);
            }

            if(distance < leashDistance)
            {
                cameraPosition = new Vector3(cameraPosition.x + Time.deltaTime * (directionVec.x * followSpeedFactor), cameraPosition.y + Time.deltaTime * (directionVec.y * followSpeedFactor), cameraPosition.z);
            }

            if(distance >= leashDistance)
            {
                cameraPosition = new Vector3(cameraPosition.x + Time.deltaTime * (movementDirection.x * currentSpeed), cameraPosition.y + Time.deltaTime * (movementDirection.y * currentSpeed), cameraPosition.z);
            }

            managedCamera.transform.position = cameraPosition;
        }
    }*/
}
