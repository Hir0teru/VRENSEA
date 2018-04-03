namespace GoogleVR.GVRDemo
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;


    [RequireComponent(typeof(Collider))]
    public class PickUp : MonoBehaviour
    {
        public Text scoreText;

        public float gazeTime = 2f;
        private float timer;
        private bool gazedAt;

        void Start()
        {
            gazedAt = false;
            SetGazedAt(false);
            SetScoreText();
        }

        private void Update()
        {
            if (gazedAt)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
            }

            if (timer >= gazeTime)
            {
                Destroy(this.gameObject);
                ScoreScript.instance.score++;
                SetScoreText();
            }
        }

        public void SetGazedAt(bool gazedAt1)
        {
            gazedAt = gazedAt1;
        }

        public void SetScoreText()
        {
            scoreText.text = "Objets: " + ScoreScript.instance.score.ToString() + "/" + ScoreScript.instance.maxScore.ToString();
        }
    }
}
