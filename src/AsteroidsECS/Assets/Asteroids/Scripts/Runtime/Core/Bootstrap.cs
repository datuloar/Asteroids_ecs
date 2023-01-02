using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return InitExternalServices();

        //TODO : Loader        
    }

    private IEnumerator InitExternalServices()
    {
        // Yandex
        // Steam
        // Epic
        // etc
        yield return null;
    }
}
