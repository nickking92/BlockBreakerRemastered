using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour {
    Level level;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockEffectVFX;
   
    [SerializeField] Sprite[] hitSprites;
     int timesHit;
    void Start()
    {

        level = FindObjectOfType<Level>();
        if (tag == "Breakable") 
            { 
            level.CountBreakableBlocks();
            }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length+1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextSrpiteHitDamage();
        }
    }

    private void ShowNextSrpiteHitDamage()
    {
        int spriteIndex =timesHit-1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError(gameObject.name+ "Sprite missing from array");
        }
    }

    private void DestroyBlock()
    {
   
            FindObjectOfType<GameStatus>().AddScore();
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            Destroy(gameObject); //staviti vrednost za delay unistenja game object-a
            level.BlockDestroyed();
            TriggerSparkles();
       
    }
    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockEffectVFX,transform.position,transform.rotation);
        Destroy(sparkles, 2f);
    }

}
