using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tree : TrashPlant
{
    [SerializeField] private Renderer[] renderers;
    [SerializeField] private float fadeDistance;
    [SerializeField] private Material materialInstance;
    [SerializeField] private float fadeDuration;
    [SerializeField] private float fadeOut;
    [SerializeField] private float fadeIn;

    private Coroutine currentFade;
    private bool isInvis = false;

    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        float s = Random.Range(0.6f, 1.2f);
        transform.localScale = new Vector3(s, s, s);
        
        materialInstance = Instantiate(renderers[0].sharedMaterial);
        foreach (Renderer renderer in renderers)
        {
            renderer.material = materialInstance;
        }
        
        SetupMaterialForTransparency();
    }

    private void LateUpdate()
    {
        float distance = Vector3.Distance(Player.instance.transform.position, transform.position);
        if (distance < fadeDistance)
        {
            if (!isInvis)
            {
                FadeIn();
                isInvis = !isInvis;
            }
        }
        else
        {
            if (isInvis)
            {
                FadeOut();
                isInvis = !isInvis;
            }
        }
    }

    public void FadeOut()
    {
        if (currentFade != null)
            StopCoroutine(currentFade);

        currentFade = StartCoroutine(FadeTo(fadeOut));
    }

    public void FadeIn()
    {
        if (currentFade != null)
            StopCoroutine(currentFade);

        currentFade = StartCoroutine(FadeTo(fadeIn));
    }
    
    private IEnumerator FadeTo(float targetAlpha)
    {
        Color startColor = materialInstance.color;
        float startAlpha = startColor.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = time / fadeDuration;

            Color newColor = materialInstance.color;
            newColor.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            materialInstance.color = newColor;

            yield return null;
        }

        Color finalColor = materialInstance.color;
        finalColor.a = targetAlpha;
        materialInstance.color = finalColor;
    }
    
    private void SetupMaterialForTransparency()
    {
        materialInstance.SetFloat("_Mode", 3);
        materialInstance.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        materialInstance.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        materialInstance.SetInt("_ZWrite", 1);
        materialInstance.DisableKeyword("_ALPHATEST_ON");
        materialInstance.EnableKeyword("_ALPHABLEND_ON");
        materialInstance.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        // materialInstance.renderQueue = 3999;
    }
}
