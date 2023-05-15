using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    private bool _isTriggered = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Element element))
        {
            if (_isTriggered) return;

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
}