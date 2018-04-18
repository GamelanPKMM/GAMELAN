using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarapanStarInstanceController : KarapanSubScontroller {
    public Vector3 OriPos;
    public float flatspeed = 3F;
    private StarController controller;
    protected override void start()
    {
        base.start();
        controller = gameControl.SubController<StarController>("StarController");
        OriPos = transform.position;

    }
    void FixedUpdate()
    {
        if (!gameControl.isPause() && gameControl.getGameState())
        {
            gameObject.transform.Translate(Vector2.down * (Time.fixedDeltaTime * (gameControl.speedControl.speed - flatspeed)));
            if (gameObject.transform.position.y <= -10)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameControl.getGameState() && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("GetStar");
            basicGameControl.SubController<QuestionControl>("QuestionControl").startQuestion();
            basicGameControl.SubController<KarapanLifeControl>("LifeControl").increaseLife();
            Destroy(gameObject);

        }
    }
}
