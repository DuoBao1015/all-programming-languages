// This program will make the meteors move across the starry sky according to the sound. The faster the loud meteors move across the sky, the music will flash according to the rhythm. Every time you open the program, the meteor will sweep across the starry sky in different directions.
import processing.sound.*;
AudioIn ai;
Amplitude ampl;
Stars myStars;

void setup()
{
  size(1920,1080);
  
  myStars=new Stars(30,5000,1920,1080);
  
  ai = new AudioIn(this,0);
  ai.play();
  
  ampl = new Amplitude(this);
  ampl.input(ai);

}

void draw()
{
  fill(0,18);
  rect(0,0,width,height);
  float v = ampl.analyze();
  myStars.update(v*5);
  myStars.checkEdges();
  myStars.display();

  

}
