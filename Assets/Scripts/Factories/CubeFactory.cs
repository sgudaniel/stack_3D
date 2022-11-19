using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFactory
{
    public CubeComponent Create(Vector3 position, bool mustUseGravity)
    {
        var cube = GameObject.Instantiate(PrefabResolver.CubePrefab, position, Quaternion.identity);
        var rigidBody = cube.AddComponent<Rigidbody>();
         rigidBody.useGravity = mustUseGravity;
        var cubeComponent  = cube.AddComponent<CubeComponent>();

        return cubeComponent;
    }
}
