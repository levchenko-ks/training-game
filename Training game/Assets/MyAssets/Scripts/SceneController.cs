using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public Player Player;

    public GameObject Weapon_1;
    public GameObject Weapon_2;

    public CameraControl MainCamera;
    public Transform Target;

    public GameHUD GameHUD;
    public InputControls InputControls;

    private HealthBar _healthBar;
    private ReloadBar _reloadBar;
    private AmmoCounter _ammoCounter;

    private void Awake()
    {
        _healthBar = GameHUD.HealthBar;
        _reloadBar = GameHUD.ReloadBar;
        _ammoCounter = GameHUD.AmmoCounter;

    }

    private void Start()
    {
        SceneInstantiate();
    }

    private void SceneInstantiate()
    {
        Vector3 playerPosition = Vector3.up;

        var player = Instantiate(Player, playerPosition, Quaternion.identity);
        player.s

    }
}
