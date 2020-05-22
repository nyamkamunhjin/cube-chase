using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMode : MonoBehaviour {
    public GameObject enemy;
    public GameObject life;
    public GameObject push;
    public GameObject coin;

    public EnemySession enemySession;
    public LifeSession lifeSession;
    public PushSession pushSession;
    public CoinSession coinSession;

    private bool isStarted = false;

    private void OnEnable() {
        startInfiniteMode();
    }

    private void Start() {
        // startInfiniteMode();
    }

    private void Update() {
        if (isStarted) {
            #region pool enemies
            enemySession.pool();
            #endregion

            #region pool lives
            lifeSession.pool();
            #endregion

            #region pool push powers
            pushSession.pool();
            #endregion

            #region pool coins
            coinSession.pool();
            #endregion
        }

    }

    private void startInfiniteMode() {
    
        GameSession.setPlayerState(GameSession.player.gameObject, true);
        isStarted = true;

        enemySession = new EnemySession(enemy);
        lifeSession = new LifeSession(life);
        pushSession = new PushSession(push);
        coinSession = new CoinSession(coin);

        GameSession.player.transform.position = GameSession.initialPos;
    }

    private void OnDisable() {
        resetGame();
    }

    private void resetGame() {

        FindObjectOfType<Player>().enabled = false;
        isStarted = false;

        enemySession.reset();
        lifeSession.reset();
        pushSession.reset();
        coinSession.reset();
    }

}