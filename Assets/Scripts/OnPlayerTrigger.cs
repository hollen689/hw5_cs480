using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPlayerTrigger : MonoBehaviour
{
    public float displayTime = 3f;
    public float delayBeforeShowing = 2f;
    public TextMeshPro textMeshPro;
    public GameObject[] bottles;
    public float moveSpeed = 2f;
    public GameObject city;
    public float moveAmount = 10f;
    public float cityMoveSpeed = 1f;
    public Material newSkybox;
    public GameObject player;
    public Transform newSpawnPoint;
    public GameObject car;  // 🚗 Car object
    public float carSpeed = 5f;
    public float carStopX = 50f; // X position where the car stops

    private bool bottlesMoving = false;
    private bool cityMoving = false;
    private bool teleportTriggered = false;
    private bool skyChanged = false;
    private bool carMoving = false;  // 🚗 Car movement flag
    private Vector3 targetCityPosition;

    public float bottleXThreshold = -10f; // X position at which player is teleported

    void Start()
    {
        Invoke("ShowText", delayBeforeShowing);
    }

    void Update()
    {
        if (bottlesMoving)
        {
            MoveBottles();
        }

        if (cityMoving)
        {
            city.SetActive(true);
            MoveCity();
        }

        if (!skyChanged && (bottlesMoving || cityMoving))
        {
            ChangeSkybox();
        }

        if (!teleportTriggered && HasBottleReachedThreshold())
        {
            MovePlayerToNewLocation();
            teleportTriggered = true;
            carMoving = true;
        }

        if (carMoving)
        {
            MoveCar();
        }
    }

    private void ShowText()
    {
        textMeshPro.gameObject.SetActive(true);
        Invoke("HideText", displayTime);
    }

    private void HideText()
    {
        textMeshPro.gameObject.SetActive(false);
        bottlesMoving = true;
        cityMoving = true;
        ActivateBottles();
        StartCity();
    }

    private void MoveBottles()
    {
        foreach (GameObject bottle in bottles)
        {
            if (bottle != null)
            {
                bottle.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
        }
    }

    private bool HasBottleReachedThreshold()
    {
        foreach (GameObject bottle in bottles)
        {
            if (bottle != null && bottle.transform.position.x <= bottleXThreshold)
            {
                return true; // Trigger teleport as soon as one bottle reaches the threshold
            }
        }
        return false;
    }

    private void ActivateBottles()
    {
        foreach (GameObject bottle in bottles)
        {
            if (bottle != null)
            {
                bottle.SetActive(true);
            }
        }
    }

    private void StartCity()
    {
        if (city != null)
        {
            targetCityPosition = city.transform.position + new Vector3(0, moveAmount, 0);
        }
    }

    private void MoveCity()
    {
        if (city != null && city.transform.position.y < targetCityPosition.y)
        {
            city.transform.position = Vector3.MoveTowards(city.transform.position, targetCityPosition, cityMoveSpeed * Time.deltaTime);
        }
        else
        {
            cityMoving = false;
        }
    }

    private void ChangeSkybox()
    {
        if (newSkybox != null)
        {
            RenderSettings.skybox = newSkybox;
            DynamicGI.UpdateEnvironment();
            skyChanged = true;
        }
    }

    private void MovePlayerToNewLocation()
    {
        SceneManager.LoadScene("city");
    }

    private void MoveCar()
    {

        car.transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);

    }
}
