using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFactory : MonoBehaviour
{
    public MenuComponent Create(Vector3 position, Quaternion rotation)
    {
        var menu = GameObject.Instantiate(PrefabResolver.MenuPrefab, position, rotation);
        var menuComponent = menu.AddComponent<MenuComponent>();

        return menuComponent;
    }
}
