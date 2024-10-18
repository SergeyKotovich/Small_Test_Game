using UnityEngine;

/// <summary>
/// Вспомогательный класс, содержащий метод, позволяющий получить выбранный объект
/// </summary>
public static class RaycastUtils
{
    public static T GetSelectedObject<T>() where T : MonoBehaviour
    {
        var mousePosition = Input.mousePosition;
        var ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            var selectedObject = hitInfo.collider.gameObject.GetComponent<T>();
            return selectedObject;
        }
        
        return null;
    }
}