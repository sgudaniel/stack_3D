using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackFactory
{
    public StackComponent Create(Vector3 position, bool mustUseGravity, Vector3 scale)
    {
        var stack = GameObject.Instantiate(PrefabResolver.StackPrefab, position, Quaternion.identity);
        var rigidBody = stack.AddComponent<Rigidbody>();
         rigidBody.useGravity = mustUseGravity;
        var stackComponent  = stack.AddComponent<StackComponent>();
        stackComponent.transform.localScale = scale;

        return stackComponent;
    }

    public StackComponent CreateFirstStack(Vector3 position, bool mustUseGravity)
    {
        var stack = GameObject.Instantiate(PrefabResolver.StackPrefab, position, Quaternion.identity);
        var rigidBody = stack.AddComponent<Rigidbody>();
         rigidBody.useGravity = mustUseGravity;
        var stackComponent  = stack.AddComponent<StackComponent>();
        stackComponent.stop();

        return stackComponent;
    }
}
