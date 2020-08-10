﻿using Obstacles;
using Player;
using Shooting;
using Statistics;

public static class PauseManager
{
    public static bool isPaused;
    private const float NormalAudioVolume = 1;
    private const float PauseAudioVolume = 0.2f;
    
    public static void PauseGamePlay()
    {
        isPaused = !isPaused;
        StartGame(isPaused);
    }

    private static void StartGame(bool state)
    {
        GameManager.instance.userInterfaceManager.EnablePauseCanvas(state);
        PlayerManager.EnablePlayerConstraints(state);
        ObstacleManager.moveObstacles = !state;
        BulletManager.moveBullets = !state;
        PlayerShooting.canShoot = !state;
        EnableCoroutines(!state);
    }

    private static void EnableCoroutines(bool state)
    {
        if (state)
        {
            TimeTracker.ResumeTimer();
            GameManager.instance.obstacleManager.StartCreatObstacleSequence();
            AudioManager.SetGlobalVolume(NormalAudioVolume);
            return;
        }
        TimeTracker.PauseTimer();
        GameManager.instance.obstacleManager.StopCreatObstacleSequence();
        AudioManager.SetGlobalVolume(PauseAudioVolume);
    }
    
}
