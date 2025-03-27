using UnityEngine;

public class CityTriggers : MonoBehaviour {
    public GameObject[] objectsToActivate; // Assign in Inspector

    // Call this function to activate all assigned objects
    public void ActivateObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }

    public void Deactivated()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}
