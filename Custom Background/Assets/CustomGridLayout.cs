using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;
using static UnityEngine.Rendering.DebugUI;

public class CustomGridLayout : MonoBehaviour
{
    public int rows = 3;
    public int columns = 3;
    public Vector2 spacing = new Vector2(10f, 10f);
    public float scaleDuration = 1f;
    public Vector3 scaleUpAmount = new Vector3(1.2f, 1.2f, 1f);
    public Ease scaleEaseType = Ease.OutBack;

    public GameObject imagePrefab;
    private GameObject[,] gridObjects;

    private Vector2 gridSize;
    public float moveSpeed = 100f;

    private void Start()
    {
        CreateGridLayout(); StartScalingAnimation();

    }

    private void CreateGridLayout()
    {
        gridObjects = new GameObject[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 position = new Vector2(col * (imagePrefab.GetComponent<RectTransform>().rect.width + spacing.x),
                                               -row * (imagePrefab.GetComponent<RectTransform>().rect.height + spacing.y));

                GameObject imageObj = Instantiate(imagePrefab, transform);
                imageObj.name = "Image_" + row + "_" + col;
                imageObj.GetComponent<RectTransform>().anchoredPosition = position;

                gridObjects[row, col] = imageObj;
            }
        }
    }
    private void StartScalingAnimation()
    {
        foreach (GameObject imageObj in gridObjects)
        {
            imageObj.transform.DOScale(scaleUpAmount, scaleDuration).SetEase(scaleEaseType).SetLoops(-1, LoopType.Yoyo);
        }
    }
    private void Update()
    {
        MoveGrid();
    }

    private void MoveGrid()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 newPosition = rectTransform.anchoredPosition;

        // Move the grid in the desired direction
        newPosition += new Vector2(moveSpeed * Time.deltaTime, 0f);

        // Wrap the grid around the screen if it goes out of bounds
        if (Mathf.Abs(newPosition.x) >= gridSize.x * 0.5f)
        {
            newPosition.x = Mathf.Sign(newPosition.x) * (gridSize.x * 0.5f);
        }

        rectTransform.anchoredPosition = newPosition;
    }

}


// You can add more functions to customize and manipulate the grid as needed.


