using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Material material;
    public MeshRenderer Renderer;

    public float rotateSpeed = 10.0f;
    public float changeColorInterval = 2; 
    
    // list of color materials
    public Material[] colorMaterials;


    private float timer = 0;

    void Start()
    {
        // position change
        transform.position = new Vector3(1, 4, 1);
        // scale change
        transform.localScale = Vector3.one * 3f;

        // assign current materials into material var
        material = Renderer.material;
    }

    void Update()
    {
        if (timer > changeColorInterval)
        {
            // if time elapsed more than changeColorInterval
            StartCoroutine(LerpFunction(getRandomColor(), changeColorInterval));

            Debug.Log(timer); // Debug
            timer = 0;
        }
        else
        {
            // if time elapsed ISN'T more than changeColorInterval
            timer += Time.deltaTime;
        }

        // rotate cube
        transform.Rotate(10.0f * Time.deltaTime * rotateSpeed, 3.0f * Time.deltaTime * rotateSpeed, 0.0f);
    }

    /**
     * get a random Color from provided material color list
     */
    Color getRandomColor()
    {
        return colorMaterials[Random.Range(0, colorMaterials.Length)].color;
    }

    /**
     * Lerp function from this tut: https://bit.ly/3pwgFLK
     */
    IEnumerator LerpFunction(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = material.color;

        // while prevents layering of the function
        while (time < duration)
        {
            material.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        material.color = endValue;
    }
}