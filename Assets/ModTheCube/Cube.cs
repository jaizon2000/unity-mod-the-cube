using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float rotateSpeed = 10.0f;

    public Material[] colorMaterials;

    void Start()
    {
        transform.position = new Vector3(1, 4, 1);
        transform.localScale = Vector3.one * 1.6f;

        Material material = Renderer.material;

        // get random color from list and apply it
        material.color = colorMaterials[Random.Range(0, colorMaterials.Length)].color;
        
    }

    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime * rotateSpeed, 3.0f * Time.deltaTime * rotateSpeed, 0.0f);
    }
}