using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackHealthPowerups : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.healthPowerups.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        // Guardian clause - don't try to access the game manager if it's null
        if (GameManager.Instance == null)
        {
            return;
        }
        // Only remove this from the list if it's inside the list.
        if (GameManager.Instance.healthPowerups.Contains(this.gameObject))
        {
            GameManager.Instance.healthPowerups.Remove(this.gameObject);
        }
    }
}
