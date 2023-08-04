using UnityEngine;

public class GridElementMover : MonoBehaviour
{
    public Vector2 movementDirection = Vector2.right;
    public float moveSpeed = 5f;

    private float screenWidth;
    private float screenHeight;
    private float objectWidth;
    private float objectHeight;

    Transform parentTransform;
    private void Start()
    {
        parentTransform = transform.parent;
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        // Calculate the size of the object
        RectTransform rectTransform = GetComponentInParent<RectTransform>();
        objectWidth = rectTransform.rect.width * rectTransform.localScale.x;
        objectHeight = rectTransform.rect.height * rectTransform.localScale.y;
    }

    private void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        Vector3 forwardDirection = parentTransform.right;
        forwardDirection.z = 0f; // Set z-component to 0 to move only in the xy-plane

        Vector3 newPosition = transform.position + forwardDirection * moveSpeed * Time.deltaTime;

        // Check if the object is out of the parent's bounds
        float objectHalfWidth = objectWidth * 0.5f;
        float objectHalfHeight = objectHeight * 0.5f;

        RectTransform parentRectTransform = parentTransform.GetComponent<RectTransform>();
        float parentHalfWidth = parentRectTransform.rect.width * 0.5f;
        float parentHalfHeight = parentRectTransform.rect.height * 0.5f;

        if (newPosition.x + objectHalfWidth < parentTransform.position.x - parentHalfWidth)
            newPosition.x = parentTransform.position.x + parentHalfWidth + objectHalfWidth;
        else if (newPosition.x - objectHalfWidth > parentTransform.position.x + parentHalfWidth)
            newPosition.x = parentTransform.position.x - parentHalfWidth - objectHalfWidth;

        if (newPosition.y + objectHalfHeight < parentTransform.position.y - parentHalfHeight)
            newPosition.y = parentTransform.position.y + parentHalfHeight + objectHalfHeight;
        else if (newPosition.y - objectHalfHeight > parentTransform.position.y + parentHalfHeight)
            newPosition.y = parentTransform.position.y - parentHalfHeight - objectHalfHeight;

        transform.position = newPosition;
    }




}
