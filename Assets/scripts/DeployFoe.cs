using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DeployFoe : MonoBehaviour
{
    public static int FoeCount = 1;
    public GameObject foePrefab;
    public float respawnTime;
    private Vector2 scrnbounds;

    void Start()
    {
        scrnbounds = Camera.main.ScreenToWorldPoint(
             new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(FoeWave());
    }
    private void spawnfoe()
    {
        DeployFoe.FoeCount++;
        GameObject a = Instantiate(foePrefab) as GameObject;
        a.transform.position = new Vector2(UnityEngine.Random.Range(
            -scrnbounds.x, scrnbounds.x), scrnbounds.y * 2);
    }

    IEnumerator FoeWave()
    {


        while (respawnTime > 0.01)
        {
            spawnfoe();
            respawnTime -= .01f / DeployFoe.FoeCount;
            yield return new WaitForSeconds(respawnTime);
        }
        while (respawnTime <= 0.01)
        {
            respawnTime += .01f;
        }
        StartCoroutine(FoeWave());
    }
}
