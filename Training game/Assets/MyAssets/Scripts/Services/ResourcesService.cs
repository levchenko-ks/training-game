using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesService : MonoBehaviour, IResourcesService
{
    private Camera _camera;
    private Canvas _canvas;
    private Light _light;

    private Player _player;

    //Weapons
    private Weapon _AK_74;
    private Weapon _Bennelli_M4;

    public Camera GetCamera()
    {
        if (_camera == null)
        {
            var path = "CoreComponents/" + CoreComponents.Main_Camera.ToString();
            var res = Resources.Load<Camera>(path);
            _camera = Instantiate(res);
        }

        return _camera;
    }

    public Canvas GetCanvas()
    {
        if (_canvas == null)
        {
            var path = "UI/Canvas FHD";
            var res = Resources.Load<Canvas>(path);
            _canvas = Instantiate(res);
        }

        return _canvas;
    }

    public Player GetPlayer()
    {
        if (_player == null)
        {
            var path = "Characters/" + Characters.Player.ToString();
            var res = Resources.Load<Player>(path);
            _player = Instantiate(res);
        }

        return _player;
    }

    public Light GetLight()
    {
        if (_light == null)
        {
            var path = "CoreComponents/" + CoreComponents.Standart_Directional_Light.ToString();
            var res = Resources.Load<Light>(path);
            _light = Instantiate(res);
        }

        return _light;
    }

    public Projectile GetProjectilePref(Projectiles projectile)
    {
        var path = "Projectiles/" + projectile.ToString();
        var res = Resources.Load<Projectile>(path);
        return res;
    }

    public T GetUIModel<T>(UIModels model)
    {
        throw new System.NotImplementedException();
    }

    public T GetUIView<T>(UIViews view)
    {
        throw new System.NotImplementedException();
    }

    public Weapon GetWeapon(Weapons Name)
    {
        switch (Name)
        {
            case Weapons.AK_74:
                if(_AK_74 == null)
                {
                    var path = "Weapons/" + Name.ToString();
                    var res = Resources.Load<Weapon>(path);
                    _AK_74 = Instantiate(res);
                }
                return _AK_74;
            case Weapons.Bennelli_M4:
                if(_Bennelli_M4 == null)
                {
                    var path = "Weapons/" + Name.ToString();
                    var res = Resources.Load<Weapon>(path);
                    _Bennelli_M4 = Instantiate(res);                    
                }
                return _Bennelli_M4;                
            default: 
                return null;                
        }  
    }
}
