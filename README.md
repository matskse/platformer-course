# Platformer course with Unity

## Download and run this project

Download Unity v2021.3.11f1 using Unity Hub.  

Clone the repo with ```git clone https://github.com/matskse/platformer-course.git``` or download and extract the zip file.  

Use Unity Hub to open an existing project and select the platformer-course folder.  

Unity will now download the required packages used in this project. This might take a few minutes.  

When the project opens, go inside the Scenes folder and open the Sample scene.

## The course
The course consists of 9 tasks that teach fundamental game development concepts for 2D games.
The main branch contains skeleton code, sprites and prefabs that can be used to complete the tasks, and the lf branch contains the løsningsforslag🤓.  

If you get stuck on a task, feel free to use google, ask any of the course helpers, or take a look at the lf branch.  

## Task 1: Tilemap
**Create a Tilemap that can be used to construct levels. The Tilemap should have a Tilemap collider for objects to interact with it.**  

Right click in the project hierarcy and create a new Object under 2D Object > Tilemap > Rectangular. This creates a new Grid with a Tilemap child.
A Tilemap lets you paint in tiles from the Tile Palette into a grid formation. Find the Tilepalette window by selecting Window from the top tool bar > 2D > Tile palette.
You can drag and insert this window where you like, for example next to the inspector tab.  

