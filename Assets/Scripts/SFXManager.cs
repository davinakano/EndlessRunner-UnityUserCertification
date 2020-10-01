using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip doubleJumpPowerUpSFX;
    [SerializeField] AudioClip shieldPowerUpSFX;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip doubleJumpSFX;
    [SerializeField] AudioClip shieldBreakSFX;
    [SerializeField] AudioClip gameOverHitSFX;

    public void PlaySFX(string clipToPlay)
    {
        switch (clipToPlay)
        {
            case "Coin":
                audioSource.clip = coinSFX;
                break;
            case "DoubleJumpPowerUp":
                audioSource.clip = doubleJumpPowerUpSFX;
                break;
            case "ShieldPowerUp":
                audioSource.clip = shieldPowerUpSFX;
                break;
            case "Jump":
                audioSource.clip = jumpSFX;
                break;
            case "DoubleJump":
                audioSource.clip = doubleJumpSFX;
                break;
            case "ShieldBreak":
                audioSource.clip = shieldBreakSFX;
                break;
            case "GameOverHit":
                audioSource.clip = gameOverHitSFX;
                break;
        }

        audioSource.Play();
    }
}
