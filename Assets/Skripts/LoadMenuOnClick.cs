
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadMenuOnClick : MonoBehaviour
{
    public string menuSceneName; 
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsPointerOverObject())
        {
            SceneManager.LoadScene(menuSceneName); 
        }
    }

    private bool IsPointerOverObject()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            return true;
        }

        return false;
    }
}