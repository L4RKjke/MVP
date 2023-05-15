using UnityEngine;

public class Element : MonoBehaviour
{
    private MeshRenderer _renderer;
    private Material _material;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _material = _renderer.materials[0];
    }

    public void ChangeColor()
    {
        _material.color = Color.red;
    }
}
