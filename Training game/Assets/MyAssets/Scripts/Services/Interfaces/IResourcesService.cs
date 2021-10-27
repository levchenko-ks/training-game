using UnityEngine;

public interface IResourcesService    
{
    Canvas GetCanvas();
    Camera GetCamera();
    Light GetLight();

    T GetUIModel<T>(UIModels model);
    T GetUIView<T>(UIViews view);
    Player GetPlayer();
    Weapon GetWeapon(Weapons Name);
    Projectile GetProjectilePref(Projectiles projectile);    
}
