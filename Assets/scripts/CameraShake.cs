﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator shake(float duration, float magnitude)
    {
        Vector2 originalpos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = new Vector2(x, y);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalpos;
    }

}
