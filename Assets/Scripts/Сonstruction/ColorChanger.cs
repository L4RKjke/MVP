using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private bool _isTriggered = false;

    #region UnityTriggers
    private void OnCollisionEnter(Collision collision)
    {
        if (_isTriggered)
            return;

        if (collision.collider.TryGetComponent(out Element element))
        {
            _isTriggered = true;
            element.ChangeColor();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Element element))
        {
            _isTriggered = false;
        }
    }
    #endregion
}