using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    // Start is called before the first frame update


    //Load all needed textures
    public Texture2D[] idle_left1;

    public Texture2D[] idle_right1;

    public Texture2D[] walk_l1;

    public Texture2D[] walk_r1;

    public Texture2D[] take_damage;
    public Texture2D[] fall;
    public Texture2D[] attack;



    //Create all needed animations from the textures
    Animation player_idle_l;
    Animation player_idle_r;

    Animation player_walk;
    Animation player_walk_r;
    Animation player_jump;
    Animation player_fall;


    //Select the main current animation
    Animation currentAnimation;

    //Get the player material
    Material playerMat;

    void Start()
    {
        playerMat = GetComponent<Renderer>().material;

        AnimationPart[] animationParts = new AnimationPart[idle_left1.Length];
        for (int i = 0; i < idle_left1.Length; i++)
        {
            animationParts[i] = new AnimationPart(idle_left1[i], 270);
        }

        //Player idle animation
        player_idle_l = new Animation(
            playerMat,
            animationParts
        );

        animationParts = new AnimationPart[idle_right1.Length];
        for (int i = 0; i < idle_right1.Length; i++)
        {
            animationParts[i] = new AnimationPart(idle_right1[i], 270);
        }

        //Player idle animation
        player_idle_r = new Animation(
            playerMat,
            animationParts
        );

        animationParts = new AnimationPart[walk_l1.Length];
        for (int i = 0; i < walk_l1.Length; i++)
        {
            animationParts[i] = new AnimationPart(walk_l1[i], 100);
        }

        animationParts = new AnimationPart[take_damage.Length];
        for (int i = 0; i < take_damage.Length; i++)
        {
            animationParts[i] = new AnimationPart(take_damage[i], 100);
        }

        animationParts = new AnimationPart[fall.Length];
        for (int i = 0; i < fall.Length; i++)
        {
            animationParts[i] = new AnimationPart(fall[i], 100);
        }



        //Set current animation
        currentAnimation = player_idle_l;

    }

    public void setCurrentAnimation(int animationId)
    {
        switch (animationId)
        {
            case 0:
                currentAnimation = player_idle_l;
                break;

            case 1:
                currentAnimation = player_idle_r;
                break;
            case 2:
                currentAnimation = player_walk_r;
                break;
            case 3:
                currentAnimation = player_jump;
                break;
            case 4:
                currentAnimation = player_fall;
                break;

        }
    }
    

    void Update()
    {
        currentAnimation.PlayAnimation(Time.deltaTime);
    }

    class Animation
    {
        Material playerMat;
        List<AnimationPart> textures;
        int currentFrame;
        float currentTime;

        public Animation(Material playerMat, params AnimationPart[] values)
        {
            this.playerMat = playerMat;
            textures = new List<AnimationPart>();
            foreach (AnimationPart value in values)
            {
                textures.Add(value);
            }
            currentFrame = 0;
            currentTime = 0;
        }

        public void PlayAnimation(float deltaTime)
        {
            currentTime += deltaTime*1000; //convert seconds to miliseconds
            playerMat.mainTexture = textures[currentFrame].texture;
            if(currentTime > textures[currentFrame].duration)
            {
                currentFrame++;
                if (currentFrame == textures.Count)
                {
                    currentFrame = 0;
                }

                currentTime = 0;
            }
        }
    }

    class AnimationPart
    {
        public Texture2D texture;
        public int duration; //miliseconds

        public AnimationPart(Texture2D texture, int duration)
        {
            this.texture = texture;
            this.duration = duration;
        }

    }
}