![image](https://user-images.githubusercontent.com/37469920/195812932-b6725ab0-0280-43a4-baaa-49c6b9f29a42.png)

A Rule tile is a special kind of tile that we can set rules for which sprite to show.
For exmaple: We can set a rule to show a specific sprite when there is no other sprites above the Tile.  

Select the paint bruch tool and paint some tiles into the Tilemap. Try to paint with both normal tiles and the Rule tile.
Do not make a full level at this time, you might have to redo all the work later if you do... Just paint to see if the Tile palette works.  

Notice the Rule tile can be used to create the main ground for our levels. However, the tile is missing some rules. The top layer of the ground is not showing correctly.  
![image](https://user-images.githubusercontent.com/37469920/195814706-4d5fc72e-ca6b-4ee4-b4a2-a46d8e6e0958.png)


Find the Rule tile asset in Assets/Sprites/Tilemap. Its called GroundRuleTile.asset and should be the 2nd asset in the folder. Click it and view it in the inspector.
Add a new rule by clicking the small + symbol at the bottom of the Tiling Rules list.
Select a new sprite for the rule, tiles_out_0 is one of the top three we are missing.  

![image](https://user-images.githubusercontent.com/37469920/195816338-10de222a-904c-4b8c-9069-c3f4c44fc18b.png)

Click in the 3x3 grid to set rules for whhat this tile expects to be around it.
Red cross means it expects nothing to be there, green arrow means it expects something to be there. Blank cell means it does not care what is there.
We have now made a new rule for the top left tile of our ground. Add 2 more rules: One for the top middle tile, and one for the top right tile.  

Our Tilemap is allmost done, we are able to paint the levels more easily now, however they do not interact with the Unity world yet. They are only cosmetic images.
Add a new component to the Tilemap by selecting it and clicking the Add component button in the inspector to the left. Search Tilemap and add a Tilemap Collider 2D.
This adds a collider to the Tilemap so other objects in Unity can collide with it. We need this for out player and enemies to be able to walk on our levels. Add the default material as the Physics Material 2D fir the Tilemap Collider.  

## Task 2: Backgrounds
**Add a background with parallax effect**  

Add an empty gameObject as a child of the Backgrounds object in the scene. Add a Sprite renderer component to the new gameObject, and drag and drop one of the background sprite called nuvens_2 into the Sprite field. Change the draw mode to Tiled, we can now change the width of the sprite renderer to make it as large as we want, try 150. Change the Order in Layer to -20. Add the Parallax effect script to the object and set the effect to somewhere between 0 and 1.  
Copy this object with ctr+d and change out the sprite to nuvens_1. Set the Order in Layer to -10 and the parallax effect to a lower number than the first one.  
You can verify that the effect works by playing the game and looking at the scene window. Move the Main camera back and forth, the background should follow the camera with some delay based on the parallax effect. Ignore the errors in the console, we will fix those later.


## Task 3: Player Input
**Create actions for the player inputs we want (Movement, Jump, Shoot) and bind them to the desired buttons.**  

Open the Player Input Actions by double clicking it in the Assets/InputSystem folder.  

![image](https://user-images.githubusercontent.com/37469920/195820283-2fc378ae-2faf-4e90-b2ad-bf30d24d2735.png)  

Press the small + symbol on an action to add a new binding to it. A binding is how we define which button should triger this action.
Select a path for the binding to bind it to a button. Tip: Use the listen function to listen for button presses and select that button.  

If you have a gamepad controller, you can connect it to your computer and Unity should automatically find it and let you know by printing to the console.  
![image](https://user-images.githubusercontent.com/37469920/196051410-8940b511-762e-4953-a067-66a9c6c14f3b.png)


Some actions act as buttons and others act as Vectors. Jump and Shoot should be buttons, while movement should be a 2D vector. Thats why we choose to add a Up/Down/Left/Right composite as the binding for the movement. Set each binding for each movement direction.   

![image](https://user-images.githubusercontent.com/37469920/195821066-bf10be41-9548-42d8-9c88-8f9db8959389.png)  

Remember to Save Asset after youre done if you dont have auto-save enabled.  

## Task 4: Creating a player
**Create a player prefab**  

Right click in the hierarcy and create a new empty GameObject. Name it Player and drag it into the Prefabs folder. This is now a prefab you can use in all your scenes.
Open the Player prefab by double clicking it. To let the camera script know which GameObject to follow in the scene, drag and drop the player object in the scene into the target field of the cameraScript on the Main camera. Add components to the Player by clicking the Add component button in the inspector.
Components to add:

- **Sprite renderer:** Select a sprite to be used by the Sprite Renderer.
- **Rigidbody 2D:** Make sure the body type is set to Dynamic. Add a material for physics calculations. Configure your mass and drag. Set collision detection to continuous. Freeze Rotation on the z-axis.
- **Capsule Collider 2D:** Edit the collider to fit the Player sprite.

## Task 5: Player movement
**Detect input from the player and transform the inputs into movement**  

Add these components to the Player prefab:
- **Player Movement:** Configure movement speeds and jump force. Set the Ground layer to Ground and WalkAbleObjects. This tells the script what the Player can walk on.
- **Animator**: Add the Player Controller in the Controller field.
- **Player Input**: Add the PlayerInputActions in the Actions field. Set the Behaviour to Invoke Unity Events. Expand Events and then Player. You will now see the 3 actions we defined earlier; Jump, Movement and Shoot. Click on the small + symbol in the Movement list. Drag and drop the Player Movement component you added into the field where it says None (Object). Select a function from the drop down menu, select PlayerMovement and OnMoveInput. Do the same for the Jump action, but select the Jump function instead.  

![image](https://user-images.githubusercontent.com/37469920/196044177-ee7da9a6-d9d9-492a-9a18-634bf98b1f7a.png)


Start the game to see if the inputs are working correctly. You should see some values being logged in the console window when you try to move and jump.  

Implement the TODOs in the PlayerMovement.cs file.  

When fixing the handleAnimations() function we also have to fix some transitions in the Animator window in Unity. Open the Player prefab and then open the Animator window. ***Only the conditions for the transitions to/from the Player_run*** animation is missing, so add the conditions for those 5 transitions. 
For example: Click one of the white arrows to Player_run and add a new condition in the conditions list in the inspector. We want to transition from Player_idle to Player_run when the Running condition is true:

![image](https://user-images.githubusercontent.com/37469920/196044525-49e1d3e5-28cc-4e6c-bab9-f7eb6c46acf1.png)  

At this point the player should be able to move and jump, while displaying the correct animations. 
Try to experiment with different values for the speed, max speed and the jump force. You can also find the DefaultMaterial in the Materials folder used for the physics calculations and change the friction to change how the player movement behaves.

## Task 6: Player attack

Add the Player attack component to the Player prefab. Drag and drop the Bullet prefab into the Bullet field. Create 2 new empty GameObjects as children of the Player; muzzle and gunBase. Move these GameObjects to align with the gun muzzle and the gun base of the Player Sprite. Drag and drop these two GameObjects into the Muzzle and Gun Base fields of the Player Attack component. We will use the positions of these two objects to calculate the direction and position of new bullets when the Player shoots.  

![image](https://user-images.githubusercontent.com/37469920/196046398-f5ab11c4-8761-4b41-93fd-100e88a006af.png)  

Now that we have the Player attack component on the Player, we can connect it to the Player Input component. Just as we did with the Movement and Jump actions, connect the OnShootButtonInput to the Shoot action on the Player Input component:  
![image](https://user-images.githubusercontent.com/37469920/196046484-e8c836d6-32d1-42ed-b174-ea86539866d1.png)  

Play the game and see if your shoot button prints some output to the console.  
Implementing the Shoot() function:  
Instantiate a bullet prefab as a new GameObject with ```GameObject newBullet = Instantiate(bullet, muzzle.transform.position, Quaternion.identity);```  
Calculate the direction we want to shoot the bullet as a 3D vector by using the difference between the muzzle and gunBase positions and normalizing the vector. ```Vector3 dir = (muzzle.transform.position - gunBase.transform.position).normalized;```
Get the Rigidbody of the newly spawned bullet and give it some velocity by multiplying the direction vector with the bullet speed: ```newBullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;```.  
We want the bullet to be facing left or right based on which way our player is facing. We can simply flip the bullet sprite: ```if (transform.localScale.x < 0) {
            b.GetComponent<SpriteRenderer>().flipX = true;
        }```  
Experiment with some different bullet speeds, as well as the angle between the positions of muzzle and gunBase. A steep angle will shoot the bullet more upwards. You can also open the Bullet prefab and change the values of its Rigidbody. For example the gravity scale or mass.

## Task 7: Player health

Add the Player health component to the Player prefab. Implement the TakeDamage() and Die() functions in the script.  
Hints for the Die() function:  
- Animators' triggers can be set just as its bool parameters: ```anim.SetTrigger("die");```
- You can disable components by setting the .enabled field: ```GetComponent<PlayerInput>().enabled = false;```
- Remember to only Die() once. We do not want the die animation to play multiple times.  

The Player prefab is now complete!🚀

## Task 8: 
**Implement the bullet**  

Open the Bullet.cs script and implement the ```OnCollisionEnter2D(Collision2D other)``` function. This function is called when the bullets collider intersects with another collider in Unity.  
The bullet should call the TakeDamage functions of PlayerHealth and EnemyHealth if they exist. We can check if the object the bullet collided with have any of these components:  
```if (other.gameObject.GetComponent<EnemyHealth>())``` and ```if (other.gameObject.GetComponent<PlayerHealth>())```. And then call the TakeDamage functions if we find any of the two components.  
We can either destroy the bullet object afterwards, or set it to an inactive state to have it stick around in the level.

## Task 9:
**Making a level**  

Make a level with the Player and some enemies. You can drag and drop Enemy prefabs into the scene, and set the values of the EnemyAttack and EnemyMovement scripts.
