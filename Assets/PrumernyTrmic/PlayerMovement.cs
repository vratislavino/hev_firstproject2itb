using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float border;

    [SerializeField]
    GameObject deathScreen;

    [SerializeField]
    TMPro.TMP_Text finalScore;

    Coroutine coroutine = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime

        float xMove = 0;
        if(Input.GetKey(KeyCode.D)) {
            xMove = 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            xMove = -1;
        }

        transform.Translate(xMove * Time.deltaTime * speed, 0, 0);

        if(transform.position.x < -border) {
            transform.position = new Vector3(-border, 0, 0);
        }
        if (transform.position.x > border) {
            transform.position = new Vector3(border, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision) {

        var fo = collision.gameObject.GetComponent<FallingObject>();
        if(fo) {
            fo.Collect(this);
        }
        Destroy(collision.gameObject);
    }

    public void ChangeSpeed(int speed, int duration) {
        this.speed = speed;

        if(coroutine != null) {
            StopCoroutine(coroutine);
            coroutine = null;
        }
        coroutine = StartCoroutine(ResetSpeed(duration));
    }

    IEnumerator ResetSpeed(float duration) {
        yield return new WaitForSeconds(duration);
        this.speed = 5;
    }

    internal void StartedToWork() {
        Time.timeScale = 0;
        deathScreen.SetActive(true);
        finalScore.text = Score.Instance.CurrentScore.ToString();
        // nastavit deathscreen
    }
}