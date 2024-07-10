using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MoveMyShip moveMyShip;
    public ParticleSystem explosion;
    public int lives = 3;
    public float respawnTime = 3.0f;
    public float respawnInvulnerabilityTime = 3.0f;
    public int score = 0;

    public void IceBergDestroyed(IceBerg iceBerg)
    {
        this.explosion.transform.position = iceBerg.transform.position;
        this.explosion.Play();

        if(iceBerg.size < 0.75f)
        {
            this.score += 100;
        }
        else if (iceBerg.size < 1.2f)
        {
            this.score += 50;
        }
        else
        {
            score += 25;
        }
    }

    public void PlayerDied()
    {
        this.explosion.transform.position = this.moveMyShip.transform.position;
        this.explosion.Play();

        this.lives--;

        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }

        
    }

    private void Respawn()
    {
        this.moveMyShip.transform.position = Vector3.zero;
        this.moveMyShip.gameObject.layer = LayerMask.NameToLayer("" +
            "Ignore Collisions");
        this.moveMyShip.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), this.respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions()
    {
        this.moveMyShip.gameObject.layer = LayerMask.NameToLayer("Player");
    }
    private void GameOver()
    {
        this.lives = 3;
        this.score = 0;

        Invoke(nameof(Respawn), this.respawnTime);
    }
}
