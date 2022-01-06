# SmolTAS
A mod for Smol Ame game which can help make tool assisted speedruns (TAS) for the game, it is mostly developed, TAS runs can be made with it. Requires SALT to work

# Mods
This single mod at this moment contains 5 different mods
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

### Fixed Frame Rate
The game will now run at a fixed framerate of 200fps for precise input recordings

# How to install

* Download SALT
* Install SALT as given in the instruction
* Download SmolTAS.dll from https://www.nexusmods.com/smolame/mods/8
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
* 'F7' sets the timescale value to 10, making the game run at very low FPS (~0).
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

* Backup input files if you have those from the previous version.
* Open the game
* 13 text files will be created in the Inputs folder each denoting a level
* AO denotes Ame's Office, similarly all levels initials denote the level, MAIN denotes the hub world
* adding text in each line of the text file determines which button will be pressed
* For e.g. if you enter DW on the 20th line, the game will press those 2 keys at the 20th frame
* Keys to enter - 'D' for right, 'W' or 'J' for up, 'A' for left and 'S' or 'G' for down
* Leave a few lines blank after the inputs so that every key is released (Else some keys can remain held)

# Update logs

# v3.1.0
* Shows Inputs read from text file on screen below timescale value
* Colour of texts shown in this mod is changed to white with black outline
* Positioning of Timescale value text is slightly modified

# v3.0.0
* Solved the varying framerate issue, now the game will run at a fixed framerate of 200fps
* With this update, this mod can be used for TASing purposes in every level without any issues

# v2.0.1
* Added text at the bottom left showing how many game frames have passed and which line the code is currently on when playing inputs
* Fixed the issue that happened when a level was reloaded while inputs were playing
* Now the inputs are played every game physics frame instead of your framerate frame
* Pausing the game by LShift will also pause the playing of inputs

# v2.1.0
* Updated for SALT v1.2
* Fixed the on screen texts which got scattered after the update
* Input recording for every level

# v2.1.1
* No need to make the "Inputs" folder yourself, it will be made by the mod automatically

# 2.1.2
* Fixed issue which created infinite ERROR logs in the console after opening a level
* Fixed issue which deleted the previous input files when the game opened
* Now exiting the menu (Esc button) won't keep the game paused

# v2.2.0
* Optimized the code a little bit
* Slow mo will work in real time now, no neeed to pause and resume the game
* Pressing 'F7' will change the timescale value to 10, making the FPS drop to nearly 0

# Acknowledgements

* SALT by [MegaPiggy](https://github.com/MegaPiggy/SALT)
* Smol Ame by [KevinCow](https://kevincow.itch.io/smol-ame)
* The Smol Ame speedrunning community [Discord](https://discord.gg/B5SyzgqWjZ)
