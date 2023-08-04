using UnityEngine;
using DG.Tweening;

public class GridElementScaler : MonoBehaviour
{
    public float startDelay = 0f;
    public float scaleDuration = 1f;
    public Vector3 scaleUpAmount = new Vector3(1.2f, 1.2f, 1f);
    public Ease scaleEaseType = Ease.OutBack;

    private void Start()
    {
        Invoke("StartScalingAnimation", startDelay);
    }

    private void StartScalingAnimation()
    {
        transform.DOScale(scaleUpAmount, scaleDuration).SetEase(scaleEaseType).SetLoops(-1, LoopType.Yoyo);
    }
}
