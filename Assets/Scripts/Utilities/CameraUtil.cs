using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraUtil
{

    public static Vector3 InFront(Camera camera){
        return camera.transform.TransformPoint(Vector3.forward * 10);
    }

    public static Quaternion InFrontRotation(Camera camera){
        var cameraRotation = camera.transform.rotation;
        return Quaternion.Euler(cameraRotation.x,cameraRotation.y,cameraRotation.z);
    }

    public static Vector3 increaseHeight(Camera camera){
        return camera.transform.TransformPoint(Vector3.up * 0.038f);
    }

    public static Vector3 setHeight(Camera camera){
        return camera.transform.TransformPoint(Vector3.up);
    }


}
