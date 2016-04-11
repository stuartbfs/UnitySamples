# Unity Samples

## BouncingBall2D
Simple sample of a 2D ball bouncing in Unity. Steps taken (no code required):  

1. Create a "Sprites" folder underneath the Assets folder.  
2. Import a ball and ground image into the "Sprites" folder and set them to be single sprites - Texture Type: Sprite (2D and UI), Sprite Mode: Single.  
3. Create a new empty object under the Hierarchy and name it Ball.  Add a Sprite Renderer component to the object and assign it the ball sprite.  
4. Create a "Materials" folder underneath the Assets folder.  
5. Create a new Physics2D Material in the "Materials" folder and label it "Bouncy".  Set the Friction to 0.2 and the Bounciness to 0.8.  
6. Add a Circle Collider 2D to the Ball object and assign it the Bouncy material.  
7. Add a Rigidbody 2D component to the Ball object (so gravity is applied to the object).  
8. Create a new empty object under the Hierarchy and name it Ground.  Add a Sprite Renderer component to the object and assign it the ground sprite.  
9. Add a Box Collider 2D component to the Ground object.  
10. Ensure that the Ball object is positioned above the Ground object.  Start the scene and the ball object should drop and bounce off the ground.  

## SimpleClock
Tutorial exercise taken from https://unity3d.com/learn/tutorials/modules/beginner/scripting/simple-clock
