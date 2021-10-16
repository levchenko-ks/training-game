using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Player Player;

    public GameObject Weapon_1;
    public GameObject Weapon_2;

    public Transform Target;
    public CameraControl MainCamera;
    public Light DirectionalLight;
    public Spawner Spawner;
    public Environment Environment;
    public GameObject FloorTile;    
    

    private Player _player;

    private GameObject _weapon_1;
    private GameObject _weapon_2;

    private Transform _target;
    private CameraControl _mainCamera;
    private Light _directionalLight;
    private Spawner _spawner;
    private Environment _environment;
        
    private InputControls _inputControls;

    private HealthBar _healthBar;
    private ReloadBar _reloadBar;
    private AmmoCounter _ammoCounter;
    private Transform _weaponHolder;
    private Transform _projectileHolder;
    private Transform _enemyHolder;

    private void Start()
    {
        SceneInstantiate();
        SetDependency();

        _player.GetReady();
    }

    private void SceneInstantiate()
    {
        Vector3 playerPosition = Vector3.up;
        Vector3 targetPosition = playerPosition + Vector3.forward;

        _player = Instantiate(Player, playerPosition, Quaternion.identity);
        _target = Instantiate(Target, targetPosition, Quaternion.identity);

        _mainCamera = Instantiate(MainCamera);
        _directionalLight = Instantiate(DirectionalLight);
        _spawner = Instantiate(Spawner);

        var inputControlsObject = new GameObject("InputControls");
        inputControlsObject.AddComponent<InputControls>();
        _inputControls = inputControlsObject.GetComponent<InputControls>();

        var environmentObject = new GameObject("Environment");
        environmentObject.AddComponent<Environment>();
        _environment = environmentObject.GetComponent<Environment>();
        _environment.FloorTile = FloorTile;
        _environment.CreatePlane();

        _weaponHolder = _player.weaponHolder.transform;
        _projectileHolder = new GameObject("ProjectileHolder").transform;
        _enemyHolder = new GameObject("EnemyHolder").transform;

        _weapon_1 = Instantiate(Weapon_1, _player.transform.position, Quaternion.identity, _weaponHolder);
        _weapon_2 = Instantiate(Weapon_2, _player.transform.position, Quaternion.identity, _weaponHolder);
    }

    private void SetDependency()
    {
        _healthBar = _gameHUD.HealthBar;
        _reloadBar = _gameHUD.ReloadBar;
        _ammoCounter = _gameHUD.AmmoCounter;

        _player.Target = _target;
        _player.HealthBar = _healthBar;
        _player.InputControls = _inputControls;

        SetWeapon(_weapon_1);
        SetWeapon(_weapon_2);

        _spawner.Player = _player;
        _spawner.Placeholder = _enemyHolder;
        _spawner.Cam = _mainCamera.transform;

        _mainCamera.Player = _player.transform;
        _mainCamera.Target = _target;
        _mainCamera.GameplayControls = _inputControls;
    }

    private void SetWeapon(GameObject Weapon)
    {
        Weapon.SetActive(false);
        _player.AddWeapon(Weapon);

        var weapon = Weapon.GetComponent<Weapon>();
        weapon.ReloadBar = _reloadBar;
        weapon.AmmoCounter = _ammoCounter;
        weapon.ProjectileHolder = _projectileHolder;
        weapon.InputControls = _inputControls;
    }
}
