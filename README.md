##Evan's Altspace VR Work

###Alterations to the Furniture Scene (Ikea Model Room)
*1. Code for a reticle meant to be used with a VR headset. 
*2. Additional code surrounding the scene in order to make for a more robust experience.
  *- sometimes, when in VR, it would be nice to know an object is interactive before I spend the time traveling to it. In AltspaceVR, in the blocks room, there is an elevator with a button on the outside. I was excited to see where it would take me, but, to my dismay, the button was not interactive. I developed a little system to communicate that an object you're looking at is interactive even though you are too far to actually use it. 
  *- Grab functionality
  *- Some UI work with signs and dynamically written text
  *- a little narrative in case you decide not to leave the store empty handed. 
3. A small Ruby on Rails backend located at: altspacevr-project-unity-cursor/Ikea
	- I created a tiny api that I was intending Unity to hit via the WWW class to get customer reviews of each piece of furniture. These reviews, including product name and price, would then be displayed on the price signs attached to each product. Unfortunately, I was having some issues Deserializing the JSON string into the container classes I'd created. I'd decided to focus on more user interaction and liveliness in the scene. 
4. A small attempt at making a card game interaction system using the Leap Motion. Over the course of a two day hackathon, I tried to learn the Leap Motion API in order to make some basic card interactions. 
	- The scene to load is located at: LeapMotionTest1/Assets/LeapMotion/Scenes/Leap_Hands_Demo_VRCards
	- if you open your left hand, with your palm facing you, your hand of three test cards should appear. Moving your right pointer finger in front of one of the cards will cause it to become selected.
	- if your set of cards does not show, you may need the camera to assign the blue hand model to your left hand. If it's green, move your hand out of the Leap's view then renter it. It should turn blue. 
	 