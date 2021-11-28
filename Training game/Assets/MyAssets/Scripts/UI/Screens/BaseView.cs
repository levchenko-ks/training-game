using UnityEngine;

public abstract class BaseView : MonoBehaviour, IView
{
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetCanvas(Canvas canvas)
    {
        transform.SetParent(canvas.transform, false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}