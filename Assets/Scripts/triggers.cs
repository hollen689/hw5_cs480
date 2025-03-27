using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;

public class triggers : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToDeactivate;
    public GameObject targetObject;

    // Call this function to activate all assigned objects
    public void ActivateObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {

            obj.SetActive(true);
        }
    }

    public void Deactivated()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ActivateObjects();
        Deactivated();
    }
}
