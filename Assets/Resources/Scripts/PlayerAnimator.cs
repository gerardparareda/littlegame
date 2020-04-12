using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Start is called before the first frame update


    //Load all needed textures
    public Texture2D player_idle1;
    public Texture2D player_idle2;
    public Texture2D player_walk1;
    public Texture2D player_walk2;
    public Texture2D player_walk3;
    public Texture2D player_walk4;
    public Texture2D player_walk5;

    public Texture2D player_walk1_r;
    public Texture2D player_walk2_r;
    public Texture2D player_walk3_r;
    public Texture2D player_walk4_r;
    public Texture2D player_walk5_r;


    //Create all needed animations from the textures
    Animation player_idle;
    Animation player_walk;
    Animation player_walk_r;

    //Select the main current animation
    Animation currentAnimation;

    //Get the player material
    Material playerMat;

    void Start()
    {
        playerMat = GetComponent<Renderer>().material;

        //Player idle animation
        player_idle = new Animation( 
            playerMat, 
            new AnimationPart[] 
                {
                    new AnimationPart(player_idle1, 300),
                    new AnimationPart(player_idle2, 300)
                } 
        );

        //Player walk animation
        player_walk = new Animation
        (
            playerMat,
            new AnimationPart[]
                {
                    new AnimationPart(player_walk1, 70),
                    new AnimationPart(player_walk2, 70),
                    new AnimationPart(player_walk3, 70),
                    new AnimationPart(player_walk4, 70),
                    new AnimationPart(player_walk5, 70)

                }
        );

        player_walk_r = new Animation
        (
            playerMat,
            new AnimationPart[]
                {
                    new AnimationPart(player_walk1_r, 70),
                    new AnimationPart(player_walk2_r, 70),
                    new AnimationPart(player_walk3_r, 70),
                    new AnimationPart(player_walk4_r, 70),
                    new AnimationPart(player_walk5_r, 70)

                }
        );

        //Set current animation
        currentAnimation = player_idle;

    }

    public void setCurrentAnimation(int animationId)
    {
        switch (animationId)
        {
            case 0:
                currentAnimation = player_idle;
                break;

            case 1:
                currentAnimation = player_walk;
                break;
            case 2:
                currentAnimation = player_walk_r;
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
