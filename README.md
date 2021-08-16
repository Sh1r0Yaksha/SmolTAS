# SmolTAS
A mod for Smol Ame game which can help make tool assisted speedruns (TAS) for the game, it is still in development. Requires SALT to work

# Mods
This single mod at this moment contains 3 different mods
* [Slow Motion](https://github.com/Sh1r0Yaksha/SmolTAS#slow-motion)
* [Frame advance](https://github.com/Sh1r0Yaksha/SmolTAS#frame-advance)
* [Save and Load Position](https://github.com/Sh1r0Yaksha/SmolTAS#save-and-load-position)
* [Coordinates and Velocity of Player](https://github.com/Sh1r0Yaksha/SmolTAS#coordinates-and-velocity-of-player)
* [Input Recording](https://github.com/Sh1r0Yaksha/SmolTAS#input-recording)

### Slow Motion
This mod pauses the game and makes it run in slow motion.

### Frame Advance
This mod makes the game advance by one game's physics frame (5ms)

### Save and Load Position
This mod saves the players position and time spent in level and then loads it when certain keys are pressed

### Coordinates and Velocity of Player
This mod displays the values of coordinates and Velocities of the player in X and Y direction

### Input Recording
This mod lets people write inputs as WASD in a text file and the game will replicate those inputs frame by frame

# How to install

* Download SALT
* Install SALT as given in the instruction
* Download SmolTAS.dll from https://github.com/Sh1r0Yaksha/SmolTAS/releases/tag/2.0.0
* After installing, put the SmolTAS.dll file in the folder "SALT/Mods".

# How to Use

* Pressing 'Left Shift' will pause the game and 'Q' will resume it. If Slow Motion is on, Pressing 'Q' will resume the game at a speed according to the timescale value.

### Slow Motion

* Pressing the alphanumeric key '1' will toggle this mod.
* Pressing function buttons (F2, F3, F4, F5, F6) will change the game's timescale value, so pressing one of those and then holding 'E' makes the game run in slow or fast motion.
* Holding 'E' will resume the game and slow it down according to the timescale value for the time you are holding it.
* 'F2' sets the timescale value to delta time which was before pausing the game, so time will increment in factors of frames of game
* 'F3' sets the timescale value to 0.10, so time will increment in factors of 4-5 ms
* 'F4' sets the timescale value to 1.00, so time will increment normally
* 'F5' decrements the timescale value by 0.1
* 'F6' increments the timescale value by 0.1
* This method is dependent on timescale value so your framerate changes while in slow motion
* The value of timescale will be visible in the bottom left corner

### Frame Advance

* Pressing the alphanumeric key '2' will toggle this mod.
* 'F' key will advance the game by one frame without changing the timescale value.
* Framerate won't change when 'F' is pressed.

### Save and Load Position

* Pressing the alphanumeric key '3' will toggle this mod.
* Pressing F10 will save player's position
* Pressing F11 will load player's position to the saved place
* If your position is not saved, default load position will be at (0, 0, 0)

### Coordinates and Velocity of Player

* These values can be seen on the bottom right corner of the screen
* To toggle this mod, press the tilde '~' key

### Input Recording

* Only for AO at the moment
* Make a text file named "AO.txt" in the Mods folder where you store your other mods
* If you don't make a text file, it will be made automatically in the Mods folder when you load the game
* adding text in each line of the text file determines which button will be pressed
* For e.g. if you enter DW on the 20th line, the game will press those 2 keys at the 20th frame
* Keys to enter - 'D' for right, 'W' for up, 'A' for left and 'S' for down
* Leave a few lines blank after the inputs so that every key is released (Else some keys can remain held)

# Acknowledgements

* SALT by [MegaPiggy](https://github.com/MegaPiggy/SALT)
* Smol Ame by [KevinCow](https://kevincow.itch.io/smol-ame)
* The Smol Ame speedrunning community [Discord](https://discord.gg/B5SyzgqWjZ)
