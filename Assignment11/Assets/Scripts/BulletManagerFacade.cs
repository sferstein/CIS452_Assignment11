using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Sam Ferstein
 * BulletManagerFacade.cs
 * Assignment 11
 * This is the manager for the Facade pattern.
 */

public class BulletManagerFacade : MonoBehaviour
{
    public RedBullet redBullet;
    public BlueBullet blueBullet;
    public YellowBullet yellowBullet;

    public void FireBullets()
    {
        blueBullet.Fire();
        yellowBullet.Fire();
        redBullet.Fire();
    }
}
