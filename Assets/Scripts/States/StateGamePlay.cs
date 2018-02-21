using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGamePlay : GameState {

	private const int MAX_HITS = 20;
	private bool m_isPaused = false;
	private float m_gameTime = 45f;

	public StateGamePlay(GameManager gm):base(gm) { }

	public override void Enter() {
		m_gameTime = 45f;
		m_gm.ResetStats();
	}

	public override void Execute() {
		if(m_gm.m_bulletHits > MAX_HITS || m_gm.m_missleHits > MAX_HITS || m_gm.m_rocketHits > MAX_HITS){
			m_gm.NewGameState(m_gm.m_stateGameWon);
		}

		m_gameTime -= Time.deltaTime;
		if(m_gameTime <= 0) {
			m_gm.NewGameState(m_gm.m_stateGameLost);
		}

		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(m_isPaused) {
				ResumeGameMode();
			} else {
				PauseGameMode();
			}
		}
		// TODO: Update HUD
	}

	public override void Exit() {
		// Nothing to see here ... these aren't the droids you're looking for
		// ... move along 
	}

	private void ResumeGameMode() {
		Time.timeScale = 1.0f;
		m_isPaused = false;
	}

	private void PauseGameMode() {
		Time.timeScale = 0.0f;
		m_isPaused = true;
	}
}
