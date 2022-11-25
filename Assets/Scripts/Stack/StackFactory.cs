using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackFactory
{
    public StackComponent Create(Vector3 position, bool mustUseGravity)
    {
        var stack = GameObject.Instantiate(PrefabResolver.StackPrefab, position, Quaternion.identity);
        var rigidBody = stack.AddComponent<Rigidbody>();
         rigidBody.useGravity = mustUseGravity;
        var stackComponent  = stack.AddComponent<StackComponent>();

        return stackComponent;
    }
}
