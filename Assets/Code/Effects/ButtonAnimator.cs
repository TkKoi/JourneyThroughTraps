using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField] private float _scaleFactor = 1f;
    [SerializeField] private float _animationDuration = 0.1f;

    private float _originalScale;

    private void Awake()
    {
        _originalScale = transform.localScale.x;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GetComponent<Button>().interactable) 
            AnimateButton(_originalScale - _scaleFactor);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (GetComponent<Button>().interactable)
            AnimateButton(_originalScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (GetComponent<Button>().interactable) 
            AnimateButton(_originalScale);
    }

    private void AnimateButton(float targetScale)
    {
        transform.DOScale(targetScale, _animationDuration).SetUpdate(true);
    }
}
