using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadMenuOnClick : MonoBehaviour
{
    [SerializeField]
    private SceneSettings sceneSettings;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsPointerOverObject())
        {
            SceneManager.LoadScene(sceneSettings.menuSceneName);
        }
    }

    private bool IsPointerOverObject()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        return hit.collider != null && hit.collider.gameObject == gameObject;
    }
}