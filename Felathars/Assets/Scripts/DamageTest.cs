using UnityEngine;

public class DamageTest : MonoBehaviour
{
    [Header("White Bullet")]
    [SerializeField] float W_W = 10;
    [SerializeField] float W_R = 10;
    [SerializeField] float W_G = 10;
    [SerializeField] float W_B = 10;
    [SerializeField] float W_Y = 10;
    [Header("Red Bullet")]
    [SerializeField] float R_W = 10;
    [SerializeField] float R_R = 10;
    [SerializeField] float R_G = 10;
    [SerializeField] float R_B = 10;
    [SerializeField] float R_Y = 10;
    [Header("Green Bullet")]
    [SerializeField] float G_W = 10;
    [SerializeField] float G_R = 10;
    [SerializeField] float G_G = 10;
    [SerializeField] float G_B = 10;
    [SerializeField] float G_Y = 10;
    [Header("Blue Bullet")]
    [SerializeField] float B_W = 10;
    [SerializeField] float B_R = 10;
    [SerializeField] float B_G = 10;
    [SerializeField] float B_B = 10;
    [SerializeField] float B_Y = 10;
    [Header("Yellow Bullet")]
    [SerializeField] float Y_W = 10;
    [SerializeField] float Y_R = 10;
    [SerializeField] float Y_G = 10;
    [SerializeField] float Y_B = 10;
    [SerializeField] float Y_Y = 10;

    void Start()
    {
        W_W = gamemanager.damageCalc(W_W, gamemanager.ColorType.WHITE, gamemanager.ColorType.WHITE);
        W_R = gamemanager.damageCalc(W_R, gamemanager.ColorType.WHITE, gamemanager.ColorType.RED);
        W_G = gamemanager.damageCalc(W_G, gamemanager.ColorType.WHITE, gamemanager.ColorType.GREEN);
        W_B = gamemanager.damageCalc(W_B, gamemanager.ColorType.WHITE, gamemanager.ColorType.BLUE);
        W_Y = gamemanager.damageCalc(W_Y, gamemanager.ColorType.WHITE, gamemanager.ColorType.YELLOW);
        R_W = gamemanager.damageCalc(R_W, gamemanager.ColorType.RED, gamemanager.ColorType.WHITE);
        R_R = gamemanager.damageCalc(R_R, gamemanager.ColorType.RED, gamemanager.ColorType.RED);
        R_G = gamemanager.damageCalc(R_G, gamemanager.ColorType.RED, gamemanager.ColorType.GREEN);
        R_B = gamemanager.damageCalc(R_B, gamemanager.ColorType.RED, gamemanager.ColorType.BLUE);
        R_Y = gamemanager.damageCalc(R_Y, gamemanager.ColorType.RED, gamemanager.ColorType.YELLOW);
        G_W = gamemanager.damageCalc(G_W, gamemanager.ColorType.GREEN, gamemanager.ColorType.WHITE);
        G_R = gamemanager.damageCalc(G_R, gamemanager.ColorType.GREEN, gamemanager.ColorType.RED);
        G_G = gamemanager.damageCalc(G_G, gamemanager.ColorType.GREEN, gamemanager.ColorType.GREEN);
        G_B = gamemanager.damageCalc(G_B, gamemanager.ColorType.GREEN, gamemanager.ColorType.BLUE);
        G_Y = gamemanager.damageCalc(G_Y, gamemanager.ColorType.GREEN, gamemanager.ColorType.YELLOW);
        B_W = gamemanager.damageCalc(B_W, gamemanager.ColorType.BLUE, gamemanager.ColorType.WHITE);
        B_R = gamemanager.damageCalc(B_R, gamemanager.ColorType.BLUE, gamemanager.ColorType.RED);
        B_G = gamemanager.damageCalc(B_G, gamemanager.ColorType.BLUE, gamemanager.ColorType.GREEN);
        B_B = gamemanager.damageCalc(B_B, gamemanager.ColorType.BLUE, gamemanager.ColorType.BLUE);
        B_Y = gamemanager.damageCalc(B_Y, gamemanager.ColorType.BLUE, gamemanager.ColorType.YELLOW);
        Y_W = gamemanager.damageCalc(Y_W, gamemanager.ColorType.YELLOW, gamemanager.ColorType.WHITE);
        Y_R = gamemanager.damageCalc(Y_R, gamemanager.ColorType.YELLOW, gamemanager.ColorType.RED);
        Y_G = gamemanager.damageCalc(Y_G, gamemanager.ColorType.YELLOW, gamemanager.ColorType.GREEN);
        Y_B = gamemanager.damageCalc(Y_B, gamemanager.ColorType.YELLOW, gamemanager.ColorType.BLUE);
        Y_Y = gamemanager.damageCalc(Y_Y, gamemanager.ColorType.YELLOW, gamemanager.ColorType.YELLOW);

    }

    
}
