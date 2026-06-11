using UnityEngine;

public enum damageTypes { game, film, music, art, writing }
public interface IDamage
{
   
    void takeDamage(float amount);

}
